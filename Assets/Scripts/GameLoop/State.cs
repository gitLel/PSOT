public abstract class State 
{
    protected readonly FiniteStateMachine finiteStateMachine;

    public State(FiniteStateMachine finiteStateMachine)
    {
        this.finiteStateMachine = finiteStateMachine;
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void Update() { }
}
