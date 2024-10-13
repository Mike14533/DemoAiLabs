using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class WaypointPatternMovementFireball : MonoBehaviour
{
    // Start is called before the first frame update
       [Serializable]
   public struct WaypointData
   {
       public GameObject location;
       public int speed;
     
   }
    // int for chase range
   public int chaseRange =120;
    public WaypointData[] pattern;
   
  
    

    private int patternIndex = 0;

    public float speed =0;
    
     public  float timeBetween = 100f;



    // Use this for initialization
    void Start ()
    {
       
	}
	
	// Update is called once per frame
	void Update ()
    {
        
      
        
       
    
        
       

       


      
         // Process the current instruction in our control data array
        WaypointData data = pattern[patternIndex];
        speed = data.speed;

        
        float range0 = Vector3.Distance(data.location.transform.position, transform.position);
      
         if (range0 <= 0.5f){
            
            StartCoroutine("Die");
            

         }
        
         
       




        // Find the range to close vector
        Vector3 rangeToClose = data.location.transform.position - transform.position;

        // Draw this vector at the position of the enemy
        Debug.DrawRay(transform.position, rangeToClose, Color.cyan);

        // What's our distance to the waypoint?
        float distance = rangeToClose.magnitude;
        // checks to see if the object distance is greater then the chase range and if so the object will pause
     
        // How far do we move each frame
        float speedDelta = speed * Time.deltaTime;

        // If we're close enough to the current waypoint 
        // then increase the pattern index
       
            if (distance <= speedDelta)
            {
                        
                patternIndex++;
                        
                // Reset the patternIndex if we are at the end of the instruction array
              if (patternIndex >= pattern.Length)
             {
                         patternIndex = 0;
             }

            

               // Process the current instruction in our control data array
                data = pattern[patternIndex];
                speed = data.speed;
                // Find the new range to close vector
                rangeToClose = data.location.transform.position - transform.position;
              

                       
            }   
        

        // In what direction is our waypoint?
        Vector3 normalizedRangeToClose = rangeToClose.normalized;

        // Draw this vector at the position of the waypoint
        Debug.DrawRay(transform.position, normalizedRangeToClose, Color.magenta);

        Vector3 delta = speedDelta * normalizedRangeToClose;

        transform.Translate(delta);
        
       
      
    } 

    IEnumerator Die()
    {


        
       
     
    
        yield return  new WaitForSeconds (0f);
          Destroy(gameObject);
        
        
    }

    

  

}
