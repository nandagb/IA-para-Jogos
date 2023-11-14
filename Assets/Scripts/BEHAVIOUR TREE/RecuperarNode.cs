using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RecuperarNode : Node
{
    GameObject playerObject;
    GameObject enemyObject;
    Player player;
    InimigoInteligente enemy;
    Transform enemyTransform; 
    Transform playerTransform;
    Transform pocao1Transform;
    Transform pocao2Transform;
    Transform pocao3Transform;
    Transform pocao4Transform;
    Transform pocao5Transform;
    PathfindingScript pathfindingScript;

    List<Vector3> pocoes;
    Vector3 target;

    public RecuperarNode(){
        playerObject = GameObject.Find("Player");
        enemyObject = GameObject.Find("InimigoInteligente");
        player = playerObject.GetComponent<Player>();
        enemy = enemyObject.GetComponent<InimigoInteligente>();
        enemyTransform = enemyObject.transform;
        playerTransform = playerObject.transform;
        pathfindingScript = enemyObject.GetComponent<PathfindingScript>();
        pocao1Transform = GameObject.Find("Pocao1").GetComponent<Pocao>().transform;
        pocao2Transform = GameObject.Find("Pocao2").GetComponent<Pocao>().transform;
        pocao3Transform = GameObject.Find("Pocao3").GetComponent<Pocao>().transform;
        pocao4Transform = GameObject.Find("Pocao4").GetComponent<Pocao>().transform;
        pocao5Transform = GameObject.Find("Pocao5").GetComponent<Pocao>().transform;



        this.pocoes = new List<Vector3>();
        
        this.pocoes.Add(new Vector3(-9.5f, 3.48000002f, -1f));
        this.pocoes.Add(new Vector3(-1.45000005f, 3.5f, -1f));
        this.pocoes.Add(new Vector3(5.55999994f, 3.50999999f, -1f));
        this.pocoes.Add(new Vector3(-1.47000003f, -2.50999999f, -1f));
        this.pocoes.Add(new Vector3(7.51999998f, -3.54999995f, -1f));
    }   

    public override NodeState Evaluate(){
        state = NodeState.RUNNING;


        //habilitando pathfind
        pathfindingScript.enabled = true;

        
            
        if(pocao1Transform != null){
            Debug.Log("setando pocao 1 como target");
            pathfindingScript.SetTarget(pocao1Transform);
        }   
        else if(pocao2Transform != null){
            Debug.Log("setando pocao 2 como target");
            pathfindingScript.SetTarget(pocao2Transform);
        }       
        else if(pocao3Transform != null){
            pathfindingScript.SetTarget(pocao3Transform);
        }   
        else if(pocao4Transform != null){
            pathfindingScript.SetTarget(pocao4Transform);
        }   
        else if(pocao5Transform != null){
            pathfindingScript.SetTarget(pocao5Transform);
        }
        else{
            pathfindingScript.SetTarget(playerTransform);
        }
                
                
        

        

        return state;
    } 
}
