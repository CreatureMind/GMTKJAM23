using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] public Image HealthbarImage;
    float Fullhealth = 100;
    public float Current = 100;

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == "Hero")
            {
            Current -= 10;
            OnHit(Fullhealth, Current);
            }
        }

    private void OnHit( float full , float current)
    {
        HealthbarImage.fillAmount = current/full;
    }

}
