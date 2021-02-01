## ContainsComparerBenchmarks

### Source
[ContainsComparerBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ContainsComparerBenchmarks.cs)

### References:
- Linq: 4.8.4300.0
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta29](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta29)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
  [Host]        : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                         Method |                Categories | Count |       Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |-------------------------- |------ |-----------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|                     Linq_Array |                     Array |   100 |   568.2 ns | 2.19 ns | 2.05 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|                Hyperlinq_Array |                     Array |   100 |   241.1 ns | 0.68 ns | 0.60 ns |  0.42 |      - |     - |     - |         - |
|                 Hyperlinq_Span |                     Array |   100 |   192.6 ns | 0.76 ns | 0.71 ns |  0.34 |      - |     - |     - |         - |
|               Hyperlinq_Memory |                     Array |   100 |   219.4 ns | 0.81 ns | 0.72 ns |  0.39 |      - |     - |     - |         - |
|                                |                           |       |            |         |         |       |        |       |       |           |
|          Linq_Enumerable_Value |          Enumerable_Value |   100 |   744.5 ns | 1.64 ns | 1.37 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   257.5 ns | 0.97 ns | 0.91 ns |  0.35 |      - |     - |     - |         - |
|                                |                           |       |            |         |         |       |        |       |       |           |
|          Linq_Collection_Value |          Collection_Value |   100 |   772.5 ns | 1.48 ns | 1.32 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_Collection_Value |          Collection_Value |   100 |   254.0 ns | 0.42 ns | 0.38 ns |  0.33 |      - |     - |     - |         - |
|                                |                           |       |            |         |         |       |        |       |       |           |
|                Linq_List_Value |                List_Value |   100 |   743.8 ns | 1.89 ns | 1.68 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|           Hyperlinq_List_Value |                List_Value |   100 |   401.6 ns | 0.75 ns | 0.62 ns |  0.54 |      - |     - |     - |         - |
|                                |                           |       |            |         |         |       |        |       |       |           |
|     Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,139.1 ns | 5.52 ns | 4.61 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|                                |                           |       |            |         |         |       |        |       |       |           |
|      Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   563.4 ns | 1.60 ns | 1.25 ns |  1.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   564.5 ns | 1.90 ns | 1.78 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|                                |                           |       |            |         |         |       |        |       |       |           |
|      Linq_Collection_Reference |      Collection_Reference |   100 |   563.9 ns | 2.11 ns | 1.87 ns |  1.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   565.1 ns | 1.37 ns | 1.22 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|                                |                           |       |            |         |         |       |        |       |       |           |
|            Linq_List_Reference |            List_Reference |   100 |   562.8 ns | 1.59 ns | 1.41 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|       Hyperlinq_List_Reference |            List_Reference |   100 |   376.3 ns | 1.97 ns | 1.75 ns |  0.67 |      - |     - |     - |         - |
|                                |                           |       |            |         |         |       |        |       |       |           |
| Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,030.0 ns | 3.80 ns | 3.37 ns |  1.00 | 0.0191 |     - |     - |      40 B |
