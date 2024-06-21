using System.Reactive.Linq;

namespace ReactiveExtensions.Task4;

// Objective: Work with time-based operators.
//
//     Task: Create an observable that emits a value every second for 10 seconds.
//      Use Throttle to only emit values if no other values have been emitted for 2 seconds. Subscribe and print the results.
//     Key Concepts: Interval, Throttle
public class TimedObservable {
    public TimedObservable() {
        Observable.Interval(TimeSpan.FromSeconds(3))
            .Take(10)
            .Throttle(TimeSpan.FromSeconds(2))
            .Subscribe(Console.WriteLine);
    }
}