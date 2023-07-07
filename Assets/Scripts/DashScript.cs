using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DashScript : MonoBehaviour
{
    float full = 100;
    float current = 0 ;
    public float DashhCooldown = 5f;
    private float Dashrefill = 0f;
    [SerializeField] private Image Dashhbar;
    bool CanDash = false;

    public void Update()
    {
        // Update attack timer
        Dashrefill += Time.deltaTime;
        if (Dashrefill <= DashhCooldown)
        {
            current += 0.36f;
            fillBar(full, current);
        }

        if (Dashhbar.fillAmount == 1 )
        {
            CanDash = true;
        }
    }
    private void fillBar(float full, float current)
    {
        Dashhbar.fillAmount = current / full;
    }

    private void Dash()
    {
        
        Dashrefill = 0;
        CanDash = false;
    }

}
