using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transicao : MonoBehaviour
{

    //propriedades

    Estado target;
    Condicao condition

    //metodos

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void setTarget(Estado target){
        this.target = target;
    }

    condition setCondition(Condicao condition){
        this.target = target;
    }


}
