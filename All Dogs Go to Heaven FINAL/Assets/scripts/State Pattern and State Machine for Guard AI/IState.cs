
using Unity.VisualScripting;
using UnityEngine.AI;

public interface IState
{
    void Execute();
}

public abstract class State: IState
{
    protected StateMachine controller;
    protected NavMeshAgent agent;

    public State(StateMachine controller, NavMeshAgent agent)
    {
        this.controller = controller;
        this.agent = agent;
    }

    public abstract void Execute();
}