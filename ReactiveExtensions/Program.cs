using ReactiveExtensions.Task5;
using ReactiveExtensions.Task6;
using ReactiveExtensions.Task7;

BufferedObservable bufferedObservable = new BufferedObservable();

bufferedObservable.ObservableWithWindow
    .Subscribe(window => {
        Console.WriteLine("New window");

        window.Subscribe(Console.WriteLine, 
            (err) => Console.WriteLine("Error on window"),
            () => Console.WriteLine("Window completed"));
    });

Console.ReadKey();