using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MEF : MonoBehaviour
{

    //propriedades

    List<Estado> states;
    Estado current_state;
    

    //metodos
    // Start is called before the first frame update
    void Start()
    {
        this.states = new List<Estado>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.current_state != null){
            this.current_state.Update();
        }
    }

    void FixedUpdate(){
        if(this.current_state != null){
            this.current_state.FixedUpdate();
        }
    }

    public void addState(Estado estado){
        this.states.Add(estado);
    }

    public Estado getCurrentState(){
        return this.current_state;
    }

    public void setCurrentState(Estado estado){
        if(this.current_state == estado){
            return;
        }

        if(this.current_state != null){
            this.current_state.Exit();
        }

        this.current_state = estado;

        if(this.current_state != null){
            this.current_state.Enter();
        }

    }
}
