using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Outroscript : MonoBehaviour
{
    public TextMeshProUGUI outrotext;

    // Start is called before the first frame update
    void Start()
    {
        ScoreHolder target = FindObjectOfType<ScoreHolder>();
        StartCoroutine(TypewriterEffect.TypeText(ConverttoString(), outrotext, 0.05f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string ConverttoString()
    {
        string Tennis = Convert.ToString(ScoreHolder.GetScoreTennis());
        string ball = Convert.ToString(ScoreHolder.GetScoreBall());
        string bone = Convert.ToString(ScoreHolder.GetScoreBone());
        string bear = Convert.ToString(ScoreHolder.GetScoreBear());
        string total = Convert.ToString(ScoreHolder.GetScore());

        return ($"You collected {Tennis} Tennis Balls, {ball} Big Balls, {bone} Bones and {bear} Toy Bears. Thats {total} toys in total! Well done little pup!");

    }
}
