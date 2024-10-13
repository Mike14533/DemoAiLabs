using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerdetect : MonoBehaviour
{
    public int x =0;
     void OnCollisionEnter(Collision collision)
    {
     x =1;
     Debug.Log("X is equal to one");
    }
}
