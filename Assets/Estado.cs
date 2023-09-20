using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Estado : MonoBehaviour
{

    //propriedades

    //list of actions?

    List<Transicao> transicoes;

    //metodos

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void getExitAction();

    public abstract void getEntryAction();

    public abstract void getAction();

    public void setTransicoes(List<Transicao> transicoes){
        this.transicoes = transicoes;
    }
}
