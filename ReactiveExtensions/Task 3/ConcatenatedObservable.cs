using System.Reactive.Linq;

namespace ReactiveExtensions.Task_3;
// Objective: Combine multiple observables.
//
//     Task: Create two observables that emit integers from 1 to 5 and 6 to 10, respectively.
//      Use Concat to combine them into a single observable and subscribe to print the values.
//     Key Concepts: Concat
public class ConcatenatedObservable {
    public ConcatenatedObservable() {
        var interval = TimeSpan.FromMilliseconds(500);
        
        var first = Observable
            .Range(1, 5)
            .Zip(Observable.Interval(interval), (i, _) => i);
        
        var second = Observable
            .Range(6, 10)
            .Zip(Observable.Interval(interval), (i, _) => i);

        first.Concat(second)
            .Subscribe(Console.WriteLine);
    }
}