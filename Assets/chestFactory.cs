using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestFactory : MonoBehaviour
{
    public GameObject chest;
    private GameObject[] allChests;
    public int chestCount = 0;
    public int maxChestCount = 1000;
    public float spawnTime = 1.0f;
    public float time = 0.0f;
    public float minSpawnTime = 3.0f;
    public float maxSpawnTime = 5.0f;
    public Transform Player;
    public float instantiatePosition;

    // Start is called before the first frame update
    void Start()
    {
        allChests = new GameObject[maxChestCount];
        spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }


    // Update is called once per frame
    void Update()
    {
        if(chestCount < maxChestCount)
        {
            time += Time.deltaTime;
            if(time >= spawnTime)
            {
                time = 0.0f;
                addchest();
                spawnTime = Random.Range(1.0f, 3.0f);
            }
        }
    }

    void addchest()
    {
        if(chestCount < maxChestCount)
        {
            // Debug.Log("chest Count: " + chestCount);
            instantiatePosition =  Player.position.x + 1000;
            Vector2 spawnPosition = new Vector2(instantiatePosition, 45);
            GameObject chestObj = Instantiate(chest.gameObject, spawnPosition, Quaternion.identity);
            allChests[chestCount] = chestObj;
            chestCount++;
        }
    }
}
