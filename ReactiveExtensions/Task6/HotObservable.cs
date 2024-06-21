using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace ReactiveExtensions.Task6;
// Objective: Understand the difference between hot and cold observables.
//
//     Task: Create a cold observable that emits integers from 1 to 5.
//      Convert it to a hot observable using Publish and Connect. Subscribe two observers at different times and print the results.
//     Key Concepts: Cold Observable, Hot Observable, Publish, Connect
public class HotObservable {
    private readonly int _max;
    private int _hotValue;
    private readonly IConnectableObservable<int> _connectableObservable;
    public HotObservable(int max) {
        _max = max;
        _hotValue = 0;


        _connectableObservable = Observable.Interval(TimeSpan.FromMilliseconds(500))
            .Select(_ => _hotValue++)
            .TakeWhile(val => val <= _max)
            .Publish();

        _connectableObservable.Connect();
    }

    public IObservable<int> GetHotObservable() => _connectableObservable.AsObservable();
}