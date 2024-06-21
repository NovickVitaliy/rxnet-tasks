namespace ReactiveExtensions.Task10;

public class WeatherInfo {
    public string City { get; set; }
    public int Temperature { get; set; }

    public override string ToString() {
        return $"{nameof(City)}: {City}, {nameof(Temperature)}: {Temperature} Celsius";
    }
}