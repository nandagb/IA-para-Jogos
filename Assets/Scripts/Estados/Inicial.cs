using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inicial : Estado
{
    //propriedades

    //List of Actions
    //List of Transitions: SemInimigos, ComInimigos

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
        //spawnar em um lugar aleatorio
        return;
    }


    public override  void Exit(){
        //sem acao
        return;
    }

    public override void Enter(){
        //sem acao
        return;
    }

}
