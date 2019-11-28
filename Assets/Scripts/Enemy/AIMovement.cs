
using UnityEngine;
using UnityEngine.AI;
public class AIMovement : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent navMeshAgent;
    //public GameObject enemy;
    //public GameObject player;
    private Vector3 startPoint;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent> ();
        //enemy = GameObject.FindWithTag("AI");
        //player = GameObject.FindWithTag("Player");
        startPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        navMeshAgent.SetDestination(target.position);
        //transform.LookAt(player.transform);
        transform.Translate(0, 0, 8 * Time.deltaTime);
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            
            Destroy(gameObject);
            collision.gameObject.GetComponent<TriggerSpawn>().permanentSleep = true;
        }
    }

}
