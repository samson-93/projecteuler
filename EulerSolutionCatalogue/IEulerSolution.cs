namespace ProjectEuler;

public interface IEulerSolution
{
    string Name { get; }
    string Description { get; }
    void Run();
}