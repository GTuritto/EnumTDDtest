using NUnit.Framework;

using Weather;

[TestFixture]
public class TemperatureTests
{

// Notice that I use the Enum values to confirm the result.
    [TestCase(-25, TemperatureFeelingRange.ExtremelyCold)]
    [TestCase(0, TemperatureFeelingRange.Cold)]
    [TestCase(10, TemperatureFeelingRange.Chilly)]
    [TestCase(18, TemperatureFeelingRange.Cool)]
    [TestCase(35, TemperatureFeelingRange.Hot)]
    [TestCase(50, TemperatureFeelingRange.Hellish)]
    public void TemperatureFeelsLike_ShouldReturnCorrectRange(int temperature, TemperatureFeelingRange expectedRange)
    {
        // Arrange
        var instance = Temperature.GetInstance(temperature);
  
        // Act
        var actualRange = instance.TemperatureFeelsLike();

        // Assert
        Assert.That(actualRange, Is.EqualTo(expectedRange));

        Temperature.DestroyInstance();
    }

// I am using the Enum  for testing functionality
    [TestCase(TemperatureFeelingRange.ExtremelyCold, "Hell is Frozen")]
    [TestCase(TemperatureFeelingRange.Cold, "it is COLD")]
    [TestCase(TemperatureFeelingRange.Chilly, "it is CHILLY")]
    [TestCase(TemperatureFeelingRange.Cool, "it is COOL")]
    [TestCase(TemperatureFeelingRange.Hot, "it is HOT")]
    [TestCase(TemperatureFeelingRange.Hellish, "it is HELLISH, we are DEAD, the Devil is Sweating")]
    public void TemperatureFeelsLikeMessage_ShouldReturnCorrectMessage(TemperatureFeelingRange range, string expectedMessage)
    {
        // Arrange
        // For this case it doesn't matter what is the temperature value in the Temperarure Instance, we will be pasing the Enum value to a method that will return a message based on the value passed.
        var instance = Temperature.GetInstance(0);

        // Act
        var actualMessage = instance.TemperatureFeelsLikeMessage(range);

        // Assert
        Assert.That(actualMessage, Is.EqualTo(expectedMessage));

        Temperature.DestroyInstance();
    }
 
    [TestCase(500)]
    public void TemperatureFeelsLike_ShouldThrowException(int temperature)
    {
        var instance = Temperature.GetInstance(temperature);

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            instance.TemperatureFeelsLike();
        },  "Temperature must be between -20 and 50.");

        Temperature.DestroyInstance();
    }
}