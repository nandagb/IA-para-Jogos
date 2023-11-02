using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CheckInimigo : Node
{
    GameObject playerObject;
    GameObject enemyObject;
    Player player;
    InimigoInteligente enemy;
    Transform enemyTransform; 
    Transform playerTransform;
    GameObject mapObject;
    Mapa map;

    public CheckInimigo(){
        playerObject = GameObject.Find("Player");
        enemyObject = GameObject.Find("InimigoInteligente");
        player = playerObject.GetComponent<Player>();
        enemy = enemyObject.GetComponent<InimigoInteligente>();
        enemyTransform = enemyObject.transform;
        playerTransform = playerObject.transform;
        mapObject = GameObject.Find("Mapa");
        map = mapObject.GetComponent<Mapa>();
        name = "CheckInimigo";
    }

    public override NodeState Evaluate(){
        Debug.Log("evaluating check inimigo");
        state = NodeState.FAILURE;
        
        double diffx = Math.Pow(playerTransform.position.x - enemyTransform.position.x, 2);
        double diffy = Math.Pow(playerTransform.position.y - enemyTransform.position.y, 2); 
        double dist = Math.Sqrt(diffx+diffy);

        if(dist <= 2.5){
            state = NodeState.SUCCESS;
            Debug.Log("returning success from check inimigo");
            return state;
        }

        Debug.Log("returning failure from check inimigo");
        return state;
    }
}
