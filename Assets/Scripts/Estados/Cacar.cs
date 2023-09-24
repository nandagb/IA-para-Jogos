using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cacar : Estado
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

    //List of Actions
    //List of Transitions: InimigoProximo

    //metodos

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        return;
        
    }

    public Cacar(){
        this.nome = "Cacar";
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
        
        
    }

    public override void Exit(){
        //sem acao
        return;
    }

    public override void Enter(){
        //sem acao
        return;
    }

    public override void printEstado(){
        //print("Estado Cacar");
    }
}
