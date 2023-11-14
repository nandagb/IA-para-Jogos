using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoInteligente : Personagem
{
    public float speed = 5f;
    public bool looking_for_potion = false;
    public float max_life = 10;
    // Start is called before the first frame update
    public override void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        
    }

    public void Die(){
        Destroy(gameObject);
    }
}
