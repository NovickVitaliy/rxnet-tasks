// See https://aka.ms/new-console-template for more information

using ReactiveExtensions.Task1;

IntegersEmitter integersEmitter = new(10, TimeSpan.FromMilliseconds(500));

integersEmitter.IntegerStream.Subscribe(val => Console.WriteLine($"Subscriber 1: {val}"),
    err => { Console.WriteLine($"Error occured subscriber 1: {err.Message}."); },
    () => { Console.WriteLine("Sequence completed for subscriber 1."); });

Thread.Sleep(5000);

integersEmitter.IntegerStream.Subscribe(val => Console.WriteLine($"Subscriber 2: {val}"),
    err => { Console.WriteLine($"Error occured for subscriber 2: {err.Message}."); },
    () => { Console.WriteLine("Sequence completed for subscriber 2."); });