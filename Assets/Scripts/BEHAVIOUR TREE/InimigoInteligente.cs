using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoInteligente : Personagem
{
    public float speed = 5f;
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
