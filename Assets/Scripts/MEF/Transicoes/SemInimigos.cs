using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SemInimigos : Transicao
{
    //propriedades

    Transform enemyTransform;
    Transform playerTransform;
    GameObject playerObject;
    Player player;
    //public string nome = "SemInimigos";
    //target state: busca

    //metodos

    public SemInimigos(){
        this.nome = "SemInimigos";
        
        playerObject = GameObject.Find("Player");
        player = playerObject.GetComponent<Player>();
        enemyTransform = GameObject.Find("Inimigo").transform; 
        playerTransform = playerObject.transform;
    }


    public override void Action(){
        //sem acao
    }

    public bool Inimigos(){
        //Vector3.distance(pont1, ponto2);
        double diffx = Math.Pow(playerTransform.position.x - enemyTransform.position.x, 2);
        double diffy = Math.Pow(playerTransform.position.y - enemyTransform.position.y, 2); 
        double dist = Math.Sqrt(diffx+diffy);
        if(dist <= 2.5){
            return true;
        }
        return false;
    }

    public override bool isTriggered(){
        return !Inimigos();   
    }

    public override void printTransicao(){
        //print("Transição: Sem Inimigos");
    }

}
