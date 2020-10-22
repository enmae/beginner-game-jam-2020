using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject tile1;
    public GameObject tile2;
    public GameObject tile3;
    public GameObject tile4;
    public GameObject tile5;
    public GameObject tile6;
    public GameObject tile7;
    public GameObject tile8;
    public GameObject tile9;
    public GameObject tile10;
    public GameObject tile11;
    public GameObject tile12;
    public GameObject tile13;
    public GameObject tile14;

    public GameObject ground;
    public GameObject ceiling;

    // I add these values to the position when generating new obstacles
    // in order to calculate the max and min y position of obstacles
    private float groundPos;
    private float ceilingPos;

    List<GameObject> pool = new List<GameObject>();
    // with this list I make sure all the pool items are generated
    // before repeating generation again
    List<int> currentPool = new List<int>();

    private float lastObstaclePos = 50;

    public Transform player;

    private void Start()
    {
        // my pool has two of each type of obstacle
        pool.Add(tile1);
        pool.Add(tile2);
        pool.Add(tile3);
        pool.Add(tile4);
        pool.Add(tile5);
        pool.Add(tile6);
        pool.Add(tile7);
        pool.Add(tile8);
        pool.Add(tile9);
        pool.Add(tile10);
        pool.Add(tile11);
        pool.Add(tile12);
        pool.Add(tile13);
        pool.Add(tile14);

        ceilingPos = ceiling.GetComponent<Transform>().position.y - ceiling.GetComponent<Transform>().localScale.y / 2;
        groundPos = ground.GetComponent<Transform>().localScale.y / 2 + ground.GetComponent<Transform>().position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if ((int)player.position.x > lastObstaclePos - 40)
        {
            generateNewObstacle();
        }
    }

    private void generateNewObstacle()
    {
        int obstacleNum = Random.Range(0, pool.Count);
        while (currentPool.Contains(obstacleNum))
        {
            obstacleNum = Random.Range(0, pool.Count);
        }
        currentPool.Add(obstacleNum);
        if (currentPool.Count == pool.Count)
        {
            currentPool.Clear();
        }
        
        GameObject newObstacle = pool[obstacleNum];
        
        float x = lastObstaclePos + Random.Range(27, 32);
        float y;

        float minY = groundPos + newObstacle.GetComponent<Transform>().localScale.y * 1.27f; 
        float maxY = ceilingPos - newObstacle.GetComponent<Transform>().localScale.y * 1.27f;

        // we make most obstacles stick to either the ceiling or floor
        int num = Random.Range(1, 11);
        if (num > 5)
        {
            if (num % 2 == 0)
            {
                y = maxY;
            } else
            {
                y = minY;
            }
        } else // we make the obstacle a floating boi
        {
            // basically making sure the player will always be able to fit
            // underneath or above so they don't get mad
            y = Random.Range(minY + 8, maxY - 8);
        }

        newObstacle.GetComponent<Transform>().position = new Vector3(x, y, 0);

        lastObstaclePos = x + newObstacle.GetComponent<Transform>().localScale.x / 1.5f; // same thing here
        
    }
}
