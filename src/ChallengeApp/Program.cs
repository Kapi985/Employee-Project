// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, please enter employee name");

string? InputName = Console.ReadLine() + ".emp";

var employee = new SavedEmployee(InputName);

employee.GradeAdded += OnGradeAdded;

employee.GradeLowerThanThree += LowGrade;

//var imie = employee.napis;
//var listy = employee.grades;

EnterGrade(employee);

static void OnGradeAdded(object sender, EventArgs args)
        {
            Console.WriteLine("New Value Added");
        }

static void LowGrade(object sender, EventArgs args)
{
    Console.WriteLine("Oh no we must inform the parents!");
}

static void EnterGrade(IEmployee employee)
{
while(true)
{
    Console.WriteLine($"Please enter grade for {employee.Name}");
    var input = Console.ReadLine();

    if(input == "q")
    {
        break;
    }

    try
    {
        if(input != null)
        {
            int grade;
            var isNumber = int.TryParse(input, out grade);
            if(isNumber)
            {
                employee.AddGrade(grade);
            }
            else
            {
                employee.AddGrade(input);
            }
        }
    }
    catch(FormatException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch(ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        
    }
}
    var stats = employee.GetStatistics();
    Console.WriteLine($"Employee's high grade is {stats.High}");
    Console.WriteLine($"Employee's low grade is {stats.Low}");
    Console.WriteLine($"Employee's average grade is {stats.Average :N3}");
    Console.WriteLine($"Employee's letter is {stats.Letter}");
}



