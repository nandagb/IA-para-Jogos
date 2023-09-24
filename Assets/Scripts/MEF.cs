using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MEF : MonoBehaviour
{

    //propriedades

    List<Estado> states;
    Estado current_state;
    Transicao triggered_transition;

    
    

    //metodos

    // Start is called before the first frame update
    void Start()
    {
        this.states = new List<Estado>();
        this.states.Add(new Inicial());

        this.current_state = this.states[0];

        this.states.Add(new Busca());
        this.states.Add(new Cacar());
    }

    // Update is called once per frame
    void Update()
    {   
        this.current_state.Action();
        print("current_state: " + this.current_state.nome);
        triggered_transition = null;

        foreach(Transicao transicao in this.current_state.getTransicoes()){
            if(transicao.isTriggered()){
                Debug.Log("nome da transicao: " + transicao.nome);
                this.triggered_transition = transicao;
                break;
            }
            
        }

        Debug.Log("nome da triggered_transition: " + this.triggered_transition.nome);
        
        if(this.triggered_transition != null){
            Debug.Log("não é null");
            Estado target_state = this.triggered_transition.getTargedState();

            this.current_state.Exit();
            this.triggered_transition.Action();
            target_state.Enter();

            this.current_state = target_state;
        }


    }

    public MEF(){
        
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
