namespace Challenge.Tests;

public class EmployeeTests
{
    [Fact]
    public void Test1()
    {
        //arrange
        var emp = new MemoryEmployee("Kacper");
        emp.AddGrade(4);
        emp.AddGrade("5+");
        emp.AddGrade("6-");

        //act
        var result = emp.GetStatistics();

        //assert
        Assert.Equal(4, result.Low);
        Assert.Equal(5.75, result.High);
        Assert.Equal(5.08, result.Average, 1);
    }
}