using ReactiveExtensions.Task5;
using ReactiveExtensions.Task6;

HotObservable coldObservable = new HotObservable(10);
await Task.Delay(1000);
coldObservable.GetHotObservable()
    .Subscribe(val => { Console.WriteLine($"Subscriber 1: {val}"); });

await Task.Delay(2000);
coldObservable.GetHotObservable()
    .Subscribe(val => { Console.WriteLine($"Subscriber 2: {val}"); });

Console.ReadKey();