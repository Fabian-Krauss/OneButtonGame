using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public float followSpeed = 3.0f;
    private Transform player;
    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        player = GameObject.Find("Player").transform;
        Debug.Log(player);
        pos = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position+ pos, followSpeed*Time.deltaTime);
        }
        if(transform.position.y < 2f){
            transform.position = new Vector3(transform.position.x, 2f, transform.position.z);
        }
    }
}
