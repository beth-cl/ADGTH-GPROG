using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public float CountdownTime = 90f;
    public TextMeshProUGUI countdownText;

    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = CountdownTime;
        UpdateTimerUI();
    }

    // Update is called once per frame
    void Update()
    {
        Countdown();
    }

    void UpdateTimerUI()
    {
        countdownText.text = "Time: " + Mathf.Ceil(currentTime).ToString();
    }

    void Countdown()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerUI();
        }
        else
        {
            currentTime = 0;
            switchscenes.LoadSceneIndex(2);
        }
    }
}
