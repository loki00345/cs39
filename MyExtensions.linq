<Query Kind="Program" />

public class Firma
{
    public string Name { get; set; }
    public DateTime Founded { get; set; }
    public string BusinessProfile { get; set; }
    public string Director { get; set; }
    public int EmployeeCount { get; set; }
    public string Address { get; set; }
    public List<Employee> Employees { get; set; } = new List<Employee>();
}

public class Employee
{
    public string FullName { get; set; }
    public string Position { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public decimal Salary { get; set; }
}

// Головний метод Main() має бути ОКРЕМО від класів!
public static class Program
{
    public static void Main()
    {
        var firms = new List<Firma>
        {
            new Firma { Name = "Tech Solutions", Founded = DateTime.Now.AddYears(-5), BusinessProfile = "IT", Director = "John White", EmployeeCount = 250, Address = "London" },
            new Firma { Name = "Marketing Hub", Founded = DateTime.Now.AddYears(-3), BusinessProfile = "Marketing", Director = "Alice Green", EmployeeCount = 120, Address = "New York" },
            new Firma { Name = "Food Express", Founded = DateTime.Now.AddYears(-1), BusinessProfile = "Food Industry", Director = "Michael Black", EmployeeCount = 90, Address = "London" },
            new Firma { Name = "White Consulting", Founded = DateTime.Now.AddYears(-10), BusinessProfile = "IT", Director = "Robert Black", EmployeeCount = 400, Address = "Berlin" }
        };

        // Завдання 1 - Запити LINQ
        var allFirms = from f in firms select f;
        var foodFirms = from f in firms where f.Name.Contains("Food") select f;
        var marketingFirms = from f in firms where f.BusinessProfile == "Marketing" select f;
        var marketingOrITFirms = from f in firms where f.BusinessProfile == "Marketing" || f.BusinessProfile == "IT" select f;
        var largeFirms = from f in firms where f.EmployeeCount > 100 select f;
        var midSizeFirms = from f in firms where f.EmployeeCount >= 100 && f.EmployeeCount <= 300 select f;
        var londonFirms = from f in firms where f.Address == "London" select f;
        var directorWhite = from f in firms where f.Director.Contains("White") select f;
        var oldFirms = from f in firms where (DateTime.Now - f.Founded).TotalDays > 365 * 2 select f;
        var founded123DaysAgo = from f in firms where (DateTime.Now - f.Founded).TotalDays == 123 select f;
        var blackDirectorWhiteName = from f in firms where f.Director.Contains("Black") && f.Name.Contains("White") select f;

        // Завдання 2 - Запити методом розширення
        var allFirmsMethod = firms.Select(f => f);
        var foodFirmsMethod = firms.Where(f => f.Name.Contains("Food"));
        var marketingFirmsMethod = firms.Where(f => f.BusinessProfile == "Marketing");
        var marketingOrITFirmsMethod = firms.Where(f => f.BusinessProfile == "Marketing" || f.BusinessProfile == "IT");
        var largeFirmsMethod = firms.Where(f => f.EmployeeCount > 100);
        var midSizeFirmsMethod = firms.Where(f => f.EmployeeCount >= 100 && f.EmployeeCount <= 300);
        var londonFirmsMethod = firms.Where(f => f.Address == "London");
        var directorWhiteMethod = firms.Where(f => f.Director.Contains("White"));
        var oldFirmsMethod = firms.Where(f => (DateTime.Now - f.Founded).TotalDays > 365 * 2);
        var founded123DaysAgoMethod = firms.Where(f => (DateTime.Now - f.Founded).TotalDays == 123);
        var blackDirectorWhiteNameMethod = firms.Where(f => f.Director.Contains("Black") && f.Name.Contains("White"));

        // Завдання 3 - Запити по співробітниках
        firms[0].Employees.Add(new Employee { FullName = "Lionel Messi", Position = "Developer", Phone = "234567890", Email = "lmessi@tech.com", Salary = 5000 });
        firms[1].Employees.Add(new Employee { FullName = "Diana Prince", Position = "Manager", Phone = "231234567", Email = "dprince@marketing.com", Salary = 6000 });

        var employeesOfFirm = firms.FirstOrDefault(f => f.Name == "Tech Solutions")?.Employees;
        var employeesWithHighSalary = firms.SelectMany(f => f.Employees).Where(e => e.Salary > 5500);
        var managers = firms.SelectMany(f => f.Employees).Where(e => e.Position == "Manager");
        var phoneStartsWith23 = firms.SelectMany(f => f.Employees).Where(e => e.Phone.StartsWith("23"));
        var emailStartsWithDi = firms.SelectMany(f => f.Employees).Where(e => e.Email.StartsWith("di"));
        var namedLionel = firms.SelectMany(f => f.Employees).Where(e => e.FullName.StartsWith("Lionel"));

        // Виведення результатів (LINQPad метод)
        foodFirms.Dump("Фірми з 'Food' у назві");
        marketingFirms.Dump("Фірми у сфері маркетингу");
        largeFirms.Dump("Фірми з понад 100 працівниками");
    }
}


#region Advanced - How to multi-target

// The NETx symbol is active when a query runs under .NET x or later.
// (LINQPad also recognizes NETx_0_OR_GREATER in case you enjoy typing.)

#if NET8
// Code that requires .NET 8 or later
#endif

#if NET7
// Code that requires .NET 7 or later
#endif

#if NET6
// Code that requires .NET 6 or later
#endif

#if NETCORE
// Code that requires .NET Core or later
#else
// Code that runs under .NET Framework (LINQPad 5)
#endif

#endregion