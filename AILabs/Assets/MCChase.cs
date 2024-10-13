using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCChase : MonoBehaviour
{

    GameObject target;
    public GameObject[] targets;
    public float speed = 1.0f;
    public float chaseRange;
   
    float targetRange = 100;
    


    void start(){
        

       
        target = targets[0];
    }
    

    
  
	// Update is called once per frame
	void Update ()
    {
        
        float range0 = Vector3.Distance(targets[0].transform.position, transform.position);
        float range1 = Vector3.Distance(targets[1].transform.position, transform.position);
        float range2 = Vector3.Distance(targets[2].transform.position, transform.position);

        if (range0 <= targetRange ){
            target = targets[0] ;
          
            targetRange = range0;
            Debug.Log("0 Set to target");
            }
             if(range1 <= targetRange ){
                target = targets[1];
                
                 targetRange = range1;
                 Debug.Log("1 Set to target");
             }
        if (range2 <= targetRange)
        {
            target = targets[2];

            targetRange = range2;
            Debug.Log("1 Set to target");
        }

        float speedDelta  = speed * Time.deltaTime;
        Vector3 newPosition = tusMoveTowards(speedDelta);

        transform.position = newPosition;
        
    }

 
        
    
        
   

    Vector3 tusMoveTowards(float sd)
    {
        
      

    
        Vector3 currentPosition = transform.position;
        Vector3 targetPosition = target.transform.position;

        Vector3 rangeToClose = targetPosition - currentPosition;
  
        
       // float range0 = (targets[0].position, transform.position);

        //Debug.DrawRay(currentPosition, rangeToClose, Color.red);
         
        
        Vector3 newPosition;

        // Get the magnitude of the vector
        float magnitude = rangeToClose.magnitude;
    
        if (magnitude < chaseRange)
        {
        
           
                 Vector3 normalisedRangeToClose = rangeToClose.normalized;
                
                 Vector3 velocity = normalisedRangeToClose * sd;
              
              
                newPosition = currentPosition + velocity;
            
        
        }

        else
        {
            newPosition = currentPosition;
        }

        return newPosition;
    }
        
        
        
}






