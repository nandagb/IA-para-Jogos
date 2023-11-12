using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode : MonoBehaviour
{
    public GameObject goal;
    public float g;
    public float h { get { return (Vector3.Distance(transform.position, goal.transform.position)); }}
    public float totalCost { get{ return g + h; }}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
