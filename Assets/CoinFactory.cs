using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinFactory : MonoBehaviour
{
    public GameObject coin;
    private GameObject[] allCoins;
    public int coinCount = 0;
    public int maxCoinCount = 1000;
    public float spawnTime = 1.0f;
    public float time = 0.0f;
    public Transform Player;
    public float instantiatePosition;
    public ScenenManager sm;

    // Start is called before the first frame update
    void Start()
    {
        allCoins = new GameObject[maxCoinCount];
        spawnTime = Random.Range(1.0f, 3.0f);
    }


    // Update is called once per frame
    void Update()
    {
        if(coinCount < maxCoinCount)
        {
            time += Time.deltaTime;
            if(time >= spawnTime)
            {
                time = 0.0f;
                addCoin();
                spawnTime = Random.Range(1.0f, 3.0f);
            }
        }
    }

    void addCoin()
    {
        if(coinCount < maxCoinCount)
        {
            // Debug.Log("Coin Count: " + coinCount);
            instantiatePosition =  Player.position.x + 1000;
            float spawnHight = 0;
            if(SceneManager.GetActiveScene().buildIndex == 4){
                   spawnHight = 180;
            }
            else{
                   spawnHight = 35;
            }

            Vector2 spawnPosition = new Vector2(instantiatePosition, spawnHight);
            GameObject coinObj = Instantiate(coin.gameObject, spawnPosition, Quaternion.identity);
            allCoins[coinCount] = coinObj;
            coinCount++;
        }
    }
}
