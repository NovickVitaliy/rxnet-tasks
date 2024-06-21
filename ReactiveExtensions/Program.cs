using ReactiveExtensions.Task10;
using ReactiveExtensions.Task5;
using ReactiveExtensions.Task6;
using ReactiveExtensions.Task7;
using ReactiveExtensions.Task8;
using ReactiveExtensions.Task9;


var weatherService = new WeatherService();

weatherService.WeatherStreamForCity("Mlyniv")
    .Subscribe(onNext: (window) => {
            Console.WriteLine("Window started.");

            window.Subscribe(val => {
                Console.WriteLine($"Average for the last window: {val:N} Celsius");
            });
        },
        onError: err => { Console.WriteLine($"Error: {err.Message}."); },
        onCompleted: () => { Console.WriteLine("Window completed."); });
        
        Console.ReadKey();