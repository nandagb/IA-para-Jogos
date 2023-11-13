using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BuscaNode : Node
{
    GameObject playerObject;
    GameObject enemyObject;
    Player player;
    InimigoInteligente enemy;
    Transform enemyTransform; 
    Transform playerTransform;
    GameObject mapObject;
    Mapa map;
    PathfindingScript pathfindingScript;

    public BuscaNode(){

        playerObject = GameObject.Find("Player");
        enemyObject = GameObject.Find("InimigoInteligente");
        player = playerObject.GetComponent<Player>();
        enemy = enemyObject.GetComponent<InimigoInteligente>();
        enemyTransform = enemyObject.transform;
        playerTransform = playerObject.transform;
        mapObject = GameObject.Find("Mapa");
        map = mapObject.GetComponent<Mapa>();
        pathfindingScript = enemyObject.GetComponent<PathfindingScript>();

    }

    public override NodeState Evaluate(){        
        //buscar um inimigo
        state = NodeState.RUNNING;
        pathfindingScript.enabled = false;

        //enquanto estiver rodando calcula uma posicao nova para ir
        Vector3 newPosition = enemyTransform.position;
        Vector3 randomPosition = enemyTransform.position;

        System.Random ran = new System.Random();
        float x = ran.Next(-5, 5);
        randomPosition.x = x;
        float y = ran.Next(-5, 5);
        randomPosition.y = y;

        if(randomPosition.x > enemyTransform.position.x){
            newPosition.x += + 0.5f * enemy.speed * Time.deltaTime;
        }
        else if(randomPosition.x < enemyTransform.position.x) {
            newPosition.x -= 0.5f * enemy.speed * Time.deltaTime;
        }
                    

        if(randomPosition.y > enemyTransform.position.y){
            newPosition.y += 0.5f * enemy.speed * Time.deltaTime;
        }
        else if(randomPosition.y < enemyTransform.position.y) {
            newPosition.y -= 0.5f * enemy.speed * Time.deltaTime;
        }

        enemyTransform.position = newPosition;
        //fim da acao de busca
        return state;
        

    }
}
