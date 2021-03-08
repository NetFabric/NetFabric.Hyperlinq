## WhereFirstBenchmarks

### Source
[WhereFirstBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereFirstBenchmarks.cs)

### References:
- Linq: 5.0.3
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=6.0.100-preview.1.21103.13
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                              Method |                Categories | Count |       Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |         NA |      NA |      NA |     ? |       ? |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |   183.2 ns | 0.84 ns | 0.79 ns |     ? |       ? | 0.0305 |     - |     - |      64 B |
|                                     |                           |       |            |         |         |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |         NA |      NA |      NA |     ? |       ? |      - |     - |     - |         - |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   217.7 ns | 0.92 ns | 0.82 ns |     ? |       ? | 0.0305 |     - |     - |      64 B |
|                                     |                           |       |            |         |         |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |         NA |      NA |      NA |     ? |       ? |      - |     - |     - |         - |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   223.2 ns | 0.70 ns | 0.62 ns |     ? |       ? | 0.0305 |     - |     - |      64 B |
|                                     |                           |       |            |         |         |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |         NA |      NA |      NA |     ? |       ? |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |   625.9 ns | 2.16 ns | 1.80 ns |     ? |       ? | 0.0305 |     - |     - |      64 B |
|                                     |                           |       |            |         |         |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 |         NA |      NA |      NA |     ? |       ? |      - |     - |     - |         - |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 3,485.7 ns | 7.43 ns | 6.95 ns |     ? |       ? | 0.0305 |     - |     - |      64 B |
|                                     |                           |       |            |         |         |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |         NA |      NA |      NA |     ? |       ? |      - |     - |     - |         - |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   560.4 ns | 2.78 ns | 2.46 ns |     ? |       ? | 0.0458 |     - |     - |      96 B |
|                                     |                           |       |            |         |         |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |         NA |      NA |      NA |     ? |       ? |      - |     - |     - |         - |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   553.1 ns | 3.00 ns | 2.81 ns |     ? |       ? | 0.0458 |     - |     - |      96 B |
|                                     |                           |       |            |         |         |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |         NA |      NA |      NA |     ? |       ? |      - |     - |     - |         - |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   654.8 ns | 2.75 ns | 2.57 ns |     ? |       ? | 0.0305 |     - |     - |      64 B |
|                                     |                           |       |            |         |         |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 |         NA |      NA |      NA |     ? |       ? |      - |     - |     - |         - |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 3,637.2 ns | 5.87 ns | 5.20 ns |     ? |       ? | 0.0496 |     - |     - |     104 B |

Benchmarks with issues:
  WhereFirstBenchmarks.Linq_Array: .NET Core 5.0(Runtime=.NET Core 5.0) [Count=100]
  WhereFirstBenchmarks.Linq_Enumerable_Value: .NET Core 5.0(Runtime=.NET Core 5.0) [Count=100]
  WhereFirstBenchmarks.Linq_Collection_Value: .NET Core 5.0(Runtime=.NET Core 5.0) [Count=100]
  WhereFirstBenchmarks.Linq_List_Value: .NET Core 5.0(Runtime=.NET Core 5.0) [Count=100]
  WhereFirstBenchmarks.Linq_AsyncEnumerable_Value: .NET Core 5.0(Runtime=.NET Core 5.0) [Count=100]
  WhereFirstBenchmarks.Linq_Enumerable_Reference: .NET Core 5.0(Runtime=.NET Core 5.0) [Count=100]
  WhereFirstBenchmarks.Linq_Collection_Reference: .NET Core 5.0(Runtime=.NET Core 5.0) [Count=100]
  WhereFirstBenchmarks.Linq_List_Reference: .NET Core 5.0(Runtime=.NET Core 5.0) [Count=100]
  WhereFirstBenchmarks.Linq_AsyncEnumerable_Reference: .NET Core 5.0(Runtime=.NET Core 5.0) [Count=100]
