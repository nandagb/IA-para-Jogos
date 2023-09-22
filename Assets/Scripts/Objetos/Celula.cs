using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Celula
{
    float min_x;
    float max_x;
    float min_y;
    float max_y;
    bool ativa = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Celula(){

    }

    public Celula(float min_x, float max_x, float min_y, float max_y){
        this.min_x = min_x;
        this.max_x = max_x;
        this.min_y = min_y;
        this.max_y = max_y;
    }

    public bool Inside(float x, float y){
        if(x >= min_x && x <= max_x && y >= min_y && y <= max_y){
            return true;
        }
        return false;
    }

    public bool Close(float x, float y){
        if( (Math.Abs( x - min_x) <= 1 || Math.Abs(x - max_x) <= 1) && (Math.Abs(y - min_y) <= 1 || Math.Abs(y - max_y) <= 1) ){
            return true;
        }
        return false;
    }

    public void setAtiva(bool estado){
        this.ativa = estado;
    }

    public bool Ativa(){
        return this.ativa;
    }

}
