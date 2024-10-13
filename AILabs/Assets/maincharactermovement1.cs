using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maincharactermovement1 : MonoBehaviour
{

    SpriteRenderer SR;

   
    public float speed = 3.0f;

	// Use this for initialization
	void Start ()
    {
      SR = GetComponent<SpriteRenderer>();
     
      
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Move the player ship to where the mouse is clicked on-screen


        Vector3 input = new Vector3(0.0f,0.0f,0.0f);

        // Move the player based on cursor key inputs
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            input += Vector3.left;
            SR.flipX = true;
            
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            input += Vector3.right;
            SR.flipX = false;
      
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            input += Vector3.up;
            
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            input += Vector3.down;
            
        }
        else{
            
        }

        Vector3 velocity = input.normalized * speed * Time.deltaTime;

        // Could replace the above with the following code
        //Vector3 velocity = Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        transform.position += velocity;
    }

    void OnBecameInvisible()
    {
        Camera cam = Camera.main;

        if (cam != null)
        {
            Vector3 viewportPosition = cam.WorldToViewportPoint(transform.position);

            Vector3 newPosition = transform.position;

            if (viewportPosition.x > 1 || viewportPosition.x < 0)
            {
                newPosition.x = -newPosition.x;
            }

            if (viewportPosition.y > 1 || viewportPosition.y < 0)
            {
                newPosition.y = -newPosition.y;
            }

            transform.position = newPosition;
        }

    }

    
}

