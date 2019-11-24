using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public GameObject player;
    public Animator animate;
    private Vector3 startPoint;
    public Transform originalPoint;

    // Start is called before the first frame update
    void Start()
    {
        animate = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");

        startPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.LookAt(player.transform);
        transform.Translate(0, 0, 3 * Time.deltaTime);
        animate.SetBool("isWalking", true);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        transform.position = startPoint;
    }

}
