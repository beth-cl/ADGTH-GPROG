using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;  // Assign in the Inspector

    // Get the current scores from ScoreHolder
    int totalScore = ScoreHolder.GetScore();
    int tennisScore = ScoreHolder.GetScoreTennis();
    int ballScore = ScoreHolder.GetScoreBall();
    int boneScore = ScoreHolder.GetScoreBone();
    int bearScore = ScoreHolder.GetScoreBear();

    private void Start()
    {
        CheckForHighScore();
        StartCoroutine(TypewriterEffect.TypeText(UpdateScoreText(), scoreText, 0.05f));
    }

    public void CheckForHighScore()
    {
        if (PlayerPrefs.HasKey("SavedHighScore"))
        {
            if (totalScore > PlayerPrefs.GetInt("SavedHighScore"))
            {
                PlayerPrefs.SetInt("SavedHighScore", totalScore);
                PlayerPrefs.SetInt("SavedHighTennisScore", tennisScore);
                PlayerPrefs.SetInt("SavedHighBallScore", ballScore);
                PlayerPrefs.SetInt("SavedHighBoneScore", boneScore);
                PlayerPrefs.SetInt("SavedHighBearScore", bearScore);
            }
        }

        else
        {
            PlayerPrefs.SetInt("SavedHighScore", totalScore);
            PlayerPrefs.SetInt("SavedHighTennisScore", tennisScore);
            PlayerPrefs.SetInt("SavedHighBallScore", ballScore);
            PlayerPrefs.SetInt("SavedHighBoneScore", boneScore);
            PlayerPrefs.SetInt("SavedHighBearScore", bearScore);
        }
    }

    public static string UpdateScoreText()
    {
        // Format the text to display all scores
        return "HIGH SCORE : \n" +
                         $"Total Score: {PlayerPrefs.GetInt("SavedHighScore")}, " +
                         $"Tennis Ball Score: {PlayerPrefs.GetInt("SavedHighTennisScore")}, " +
                         $"Big Ball Score: {PlayerPrefs.GetInt("SavedHighBallScore")}, " +
                         $"Bone Score: {PlayerPrefs.GetInt("SavedHighBoneScore")}, " +
                         $"Bear Score: {PlayerPrefs.GetInt("SavedHighBearScore")}";
    }
}
