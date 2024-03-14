using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyAi : MonoBehaviour
{
    // script referenced from Module 1 (Jeevi)
    public float health;
    public NavMeshAgent agent;
    public Transform player;
    public bool chaseForever = false;
    public bool isRanged = false;
    public LayerMask whatIsGround, whatIsPlayer;
    public GameObject bulletObj;
    public float attackRange, sightRange;
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    public bool dead;
    public bool playerInSightRange, playerInAttackRange;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            if (gameObject.tag == "megaboy")
            {
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene("Win");
            }
            gameObject.SetActive(false);
            dead = true;
        }
    }
    private void Awake()
    {
        player = GameObject.Find("player").transform;
        agent = GetComponent<NavMeshAgent>();
        dead = false;
    }
    private void Update()
    {
        if(!dead)
        {
            RaycastHit hit;
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
            playerInAttackRange = Physics.Raycast(transform.position, player.position - transform.position, out hit, attackRange, whatIsPlayer);
            if(!playerInSightRange && !playerInAttackRange)
            {
                Patroling();
            }
            else if (playerInSightRange && !playerInAttackRange)
            {
                ChasePlayer();
            }

            else
            {
                if (chaseForever)
                {
                    ChasePlayer();
                }
                if (isRanged)
                {
                    AttackPlayer();
                }
            }
        }
    }
    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 0.1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            GameObject newBullet = Instantiate(bulletObj, transform.position, transform.rotation);
            newBullet.GetComponent<Rigidbody>().AddRelativeForce(0, 0, 1500f);
            Destroy(newBullet, 1f);
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
