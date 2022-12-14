// See https://aka.ms/new-console-template for more information
public delegate void GradeAddedDelegate(object sender, EventArgs args);
public delegate void GradeLowerThanThreeDelegate(object sender, EventArgs args);


public class SavedEmployee : EmployeeBase
{
    public SavedEmployee(string name) : base(name)
    {
    }

    public override event GradeAddedDelegate? GradeAdded;
    public override event GradeLowerThanThreeDelegate? GradeLowerThanThree;

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
    public override void AddGrade(double grade)
    {
        
        using(var writer = File.AppendText($"{Name}.txt"))
        using(var writer2 = File.AppendText($"audit.txt"))
        {
             if(grade > 0 && grade <= 6)
            {
                writer.WriteLine(grade);
                if(GradeAdded != null)
                    {
                GradeAdded(this, new EventArgs());
                    }
                if(grade <= 3 && GradeLowerThanThree != null)
                    {
                GradeLowerThanThree(this, new EventArgs());
                    }
                writer2.WriteLine($"Grade received: {grade}    Date added: {DateTime.UtcNow}");
            }
            else
            {
                throw new ArgumentException($"Invalid exception: {nameof(grade)}");
            }
        }
    }
    public override Statistics GetStatistics()
    {
        var result = new Statistics();

        using (var reader = File.OpenText($"{Name}.txt"))
        {
            var line = reader.ReadLine();
            while(line != null)
            {
                var number = double.Parse(line);
                result.Add(number);
                line = reader.ReadLine();
            }
        }

        return result;
    }
}
