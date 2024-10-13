﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    SpriteRenderer SR;
    public GameObject target;
    public float speed = 1.0f;
    public float chaseRange;
    Color newColor;
   
    public int evade;
    public int boost;
    public float speedx = 1.0f;



    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
       
    }
	// Update is called once per frame
	void Update ()
    {
        evade = playerInventory.attack;
        boost = playerInventory.points;
        float speedDelta  = speed * Time.deltaTime;
        speed = speedx + 0.2f * boost; 
       
        // Use Unity's Vector3.moveTowards
        //Vector3 newPosition = Vector3.MoveTowards(transform.position, target.transform.position, speedDelta);        
        // Write our own aitMoveTorwards
        
        Vector3 newPosition = tusMoveTowards(speedDelta);

        transform.position = newPosition;
    }

 
        
    
        
   

    Vector3 tusMoveTowards(float sd)
    {
        Vector3 currentPosition = transform.position;
        Vector3 targetPosition = target.transform.position;

        Vector3 rangeToClose = targetPosition - currentPosition;

        //Debug.DrawRay(currentPosition, rangeToClose, Color.red);
         
        
        Vector3 newPosition;

        // Get the magnitude of the vector
        float magnitude = rangeToClose.magnitude;

        if (magnitude < chaseRange)
        {
            
             if (evade  < 1)
            {
                Vector3 normalisedRangeToClose = rangeToClose.normalized;
                
                Vector3 velocity = normalisedRangeToClose * sd;
               // Color newColor = new Color(0.3f, 0.4f, 0.6f, 0.0f);
                Color newColor = new Color(255f, 255f, 255f, 0.1f);
                SR.color = newColor;
                newPosition = currentPosition + velocity;
            }
            else {
              Vector3 normalisedRangeToClose = rangeToClose.normalized;
                Color newColor = new Color(255f, 255f, 255f, 1.0f);
                SR.color = newColor;
                Vector3 velocity = normalisedRangeToClose * -sd;
               // Color newColor = new Color(0.3f, 0.4f, 0.6f, 90.0f);
                newPosition = currentPosition + velocity; 
            }
        }

        else
        {
            newPosition = currentPosition;
        }

        return newPosition;
        
        
        
        

        /*// Calculate our range to close i.e. the vector between
        // our enemy and the target
        Vector3 rangeToClose = targetPosition - currentPosition;
        Debug.DrawRay(currentPosition, rangeToClose, Color.red);

        // Get the magnitude of the vector
        float magnitude = rangeToClose.magnitude;

        Vector3 newPosition;

        if (magnitude < chaseRange)
        {
            // Get the direction only
            Vector3 normalisedRangeToClose = rangeToClose.normalized;
            Debug.DrawRay(currentPosition, normalisedRangeToClose, Color.green);

            Debug.Log("Magnitude: " + magnitude + " Direction: " + normalisedRangeToClose);

            // Move speedDelta along the normalisedRangeToClose direction
            Vector3 velocity = normalisedRangeToClose * sd;

            newPosition = currentPosition + velocity;
        }
        else
        {
            newPosition = currentPosition;
        }

        return newPosition;*/
        //return transform.position;
    }

}






