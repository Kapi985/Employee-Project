// See https://aka.ms/new-console-template for more information
public interface IEmployee
{
    void AddGrade(double grade);
    void AddGrade(string grade);
    string Name {get;}

    Statistics GetStatistics();

    event GradeAddedDelegate GradeAdded;

    event GradeLowerThanThreeDelegate GradeLowerThanThree;
}
