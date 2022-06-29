using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelFactory : MonoBehaviour
{
    public GameObject barrel;
    private GameObject[] allBarrels;
    public int barrelCount = 0;
    public int maxBarrelCount = 1000;
    public float spawnTime = 1.0f;
    public float time = 0.0f;
    public float minSpawnTime = 3.0f;
    public float maxSpawnTime = 5.0f;
    public Transform Player;
    public float instantiatePosition;
    public obstcleDesignRules designChecker;

    // Start is called before the first frame update
    void Start()
    {
        allBarrels = new GameObject[maxBarrelCount];
        spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }


    // Update is called once per frame
    void Update()
    {
        if(barrelCount < maxBarrelCount)
        {
            time += Time.deltaTime;
            if(time >= spawnTime)
            {
                time = 0.0f;
                if(designChecker.isPlaceOk(Player.position.x + 2000, 2))addBarrel();
                spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            }
        }

    }

    

    void addBarrel()
    {
        if(barrelCount < maxBarrelCount)
        {
            Debug.Log("Barrel Count: " + barrelCount);
            instantiatePosition =  Player.position.x + 2000;
            Vector2 spawnPosition = new Vector2(instantiatePosition, 35);
            GameObject barrelObj = Instantiate(barrel.gameObject, spawnPosition, Quaternion.identity);
            allBarrels[barrelCount] = barrelObj;
            barrelCount++;
        }
    }
}






