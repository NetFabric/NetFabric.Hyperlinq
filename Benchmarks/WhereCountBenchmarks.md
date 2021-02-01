## WhereCountBenchmarks

### Source
[WhereCountBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereCountBenchmarks.cs)

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
|                              Method |                Categories | Count |       Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   636.8 ns | 3.95 ns | 3.70 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|                    StructLinq_Array |                     Array |   100 |   234.2 ns | 0.35 ns | 0.28 ns |  0.37 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |   167.7 ns | 0.32 ns | 0.28 ns |  0.26 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |   164.7 ns | 0.40 ns | 0.34 ns |  0.26 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |   190.7 ns | 0.25 ns | 0.21 ns |  0.30 |      - |     - |     - |         - |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,167.4 ns | 2.08 ns | 1.84 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,069.0 ns | 2.98 ns | 2.79 ns |  0.92 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   204.2 ns | 0.33 ns | 0.29 ns |  0.17 |      - |     - |     - |         - |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,167.7 ns | 3.31 ns | 2.77 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,088.3 ns | 2.76 ns | 2.58 ns |  0.93 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   203.3 ns | 0.31 ns | 0.27 ns |  0.17 |      - |     - |     - |         - |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,153.8 ns | 3.52 ns | 2.75 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|               StructLinq_List_Value |                List_Value |   100 |   397.2 ns | 3.08 ns | 2.88 ns |  0.34 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |   358.9 ns | 1.94 ns | 1.82 ns |  0.31 |      - |     - |     - |         - |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,165.8 ns | 5.26 ns | 4.66 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 5,691.8 ns | 8.07 ns | 7.16 ns |  2.63 | 0.0610 |     - |     - |     136 B |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   771.0 ns | 2.55 ns | 2.13 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   599.0 ns | 2.97 ns | 2.48 ns |  0.78 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   565.4 ns | 2.37 ns | 1.85 ns |  0.73 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   772.4 ns | 3.35 ns | 2.97 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   585.3 ns | 3.35 ns | 3.14 ns |  0.76 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   565.4 ns | 1.26 ns | 1.18 ns |  0.73 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   768.5 ns | 4.69 ns | 4.16 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   585.7 ns | 3.06 ns | 2.86 ns |  0.76 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   372.9 ns | 0.55 ns | 0.49 ns |  0.49 |      - |     - |     - |         - |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,064.2 ns | 4.18 ns | 3.70 ns |  1.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5,883.8 ns | 9.57 ns | 8.49 ns |  2.85 | 0.0687 |     - |     - |     152 B |
