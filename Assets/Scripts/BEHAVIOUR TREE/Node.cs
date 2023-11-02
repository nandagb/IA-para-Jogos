using System.Collections;
using System.Collections.Generic;

public enum NodeState{
    RUNNING,
    SUCCESS,
    FAILURE
}

public class Node
{
    protected NodeState state;
    public Node parent;
    protected List<Node> children = new List<Node>();
    public string name;
    //compartilhamento de informacoes entre nos da arvore
    private Dictionary<string, object> _dataContext = new Dictionary<string, object>();

    public Node(){
        parent = null;
    }

    public Node(List<Node> children){
        foreach (Node child in children){
            _Attach(child);
        }
    }

    //adiciona um filho a este no
    public void _Attach(Node node){
        
        node.parent = this;
        children.Add(node);
    }

    //o metodo evaluate avalia o estado do no, cada no vai avaliar seu estado de forma diferente, o padrao eh retornar failure
    public virtual NodeState Evaluate() => NodeState.FAILURE;

    public void setData(string key, object value){
        _dataContext[key] = value;
    }

    public object GetData(string key){
        object value = null;
        if(_dataContext.TryGetValue(key, out value)){
            return value;
        }

        Node node = parent;

        while(node != null){
            value = node.GetData(key);
            if(value != null){
                return value;
            }
            node = node.parent;
        }
        return null;
    }

    public bool ClearData(string key){
        if(_dataContext.ContainsKey(key)){
            _dataContext.Remove(key);
            return true;
        }
        
        Node node = parent;
        while(node != null){
            bool cleared = node.ClearData(key);
            if(cleared){
                return true;
            }
            node = node.parent;
        }
        return false;
    }
    
}
