using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Estado
{

    //propriedades

    public string nome = "";
    //list of actions?

    public List<Transicao> transicoes;

    //metodos


    public Estado(){

    }

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    public abstract void Update();

    public abstract void Exit();

    public abstract void Enter();

    public abstract void Action();

    public void setTransicoes(List<Transicao> transicoes){
        this.transicoes = transicoes;
    }

    public abstract void printEstado();

    public List<Transicao> getTransicoes(){
        return this.transicoes;
    }

}
