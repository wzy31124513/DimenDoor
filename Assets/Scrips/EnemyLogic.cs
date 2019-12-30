using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

enum EnemyState
{
    Idle,
    Chase,
    Attack
}

public class EnemyLogic : MonoBehaviour
{
    GameObject m_player;

    NavMeshAgent m_navMeshAgent;

    Vector3 m_patrolOrigin;
    Vector3 m_patrolDestination;

    [SerializeField]
    EnemyState m_enemyState;

    float m_offset = 2.5f;
    float m_searchRadius = 8.0f;

    int m_health = 100;
    const float MAX_ATTACK_COOLDOWN = 1.0f;
    float m_attackCooldown = MAX_ATTACK_COOLDOWN;

    AudioSource m_audioSource;

    // Start is called before the first frame update
    void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
        m_navMeshAgent = GetComponent<NavMeshAgent>();

        m_patrolOrigin = transform.position;

        SetState(m_enemyState);

        m_audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(m_enemyState)
        {
            case (EnemyState.Idle):
                SearchForPlayer();
                break;

            case (EnemyState.Chase):
                Chase();
                break;

            case (EnemyState.Attack):
                Attack();
                break;
        }

        if(m_attackCooldown > 0.0f)
        {
            m_attackCooldown -= Time.deltaTime;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.25f);
        Gizmos.DrawSphere(transform.position, m_searchRadius);
    }

    void SetState(EnemyState enemyState)
    {
        m_enemyState = enemyState;

        switch (m_enemyState)
        {
            case (EnemyState.Idle):
                // Do nothing
                break;

            case (EnemyState.Chase):
                // Play Chase Sound Effect

                m_navMeshAgent.Resume();
                break;

            case (EnemyState.Attack):
                m_navMeshAgent.Stop();
                break;
        }
    }

    void Patrol()
    {
        if (Vector3.Distance(m_navMeshAgent.destination, transform.position) < m_offset)
        {
            // Swap Destination between Origin and Destination, remove Y coordinates
            Vector3 navMeshDestination = new Vector3(m_navMeshAgent.destination.x, 0, m_navMeshAgent.destination.z);
            Vector3 patrolOrigin = new Vector3(m_patrolOrigin.x, 0, m_patrolOrigin.z);
            Vector3 patrolDestination = new Vector3(m_patrolDestination.x, 0, m_patrolDestination.z);

            if (navMeshDestination == patrolDestination)
            {
                m_navMeshAgent.SetDestination(m_patrolOrigin);
            }
            else if (navMeshDestination == patrolOrigin)
            {
                m_navMeshAgent.SetDestination(m_patrolDestination);
            }
        }
    }

    void SearchForPlayer()
    {
        if(Vector3.Distance(transform.position, m_player.transform.position) < m_searchRadius)
        {
            SetState(EnemyState.Chase);
        }
    }

    void Chase()
    {
        m_navMeshAgent.SetDestination(m_player.transform.position);

        if (Vector3.Distance(m_navMeshAgent.destination, transform.position) < m_offset)
        {
            SetState(EnemyState.Attack);
        }
    }

    void Attack()
    {
        if (Vector3.Distance(m_player.transform.position, transform.position) < m_offset)
        {
            // Check if we can Attack
            if(m_attackCooldown < 0)
            {
                // Reset Attack Cooldown
                m_attackCooldown = MAX_ATTACK_COOLDOWN;
            }
        }
        else
        {
            // If we are too far away chase the player again
            SetState(EnemyState.Chase);
        }
    }

}
