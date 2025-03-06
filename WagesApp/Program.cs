namespace WagesApp;

class Program
{
    //Global Variables
    static List<string> DAYS = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday"};
    //Constant Variable
    static readonly float PAYRATE = 22.00f, TAXA = 0.075f, TAXB = 0.08f;
   
    //Methods or Functions
    static string FormatToDollar(float value)
    {
        return string.Format("{0:0.00}", value);
    }


    static string PaySummary(string name, List<int> hrsWorked)
    {
      return "----- Pay Summary -----\n" +
            $"Employee Name: {name}\n" +
            $"Hours Worked: {SumHoursWorked(hrsWorked)}\n" +
            $"Bonus Owed: ${FormatToDollar(CalculateBonus(hrsWorked))}\n" +
            $"Gross Pay: ${FormatToDollar(CalculateWages(hrsWorked) + CalculateBonus(hrsWorked))}\n" +
            $"Net Pay: ${FormatToDollar(CalculateWages(hrsWorked) + CalculateBonus(hrsWorked) - CalculateTax(hrsWorked))}\n" +
            $"Tax Owed: ${FormatToDollar(CalculateTax(hrsWorked))}";
    }
    //Calculate tax (pay <450 then 7.5% tax else tax =8%
    static float CalculateTax(List<int> hrsWorked)
            //Calculate weekly wages (total hours x pay rate)
    {



        if(CalculateWages(hrsWorked)+CalculateBonus(hrsWorked)< 450)
        {
            return (float)Math.Round((CalculateWages(hrsWorked) + CalculateBonus(hrsWorked)) * TAXA);
        }

        return (float)Math.Round((CalculateWages(hrsWorked) + CalculateBonus(hrsWorked)) * TAXB);


    }

    // Determine if employee qualifies for a bonus (>30 hours for the week)

    static float CalculateBonus(List<int> hrsWorked)
    {

        if (SumHoursWorked(hrsWorked) > 30)
        {
            return (float)Math.Round(5 * PAYRATE, 2);
        }

        return 0;

    }

    //Calculate weekly wages (total hours x pay rate)
    static float CalculateWages(List<int> hrsWorked)
    {
        return (float)Math.Round(SumHoursWorked(hrsWorked) * PAYRATE, 2);
     //Calculate total hours worked
    }
    static int SumHoursWorked(List<int> hrsWorked)
    {
        int SumHoursWorked = 0;

        foreach (int hour in hrsWorked)
        {
            SumHoursWorked += hour;
        }

        return SumHoursWorked;
    }

    static void OneEmployee()
    {
        //local variables
        string employeeName;
        List<int> hoursWorked = new List<int>();

        //Input employee name
        Console.WriteLine("Enter The Employee's Name:/n");
        employeeName = Console.ReadLine();

        //Input the number of hours worked for each day
        foreach (string day in DAYS)
        {
            Console.WriteLine($"Enter the hours worked on {day}:");
            hoursWorked.Add(int.Parse(Console.ReadLine()));
        }
        


        //Display employees pay summary
        Console.WriteLine(PaySummary(employeeName, hoursWorked));

        Console.ReadLine();
    }

    //When Run...

    static void Main(string[] args)
    {
        OneEmployee();

        //Display total amount paiyed to all employees

        //Display highest paiyed employee


    }
}

