namespace Weather
{
    // Temperature follow the Singleton Pattern.

    public class Temperature
    {
        private static readonly object padlock = new object();
        private static Temperature? _instance;
        public int TemperatureValue { get; private set; }

        private Temperature(int temperatureValue) 
        { 
            this.TemperatureValue = temperatureValue;
        }

        public static Temperature GetInstance(int temperatureValue)
        {
            lock (padlock)
            {
                if (_instance == null)
                {
                    _instance = new Temperature(temperatureValue);
                }
                return _instance;
            }
        }

        public static void DestroyInstance()
        {
            _instance = null;
        }


        public TemperatureFeelingRange TemperatureFeelsLike()
        {
            return this.TemperatureValue switch
            {
                var t when t >= -100 && t <= -11 => TemperatureFeelingRange.ExtremelyCold,
                var t when t >= -10 && t <= -5 => TemperatureFeelingRange.VeryCold,
                var t when t >= -6 && t <= 5 => TemperatureFeelingRange.Cold,
                var t when t >= 6 && t <= 15 => TemperatureFeelingRange.Chilly,
                var t when t >= 16 && t <= 20 => TemperatureFeelingRange.Cool,
                var t when t >= 21 && t <= 24 => TemperatureFeelingRange.Mild,
                var t when t >= 25 && t <= 28 => TemperatureFeelingRange.Warm,
                var t when t >= 29 && t <= 32 => TemperatureFeelingRange.Balmy,
                var t when t >= 33 && t <= 39 => TemperatureFeelingRange.Hot,
                var t when t >= 40 && t <= 45 => TemperatureFeelingRange.Sweltering,
                var t when t >= 46 && t <= 49 => TemperatureFeelingRange.Scorching,
                var t when t >= 50 && t <= 100 => TemperatureFeelingRange.Hellish,
                _ => throw new ArgumentOutOfRangeException(
                        nameof(this.TemperatureValue),
                        "Temperature must be between -20 and 50."
                    )
            };
        }

        // We should refactor this, it can be a message display class that takes the enum and returns the message; but this is just for testing and example.
        public string TemperatureFeelsLikeMessage(TemperatureFeelingRange range)
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
                TemperatureFeelingRange.Scorching
                    => "it is SCORCHING, I am dying, the Devil is wearing shorts",
                TemperatureFeelingRange.Hellish
                    => "it is HELLISH, we are DEAD, the Devil is Sweating",
                _ => throw new NotImplementedException()
            };
        }
    }
}
