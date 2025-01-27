using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    //public variables, can be set in engine
    public Transform player;
    private Vector3 offset;
    public float smoothSpeed = 0.125f;
    // Start is called before the first frame update
    void Start()
    {
        if (offset == Vector3.zero) //manually sets an offset if one hasn't been set
        {
            offset = new Vector3(0f, 10f, -15f);
        }
        
    }

    // Update is called once per frame
    void LateUpdate() //after all other update functions are run, LateUpdate runs
    {
        smoothMove();
    }
    void smoothMove()
    {
        Vector3 desiredPosition = player.position + offset; // gets the xyz of player and adds the xyz of the offset
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); //interpolates btwn the desired position and the current position to make a smooth change between the two
        transform.position = smoothedPosition; // sets the camera xyz to the smoothedPosition

        transform.LookAt(player); // makes sure the camera looks at the player
    }
}

