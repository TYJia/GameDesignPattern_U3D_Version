public abstract class Command {

    protected float _TheTime;
    public float TheTime
    {
        get { return _TheTime; }
    }
    public virtual void execute(Avatar avatar) { }
    public virtual void undo(Avatar avatar) { }
}
