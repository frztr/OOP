namespace Lab_1;
public interface IContext
{
    public void Dialog();
}

public interface IContextSpecified<T>: IContext{}