using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // follow the player with the camera
        transform.position = new Vector3(GameObject.Find("Player").transform.position.x + 300, 200, -80);
        
    }
}
