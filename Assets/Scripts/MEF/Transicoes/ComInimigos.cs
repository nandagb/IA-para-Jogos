using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ComInimigos : Transicao
{

    //propriedades
    
    Transform enemyTransform;
    Transform playerTransform;
    GameObject playerObject;
    Player player;

    //metodos

    public ComInimigos(){
        this.nome = "Com Inimigos";
        playerObject = GameObject.Find("Player");
        player = playerObject.GetComponent<Player>();
        enemyTransform = GameObject.Find("Inimigo").transform; 
        playerTransform = playerObject.transform;
    }

    public override void Action(){
        //sem acao
    }

    public bool Inimigos(){
        double diffx = Math.Pow(playerTransform.position.x - enemyTransform.position.x, 2);
        double diffy = Math.Pow(playerTransform.position.y - enemyTransform.position.y, 2); 
        double dist = Math.Sqrt(diffx+diffy);
        if(dist <= 2.5){
            return true;
        }
        return false;
    }

    public override bool isTriggered(){ 
        return Inimigos();
        
    }

    public override void printTransicao(){
        
    }
}
