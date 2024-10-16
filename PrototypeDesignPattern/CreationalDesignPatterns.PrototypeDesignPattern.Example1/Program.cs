
Person person1 = new("Ahmet", "Yazıcı", Department.A, 100, 10);

Person person2 = person1.Clone();
person2.Name = "Mehmet";
person2.Department = Department.B;

enum Department
{
    A, B, C
}

#region Abstract Prototype
interface IPersonCloneable
{
    Person Clone();
}
#endregion

#region Concrete Prototype
class Person : IPersonCloneable
{
    public Person(string name, string surname, Department department, int salary, int premium)
    {
        Name = name;
        Surname = surname;
        Department = department;
        Salary = salary;
        Premium = premium;
        Console.WriteLine($"{nameof(Person)} is created.");
    }

    public string Name { get; set; }
    public string Surname { get; set; }
    public Department Department { get; set; }
    public int Salary { get; set; }
    public int Premium { get; set; }

    public Person Clone()
    {
        return (Person)base.MemberwiseClone();
    }
}
#endregion