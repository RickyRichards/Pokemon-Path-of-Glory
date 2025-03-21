using UnityEngine;
using UnityEngine.AI;

public class CharacterMove : MonoBehaviour
{
    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void SetDestination(Vector3 dest)
    {
        agent.SetDestination(dest);
    }

    private void Update()
    {
        // Stop agent if it reaches destination
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.isStopped = true;
        }
        else
        {
            agent.isStopped = false;
        }
    }

    public void SetSpeed(float speed) // Optional: Speed Control
    {
        agent.speed = speed;
    }
}
