using UnityEngine;
using System.Collections.Generic;

public class PathfindingScript : MonoBehaviour
{
    public Transform target;  // Objeto de destino para o pathfinding
    public LayerMask unwalkableMask;
    public Vector2 gridWorldSize = new Vector2(22, 10);
    public float nodeRadius = 0.5f;
    public float moveSpeed = 1f;

    private GridNode[,] grid;

    void Start()
    {
        CreateGrid();
    }

    void Update()
    {
        // Encontrar o caminho e mover em direção ao primeiro nó no caminho
        List<GridNode> path = FindPath(transform.position, target.position);
        MoveAlongPath(path);
    }

    void CreateGrid()
{
    // Criar uma grade de nós com base nos parâmetros especificados
    grid = new GridNode[Mathf.RoundToInt(gridWorldSize.x), Mathf.RoundToInt(gridWorldSize.y)];

    // Calcular o canto inferior esquerdo da grade em coordenadas mundiais
    Vector3 worldBottomLeft = new Vector2(-10.5f, -4.5f);

    // Iterar através de cada célula da grade e criar um nó
    for (int x = 0; x < grid.GetLength(0); x++)
    {
        for (int y = 0; y < grid.GetLength(1); y++)
        {
            // Calcular a posição mundial do nó
            Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeRadius * 2) + Vector3.up * (y * nodeRadius * 2);

            // Debug information
            Debug.DrawRay(worldPoint, Vector3.up * 2f, Color.yellow, 1f);
            Debug.DrawRay(worldPoint, Vector3.down * 2f, Color.yellow, 1f);

            // Verificar se o nó é alcançável com base em colisões com objetos intransponíveis
            Collider2D hitCollider = Physics2D.OverlapCircle(worldPoint, nodeRadius, unwalkableMask);
            bool walkable = (hitCollider == null);

            // Criar um GridNode e atribuí-lo à matriz da grade
            grid[x, y] = new GridNode(walkable, worldPoint, x, y);
        }
    }
}


    public void SetTarget(Vector3 targetPosition)
    {
        // Definir a posição de destino quando um novo destino é especificado
        target.position = targetPosition;

        // Encontrar o caminho para a nova posição de destino
        List<GridNode> path = FindPath(transform.position, target.position);
        // Realizar ações com o caminho, como mover o objeto ao longo dele
    }

    List<GridNode> FindPath(Vector3 startPos, Vector3 targetPos)
    {
        // Converter posições mundiais para nós da grade
        GridNode startNode = NodeFromWorldPoint(startPos);
        GridNode targetNode = NodeFromWorldPoint(targetPos);

        // Inicializar conjuntos abertos e fechados para pathfinding
        List<GridNode> openSet = new List<GridNode>();
        HashSet<GridNode> closedSet = new HashSet<GridNode>();

        // Adicionar o nó de início ao conjunto aberto
        openSet.Add(startNode);

        // Executar o algoritmo de pathfinding A*
        while (openSet.Count > 0)
        {
            GridNode currentNode = openSet[0];
            for (int i = 1; i < openSet.Count; i++)
            {
                // Encontrar o nó com o menor custo total (fCost)
                if (openSet[i].fCost < currentNode.fCost || (openSet[i].fCost == currentNode.fCost && openSet[i].hCost < currentNode.hCost))
                {
                    currentNode = openSet[i];
                }
            }

            // Mover o nó atual do conjunto aberto para o conjunto fechado
            openSet.Remove(currentNode);
            closedSet.Add(currentNode);

            // Se o nó de destino for alcançado, retrace o caminho
            if (currentNode == targetNode)
            {
                return RetracePath(startNode, targetNode);
            }

            // Explorar vizinhos do nó atual
            foreach (GridNode neighbor in GetNeighbors(currentNode))
            {
                Debug.Log(neighbor);
                if (!neighbor.walkable || closedSet.Contains(neighbor))
                {
                    continue;
                }

                // Calcular o custo de movimento para o vizinho
                int newMovementCostToNeighbor = currentNode.gCost + 1;

                // Atualizar custo do vizinho e definir o pai se for um caminho melhor
                if (newMovementCostToNeighbor < neighbor.gCost || !openSet.Contains(neighbor))
                {
                    neighbor.gCost = newMovementCostToNeighbor;
                    neighbor.hCost = GetDistance(neighbor, targetNode);
                    neighbor.parent = currentNode;

                    // Adicionar o vizinho ao conjunto aberto se ainda não estiver presente
                    if (!openSet.Contains(neighbor))
                    {
                        openSet.Add(neighbor);
                    }
                }
            }
        }
        return null; // Caminho não encontrado
    }

    int GetDistance(GridNode nodeA, GridNode nodeB)
    {
        // Calcular a distância de Manhattan entre dois nós
        int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

        return dstX + dstY;
    }

    void OnDrawGizmos()
    {
        if (grid != null)
        {
            foreach (GridNode node in grid)
            {
                Gizmos.color = (node.walkable) ? Color.white : Color.red;
                Gizmos.DrawCube(node.worldPosition, Vector3.one * (nodeRadius * 2 - 0.1f));

                // Visualize the sphere for collision checking
                Gizmos.color = Color.blue;
                Gizmos.DrawWireSphere(node.worldPosition, nodeRadius);
            }
        }
    }


    GridNode NodeFromWorldPoint(Vector3 worldPosition)
    {
        // Converter uma posição mundial para o nó correspondente da grade
        float percentX = (worldPosition.x + gridWorldSize.x / 2) / gridWorldSize.x;
        float percentY = (worldPosition.y + gridWorldSize.y / 2) / gridWorldSize.y;

        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((grid.GetLength(0) - 1) * percentX);
        int y = Mathf.RoundToInt((grid.GetLength(1) - 1) * percentY);

        return grid[x, y];
    }

    List<GridNode> RetracePath(GridNode startNode, GridNode endNode)
    {
        // Retrace o caminho do nó final para o nó inicial
        List<GridNode> path = new List<GridNode>();
        GridNode currentNode = endNode;

        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }

        // Reverter o caminho para manter a ordem correta
        path.Reverse();
        return path;
    }

    List<GridNode> GetNeighbors(GridNode node)
    {
        // Obter nós vizinhos de um determinado nó
        List<GridNode> neighbors = new List<GridNode>();

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0)
                {
                    continue;
                }

                int checkX = node.gridX + x;
                int checkY = node.gridY + y;

                if (checkX >= 0 && checkX < grid.GetLength(0) && checkY >= 0 && checkY < grid.GetLength(1))
                {
                    neighbors.Add(grid[checkX, checkY]);
                }
            }
        }

        return neighbors;
    }

    void MoveAlongPath(List<GridNode> path)
    {
        Debug.Log(path);
        if (path != null && path.Count > 0)
        {
            // Obter o próximo nó no caminho
            GridNode nextNode = path[0];

            // Mover em direção ao próximo nó
            transform.position = Vector3.MoveTowards(transform.position, nextNode.worldPosition, Time.deltaTime * moveSpeed);

            // Verificar se o objeto chegou ao próximo nó
            if (Vector3.Distance(transform.position, nextNode.worldPosition) < 0.1f)
            {
                // Remover o nó atual do caminho
                path.RemoveAt(0);
            }
        }
    }
}