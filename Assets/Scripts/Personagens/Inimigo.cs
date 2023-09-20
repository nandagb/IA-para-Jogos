using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    //propriedades
    public float speed = 5f;

    public int life = 10;
    Transform enemyTransform;

    //metodos

    // Start is called before the first frame update
    void Start()
    {
       enemyTransform = GameObject.Find("Inimigo").transform; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
