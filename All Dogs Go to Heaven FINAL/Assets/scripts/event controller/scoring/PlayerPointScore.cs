using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPointScore : MonoBehaviour
{
    

    string[][] options = ID_strings.digSpotOptions;
    private string[] DigSpotValues;

    void Start()
    {
        ScoreHolder target = FindObjectOfType<ScoreHolder>(); //find the scoreholder instance in engine
        Material material = findMaterial();
        if (material != null)
        {
            WhatOption(material);
        }
        else
        {
            Debug.LogWarning($"No material found for {gameObject.name}");
        }

        //EventController.OnCloneDestroyed += UpdateScore;
        EventController.current.OnCollisionWithDigsite += UpdateScore;
    }

    void OnDestroy() // unsubscribe to anything
    {
        //EventController.OnCloneDestroyed -= UpdateScore;
        EventController.current.OnCollisionWithDigsite -= UpdateScore;
    }

    private Material findMaterial() //find the digspots material
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            return renderer.material;
        }
        else
        {
            Debug.LogWarning($"Cannot find a renderer on {gameObject.name}");
            return null;
        }
    }

    private void WhatOption(Material mat_type) // compares the material name to its ID string counterpart
    {
        for (int i = 0; i < options.Length; i++)
        {
            // Clean the "(Instance)" suffix if present
            string cleanedMaterialName = mat_type.name.Replace(" (Instance)", "");

            if (cleanedMaterialName == options[i][0])
            {
                DigSpotValues = options[i];
                Debug.Log($"Matched material: {cleanedMaterialName}, Values: {string.Join(", ", DigSpotValues)}");
                return;
            }
        }
        Debug.LogWarning($"Material {mat_type.name} not found in options.");
        DigSpotValues = null;
    }

    public void UpdateScore(string id) // gets the point value from the ID string of the digspot and adds it to the score variable in the score holder
    {
        GameObject targetObject = GameObject.Find(id);

        if (DigSpotValues != null && targetObject.name == gameObject.name && targetObject.activeSelf)
        {
            int pointgained = int.Parse(DigSpotValues[2]);
            
            switch(pointgained)
            {
                case 0:
                    ScoreHolder.SetScoreTennis();
                    ScoreHolder.SetScore();
                    break;

                case 1:
                    ScoreHolder.SetScoreBall();
                    ScoreHolder.SetScore();
                    break;

                case 2:
                    ScoreHolder.SetScoreBone();
                    ScoreHolder.SetScore();
                    break;

                case 3:
                    ScoreHolder.SetScoreBear();
                    ScoreHolder.SetScore();
                    break;

                default:
                    Debug.LogError("collision was not correct");
                    break;
            }

            Debug.Log(pointgained + " " + targetObject.name);
            Debug.Log($"Updated Score: {ScoreHolder.GetScore()}");
        }
        else
        {
            Debug.LogWarning("Cannot update score: DigSpotValues is null.");
        }
    }
}
