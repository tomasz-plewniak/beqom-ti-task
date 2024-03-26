namespace ApplicationCore.Interfaces;

public interface IEnvironment
{
    object Get(string name);

    void Set(string name, object value);
}