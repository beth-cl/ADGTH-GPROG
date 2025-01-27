using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCareTaker
{
    private Stack<ScoreMemento> history = new Stack<ScoreMemento>();

    public void SaveState(ScoreMemento memento)
    {
        history.Push(memento);
    }

    public ScoreMemento RestoreState()
    {
        return history.Count > 0 ? history.Pop() : null;
    }
}

