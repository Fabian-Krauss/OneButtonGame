using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonFactory : MonoBehaviour
{
    public GameObject skeleton;
    private GameObject[] allSkeletons;
    public int skeletonCount = 0;
    public int maxSkeletonCount = 1000;
    public float spawnTime = 1.0f;
    public float time = 0.0f;
    public float minSpawnTime = 3.0f;
    public float maxSpawnTime = 5.0f;
    public Transform Player;
    public float instantiatePosition;

    // Start is called before the first frame update
    void Start()
    {
        allSkeletons = new GameObject[maxSkeletonCount];
        spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }


    // Update is called once per frame
    void Update()
    {
        if(skeletonCount < maxSkeletonCount)
        {
            time += Time.deltaTime;
            if(time >= spawnTime)
            {
                time = 0.0f;
                addSkeleton();
                spawnTime = Random.Range(1.0f, 3.0f);
            }
        }

    }

    void addSkeleton()
    {
        if(skeletonCount < maxSkeletonCount)
        {
            Debug.Log("Skeleton Count: " + skeletonCount);
            instantiatePosition =  Player.position.x + 1000;
            Vector2 spawnPosition = new Vector2(instantiatePosition, 35);
            GameObject skeletonObj = Instantiate(skeleton.gameObject, spawnPosition, Quaternion.identity);
            allSkeletons[skeletonCount] = skeletonObj;
            skeletonCount++;
        }
    }
}

