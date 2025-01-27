using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR;

public class StateMachine : MonoBehaviour
{
    private NavMeshAgent agent;
    private State currentstate;

    [SerializeField] List<Transform> waypoints;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //initialise the guards starting state
        ChangeState(new PatrolState(this, agent, waypoints));

    }

    // Update is called once per frame
    void Update()
    {
        currentstate?.Execute();
    }

    public void ChangeState(State newstate)
    {
        currentstate = newstate;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !(currentstate is ChaseState))
        {
            ChangeState(new ChaseState(this, agent, other.transform));
        }
    }
}
