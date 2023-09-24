using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapa : MonoBehaviour
{
    //propriedades

    Celula[,] celulas;

    Transform playerTransform;
    GameObject playerObject;
    Player player;

    Celula current_cell;

    //metodos

    // Start is called before the first frame update
    void Start()
    {
        celulas = new Celula[3, 3];
        
        celulas[0, 0] = new Celula(-5, -2, 2, 5);
        celulas[0, 1] = new Celula(-2, 1, 2, 5);
        celulas[0, 2] = new Celula(1, 4, 2, 5);

        celulas[1, 0] = new Celula(-5, -2, -1, 2);
        celulas[1, 1] = new Celula(-2, 1, -1, 2);
        celulas[1, 2] = new Celula(1, 4, -1, 2);

        celulas[2, 0] = new Celula(-5, -2, -4, -1);
        celulas[2, 1] = new Celula(-2, 1, -4, -1);
        celulas[2, 2] = new Celula(1, 4, -4, -1);

        playerObject = GameObject.Find("Player");
        player = playerObject.GetComponent<Player>();
        playerTransform = playerObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        int linhas = celulas.GetLength(0);
        int colunas = celulas.GetLength(1);

        //setando celulas ativas
        for (int i = 0; i < linhas; i++)
        {
            for (int j = 0; j < colunas; j++)
            {
                Celula celula = celulas[i, j];
                if(celula.Inside(playerTransform.position.x, playerTransform.position.y)){//celula onde o player está
                    this.current_cell = celula;
                    celulas[i, j].setAtiva(true);
                }
                else if(celula.Close(playerTransform.position.x, playerTransform.position.y)){//celula adjacentes
                    celulas[i, j].setAtiva(true);
                }
                else{//celula onde o player não está
                    celulas[i, j].setAtiva(false);
                }
            }
        }

    }

    public Celula getCelula(float x, float y){
        int linhas = celulas.GetLength(0);
        int colunas = celulas.GetLength(1);        

        //setando celulas ativas
        for (int i = 0; i < linhas; i++)
        {
            for (int j = 0; j < colunas; j++)
            {
                Celula celula = celulas[i, j];
                if(celula.Inside(x, y)){
                    return celula;
                }
            }
        }

        return null;

    }


    //num da malha, x(min, max), y(min, max)
    //limites do cenario: 
    //ponta cima esquerda: (-5, 5)
    //ponta cima direita: (4, 5)
    //ponta baixo esquerda: (-5, -4)
    //ponta baixo direita: (4, -4)

    //largura: 9
    //altura: 9

    //area 1: x(-5, -2), y(5, 2)
    //area 2: x(-2, 1), y(5, 2)
    //area 3: x(1, 4), y(5, 2)
    //area 4: x(-5, -2), y(2, -1)
    //area 5: x(-2, 1), y(2, -1)
    //area 6: x(1, 4), y(2, -1)
    //area 7: x(-5, -2), y(-1, -4)
    //area 8: x(-2, 1), y(-1, -4)
    //area 9: x(1, 4), y(-1, -4)
}
