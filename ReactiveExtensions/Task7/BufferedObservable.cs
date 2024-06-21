using System.Reactive.Linq;

namespace ReactiveExtensions.Task7;
// Objective: Use buffering and windowing to batch data.
//
//     Task: Create an observable that emits a value every 200ms.
//           Use Buffer to collect values in batches of 1 second and Window to create observable windows of 1 second. Subscribe and print the results.
//     Key Concepts: Buffer, Window
public class BufferedObservable {
    public BufferedObservable() {
        ObservableWithBuffer = Observable.Interval(TimeSpan.FromMilliseconds(200))
            .Buffer(TimeSpan.FromSeconds(1))
            .Select(buffer => string.Join(',', buffer));

        ObservableWithWindow = Observable.Interval(TimeSpan.FromMilliseconds(200))
            .Window(TimeSpan.FromSeconds(1));
    }
    
    public IObservable<string> ObservableWithBuffer { get; private init; }
    public IObservable<IObservable<long>> ObservableWithWindow { get; private init; }
}