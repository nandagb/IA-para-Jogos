using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MEF : MonoBehaviour
{

    //propriedades

    List<Estado> states;
    Estado current_state;
    Transicao triggered_transition;
    Mapa mapa;

    //metodos

    // Start is called before the first frame update
    void Start()
    {
        /* INCIALIZANDO MAPA */
        this.mapa = GameObject.Find("Mapa").GetComponent<Mapa>();
        //iniciando transicoes
        Transicao comInimigos = new ComInimigos();
        Transicao semInimigos = new SemInimigos();
        Transicao inimigoProximo = new InimigoProximo();
        Transicao morto = new Morto();
        Transicao poucaVida = new PoucaVida();
        Transicao vidaRecuperada = new VidaRecuperada();
        Transicao inimigoLonge = new InimigoLonge();

        //iniciando estados
        Estado inicial = new Inicial();
        Estado busca = new Busca();
        Estado cacar = new Cacar();
        Estado atacar = new Atacar();
        Estado recuperar = new Recuperar();

        //adicionando transicoes a estados
        inicial.addTransicao(comInimigos);
        inicial.addTransicao(semInimigos);

        busca.addTransicao(comInimigos);

        cacar.addTransicao(inimigoProximo);

        atacar.addTransicao(morto);
        atacar.addTransicao(poucaVida);
        atacar.addTransicao(inimigoLonge);

        recuperar.addTransicao(vidaRecuperada);

        cacar.addTransicao(semInimigos);

        //adicionando estados a transicoes
        comInimigos.setTargetState(cacar);
        semInimigos.setTargetState(busca);
        inimigoProximo.setTargetState(atacar);
        poucaVida.setTargetState(recuperar);
        vidaRecuperada.setTargetState(busca);
        morto.setTargetState(inicial);
        inimigoLonge.setTargetState(cacar);
        semInimigos.setTargetState(busca);

        //preenchendo lista de estados
        this.states = new List<Estado>();
        this.states.Add(inicial);
        this.states.Add(busca);
        this.states.Add(cacar);
        this.states.Add(atacar);
        this.states.Add(recuperar);

        this.current_state = this.states[0];

    }

    // Update is called once per frame
    void Update()
    {
        if (mapa.getCelula(transform.position.x, transform.position.y).Ativa() || this.current_state == this.states[0])
        {
            print("current_state: " + this.current_state.nome);
            this.current_state.Action();
            triggered_transition = null;

            foreach (Transicao transicao in this.current_state.getTransicoes())
            {
                if (transicao.isTriggered())
                {
                    Debug.Log("nome da transicao: " + transicao.nome);
                    this.triggered_transition = transicao;
                    break;
                }

            }

            if (this.triggered_transition != null)
            {
                Estado target_state = this.triggered_transition.getTargedState();

                this.current_state.Exit();
                this.triggered_transition.Action();
                target_state.Enter();

                this.current_state = target_state;
            }
        }
        else
        {
            Debug.Log("A célula está desativada");
        }
    }

    public MEF()
    {

    }

    public void addState(Estado estado)
    {
        this.states.Add(estado);
    }

    public Estado getCurrentState()
    {
        return this.current_state;
    }

    public void setCurrentState(Estado estado)
    {
        if (this.current_state == estado)
        {
            return;
        }

        if (this.current_state != null)
        {
            this.current_state.Exit();
        }

        this.current_state = estado;

        if (this.current_state != null)
        {
            this.current_state.Enter();
        }

    }
}
