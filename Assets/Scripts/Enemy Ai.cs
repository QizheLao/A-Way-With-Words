using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
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

    private void Start()
    {
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
            gameObject.SetActive(false);
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
