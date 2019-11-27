
using UnityEngine;
using UnityEngine.AI;
public class AIMovement : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent navMeshAgent;
    public float maxDistance = 15f;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        navMeshAgent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {

        navMeshAgent.SetDestination(target.position);
        navMeshAgent.stoppingDistance = 25f;
        transform.LookAt(player.transform);
        transform.position += transform.forward * 5 * Time.deltaTime;


    }
}