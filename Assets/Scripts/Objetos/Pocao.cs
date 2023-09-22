using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocao : MonoBehaviour
{
    //propriedades

    public int valorPocao = 2;
    // Start is called before the first frame update
    void Start()
    {
        
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

            Destroy(gameObject);
        }
    }

    
}
