namespace Weather
{

public enum TemperatureFeelingRange
    {
        ExtremelyCold, // less or equal to -11
        VeryCold, // between -10 and -5 
        Cold, // between -6 and 5
        Chilly, // between 6 and 15
        Cool, // between 16 and 20
        Mild, // between 21 and 24
        Warm, // between 25 and 28
        Balmy, // between 29 and 32
        Hot, // between 33 and 39
        Sweltering, // between 40 and 45
        Scorching, // between 46 and 49
        Hellish // greater or equal to 50
    }

public sealed class Temperature
{
    private static Temperature _instance = new Temperature();
    private static readonly object padlock = new object();

    public int TemperatureValue { get; private set; }

    private Temperature()
    {
    }

    public static Temperature Instance
    {
        get
        {
            lock (padlock)
            {
                if (_instance == null)
                {
                    _instance = new Temperature();
                }
                return _instance;
            }
        }
    }

    public void SetTemperature(int temperature)
    {
        this.TemperatureValue = temperature;
    }

    public TemperatureFeelingRange GetTemperatureRange()
    {
        return this.TemperatureValue switch
        {
            var t when t<=-11 => TemperatureFeelingRange.ExtremelyCold,
            var t when t >= -10 && t <= -5 => TemperatureFeelingRange.VeryCold,
            var t when t >= -6 && t <=5 => TemperatureFeelingRange.Cold,
            var t when t >= 6 && t <= 15 => TemperatureFeelingRange.Chilly,
            var t when t >= 16 && t <= 20 => TemperatureFeelingRange.Cool,
            var t when t >= 21 && t <= 24 => TemperatureFeelingRange.Mild,
            var t when t >= 25 && t <= 28 => TemperatureFeelingRange.Warm,
            var t when t >= 29 && t <= 32 => TemperatureFeelingRange.Balmy,
            var t when t >= 33 && t <= 39 => TemperatureFeelingRange.Hot,
            var t when t >= 40 && t <= 45 => TemperatureFeelingRange.Sweltering,
            var t when t >= 46 && t <= 49 => TemperatureFeelingRange.Scorching,
            var t when t >= 50  => TemperatureFeelingRange.Hellish,
            _ => throw new ArgumentOutOfRangeException(nameof(this.TemperatureValue), "Temperature must be between -15 and 45.")
        };
    }

    public string GetTemperatureMessage(TemperatureFeelingRange range)
    {
        return range switch
        {
            TemperatureFeelingRange.ExtremelyCold => "Hell is Frozen",
            TemperatureFeelingRange.VeryCold => "it is VERY COLD",
            TemperatureFeelingRange.Cold => "it is COLD",
            TemperatureFeelingRange.Chilly => "it is CHILLY",
            TemperatureFeelingRange.Cool => "it is COOL",
            TemperatureFeelingRange.Mild => "it is MILD",
            TemperatureFeelingRange.Warm => "it is WARM",
            TemperatureFeelingRange.Balmy => "it is BALMY",
            TemperatureFeelingRange.Hot => "it is HOT",
            TemperatureFeelingRange.Sweltering => "it is SWELTERING, I feel like I am dying",
            TemperatureFeelingRange.Scorching => "it is SCORCHING, I am dying, the Devil is wearing shorts",
            TemperatureFeelingRange.Hellish => "it is HELLISH, we are DEAD, the Devil is Sweating",
            _ => throw new NotImplementedException()
        };
    }
    
}

}