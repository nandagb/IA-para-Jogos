using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BehaviourTree : MonoBehaviour
{

    private Node _root = null;
    // Start is called before the first frame update
    void Start()
    {
        _root = SetUpTree();
    }

    // Update is called once per frame
    void Update()
    {
        if(_root != null){
            _root.Evaluate();
        }
    }

    protected abstract Node SetUpTree();
}
