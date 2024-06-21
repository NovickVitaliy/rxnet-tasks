using System.Reactive.Linq;

namespace ReactiveExtensions.Task8;
// Objective: Group emitted items based on a key.
//
//     Task: Create an observable that emits random integers between 1 and 10.
//           Use GroupBy to group these integers into odd and even groups. Subscribe to each group and print the results.
//     Key Concepts: GroupBy

public class NumbersGrouperObservable {
    public NumbersGrouperObservable() {
        Observable.Range(1, 10)
            .GroupBy(x => x % 2 == 0 ? "Even" : "Odd")
            .Subscribe(group => {
                group.Subscribe(
                    x => Console.WriteLine($"{group.Key}: {x}"), 
                    ex => Console.WriteLine($"Error: {ex.Message}"), 
                    () => Console.WriteLine($"{group.Key} group completed") 
                );
            });
    }
}