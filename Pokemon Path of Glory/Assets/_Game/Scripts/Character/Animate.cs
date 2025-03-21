using UnityEngine;
using UnityEngine.AI;

public class Animate : MonoBehaviour
{
    Animator anim;
    NavMeshAgent agent;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>(); // Ensures the Animator is found
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        float speed = agent.velocity.magnitude; // Get movement speed

        anim.SetFloat("Motion", speed); // Controls Walk & Run

        // Optional: Set isMoving Bool
        anim.SetBool("isMoving", speed > 0.1f);
    }
}
