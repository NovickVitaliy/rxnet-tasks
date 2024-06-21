using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace ReactiveExtensions.Task5;
// Objective: Handle errors in observables.
//
//     Task: Create an observable that emits integers from 1 to 10 but throws an exception when it reaches 5.
//          Use Catch to handle the error and continue emitting values from 6 to 10.
//     Key Concepts: Catch, OnErrorResumeNext
public class ThrowableObserver {
    public ThrowableObserver() {
        var observable = Observable.Create<int>(observer => {
            var current = 0;
            var timer = Observable.Interval(TimeSpan.FromMilliseconds(500))
                .Subscribe(_ => {
                        if (current == 5) {
                            observer.OnError(new InvalidOperationException());
                        }

                        observer.OnNext(current++);
                    }, observer.OnError,
                    observer.OnCompleted);

            return Disposable.Create(() => timer.Dispose());
        });

        // var handled = observable.Catch<int, InvalidOperationException>(err => {
        //     Console.WriteLine($"Error occured: {err.Message}");
        //     return Observable.Range(6, 5)
        //         .Zip(Observable.Interval(TimeSpan.FromMilliseconds(500)), (i, _) => i);
        // });

        var handled = observable.OnErrorResumeNext(Observable.Range(6, 5)
            .Zip(Observable.Interval(TimeSpan.FromMilliseconds(500)), (i, l) => i));

        handled.Subscribe(Console.WriteLine,
            err => Console.WriteLine(err.Message),
            () => Console.WriteLine("Finished"));
    }
}