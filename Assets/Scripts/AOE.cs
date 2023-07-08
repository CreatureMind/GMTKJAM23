using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AOE : MonoBehaviour
{

    public float _AOE_Flash;
    public float _AOE_Flash_Timer;
    public float _AOE_Flash_Speed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
          if (_AOE_Flash >= _AOE_Flash_Timer)
            {
               
                // Reset timer
                _AOE_Flash = 0f;
            }
            // Update timers
            _AOE_Flash += Time.deltaTime * _AOE_Flash_Speed;
             // Perform Flash
            PerformFlash();
    }

    public void PerformFlash()
    {

  foreach (Transform child in transform)
        {
           // if(child.gameObject.name == "Lazer")
          //  {
                var image = child.GetComponent<Image>();
                var tempColor = image.color;
                tempColor.a = _AOE_Flash / 100; //0f;
                image.color = tempColor;
           // }
        }
        
    }
}
