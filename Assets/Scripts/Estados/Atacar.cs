using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atacar : Estado
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

    //List of Transitions: InimigoFracoProximo, Morto, PoucaVida

    //metodos

    public Atacar(){
        this.nome = "Atacar";

        this.transicoes = new List<Transicao>();
        this.transicoes.Add(new PoucaVida());

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
        if(player.life > 0){
            player.life--;
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
