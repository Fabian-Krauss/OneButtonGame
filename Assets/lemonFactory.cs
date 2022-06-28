using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lemonFactory : MonoBehaviour
{

    public GameObject lemon;
    private GameObject[] allLemons;
    public int lemonCount = 0;
    public int maxLemonCount = 1000;
    public float spawnTime = 3.5f;
    public float time = 0.0f;
    public Transform Player;
    public float instantiatePosition;
    // Start is called before the first frame update
    void Start()
    {
        allLemons = new GameObject[maxLemonCount];
    }

    // Update is called once per frame
    void Update()
    {
         if(lemonCount < maxLemonCount)
        {
            time += Time.deltaTime;
            if(time >= spawnTime)
            {
                time = 0.0f;
                addLemon();
            }
        }
    }

        void addLemon()
    {
        if(lemonCount < maxLemonCount)
        {
            // Debug.Log("Lemon Count: " + lemonCount);
            instantiatePosition =  Player.position.x + 1000;
            Vector2 spawnPosition = new Vector2(instantiatePosition, 50);
            GameObject lemonObj = Instantiate(lemon.gameObject, spawnPosition, Quaternion.identity);
            allLemons[lemonCount] = lemonObj;
            lemonCount++;
        }
    }
}
