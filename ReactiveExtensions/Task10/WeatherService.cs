using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace ReactiveExtensions.Task10;

// Objective: Apply reactive programming to a real-time data scenario.
//
//     Task: Create a class WeatherService that fetches temperature data every second (simulated with random values).
//      Use Rx.NET to process this data stream, filter out invalid readings (e.g., below -50°C or above 50°C),
//      and calculate a moving average over a 10-second window. Subscribe and print the results.
//     Key Concepts: Subject, Where, Buffer, Select, Subscribe
public class WeatherService {
    public IObservable<IObservable<double>> WeatherStreamForCity(string city) {
        return Observable.Create<WeatherInfo>(observer => {
                var timer = Observable.Interval(TimeSpan.FromSeconds(1))
                    .Subscribe(_ => {
                        observer.OnNext(new WeatherInfo() {
                            City = city,
                            Temperature = Random.Shared.Next(-100, 100)
                        });
                    }, observer.OnError);
                return Disposable.Create(() => { timer.Dispose(); });
            })
            .Do(x => Console.WriteLine($"Processing the {x}"))
            .Where(x => x.Temperature is >= -50 and <= 50)
            .Window(TimeSpan.FromSeconds(10))
            .Select(x => x.Average(y => y.Temperature));
    }
}