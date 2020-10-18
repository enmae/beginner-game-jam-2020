using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayerScript : MonoBehaviour
{
    public Transform playerSprite;
    private float distanceToPlayer;
    void Start()
    {
        distanceToPlayer = playerSprite.position.x - transform.position.x;
    }

    void Update()
    {
        // Make sure floor moves below the player
        transform.position = new Vector3(playerSprite.position.x - distanceToPlayer, transform.position.y, transform.position.z);        
    }
}