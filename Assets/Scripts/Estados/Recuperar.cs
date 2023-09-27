using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    //List of Actions
    //List of Transitions: VidaRecuperada

    //metodos

    public Recuperar(){
        this.nome = "Recuperar";

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
        //procurar pocoes de vida para recuperar a vida

        //por enquanto está seguindo a funcao de busca, (melhorar)

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
        //sem acao
    }

    public override void Enter(){
        //sem acao
    }

    public override void printEstado(){

    }
}
