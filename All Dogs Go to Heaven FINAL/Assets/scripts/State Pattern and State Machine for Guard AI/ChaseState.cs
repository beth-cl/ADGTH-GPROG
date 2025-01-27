using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : State
{
    private Transform player;

    public ChaseState(StateMachine controller, NavMeshAgent agent, Transform player) : base (controller, agent)
    {
        this.player = player;
    }

    public override void Execute()
    {
        agent.SetDestination(player.position);
    }
}
