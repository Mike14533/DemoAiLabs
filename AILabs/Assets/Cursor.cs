using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    public float moveSpeed = 10;
    public GameObject[] objectsToBePlaced;
    public GameObject[] DirectionWaypoint;
    public int limit = 0;

    void Update()
    {
   
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);
    if(limit > 0){
            if (Input.GetMouseButtonDown(0))
            {
                if (mousePosition.x < -0.64 && mousePosition.y > -1.43)
                {
                    Debug.Log("Pressed primary button.");
                    Instantiate(objectsToBePlaced[2], transform.position, transform.rotation);
                    limit -= 1;
                }
                if (mousePosition.x < -0.64 && mousePosition.y < -1.43)
                {
                    Debug.Log("Pressed primary button.");
                    Instantiate(objectsToBePlaced[0], transform.position, transform.rotation);
                    limit -= 1;
                }
            }
          if (Input.GetMouseButtonDown(1)){
            Debug.Log("Pressed primary button.");
            Instantiate(objectsToBePlaced[1], transform.position, transform.rotation);
             limit -= 1;
          }
    }

         
         }
    }

