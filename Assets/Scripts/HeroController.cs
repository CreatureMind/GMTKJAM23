using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HeroController : MonoBehaviour
{

    public float movmentSpeed = 5f;
    public NavMeshAgent agent;
    public float maxMovmentRange;
    public bool isMoving = false;
    public Vector3 centerPosition;
    public Vector3 targetPos;
    public HeroMovmentArea movmentArea;
    private GameObject boss;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        boss = GameObject.Find("Boss");
            agent.SetDestination(boss.transform.position);


       // FindNewTargetPos();
    }

    // Update is called once per frame
    void Update()
    {
    agent.SetDestination(boss.transform.position);


    }


     public void Move()
     {         
              isMoving = true;
            agent.SetDestination(boss.transform.position);
     }

     void OnDrawGizmosSelected()
     {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, boss.transform.position);
     }

      void OnCollisionEnter(Collision collision)
      {
        if(collision.gameObject.tag == "Laser")
        {
            print("Dead");
        }
      }
}
