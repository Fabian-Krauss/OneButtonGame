using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class soldierFactory : MonoBehaviour
{
    public GameObject soldier;
    private GameObject[] allsoldiers;
    public int soldierCount = 0;
    public int maxSoldierCount = 1000;
    public float spawnTime = 1.0f;
    public float time = 0.0f;
    public float minSpawnTime = 3.0f;
    public float maxSpawnTime = 5.0f;
    public Transform Player;
    public float instantiatePosition;
    public obstcleDesignRules designChecker;
    public float timeToStartSpawn = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        allsoldiers = new GameObject[maxSoldierCount];
        spawnTime = Random.Range(10 , 10);
    }

    // Update is called once per frame
    void Update()
    {
           if(soldierCount < maxSoldierCount && Time.realtimeSinceStartup > timeToStartSpawn)
        {
            time += Time.deltaTime;
            if(time >= spawnTime)
            {
                time = 0.0f;
                if(designChecker.isPlaceOk(Player.position.x + 1000, 3))addsoldier();
                spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            }
        }   
    }

        void addsoldier()
    {
        if(soldierCount < maxSoldierCount)
        {
            Debug.Log("soldier Count: " + soldierCount);
            instantiatePosition =  Player.position.x + 1000;
             float spawnHight = 0;
            if(SceneManager.GetActiveScene().buildIndex == 4){
                   spawnHight = 180;
            }
            else{
                   spawnHight = 50;
            }

            Vector2 spawnPosition = new Vector2(instantiatePosition, spawnHight);
            GameObject soldierObj = Instantiate(soldier.gameObject, spawnPosition, Quaternion.identity);
            allsoldiers[soldierCount] = soldierObj;
            soldierCount++;
        }
    }
}
