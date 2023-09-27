using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaRecuperada : Transicao
{
    //propriedades
    Transform enemyTransform;
    Transform playerTransform;
    GameObject playerObject;
    GameObject enemyObject;
    Player player;
    Inimigo enemy;

    //Target State: Busca

    //metodos

    public VidaRecuperada(){
        this.nome = "Vida Recuperada";

        playerObject = GameObject.Find("Player");
        enemyObject = GameObject.Find("Inimigo");
        player = playerObject.GetComponent<Player>();
        enemy = enemyObject.GetComponent<Inimigo>();
        enemyTransform = enemyObject.transform;
        playerTransform = playerObject.transform;
        
        this.target_state = new Busca();
    }

    public override void Action(){
        //sem acao
    }

    public override bool isTriggered(){
        return enemy.life == 10;
    }

    public override void printTransicao(){

    }
}
