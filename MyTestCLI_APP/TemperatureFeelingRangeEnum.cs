namespace Weather
{
    // This Enum will be avaialable to any code or Project that has a reference to this project and uses this Namespace.

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
}
