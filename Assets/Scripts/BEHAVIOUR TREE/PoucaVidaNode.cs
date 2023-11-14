using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoucaVidaNode : Node
{
    GameObject playerObject;
    GameObject enemyObject;
    Player player;
    InimigoInteligente enemy;
    Transform enemyTransform; 
    Transform playerTransform;
    GameObject mapObject;
    Mapa map;

    public PoucaVidaNode(){
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
        state = NodeState.FAILURE;

        if(enemy.life <= 3){
            enemy.looking_for_potion = true;
            Debug.Log("inimigo deve procurar por poção");
            state = NodeState.SUCCESS;
        }
        else if(enemy.life < enemy.max_life){
            if(enemy.looking_for_potion){
                Debug.Log("inimigo deve continuar procurando por poção");
                state = NodeState.SUCCESS;
            }
            else{
                Debug.Log("inimigo ainda pode perder vida");
                state = NodeState.FAILURE;
            }
        }
        else{
            enemy.looking_for_potion = false;
            Debug.Log("inimigo está com vida completa");
            state = NodeState.FAILURE;
        }

        return state;
    }
}
