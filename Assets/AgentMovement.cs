using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class AgentMovement : MonoBehaviour
{
    private Vector3 target;
    NavMeshAgent agent;
    public GameObject player;
    // Start is called before the first frame update
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        player = GameObject.Find("Player");

    }

    private void Update()
    {
        SetTargetPosition();
    }

    private void SetTargetPosition()
    {
        /*Vector2 tpos;
        tpos.x = player.GetComponent<Rigidbody2D>().position.x;
        tpos.y = player.GetComponent<Rigidbody2D>().position.y;*/
        if (player.transform.position.x > 0.32f)
        {
            agent.SetDestination(player.transform.position);
        }
    }
}
