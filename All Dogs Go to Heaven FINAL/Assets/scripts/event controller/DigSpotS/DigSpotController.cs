using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

public class DigSpotController : MonoBehaviour
{
    public string id;
    //public TextMeshProUGUI pressEUI;

    // Start is called before the first frame update
    void Start()
    {
        //pressEUI.gameObject.SetActive(false);
        EventController.OnObjectCloned += AssignUniqueid;

        EventController.current.OnCollisionWithDigsite += OnCollisionWithPlayer;
    }

    private void AssignUniqueid(int cloneId)
    {
        id = "Clone_" + cloneId;
    }

    private void OnCollisionWithPlayer(string digsiteid)
    {
        //pressEUI.gameObject.SetActive(true);
        GameObject targetObject = GameObject.Find(digsiteid);

        Destroy(targetObject);
        Debug.Log("Collided " + digsiteid + " " + id);


    }

    private void OnDestroy()
    {
        EventController.CloneDestroyed();

        EventController.OnObjectCloned -= AssignUniqueid;
        if (EventController.current != null)
        {
            EventController.current.OnCollisionWithDigsite -= OnCollisionWithPlayer;
        }
    }


}
