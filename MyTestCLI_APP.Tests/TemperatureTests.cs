using NUnit.Framework;

using Weather;

[TestFixture]
public class TemperatureTests
{
    [Test]
    public void SetTemperature_ShouldSetTemperatureValue()
    {
        // Arrange
        var temperature = Temperature.Instance;

        // Act
        temperature.SetTemperature(25);

        // Assert
        Assert.That(temperature.TemperatureValue, Is.EqualTo(25));
    }

    [TestCase(-25, TemperatureFeelingRange.ExtremelyCold)]
    [TestCase(0, TemperatureFeelingRange.Cold)]
    [TestCase(10, TemperatureFeelingRange.Chilly)]
    [TestCase(18, TemperatureFeelingRange.Cool)]
    [TestCase(35, TemperatureFeelingRange.Hot)]
    [TestCase(50, TemperatureFeelingRange.Hellish)]
    public void GetTemperatureRange_ShouldReturnCorrectRange(int temperature, TemperatureFeelingRange expectedRange)
    {
        // Arrange
        var instance = Temperature.Instance;
        instance.SetTemperature(temperature);

        // Act
        var actualRange = instance.GetTemperatureRange();

        // Assert
        Assert.That(actualRange, Is.EqualTo(expectedRange));
    }

    [TestCase(TemperatureFeelingRange.ExtremelyCold, "Hell is Frozen")]
    [TestCase(TemperatureFeelingRange.Cold, "it is COLD")]
    [TestCase(TemperatureFeelingRange.Chilly, "it is CHILLY")]
    [TestCase(TemperatureFeelingRange.Cool, "it is COOL")]
    [TestCase(TemperatureFeelingRange.Hot, "it is HOT")]
    [TestCase(TemperatureFeelingRange.Hellish, "it is HELLISH, we are DEAD, the Devil is Sweating")]
    public void GetTemperatureMessage_ShouldReturnCorrectMessage(TemperatureFeelingRange range, string expectedMessage)
    {
        // Arrange
        var instance = Temperature.Instance;

        // Act
        var actualMessage = instance.GetTemperatureMessage(range);

        // Assert
        Assert.That(actualMessage, Is.EqualTo(expectedMessage));
    }
}