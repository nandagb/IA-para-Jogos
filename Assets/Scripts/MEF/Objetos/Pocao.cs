using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocao : MonoBehaviour
{
    //propriedades
    PathfindingScript pathfindingScript;
    GameObject playerObject;
    GameObject enemyObject;
    Player player;
    Transform playerTransform;

    public int valorPocao = 2;
    // Start is called before the first frame update
    void Start()
    {
        enemyObject = GameObject.Find("InimigoInteligente");
        pathfindingScript = enemyObject.GetComponent<PathfindingScript>();
        playerObject = GameObject.Find("Player");
        player = playerObject.GetComponent<Player>();
        playerTransform = playerObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other){
        Personagem personagem = other.GetComponent<Personagem>();

        if(personagem != null){
            if(personagem.life <10){
                personagem.life += valorPocao;
            }
            Debug.Log("destruindo pocao");
            if(pathfindingScript.enabled){
                pathfindingScript.SetTarget(playerTransform);
                pathfindingScript.enabled = false;
            }
            Destroy(gameObject);
            
        }
    }

    
}
