using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InimigoProximo : Transicao
{
    //propriedades

    Transform enemyTransform;
    Transform playerTransform;
    GameObject playerObject;
    Player player;

    //target state: Atacar

    //metodos 

    public InimigoProximo(){
        this.nome = "Inimigo Proximo";
        
        playerObject = GameObject.Find("Player");
        player = playerObject.GetComponent<Player>();
        enemyTransform = GameObject.Find("Inimigo").transform; 
        playerTransform = playerObject.transform;
    }

    public override void Action(){
        //sem acao
    }

    public override bool isTriggered(){
        double diffx = Math.Pow(playerTransform.position.x - enemyTransform.position.x, 2);
        double diffy = Math.Pow(playerTransform.position.y - enemyTransform.position.y, 2); 
        double dist = Math.Sqrt(diffx+diffy);

        return dist < 0.5;
    }

    public override void printTransicao(){

    }
}
