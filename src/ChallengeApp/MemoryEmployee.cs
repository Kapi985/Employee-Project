// See https://aka.ms/new-console-template for more information
public class MemoryEmployee : EmployeeBase
{
    public List<double> grades;
    public MemoryEmployee(string name) : base(name)
    {
        grades = new List<double>();
    }

    public override event GradeLowerThanThreeDelegate? GradeLowerThanThree;
    public override event GradeAddedDelegate? GradeAdded;

    public override void AddGrade(double grade)
    {
        if(grade >= 0 && grade <= 100)
        {
            grades.Add(grade);
            if(GradeAdded != null)
            {
                GradeAdded(this, new EventArgs());
            }
        }
        else
            {
                throw new ArgumentException($"Invalid exception: {nameof(grade)}");
            }
    }
    public override void AddGrade(string grade)
    {
        switch(grade)
        {
            case "1-":
            this.AddGrade(.75);
            break;
            case "1+":
            this.AddGrade(1.5);
            break;
            case "2-":
            this.AddGrade(1.75);
            break;
            case "2+":
            this.AddGrade(2.5);
            break;
            case "3-":
            this.AddGrade(2.75);
            break;
            case "3+":
            this.AddGrade(3.5);
            break;
            case "4-":
            this.AddGrade(3.75);
            break;
            case "4+":
            this.AddGrade(4.5);
            break;
            case "5-":
            this.AddGrade(4.75);
            break;
            case "5+":
            this.AddGrade(5.5);
            break;
            case "6-":
            this.AddGrade(5.75);
            break;
            default :
            throw new ArgumentOutOfRangeException($"Invalid value of {nameof(grade)}");
        }
    }

    public override Statistics GetStatistics()
    {
        var result = new Statistics();

        for(var index = 0; index < grades.Count; index ++)
        {
            result.Add(grades[index]);
        }

        return result;
    }
}