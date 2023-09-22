using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Inimigo : Personagem
{
    //propriedades
    public float speed = 5f;

    //public int life = 10;
    Transform enemyTransform;
    Transform playerTransform;
    GameObject playerObject;
    Player player;
    GameObject mapObject;
    Mapa map;
    Celula celula;

    public enum InimigoMEFStateStype{
        INICIAL = 0,
        CACAR,
        ATACAR,
        RECUPERAR,
        BUSCA,
    }

    //metodos

    // Start is called before the first frame update
    public override void Start()
    {
        playerObject = GameObject.Find("Player");
        player = playerObject.GetComponent<Player>();
        enemyTransform = GameObject.Find("Inimigo").transform; 
        playerTransform = playerObject.transform;
        mapObject = GameObject.Find("Mapa");
        map = mapObject.GetComponent<Mapa>();

        //spawnar
        Vector3 newPosition = enemyTransform.position;
        
        System.Random ran = new System.Random();
        float x = ran.Next(-5, 4);
        newPosition.x = x;
        float y = ran.Next(-4, 5);
        newPosition.y = y;

        enemyTransform.position = newPosition;

        celula = map.getCelula(enemyTransform.position.x, enemyTransform.position.y);
    }

    double EuclidianDist(){
        //calcula a distancia 
        double diffx = Math.Pow(playerTransform.position.x - enemyTransform.position.x, 2);
        double diffy = Math.Pow(playerTransform.position.y - enemyTransform.position.y, 2); 
        return Math.Sqrt(diffx+diffy);
    }

    // Update is called once per frame
    public override void Update()
    {
        celula = map.getCelula(enemyTransform.position.x, enemyTransform.position.y);

        Vector3 newPosition = enemyTransform.position;

        double dist = EuclidianDist();

        if(celula != null && celula.Ativa()){
            if(Inimigos()){
                //seguir player
                if(dist >= 0.5){
                    if(playerTransform.position.x > enemyTransform.position.x){
                        newPosition.x += + 0.5f * speed * Time.deltaTime;
                    }
                    else if(playerTransform.position.x < enemyTransform.position.x) {
                        newPosition.x -= 0.5f * speed * Time.deltaTime;
                    }
                

                    if(playerTransform.position.y > enemyTransform.position.y){
                        newPosition.y += 0.5f * speed * Time.deltaTime;
                    }
                    else if(playerTransform.position.y < enemyTransform.position.y) {
                        newPosition.y -= 0.5f * speed * Time.deltaTime;
                    }
                }
                else{
                    //atacar
                    if(player.life > 0){
                        player.life--;
                    }
                    
                }

                enemyTransform.position = newPosition;
            }
            else{
                //buscar um inimigo
                Vector3 randomPosition = enemyTransform.position;

                System.Random ran = new System.Random();
                float x = ran.Next(-5, 5);
                randomPosition.x = x;
                float y = ran.Next(-5, 5);
                randomPosition.y = y;

                if(randomPosition.x > enemyTransform.position.x){
                    newPosition.x += + 0.5f * speed * Time.deltaTime;
                }
                else if(randomPosition.x < enemyTransform.position.x) {
                    newPosition.x -= 0.5f * speed * Time.deltaTime;
                }
                

                if(randomPosition.y > enemyTransform.position.y){
                    newPosition.y += 0.5f * speed * Time.deltaTime;
                }
                else if(randomPosition.y < enemyTransform.position.y) {
                    newPosition.y -= 0.5f * speed * Time.deltaTime;
                }

                enemyTransform.position = newPosition;

            }
        }        

    }

    bool Inimigos(){
        double dist = EuclidianDist();
        if(dist <= 2.5){
            return true;
        }
        return false;
    }

}
