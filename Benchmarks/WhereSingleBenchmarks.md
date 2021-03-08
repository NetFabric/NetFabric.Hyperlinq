## WhereSingleBenchmarks

### Source
[WhereSingleBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereSingleBenchmarks.cs)

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
|                     Hyperlinq_Array |                     Array |   100 | 208.0 ns | 1.36 ns | 1.14 ns |     ? |       ? | 0.0305 |     - |     - |      64 B |
|                      Hyperlinq_Span |                     Array |   100 | 206.4 ns | 0.59 ns | 0.55 ns |     ? |       ? | 0.0305 |     - |     - |      64 B |
|                    Hyperlinq_Memory |                     Array |   100 | 212.6 ns | 0.88 ns | 0.78 ns |     ? |       ? | 0.0305 |     - |     - |      64 B |
|                                     |                           |       |          |         |         |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |       NA |      NA |      NA |     ? |       ? |      - |     - |     - |         - |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 | 777.4 ns | 3.23 ns | 3.02 ns |     ? |       ? | 0.0458 |     - |     - |      96 B |
|                                     |                           |       |          |         |         |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |       NA |      NA |      NA |     ? |       ? |      - |     - |     - |         - |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 | 778.6 ns | 2.98 ns | 2.64 ns |     ? |       ? | 0.0458 |     - |     - |      96 B |
|                                     |                           |       |          |         |         |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |       NA |      NA |      NA |     ? |       ? |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 | 638.7 ns | 3.20 ns | 2.84 ns |     ? |       ? | 0.0305 |     - |     - |      64 B |
|                                     |                           |       |          |         |         |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 |       NA |      NA |      NA |     ? |       ? |      - |     - |     - |         - |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 |       NA |      NA |      NA |     ? |       ? |      - |     - |     - |         - |
|                                     |                           |       |          |         |         |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |       NA |      NA |      NA |     ? |       ? |      - |     - |     - |         - |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 535.1 ns | 1.84 ns | 1.63 ns |     ? |       ? | 0.0458 |     - |     - |      96 B |
|                                     |                           |       |          |         |         |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |       NA |      NA |      NA |     ? |       ? |      - |     - |     - |         - |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 | 614.2 ns | 3.39 ns | 3.17 ns |     ? |       ? | 0.0458 |     - |     - |      96 B |
|                                     |                           |       |          |         |         |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |       NA |      NA |      NA |     ? |       ? |      - |     - |     - |         - |
|            Hyperlinq_List_Reference |            List_Reference |   100 | 637.8 ns | 2.60 ns | 2.30 ns |     ? |       ? | 0.0305 |     - |     - |      64 B |
|                                     |                           |       |          |         |         |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 |       NA |      NA |      NA |     ? |       ? |      - |     - |     - |         - |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 |       NA |      NA |      NA |     ? |       ? |      - |     - |     - |         - |

Benchmarks with issues:
  WhereSingleBenchmarks.Linq_Array: .NET Core 5.0(Runtime=.NET Core 5.0) [Count=100]
  WhereSingleBenchmarks.Linq_Enumerable_Value: .NET Core 5.0(Runtime=.NET Core 5.0) [Count=100]
  WhereSingleBenchmarks.Linq_Collection_Value: .NET Core 5.0(Runtime=.NET Core 5.0) [Count=100]
  WhereSingleBenchmarks.Linq_List_Value: .NET Core 5.0(Runtime=.NET Core 5.0) [Count=100]
  WhereSingleBenchmarks.Linq_AsyncEnumerable_Value: .NET Core 5.0(Runtime=.NET Core 5.0) [Count=100]
  WhereSingleBenchmarks.Hyperlinq_AsyncEnumerable_Value: .NET Core 5.0(Runtime=.NET Core 5.0) [Count=100]
  WhereSingleBenchmarks.Linq_Enumerable_Reference: .NET Core 5.0(Runtime=.NET Core 5.0) [Count=100]
  WhereSingleBenchmarks.Linq_Collection_Reference: .NET Core 5.0(Runtime=.NET Core 5.0) [Count=100]
  WhereSingleBenchmarks.Linq_List_Reference: .NET Core 5.0(Runtime=.NET Core 5.0) [Count=100]
  WhereSingleBenchmarks.Linq_AsyncEnumerable_Reference: .NET Core 5.0(Runtime=.NET Core 5.0) [Count=100]
  WhereSingleBenchmarks.Hyperlinq_AsyncEnumerable_Reference: .NET Core 5.0(Runtime=.NET Core 5.0) [Count=100]
