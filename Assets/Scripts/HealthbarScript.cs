using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    [SerializeField] private Image Healthbar;

    public void OnHIt()
    {
        void OnCollisionEnter(Collision collision)
        {
            Healthbar.fillAmount = -0.1f;
        }
        
    }
}
