// See https://aka.ms/new-console-template for more information
public class NamedObject
{
    public string Name{get; set;} = "new name";
    public NamedObject(string name)
    {
        if(name != null)
        {
            bool isValid = true;
        foreach(char c in name)
        {
            if(char.IsDigit(c))
            {
                isValid = false;
            }
        }
        if(isValid)
        {
            this.Name = name;
        }
        else
        {
            throw new FormatException($"Wrong format of {name}");
        }
        }
    }
    public string Sex{get; set;} = "male";
}
