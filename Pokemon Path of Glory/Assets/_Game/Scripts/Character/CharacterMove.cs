using UnityEngine;
using UnityEngine.AI;

public class CharacterMove : MonoBehaviour
{
    NavMeshAgent agent;

    private void Awake() {
        agent = GetComponent<NavMeshAgent>();    
    }

    public void SetDestination(Vector3 dest){
        agent.SetDestination(dest);
    }
}
