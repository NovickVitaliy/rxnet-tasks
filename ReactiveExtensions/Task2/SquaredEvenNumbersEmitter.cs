using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace ReactiveExtensions.Task2;

// Objective: Apply filtering and transformation operators.
//
//     Task: Create an observable that emits integers from 1 to N within a specified interval. Use Where to filter out odd numbers and
//          Select to square the remaining numbers. Subscribe and print the results.
//     Key Concepts: Where, Select
public class SquaredEvenNumbersEmitter {
    public SquaredEvenNumbersEmitter(int max, TimeSpan interval) {
        Observable.Interval(interval)
            .Take(max)
            .Select(x => (int)x + 1)
            .Do(x => Console.WriteLine($"Processing number {x}"))
            .Where(x => x % 2 == 0)
            .Select(x => x * x)
            .Subscribe(Console.WriteLine,
                err => Console.WriteLine(),
                () => Console.WriteLine("Sequence completed"));
    }
}