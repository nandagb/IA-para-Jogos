using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cacar : Estado
{

    //propriedades

    //List of Actions
    //List of Transitions: InimigoProximo

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

    public override void Action(){
        //perseguir o inimigo próximo
        return;
    }

    public override void Exit(){
        //sem acao
        return;
    }

    public override void Enter(){
        //sem acao
        return;
    }
}
