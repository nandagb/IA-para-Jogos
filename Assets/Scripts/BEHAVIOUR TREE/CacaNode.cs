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
    PathfindingScript pathfindingScript;


    public CacaNode(){
        playerObject = GameObject.Find("Player");
        enemyObject = GameObject.Find("InimigoInteligente");
        player = playerObject.GetComponent<Player>();
        enemy = enemyObject.GetComponent<InimigoInteligente>();
        enemyTransform = enemyObject.transform;
        playerTransform = playerObject.transform;
        pathfindingScript = enemyObject.GetComponent<PathfindingScript>();
    }


    public override NodeState Evaluate(){
        state = NodeState.RUNNING;
        
        //habilitando pathfind
        pathfindingScript.enabled = true;

        Debug.Log("estou no CacaNode");
        pathfindingScript.SetTarget(playerTransform);


        return state;
    }
}
