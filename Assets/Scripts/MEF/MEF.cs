using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Estado;

public abstract class MEF : MonoBehaviour
{

    //propriedades

    Estado estadoAtivo;

    public MEF(Estado estado_inicial){
        this.estadoAtivo = estado_inicial;
    }

    //metodos

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
