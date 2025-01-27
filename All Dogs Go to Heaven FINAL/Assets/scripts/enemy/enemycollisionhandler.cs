using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemycollisionhandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))  // Ensure the enemy GameObject has the "Enemy" tag
        {
            string enemyId = other.gameObject.name;
            EventController.current.CollisionWithEnemy(enemyId);
            Debug.Log("Collided with enemy: " + enemyId);
        }
    }
}
