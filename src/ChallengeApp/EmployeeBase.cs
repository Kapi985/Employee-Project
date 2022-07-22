// See https://aka.ms/new-console-template for more information
public abstract class EmployeeBase : NamedObject, IEmployee
{
    public EmployeeBase(string name) : base(name)
    {
    }
    public abstract event GradeLowerThanThreeDelegate GradeLowerThanThree;
    public abstract event GradeAddedDelegate GradeAdded;

    public abstract void AddGrade(double grade);

    public abstract void AddGrade(string grade);

    public abstract Statistics GetStatistics();
}
