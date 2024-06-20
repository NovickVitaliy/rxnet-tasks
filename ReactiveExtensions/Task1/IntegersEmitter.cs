using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace ReactiveExtensions.Task1;

// Objective: Learn to create and subscribe to basic observables.
//     Task: Create an observable that emits integers from 0 to N within a specified interval.
//          Subscribe to this observable and print each emitted value to the console.
//     Key Concepts: Observable.Create, Subscribe

public class IntegersEmitter {
    private readonly IObservable<int> _subject;

    public IntegersEmitter(int max, TimeSpan interval) {
        _subject = Observable.Create<int>(observer => {
            var current = 0;
            var timer = Observable.Interval(interval)
                .Subscribe(_ => {
                    if (current <= max) {
                        observer.OnNext(current++);
                    }
                    else {
                        observer.OnCompleted();
                    }
                });
            
            return Disposable.Create(() => timer.Dispose());
        });
    }

    public IObservable<int> IntegerStream => _subject.AsObservable();
}