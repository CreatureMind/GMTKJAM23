using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HeroController : MonoBehaviour
{

    public float movmentSpeed = 5f;
    public NavMeshAgent agent;
    public Transform target;
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
        if (!agent.pathPending)
 {
     if (agent.remainingDistance <= agent.stoppingDistance)
     {
         if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
         {
            agent.velocity = Vector3.zero;
            agent.Stop();
              agent.SetDestination(boss.transform.position);
         }
     }
 }

    }

//      private void FindNewTargetPos() {
//            maxMovmentRange = movmentArea.circleRadius; //radius of *black circle*
//   centerPosition = gameObject.transform.localPosition; //center of *black circle*
//        Vector3 pos = movmentArea.gameObject.transform.localPosition;
//          targetPos = new Vector3();
//          targetPos.x  = Random.Range(pos.x - maxMovmentRange, pos.x + maxMovmentRange);
//          targetPos.y = pos.y;
//          targetPos.z = Random.Range(pos.z - maxMovmentRange, pos.z + maxMovmentRange);
    
//        Move();          

//      }
//      public void Move()
//      {         
//               isMoving = true;
//             agent.SetDestination(targetPos);
//      }

     void OnDrawGizmosSelected()
     {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, boss.transform.position);
     }

      
}
