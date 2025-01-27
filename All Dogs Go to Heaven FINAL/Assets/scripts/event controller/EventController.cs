using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public static EventController current;
    public int maxSpawns = 10;
    public int currentSpawns = 0;

    // Static variable to track the next clone ID
    private static int nextCloneId = 1;

    // Start is called before the first frame update
    private void Awake()
    {
        if (current != null && current != this)
        {
            Destroy(this.gameObject);
            return;
        }
        current = this;
    }

    // Event to handle collision with the digsite (passing an ID)
    public event Action<string> OnCollisionWithDigsite;
    public void CollisionWithDigsite(string id)
    {
        OnCollisionWithDigsite?.Invoke(id);
    }

    // Static event to notify when an object is cloned (passing the clone's unique ID)
    public static event Action<int> OnObjectCloned;

    // Static method to trigger the ObjectCloned event with the unique clone ID
    public static void ObjectCloned(GameObject cloneObject)
    {
        // Assign the next unique ID and increment the counter
        int cloneId = nextCloneId;
        nextCloneId++;
        
        if (cloneObject != null)
        {
            cloneObject.name = "Clone_" + cloneId.ToString();
        }
        

        // Trigger the event with the unique ID
        OnObjectCloned?.Invoke(cloneId);
    }

    public static event Action OnCloneDestroyed;

    public static void CloneDestroyed()
    {
        OnCloneDestroyed?.Invoke();
    }

    public event Action<string> OnCollisionWithEnemy;

    public void CollisionWithEnemy(string enemyid)
    {
        OnCollisionWithEnemy?.Invoke(enemyid);
    }
}
