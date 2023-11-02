using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class Selector : Node
{
    public Selector() : base() { }
    public Selector(List<Node> children) : base(children) { }
    //public string name = "Selector";

    public override NodeState Evaluate(){
        name = "Selector";
        //Debug.Log("evaluating selector node");
        Debug.Log("selector tem filhos: " + children.Count);
        foreach (Node child in children)
        {
            Debug.Log("child: " + child.name);
        }


        foreach(Node node in children){
            switch (node.Evaluate()){
                case NodeState.FAILURE:
                    continue;
                case NodeState.SUCCESS:
                    state = NodeState.SUCCESS;
                    return state;
                case NodeState.RUNNING:
                    state = NodeState.RUNNING;
                    return state;
                default: 
                    continue;
            }
        }
        
        state = NodeState.FAILURE;
        return state;
    }
}
