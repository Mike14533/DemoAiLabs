using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class playerInventoryBjorn : MonoBehaviour
{
    public static int points = 0;
    public static int attack = 3;
    public static int chest= 3;
    // float timer = 0.0f;
    // float scorex = 0.0f;
    int health = 3;
   

    //Get a reference to the Text UI
    public TextMeshProUGUI Health1;
    public TextMeshProUGUI Health2;
    public TextMeshProUGUI Health3;

     public TextMeshProUGUI Attack1;
     public TextMeshProUGUI Attack2;
     public TextMeshProUGUI Attack3;

    public TextMeshProUGUI Chest1;
     public TextMeshProUGUI Chest2;
     public TextMeshProUGUI Chest3;

     public GameObject Win;
     public GameObject Loss;
    public GameObject smartEnemy;

    // public TextMeshProUGUI Score;


    //Reference the HP Monitor
    itemLife itemLife;

    Death Death;


     // Start is called before the first frame update
    void Start()
    {
        itemLife = gameObject.GetComponent<itemLife>();
        Death = gameObject.GetComponent<Death>();
        Loss.SetActive(false);
        Win.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        // timer += Time.deltaTime;
        // scorex = timer % 60;

 
       
            
   
        // Score.text = "Score: " +  ((int)scorex + (3*(int)points));
        // if (attack == 0){
        //      Attack.enabled = false;
        // }
        // else{
        //     Attack.enabled = true;
        // }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        //Is the player colliding with a collectable?
        // if (collision.collider.tag == "Collectables"){
            
        //     points += 1;
            
        //     Debug.Log(points);

        //     GameObject collectable  = collision.gameObject;
        //     Destroy(collectable);
        // }

        // if (collision.collider.tag == "bonus"){
        //     attack  = 1 ;
           
            
        //     Debug.Log("Attack mode engaged");

        //     GameObject collectable  = collision.gameObject;
        //     Destroy(collectable);
        // }

         if (collision.collider.tag == "chest"){
            if(chest > 0){
                
                 GameObject collectable  = collision.gameObject;
                Destroy(collectable);
                
                chest -= 1;
           
                if (chest == 2){
                  Chest1.enabled = false;
                    
                }
                if (chest == 1){
                 Chest2.enabled = false;
                
                }
                if (chest == 0){
                    Chest3.enabled = false;
                    Win.SetActive(true);
                }
            }
         }

   

         if (collision.collider.tag == "enemy"){
            StartCoroutine("MyCoroutine");
            StartCoroutine("MyCoroutineHealth");
            if(attack > 0){
                
                 GameObject collectable  = collision.gameObject;
                Destroy(collectable);
                
                attack -= 1;
           
                if (attack == 2){
                  Attack1.enabled = false;
                 
                }
                if (attack == 1){
                 Attack2.enabled = false;
                 
                }
                if (attack == 0){
                    Attack3.enabled = false;
                    
                  
                }
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
                    Loss.SetActive(true);
                }
                
              
            }
        }
    }

   private IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(10f);
    //code here will execute after 5 seconds
        attack += 1;
        Debug.Log("Attack now up one");
             if(attack == 1){
            Attack3.enabled = true;
        }
        if(attack == 2){
            Attack2.enabled = true;
            Attack3.enabled = true;
        }
        if(attack == 3){
            Attack1.enabled = true;
            Attack2.enabled = true;
        }
    }

    private IEnumerator MyCoroutineHealth()
    {
        yield return new WaitForSeconds(30f);
    //code here will execute after 5 seconds
        health += 1;
        Debug.Log("Attack now up one");
             if(health == 1){
            Health3.enabled = true;
        }
        if(health == 2){
            Health2.enabled = true;
            Health3.enabled = true;
        }
        if(health == 3){
            Health1.enabled = true;
            Health2.enabled = true;
        }
    }
   

   
   
}
