using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inicial : Estado
{
    //propriedades

    GameObject playerObject;
    GameObject enemyObject;
    Player player;
    Inimigo enemy;
    Transform enemyTransform; 
    Transform playerTransform;
    GameObject mapObject;
    Mapa map;

    

    //metodos

    public Inicial(){
        this.nome = "Inicial";

        this.transicoes = new List<Transicao>();

        playerObject = GameObject.Find("Player");
        enemyObject = GameObject.Find("Inimigo");
        player = playerObject.GetComponent<Player>();
        enemy = enemyObject.GetComponent<Inimigo>();
        enemyTransform = enemyObject.transform;
        playerTransform = playerObject.transform;
        mapObject = GameObject.Find("Mapa");
        map = mapObject.GetComponent<Mapa>();
    }


    public override void Action(){
        //spawnar
        Vector3 newPosition = enemyTransform.position;
        
        System.Random ran = new System.Random();
        float x = ran.Next(-5, 4);
        newPosition.x = x;
        float y = ran.Next(-4, 5);
        newPosition.y = y;

        enemyTransform.position = newPosition;
        return;
    }


    public override  void Exit(){

    }

    public override void Enter(){
        
    }

    public override void printEstado(){
        
    }

}
