using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveProjectile : MonoBehaviour
{
    public bool expandCircle = false;
    public bool enteredLoop = false;
    public float circleRadius = 2f;
    public float circleMaxRadius = 10f;
    public float _circleTimer;
    public float _circleTimerInterval = 5f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {       

        if(expandCircle)
        {
            if(enteredLoop)
            {
            transform.localScale  = new Vector3(2f, -0.1f, 2f);
            enteredLoop = false;
            circleRadius = 2f;
             _circleTimer = 0f;
            }
        //    if (_circleTimer >= _circleTimerInterval)
        //         {
        //             // Reset timer
        //             _circleTimer = 0f;
        //             expandCircle = false;
                 
        //         }
          // Update timers
          _circleTimer += Time.deltaTime / 7;
          circleRadius = transform.localScale.x;
          if(circleRadius < circleMaxRadius)
          {  
            transform.localScale  = new Vector3(transform.localScale.x + _circleTimer, transform.localScale.y + _circleTimer, transform.localScale.z + _circleTimer);
          }
          else if(circleRadius >= circleMaxRadius)
          {
            
           expandCircle = false;    
             StartCoroutine(WaitAndReset());     
          }
        }
    }
     IEnumerator WaitAndReset()
    {
        // suspend execution for 5 seconds
        yield return new WaitForSeconds(0.6f);
          transform.localScale  = new Vector3(0f, -0.1f, 0f);
            enteredLoop = false;
            circleRadius = 2f;
             _circleTimer = 0f;
    }
}
