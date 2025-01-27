
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : State
{
    private List<Transform> waypoints;
    private int currentWaypoint = 0;

    public PatrolState(StateMachine controller, NavMeshAgent agent, List<Transform> waypoints) : base(controller, agent)
    {
        this.waypoints = waypoints;
    }

    public override void Execute()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            agent.SetDestination(waypoints[currentWaypoint].position);
            currentWaypoint = (currentWaypoint + 1) % waypoints.Count;
        }
    }
}
