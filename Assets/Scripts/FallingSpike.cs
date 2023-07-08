using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpike : MonoBehaviour
{
  
   void OnCollisionEnter(Collision collision)
      {
        if(collision.gameObject.tag == "Player")
        {
            print("Dead");
        }
        Destroy(gameObject,1);
        
      }
}
