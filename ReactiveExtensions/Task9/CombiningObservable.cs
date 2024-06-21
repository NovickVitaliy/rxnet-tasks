using System.Reactive.Linq;

namespace ReactiveExtensions.Task9;
// Objective: Combine the latest values from multiple observables.
//
//     Task: Create two observables that emit integers every second and every 500ms, respectively.
//      Use CombineLatest to combine the latest values from both observables. Subscribe and print the results.
//     Key Concepts: CombineLatest
public class CombiningObservable {
    public CombiningObservable() {
        var first = Observable.Interval(TimeSpan.FromMilliseconds(1000))
            .Select(x => $"From first: {x}");
        
        var second = Observable.Interval(TimeSpan.FromMilliseconds(500))
            .Select(x => $"From second: {x}");

        first.CombineLatest(second)
            .Subscribe(x => {
                Console.WriteLine(x.ToString());
            });
    }
}