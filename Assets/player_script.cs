using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_script : MonoBehaviour
{
    public float speed = 5f;
    Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") != 0){
            Vector3 newPosition = new Vector3(playerTransform.position.x + Input.GetAxis("Horizontal") * speed * Time.deltaTime, playerTransform.position.y, playerTransform.position.z);
            playerTransform.position = newPosition;
        }
        if(Input.GetAxis("Vertical") != 0){
            Vector3 newPosition = new Vector3(playerTransform.position.x, playerTransform.position.y + Input.GetAxis("Vertical") * speed * Time.deltaTime, playerTransform.position.z);
            playerTransform.position = newPosition;
        }
    }
}
