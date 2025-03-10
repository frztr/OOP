namespace Lab_1;
public interface IContext
{
    public Task ShowContext();
}

public interface IContextSpecified<T> : IContext { }