using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CacaNode : Node
{
    GameObject playerObject;
    GameObject enemyObject;
    Player player;
    InimigoInteligente enemy;
    Transform enemyTransform; 
    Transform playerTransform;
    GameObject mapObject;
    Mapa map;

    public CacaNode(){
        playerObject = GameObject.Find("Player");
        enemyObject = GameObject.Find("InimigoInteligente");
        player = playerObject.GetComponent<Player>();
        enemy = enemyObject.GetComponent<InimigoInteligente>();
        enemyTransform = enemyObject.transform;
        playerTransform = playerObject.transform;
        mapObject = GameObject.Find("Mapa");
        map = mapObject.GetComponent<Mapa>();
        name = "CacaNode";
    }


    public override NodeState Evaluate(){
        state = NodeState.RUNNING;

        double diffx = Math.Pow(playerTransform.position.x - enemyTransform.position.x, 2);
        double diffy = Math.Pow(playerTransform.position.y - enemyTransform.position.y, 2); 
        double dist = Math.Sqrt(diffx+diffy);

        Vector3 newPosition = enemyTransform.position;

        if(dist >= 0.5){
            if(playerTransform.position.x > enemyTransform.position.x){
                newPosition.x += + 0.5f * enemy.speed * Time.deltaTime;
            }
            else if(playerTransform.position.x < enemyTransform.position.x) {
                newPosition.x -= 0.5f * enemy.speed * Time.deltaTime;
            }
                    

            if(playerTransform.position.y > enemyTransform.position.y){
                newPosition.y += 0.5f * enemy.speed * Time.deltaTime;
            }
            else if(playerTransform.position.y < enemyTransform.position.y) {
                newPosition.y -= 0.5f * enemy.speed * Time.deltaTime;
            }
        }

        enemyTransform.position = newPosition;

        return state;
    }
}
