using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoInteligenteBT : BehaviourTree
{
    
    protected override Node SetUpTree(){
        Node root  = new Selector(new List<Node> 
        {
            new Sequence(new List<Node> 
            {
                new CheckInimigo(),
                new CacaNode()
            }),
            new BuscaNode(),
        });
        
        return root;
    }
    
}
