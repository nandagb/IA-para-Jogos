using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortoNode : Node
{
    GameObject playerObject;
    GameObject enemyObject;
    Player player;
    InimigoInteligente enemy;
    Transform enemyTransform; 
    Transform playerTransform;
    GameObject mapObject;
    Mapa map;

    public MortoNode(){
        playerObject = GameObject.Find("Player");
        enemyObject = GameObject.Find("InimigoInteligente");
        player = playerObject.GetComponent<Player>();
        enemy = enemyObject.GetComponent<InimigoInteligente>();
        enemyTransform = enemyObject.transform;
        playerTransform = playerObject.transform;
        mapObject = GameObject.Find("Mapa");
        map = mapObject.GetComponent<Mapa>();
    }   

    public override NodeState Evaluate(){
        state = NodeState.SUCCESS;

        if(enemy.life > 0){
            state = NodeState.FAILURE;
            return state;
        }

        return state;
    } 
}
