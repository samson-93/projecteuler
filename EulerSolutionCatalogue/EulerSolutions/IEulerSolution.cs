namespace ProjectEuler.EulerSolutions;

public interface IEulerSolution
{
    string Name { get; }
    string Description { get; }
    void Run();
}