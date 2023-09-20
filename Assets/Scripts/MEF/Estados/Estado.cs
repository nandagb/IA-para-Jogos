using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estado : Estado
{

    //propriedades

    List<Transicao> transicoes;
    List<Acao> acoes;

    //metodos

    public Estado(List<Transicao> transicoes){
        this.transicoes = transicoes
    }

    // Start is called before the first frame update
    void Start()
    {
        Enter();
    }

    // Update is called once per frame
    public void Update(){
        Action();
    }

    public void FixedUpdate(){
        
    }

    public abstract void Exit(){
        
    }

    public abstract void Enter(){
        
    }

    public abstract void Action(){
        for(int i = 0; i< acoes.length; i++){
            acoes.agir();
        }
    }

    public void setTransicoes(List<Transicao> transicoes){
        this.transicoes = transicoes;
    }
}
