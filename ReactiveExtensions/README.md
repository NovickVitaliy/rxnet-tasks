# RX.NET Tasks for practice
This is the tasks made by ChatGPT to learn and practice the RX.NET.

### Task 1
**Objective**: Learn to create and subscribe to basic observables.  

**Task**: Create an observable that emits integers from 0 to N within a specified interval.
Subscribe to this observable and print each emitted value to the console. 

**Key** Concepts: Observable.Create, Subscribe.

### Task 2
**Objective**: Apply filtering and transformation operators.

**Task**: Create an observable that emits integers from 1 to N within a specified interval. Use Where to filter out odd numbers and
Select to square the remaining numbers. Subscribe and print the results.

**Key Concepts**: Where, Select.

## Task 3
**Objective**: Combine multiple observables.

**Task**: Create two observables that emit integers from 1 to 5 and 6 to 10, respectively.
Use Concat, Merge to combine them into a single observable and subscribe to print the values.

**Key Concepts**: Concat, Merge.

### Task 4
**Objective**: Work with time-based operators.

**Task**: Create an observable that emits a value every second for 10 seconds.
Use Throttle to only emit values if no other values have been emitted for 2 seconds. Subscribe and print the results.

**Key Concepts**: Interval, Throttle.


### Task 5
**Objective**: Handle errors in observables.

**Task**: Create an observable that emits integers from 1 to 10 but throws an exception when it reaches 5.
         Use Catch to handle the error and continue emitting values from 6 to 10.

**Key Concepts**: Catch, OnErrorResumeNext.

### Task 6
**Objective**: Understand the difference between hot and cold observables.

**Task**: Create a cold observable that emits integers from 1 to 5.
     Convert it to a hot observable using Publish and Connect. Subscribe two observers at different times and print the results. 

**Key Concepts**: Cold Observable, Hot Observable, Publish, Connect.

### Task 7
**Objective**: Use buffering and windowing to batch data.

**Task**: Create an observable that emits a value every 200ms.
          Use Buffer to collect values in batches of 1 second and Window to create observable windows of 1 second. Subscribe and print the results.

**Key Concepts**: Buffer, Window.

### Task 8
**Objective**: Group emitted items based on a key.

**Task**: Create an observable that emits random integers between 1 and 10.
          Use GroupBy to group these integers into odd and even groups. Subscribe to each group and print the results.

**Key Concepts**: GroupBy.

### Task 9
**Objective**: Combine the latest values from multiple observables.

**Task**: Create two observables that emit integers every second and every 500ms, respectively.
     Use CombineLatest to combine the latest values from both observables. Subscribe and print the results.

**Key Concepts**: CombineLatest.

### Task 10
**Objective**: Apply reactive programming to a real-time data scenario.

**Task**: Create a class WeatherService that fetches temperature data every second (simulated with random values).
     Use Rx.NET to process this data stream, filter out invalid readings (e.g., below -50°C or above 50°C),
     and calculate a moving average over a 10-second window. Subscribe and print the results.

**Key Concepts**: Subject, Where, Buffer, Select, Subscribe.