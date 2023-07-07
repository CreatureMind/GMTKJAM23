using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovmentArea : MonoBehaviour
{
    public float circleRadius = 10f;

       void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, circleRadius);
    }
}
