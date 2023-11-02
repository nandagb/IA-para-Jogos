using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morto : Transicao
{

    //propriedades

    //Target State: Inicial
    Transform enemyTransform;
    Transform playerTransform;
    GameObject playerObject;
    GameObject enemyObject;
    Player player;
    Inimigo enemy;

    //metodos

    public Morto(){
        this.nome = "Morto";

        playerObject = GameObject.Find("Player");
        enemyObject = GameObject.Find("Inimigo");
        player = playerObject.GetComponent<Player>();
        enemy = enemyObject.GetComponent<Inimigo>();
        enemyTransform = enemyObject.transform;
        playerTransform = playerObject.transform;
    }

    public override void Action(){
        //sem acao
    }

    public override bool isTriggered(){
        return enemy.life == 0;
    }

    public override void printTransicao(){

    }
}
