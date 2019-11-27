
using UnityEngine;
using UnityEngine.AI;
public class AIMovement : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {

        navMeshAgent.SetDestination(target.position);
        navMeshAgent.stoppingDistance = 25f;


    }
}