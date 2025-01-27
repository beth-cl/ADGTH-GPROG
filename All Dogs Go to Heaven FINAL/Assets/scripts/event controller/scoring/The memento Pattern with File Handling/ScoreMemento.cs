public class ScoreMemento
{
    public int Score { get; private set; }
    public int ScoreTennis { get; private set; }
    public int ScoreBall { get; private set; }
    public int ScoreBone { get; private set; }
    public int ScoreBear { get; private set; }

    public ScoreMemento(int score, int scoreTennis, int scoreBall, int scoreBone, int scoreBear)
    {
        Score = score;
        ScoreTennis = scoreTennis;
        ScoreBall = scoreBall;
        ScoreBone = scoreBone;
        ScoreBear = scoreBear;
    }
}
