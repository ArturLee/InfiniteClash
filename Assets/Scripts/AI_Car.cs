using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Car : MonoBehaviour
{

    public Transform target;
    public Transform[] waypoints;
    private int currentWaypoint;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = target.position;
    }

    public void GoToNextWaypoint()
    {
        agent.destination = waypoints[currentWaypoint].position;
        currentWaypoint++;
        if (currentWaypoint >= waypoints.Length)
            currentWaypoint = 0;
    }

    public void GoToTarget()
    {
        agent.destination = target.position;
    }

    public void StopAgent()
    {
        agent.isStopped = true;
        agent.ResetPath();
    }

    public bool IsAtDestionation()
    {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    return true;
                }
            }
        }
        return false;
    }
}