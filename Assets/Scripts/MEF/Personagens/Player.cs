using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : Personagem
{
    //propriedades
    public float speed = 5f;

    //public int life = 10;
    Transform playerTransform;
    Transform enemyTransform;
    Transform smartEnemyTransform;
    GameObject enemyObject;
    GameObject smartEnemyObject;
    Inimigo enemy;
    InimigoInteligente smartEnemy;

    //metodos

    // Start is called before the first frame update
    public override void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
        enemyObject = GameObject.Find("Inimigo");
        smartEnemyObject = GameObject.Find("InimigoInteligente");
        smartEnemy = smartEnemyObject.GetComponent<InimigoInteligente>();
        smartEnemyTransform = smartEnemyObject.transform;
        if(enemyObject != null){
            enemy = enemyObject.GetComponent<Inimigo>();
            enemyTransform = enemyObject.transform; 
        }
    }

    // Update is called once per frame
    public override void Update()
    {
        //player é controlado pelo jogador
        if(Input.GetAxis("Horizontal") != 0){
            Vector3 newPosition = new Vector3(playerTransform.position.x + Input.GetAxis("Horizontal") * speed * Time.deltaTime, playerTransform.position.y, playerTransform.position.z);
            playerTransform.position = newPosition;
        }
        if(Input.GetAxis("Vertical") != 0){
            Vector3 newPosition = new Vector3(playerTransform.position.x, playerTransform.position.y + Input.GetAxis("Vertical") * speed * Time.deltaTime, playerTransform.position.z);
            playerTransform.position = newPosition;
        }

        if(smartEnemy != null){
            if(EuclidianDist(playerTransform, smartEnemyTransform) <= 0.5){
                //atacar
                if(smartEnemy.life > 0){
                    smartEnemy.life--;
                }
            
            }
        }
        
    }

    double EuclidianDist(Transform player, Transform inimigo){
        Debug.Log(inimigo);
        //calcula a distancia 
        double diffx = Math.Pow(player.position.x - inimigo.position.x, 2);
        double diffy = Math.Pow(player.position.y - inimigo.position.y, 2); 
        return Math.Sqrt(diffx+diffy);
    }


}
