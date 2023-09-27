using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Recuperar : Estado
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
    
    List<Vector3> pocoes;
    Vector3 target;


    //List of Actions
    //List of Transitions: VidaRecuperada

    //metodos

    public Recuperar(){
        this.nome = "Recuperar";

        this.transicoes = new List<Transicao>();

        this.pocoes = new List<Vector3>();
        this.pocoes.Add(new Vector3(-3.48f, 3.42f, -1f));
        this.pocoes.Add(new Vector3(2.37f, 3.42f, -1f));
        this.pocoes.Add(new Vector3(-0.58f, 3.46f, -1f));
        this.pocoes.Add(new Vector3(-3.44f, 0.51f, -1f));
        this.pocoes.Add(new Vector3(-0.45f, 0.53f, -1f));
        this.pocoes.Add(new Vector3(2.43f, 0.57f, -1f));
        this.pocoes.Add(new Vector3(-3.47f, -2.39f, -1f));
        this.pocoes.Add(new Vector3(-0.52f, -2.5f, -1f));
        this.pocoes.Add(new Vector3(2.35f, -2.5f, -1f));
        

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
        //procurar pocoes de vida para recuperar a vida

        foreach(Vector3 position in pocoes){
            if(position.z == -1f){
                Debug.Log("encontrei uma pocao");
                target = position;
                break;
            }
        }

        Vector3 newPosition = enemyTransform.position;

        if(target.x > enemyTransform.position.x){
            newPosition.x += + 0.5f * enemy.speed * Time.deltaTime;
        }
        else if(target.x < enemyTransform.position.x) {
            newPosition.x -= 0.5f * enemy.speed * Time.deltaTime;
        }
                

        if(target.y > enemyTransform.position.y){
            newPosition.y += 0.5f * enemy.speed * Time.deltaTime;
        }
        else if(target.y < enemyTransform.position.y) {
            newPosition.y -= 0.5f * enemy.speed * Time.deltaTime;
        }

        enemyTransform.position = newPosition;

        for(int i=0; i<pocoes.Count; i++){
            if(Math.Abs(enemyTransform.position.x - pocoes[i].x) <= 0.05 && Math.Abs(enemyTransform.position.y - pocoes[i].y) <= 0.05){
                Debug.Log("setando posicao como visitada");
                Vector3 updatedVector = pocoes[i];
                updatedVector.z = 1f;
                pocoes[i] = updatedVector;
                break;
            }
        }
    }

    public override void Exit(){
        //sem acao
    }

    public override void Enter(){
        //sem acao
    }

    public override void printEstado(){

    }
}
