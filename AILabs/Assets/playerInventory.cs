using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class playerInventory : MonoBehaviour
{
    public static int points = 0;
    public static int attack = 0;
    float timer = 0.0f;
    float scorex = 0.0f;
    int health = 3;
   

    //Get a reference to the Text UI
    public TextMeshProUGUI Health1;
    public TextMeshProUGUI Health2;
    public TextMeshProUGUI Health3;

    public TextMeshProUGUI Attack;

    public TextMeshProUGUI Score;
    

    //Reference the HP Monitor
    itemLife itemLife;

    Death Death;


     // Start is called before the first frame update
    void Start()
    {
        itemLife = gameObject.GetComponent<itemLife>();
        Death = gameObject.GetComponent<Death>();
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        scorex = timer % 60;

 
       
            
   
        Score.text = "Score: " +  ((int)scorex + (3*(int)points));
        if (attack == 0){
             Attack.enabled = false;
        }
        else{
            Attack.enabled = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        //Is the player colliding with a collectable?
        if (collision.collider.tag == "Collectables"){
            
            points += 1;
            
            Debug.Log(points);

            GameObject collectable  = collision.gameObject;
            Destroy(collectable);
        }

        if (collision.collider.tag == "bonus"){
            attack  = 1 ;
           
            
            Debug.Log("Attack mode engaged");

            GameObject collectable  = collision.gameObject;
            Destroy(collectable);
        }

         if (collision.collider.tag == "enemy"){
            if(attack > 0){
                
                 GameObject collectable  = collision.gameObject;
                Destroy(collectable);
                
                attack = 0;
            }
            else{
                health -= 1;
                if (health == 2){
                  Health1.enabled = false;
                }
                if (health == 1){
                 Health2.enabled = false;
                }
                if (health == 0){
                    Health3.enabled = false;
                   Debug.Log("You have Died");
                   Death.StartGame();
                }
                
              
            }
        }
    }

  
   
   
}
