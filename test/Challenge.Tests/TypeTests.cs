namespace Challenge.Tests;

public class TypeTests
{
    public delegate string WriteMessage(string message);
    int counter = 0;
    
    [Fact]
    public void WriteMessageDelegateCanPointToMethod()
    {
        WriteMessage del = ReturnMessage;
        del += ReturnMessage;
        del += ReturnMessage2;

        var result = del("HELLO!");

        Assert.Equal(3, counter);
    }
    string ReturnMessage(string message)
    {
        counter ++;
        return message;
    }
    string ReturnMessage2(string message)
    {
        counter ++;
        return message.ToLower();
    }
    
    [Fact]
    public void GetEmployeeReturnsDifferentObjects()
    {
        //arrange
        var emp1 = GetEmployee("Adam");
        var emp2 = GetEmployee("Kacper");
        
        //act

        //assert
        Assert.NotSame(emp2, emp1);
        Assert.False(Object.ReferenceEquals(emp1, emp2));
        //Assert.Equal("Adam", emp1.Name);
        //Assert.Equal("Kacper", emp2.Name);
    }
    [Fact]
    public void TwoVarsCanReferenceSameObject()
    {
        var emp1 = GetEmployee("Adam");
        var emp2 = emp1;

        Assert.Equal(emp2, emp1);
        Assert.True(Object.ReferenceEquals(emp1, emp2));
    }
    [Fact]
    public void CanSetNameFromReference()
    {
        var emp1 = GetEmployee("Adam");
        this.SetName(out emp1, "New Name");

        Assert.Equal("New Name", emp1.Name);
    }
    private SavedEmployee GetEmployee(string name)
    {
        return new SavedEmployee(name);
    }

    private void SetName(out SavedEmployee employee, string name)
    {
        employee = new SavedEmployee("NEW");
        employee.Name = name;
    }

    [Fact]
    public void Test2()
    {
        var x = GetInt();
        SetInt(ref x);

        Assert.Equal(x, 5);
    }
    private void SetInt(ref int x)
        {
            x = 5;
        }
    private int GetInt()
        {
            return 3;
        }
}