using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemycollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventController.current.OnCollisionWithEnemy += EndPlayOnEnemy;
    }

    void EndPlayOnEnemy(string enemyID)
    {
        //play sad dog sound here
        Debug.Log("Enemy collision detected with: " + enemyID);
        switchscenes.LoadSceneName("ClosingScene");
    }
}
