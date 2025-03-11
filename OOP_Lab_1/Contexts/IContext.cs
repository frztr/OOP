namespace Lab_1;
public interface IContext
{
    public void ShowContext();
}

public interface IContextSpecified<T> : IContext { }