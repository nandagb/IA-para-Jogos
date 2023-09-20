using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estado : Estado
{

    //propriedades

    //list of actions?
    public delegate void DelegateNoArg();
    public DelegateNoArg OnEnter;
    public DelegateNoArg OnExit;
    public DelegateNoArg OnUpdate;
    public DelegateNoArg OnFixedUpdate;

    List<Transicao> transicoes;

    //metodos

    public Estado(DelegateNoArg onEnter, DelegateNoArg onExit = null, DelegateNoArg onUpdate = null, DelegateNoArg onFixedUpdate = null){
        OnEnter = onEnter;
        OnExit = onExit;
        OnUpdate = onUpdate;
        OnFixedUpdate = onFixedUpdate;
    }

    public Estado(){

    }

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    virtual public void Update(){
        OnUpdate?.Invoke();
    }

    virtual public void FixedUpdate(){
        OnFixedUpdate?.Invoke();
    }

    virtual public void Exit(){
        OnExit?.Invoke();
    }

    virtual public void Enter(){
        OnEnter?.Invoke();
    }

    virtual public void Action(){

    }

    public void setTransicoes(List<Transicao> transicoes){
        this.transicoes = transicoes;
    }
}
