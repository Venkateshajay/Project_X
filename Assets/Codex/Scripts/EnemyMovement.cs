using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Transform targetTransform;
    private NavMeshAgent navmeshAgent;
    [SerializeField]bool reachedTarget = false;
    [SerializeField] Transform[] wayPoints;
    [SerializeField] private Transform player;
    [SerializeField] Canvas EndCanvas;
    [SerializeField] private Animator animator;

    private void Start()
    {
        gameObject.transform.position = wayPoints[Random.Range(0, wayPoints.Length)].position;
        navmeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        FindNextTarget();
    }
    private void Update()
    {
        CheckForPlayer();
        CheckForPlayerDeath();
        if (reachedTarget)
        {
            FindNextTarget();
        }
        else
        {
            navmeshAgent.SetDestination(targetTransform.position);
        }
    }

    private void CheckForPlayerDeath()
    {
        if(Vector3.Distance(transform.position, player.position) < 3f)
        {
            animator.SetBool("Attack", true);
        }
        if(Vector3.Distance(transform.position, player.position) < 1f)
        {
            EndCanvas.enabled = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            navmeshAgent.SetDestination(transform.position);
            Debug.Log("Player died");
        }
    }

    private void CheckForPlayer()
    {
        Ray ray = new Ray(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z + 0.3f), transform.forward);
        if(Physics.Raycast(ray,out RaycastHit hit, 10f))
        {
            Debug.DrawRay(new Vector3(transform.position.x,transform.position.y+0.5f,transform.position.z+0.3f), transform.forward *10, Color.red);
            if (hit.collider.gameObject.tag == "Player")
            {
                Debug.Log("Player got hit");
                targetTransform = player;
            }
        }
        if(Vector3.Distance(transform.position , player.position) > 10f && targetTransform == player)
        {
            FindNextTarget();
        }
    }

    private void FindNextTarget()
    {
        targetTransform = wayPoints[Random.Range(0, wayPoints.Length)];
        reachedTarget = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "WayPoint")
        {
            Debug.Log("waypoint reached");
            reachedTarget = true;
        }
    }
}
