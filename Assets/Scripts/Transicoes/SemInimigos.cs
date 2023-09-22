using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemInimigos : Transicao
{
    //propriedades

    //target state: busca

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
        //se nao houverem inimigos proximos
            //return true
        return false;
    }

}
