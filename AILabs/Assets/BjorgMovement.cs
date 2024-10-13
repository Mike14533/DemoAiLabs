using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BjorgMovement : MonoBehaviour
{

    SpriteRenderer SR;
    Animator anim;
   
    public float speed = 3.0f;
    public GameObject[] waypoints;

	// Use this for initialization
	void Start ()
    {
      SR = GetComponent<SpriteRenderer>();
      anim = GetComponent<Animator>();
      StartCoroutine("MyCoroutine");
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Move the player ship to where the mouse is clicked on-screen
       anim.speed = 0.0f;

        Vector3 input = new Vector3(0.0f,0.0f,0.0f);

        // Move the player based on cursor key inputs
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            input += Vector3.left;
            SR.flipX = true;
            anim.speed = 1.0f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            input += Vector3.right;
            SR.flipX = false;
            anim.speed = 1.0f;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            input += Vector3.up;
            anim.speed = 1.0f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            input += Vector3.down;
            anim.speed = 1.0f;
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

        private IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(1f);
    //code here will execute after 5 seconds
    waypoints[0].transform.position = transform.position;
    yield return new WaitForSeconds(1.5f);
    waypoints[1].transform.position = transform.position;
   
    StartCoroutine("MyCoroutine1");
    }
        private IEnumerator MyCoroutine1()
    {
        yield return new WaitForSeconds(0f);
    //code here will execute after 5 seconds
    StartCoroutine("MyCoroutine");
    }
}

