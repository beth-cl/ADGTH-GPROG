using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardPup : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;

    public float MoveTime = 10.0f;
    public float StopTime = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (agent == null)
        {
            Debug.LogError("NavMeshAgent component is missing on " + gameObject.name);
            return;
        }

        if (player == null)
        {
            Debug.LogError("Player reference is not assigned in " + gameObject.name);
            return;
        }

        StartCoroutine(FollowPauseCycle());
    }

    // Update is called once per frame
    void Update()
    {
        //agent.destination = player.position;
    }

    private IEnumerator FollowPauseCycle()
    {
        while (true)
        {
            // Follow the player for 'followDuration' seconds
            agent.isStopped = false;  // Ensure agent is moving
            float followTime = 0f;
            while (followTime < MoveTime)
            {
                agent.SetDestination(player.position);
                followTime += Time.deltaTime;
                yield return null;  // Wait for the next frame
            }

            // Pause for 'pauseDuration' seconds
            agent.isStopped = true;  // Stop movement
            yield return new WaitForSeconds(StopTime);

            // Resume the cycle
        }
    }
}
