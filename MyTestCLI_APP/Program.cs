
using Weather;

class Program
{
    static void Main(string[] args)
    {
         Console.Write("Enter a temperature between -30 and 60: ");
         string input = Console.ReadLine() ?? string.Empty;
         
        // validate the input is not null an integer and is between the range -15 and 45
        if (int.TryParse(input, out int inputTemp) && inputTemp >= -30 && inputTemp <= 60) 
        {
            // Set the temperature value
            Temperature.Instance.SetTemperature(inputTemp);

            // Get the temperature value
            int temperature = Temperature.Instance.TemperatureValue;

            // Display the temperature value
            Console.WriteLine($"The temperature is {temperature} degrees.");

            Console.WriteLine($"And {Temperature.Instance.GetTemperatureMessage(Temperature.Instance.GetTemperatureRange())}");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number between -15 and 45.");
        }
    }
}
