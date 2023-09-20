using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transicao : MonoBehaviour
{

    //propriedades

    Estado estado;

    //metodos

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void Action();

    public abstract bool isTriggered();

    public void setTargetState(Estado estado){
        this.estado = estado;
    }


    public Estado getTargedState(){
        return estado;
    }

}
