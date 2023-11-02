using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoucaVida : Transicao
{

    //propriedades
    Transform enemyTransform;
    Transform playerTransform;
    GameObject playerObject;
    GameObject enemyObject;
    Player player;

    Inimigo enemy;
    //Target State: Recuperar

    //metodos

    public PoucaVida(){
        this.nome = "Pouca Vida";

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
        return enemy.life <= 3;
    }

    public override void printTransicao(){

    }
}
