using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Move : MonoBehaviour {
    public GameObject item;     //pickup
    private int moveX;   //tells us which direction it's going on the x axis
    private int moveY;     //tells us the direction on the y axis
    private Rigidbody2D rb2d;   //UFO 
    public float speed;  //how fast it's moving
    private Vector2 destination;
    public GameObject UFO;
    public bool shouldMove = true;
    private GameObject[] targets;
    private int objectCount;

    // Use this for initialization
    void Start () {
        //get destination co ordinates
        rb2d = GetComponent<Rigidbody2D>();
        targets = GameObject.FindGameObjectsWithTag("PickUp");
        objectCount = 1;
        destination = targets[0].transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        //check where the UFO is and move towards the item
        Vector3 position = UFO.transform.position;
        Vector2 movement = new Vector2();

        if (destination.x < position.x)
        {
            movement = new Vector2(position.x - speed, position.y);
            
        }

        if (destination.x > position.x)
        {
            movement = new Vector2(position.x + speed, position.y);
        }

        if (destination.y < position.y)
        {
            movement = new Vector2(position.x, position.y - speed);
            if (speed > 0)
            {
                speed = -speed;
            }
        }

        if (destination.y > position.y)
        {
            movement = new Vector2(position.x, position.y + speed);
            if (speed < 0)
            {
                speed = -speed;
            }
        }


        rb2d.AddForce(movement * speed);
    }

    //void movePlayer(Vector3 position)
    //{
    //    while (shouldMove)
    //    {
    //        Vector2 movement = new Vector2(position.x - speed, position.y);

    //        rb2d.AddForce(movement * speed);
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            if (objectCount + 1 < targets.Length)
            {
                destination = targets[objectCount].transform.position;
                objectCount++;
                
            }

            else
            {
                shouldMove = false;
            }
            
            
        }
    }
}
