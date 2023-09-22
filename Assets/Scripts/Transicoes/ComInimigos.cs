using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComInimigos : Transicao
{

    //propriedades

    //target State: 

    //metodos

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Action(){
        //sem acao
    }

    public override bool isTriggered(){
        //se houverem inimigos proximos
            //return true
        return false;
    }
}
