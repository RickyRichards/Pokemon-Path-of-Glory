using UnityEngine;
using UnityEngine.AI;

public class Animate : MonoBehaviour
{
    Animator anim;
    NavMeshAgent agent;
    private void Awake() {
        anim = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        float motion = agent.velocity.magnitude;
        anim.SetFloat("Motion", motion);
    }
}
