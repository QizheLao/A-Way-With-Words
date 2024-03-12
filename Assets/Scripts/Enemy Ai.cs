using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    // script referenced from Module 1 (Jeevi)
    public float health;
    public float damage = 5;
    public NavMeshAgent agent;
    public Transform player;
    public bool chaseForever = false;
    public bool isRanged = false;
    public LayerMask whatIsPlayer;
    public GameObject bulletObj;
    public float attackRange;
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    public static int totalEnemies = 32;

    private void Start()
    {
      GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
      totalEnemies = enemies.Length;
      health = Random.Range(health / 2, health + 1);
    }
    public void Initialize(float startingHealth)
    {
        health = startingHealth;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet")
        {
            TakeDamage(damage);
        }
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
            totalEnemies = enemies.Length;
          //Debug.Log("totalEnemies: " + totalEnemies);

            Destroy(gameObject,0f);
        }
    }
    private void Awake()
    {
        player = GameObject.Find("player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, player.position - transform.position, out hit, attackRange, whatIsPlayer))
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
