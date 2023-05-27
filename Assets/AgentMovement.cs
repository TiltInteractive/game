using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMovement : MonoBehaviour
{
    private Vector3 target;
    NavMeshAgent agent;
    /*    public GameObject player;*/
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("asd");

        agent = GetComponent<NavMeshAgent>();
        agent.updatePosition = false;
        agent.updateRotation = false;
        agent.Warp(new Vector3(0, 0 ,transform.position.z));
    }

    private void Update()
    {
        SetTargetPosition();
    }

    private void SetTargetPosition()
    {
/*        target.x = player.GetComponent<Rigidbody2D>().position.x;
        target.y = player.GetComponent<Rigidbody2D>().position.y;*/
        agent.SetDestination(new Vector3(10, 10, transform.position.z));
    }
}
