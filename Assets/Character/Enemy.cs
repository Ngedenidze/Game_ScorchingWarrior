using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Enemy : MonoBehaviour
{

   private Transform player;

    public int hitPoints;
    public int maxHitPoints = 40;
    public float enemySpeed = 4f; 

    public float stoppingDistance;
    public float enemyFreeze;
    private float xPosition;
    private float xPositionPlayer;
    readonly Rigidbody2D rb2d;
    private float distance;

    //enemys da playeris shemotana
    void Start()
    {
        
        
         player = GameObject.FindGameObjectWithTag("Player").transform;
        rb2d.GetComponent<Rigidbody2D>();
        
        
    }

  
    void Update()
    {  //gamokideba
 
        xPosition = transform.position.x;
        xPositionPlayer = player.position.x;
        distance = xPosition - xPositionPlayer;
        if(distance<0) { distance = distance * (-1); } 

        if ( distance < stoppingDistance && (transform.position.y - player.position.y) <3.5 && distance > enemyFreeze)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, enemySpeed * Time.deltaTime);

        }
        else if ( distance > stoppingDistance)
        {
            rb2d.velocity = Vector2.zero;
        }


        if ( distance < 1)
        {

            rb2d.velocity = Vector2.zero;
        }
      
    }
    public void TakeDamage(int damage)
    {
        hitPoints -= damage;
        if(hitPoints <= damage)
        {

            Destroy(gameObject);
        }
    }

   

  

}
