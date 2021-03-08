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
|                              Method |                Categories | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |       NA |      NA |      NA |     ? |       ? |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 | 185.7 ns | 0.73 ns | 0.65 ns |     ? |       ? | 0.0305 |     - |     - |      64 B |
|                      Hyperlinq_Span |                     Array |   100 | 204.9 ns | 0.83 ns | 0.77 ns |     ? |       ? | 0.0305 |     - |     - |      64 B |
|                    Hyperlinq_Memory |                     Array |   100 | 212.2 ns | 0.66 ns | 0.55 ns |     ? |       ? | 0.0305 |     - |     - |      64 B |
|                                     |                           |       |          |         |         |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |       NA |      NA |      NA |     ? |       ? |      - |     - |     - |         - |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 | 753.5 ns | 3.41 ns | 2.85 ns |     ? |       ? | 0.0458 |     - |     - |      96 B |
|                                     |                           |       |          |         |         |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |       NA |      NA |      NA |     ? |       ? |      - |     - |     - |         - |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 | 762.7 ns | 2.79 ns | 2.47 ns |     ? |       ? | 0.0458 |     - |     - |      96 B |
|                                     |                           |       |          |         |         |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |       NA |      NA |      NA |     ? |       ? |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 | 657.2 ns | 2.30 ns | 2.04 ns |     ? |       ? | 0.0305 |     - |     - |      64 B |
|                                     |                           |       |          |         |         |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 |       NA |      NA |      NA |     ? |       ? |      - |     - |     - |         - |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 |       NA |      NA |      NA |     ? |       ? |      - |     - |     - |         - |
|                                     |                           |       |          |         |         |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |       NA |      NA |      NA |     ? |       ? |      - |     - |     - |         - |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 561.9 ns | 2.60 ns | 2.17 ns |     ? |       ? | 0.0458 |     - |     - |      96 B |
|                                     |                           |       |          |         |         |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |       NA |      NA |      NA |     ? |       ? |      - |     - |     - |         - |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 | 616.8 ns | 3.29 ns | 2.92 ns |     ? |       ? | 0.0458 |     - |     - |      96 B |
|                                     |                           |       |          |         |         |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |       NA |      NA |      NA |     ? |       ? |      - |     - |     - |         - |
|            Hyperlinq_List_Reference |            List_Reference |   100 | 695.7 ns | 3.26 ns | 2.89 ns |     ? |       ? | 0.0305 |     - |     - |      64 B |
|                                     |                           |       |          |         |         |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 |       NA |      NA |      NA |     ? |       ? |      - |     - |     - |         - |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 |       NA |      NA |      NA |     ? |       ? |      - |     - |     - |         - |

Benchmarks with issues:
  WhereFirstBenchmarks.Linq_Array: .NET Core 5.0(Runtime=.NET Core 5.0) [Count=100]
  WhereFirstBenchmarks.Linq_Enumerable_Value: .NET Core 5.0(Runtime=.NET Core 5.0) [Count=100]
  WhereFirstBenchmarks.Linq_Collection_Value: .NET Core 5.0(Runtime=.NET Core 5.0) [Count=100]
  WhereFirstBenchmarks.Linq_List_Value: .NET Core 5.0(Runtime=.NET Core 5.0) [Count=100]
  WhereFirstBenchmarks.Linq_AsyncEnumerable_Value: .NET Core 5.0(Runtime=.NET Core 5.0) [Count=100]
  WhereFirstBenchmarks.Hyperlinq_AsyncEnumerable_Value: .NET Core 5.0(Runtime=.NET Core 5.0) [Count=100]
  WhereFirstBenchmarks.Linq_Enumerable_Reference: .NET Core 5.0(Runtime=.NET Core 5.0) [Count=100]
  WhereFirstBenchmarks.Linq_Collection_Reference: .NET Core 5.0(Runtime=.NET Core 5.0) [Count=100]
  WhereFirstBenchmarks.Linq_List_Reference: .NET Core 5.0(Runtime=.NET Core 5.0) [Count=100]
  WhereFirstBenchmarks.Linq_AsyncEnumerable_Reference: .NET Core 5.0(Runtime=.NET Core 5.0) [Count=100]
  WhereFirstBenchmarks.Hyperlinq_AsyncEnumerable_Reference: .NET Core 5.0(Runtime=.NET Core 5.0) [Count=100]
