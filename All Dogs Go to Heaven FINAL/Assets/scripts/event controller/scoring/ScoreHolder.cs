using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHolder : MonoBehaviour
{

    private static ScoreHolder instance;

    //Scoreboard IDs

    private static int Score;

    private static int ScoreTennis;
    private static int ScoreBall;
    private static int ScoreBone;
    private static int ScoreBear;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    public static int GetScore()
    {
        return Score;
    }

    public static void SetScore()
    {
        Score ++;
    }
    public static int GetScoreTennis()
    {
        return ScoreTennis;
    }

    public static void SetScoreTennis()
    {
        ScoreTennis ++;
    }
    public static int GetScoreBall()
    {
        return ScoreBall;
    }

    public static void SetScoreBall()
    {
        ScoreBall ++;
    }
    public static int GetScoreBone()
    {
        return ScoreBone;
    }

    public static void SetScoreBone()
    {
        ScoreBone ++;
    }
    public static int GetScoreBear()
    {
        return ScoreBear;
    }

    public static void SetScoreBear()
    {
        ScoreBear ++;
    }

}

/*using UnityEngine;

public class ScoreHolder : MonoBehaviour
{
    private static ScoreHolder instance;
    

    private static int Score;
    private static int ScoreTennis;
    private static int ScoreBall;
    private static int ScoreBone;
    private static int ScoreBear;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Originator methods to create and restore memento
    public ScoreMemento SaveScore(ScoreHolder memento)
    {

        return new ScoreMemento(Score, ScoreTennis, ScoreBall, ScoreBone, ScoreBear);
    }

    public void RestoreScore(ScoreMemento memento)
    {
        if (memento != null)
        {
            Score = memento.Score;
            ScoreTennis = memento.ScoreTennis;
            ScoreBall = memento.ScoreBall;
            ScoreBone = memento.ScoreBone;
            ScoreBear = memento.ScoreBear;
        }
    }

    // Standard getters and setters
    public static int GetScore() => Score;
    public static void SetScore() => Score++;

    public static int GetScoreTennis() => ScoreTennis;
    public static void SetScoreTennis() => ScoreTennis++;

    public static int GetScoreBall() => ScoreBall;
    public static void SetScoreBall() => ScoreBall++;

    public static int GetScoreBone() => ScoreBone;
    public static void SetScoreBone() => ScoreBone++;

    public static int GetScoreBear() => ScoreBear;
    public static void SetScoreBear() => ScoreBear++;
}
*/

