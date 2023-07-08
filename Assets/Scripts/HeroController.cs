using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HeroController : MonoBehaviour
{
    public Healthbar healthbar;
    public float movmentSpeed = 5f;
    public NavMeshAgent agent;
    public float maxMovmentRange;
    public bool isMoving = false;
    public Vector3 centerPosition;
    public Vector3 targetPos;
    public HeroMovmentArea movmentArea;
    private GameObject boss;

    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        boss = GameObject.Find("Boss");
        animator.SetBool("IsRunning", true);
        agent.SetDestination(boss.transform.position);
    }

    void Update()
    {
        agent.SetDestination(boss.transform.position);

        if (!animator.GetBool("IsDead"))
        {
            agent.SetDestination(boss.transform.position);
            if (agent.velocity.sqrMagnitude > 0)
            {
                animator.SetBool("IsRunning", true);
            }

            if (Vector3.Distance(transform.position, boss.transform.position) < 25.0f)
            {
                animator.SetBool("IsAttacking", true);
                this.transform.LookAt(boss.transform);
            }
            if (healthbar.Current == 0.0f)
            {
                animator.SetBool("IsWonGame", true);
            }
        }
        else
        {
            agent.ResetPath();
        }
    }

    public void Move()
    {
        if (!animator.GetBool("IsDead"))
        {
            isMoving = true;
            agent.SetDestination(boss.transform.position);
        }
        else
        {
            agent.ResetPath();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        if (boss != null)
        {
            Gizmos.DrawLine(transform.position, boss.transform.position);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (
            collision.gameObject.tag == "Laser"
            || collision.gameObject.tag == "Slash"
            || collision.gameObject.tag == "Wave"
            || collision.gameObject.tag == "Scattar"
        )
        {
            animator.SetBool("IsDead", true);
            animator.SetBool("IsAttacking", false);
            animator.SetBool("IsRunning", false);
        }
    }
}
