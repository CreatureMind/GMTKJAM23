using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    [SerializeField] private Image Healthbar;
    float Fullhealth = 100;
    float current = 100;

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == "Hero")
            {
            current -= 10;
            OnHit(Fullhealth, current);
            }
        }

    private void OnHit( float full , float current)
    {
        Healthbar.fillAmount = current/full;
    }

}
