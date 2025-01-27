using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigSpotTrigger : MonoBehaviour
{
    public string id;

    private void Start()
    {
        id = gameObject.name;
    }
    private void OnCollisionEnter(Collision collision)
    {
        EventController.current.CollisionWithDigsite(id);
    }
}
