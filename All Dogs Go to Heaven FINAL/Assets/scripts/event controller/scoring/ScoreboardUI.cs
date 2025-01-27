using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreboardUI : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public int printedscore;
    string stringscore;

    // Start is called before the first frame update
    void Start()
    {
        ScoreHolder target = FindObjectOfType<ScoreHolder>(); //find the scoreholder instance in engine
    }

    // Update is called once per frame
    void Update()
    {
        textMeshPro.text = "Tennis Balls: " + UpdateUI(ScoreHolder.GetScoreTennis()) + 
            "\nBig Balls: " + UpdateUI(ScoreHolder.GetScoreBall()) + 
            "\nBones: " + UpdateUI(ScoreHolder.GetScoreBone()) + 
            "\nBears: " + UpdateUI(ScoreHolder.GetScoreBear()) + 
            "\nTotal : " + UpdateUI(ScoreHolder.GetScore());

    }

    public string UpdateUI(int type)
    {
        //printedscore = ScoreHolder.GetScore();
        stringscore = Convert.ToString(type);

        return stringscore;

    }
}
