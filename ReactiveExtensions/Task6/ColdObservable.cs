using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace ReactiveExtensions.Task6;

// Objective: Understand the difference between hot and cold observables.
//
//     Task: Create a cold observable that emits integers from 1 to 5.
//      Convert it to a hot observable using Publish and Connect. Subscribe two observers at different times and print the results.
//     Key Concepts: Cold Observable, Hot Observable, Publish, Connect
public class ColdObservable {
    private readonly int _max;
    public ColdObservable(int max) {
        _max = max;
    }

    public IObservable<int> GetColdObservable() {
        return Observable.Create<int>(observer => {
            var current = 0;
            Observable.Interval(TimeSpan.FromMilliseconds(500))
                .Subscribe(_ => {
                    if (current <= _max) {
                        observer.OnNext(current++);
                    }
                    else {
                        observer.OnCompleted();
                    }
                }, observer.OnError);

            return Disposable.Create(() => { });
        });
    }

   
}