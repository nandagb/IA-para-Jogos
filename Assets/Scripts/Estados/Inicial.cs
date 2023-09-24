using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inicial : Estado
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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public override void Update()
    {
        return;   
    }

    public Inicial(){
        this.nome = "Inicial";
        this.transicoes = new List<Transicao>();
        this.transicoes.Add(new ComInimigos());
        this.transicoes.Add(new SemInimigos());

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
       //print("acao de Inicial: spawn");

        //spawnar
        Vector3 newPosition = enemyTransform.position;
        
        System.Random ran = new System.Random();
        float x = ran.Next(-5, 4);
        newPosition.x = x;
        float y = ran.Next(-4, 5);
        newPosition.y = y;

        enemyTransform.position = newPosition;
        return;
    }


    public override  void Exit(){
        //sem acao
        return;
    }

    public override void Enter(){
        //sem acao
        return;
    }

    public override void printEstado(){
        //print("Estado Inicial");
    }

}
