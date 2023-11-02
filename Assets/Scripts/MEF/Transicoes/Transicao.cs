using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transicao
{

    //propriedades

    public Estado target_state;
    public string nome = "";

    //metodos

    public abstract void Action();

    public abstract bool isTriggered();

    public abstract void printTransicao();

    public void setTargetState(Estado estado){
        this.target_state = estado;
    }


    public Estado getTargedState(){
        return this.target_state;
    }

}
