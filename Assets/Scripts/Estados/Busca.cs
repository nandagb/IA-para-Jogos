using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Busca : Estado
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

    public Busca(){
        this.nome = "Busca";

        this.transicoes = new List<Transicao>();
        this.transicoes.Add(new ComInimigos());

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
        //buscar um inimigo

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
    }

    public override void Exit(){

    }

    public override void Enter(){
        
    }

    public override void printEstado(){
        
    }
}
