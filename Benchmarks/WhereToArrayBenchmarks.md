## WhereToArrayBenchmarks

### Source
[WhereToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereToArrayBenchmarks.cs)

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
|                              Method |                Categories | Count |       Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   408.4 ns |  0.82 ns |  0.68 ns |  1.00 | 0.3519 |     - |     - |     736 B |
|                    StructLinq_Array |                     Array |   100 |   385.2 ns |  0.94 ns |  0.78 ns |  0.94 | 0.1144 |     - |     - |     240 B |
|                     Hyperlinq_Array |                     Array |   100 |   471.4 ns |  1.16 ns |  1.03 ns |  1.15 | 0.1144 |     - |     - |     240 B |
|                      Hyperlinq_Span |                     Array |   100 |   479.2 ns |  2.08 ns |  1.94 ns |  1.17 | 0.1144 |     - |     - |     240 B |
|                    Hyperlinq_Memory |                     Array |   100 |   520.2 ns |  1.69 ns |  1.50 ns |  1.27 | 0.1144 |     - |     - |     240 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,344.1 ns |  1.97 ns |  1.75 ns |  1.00 | 0.3700 |     - |     - |     776 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,257.3 ns |  5.13 ns |  4.80 ns |  0.94 | 0.1297 |     - |     - |     272 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   506.3 ns |  3.55 ns |  3.33 ns |  0.38 | 0.1144 |     - |     - |     240 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,221.0 ns |  2.79 ns |  2.47 ns |  1.00 | 0.3700 |     - |     - |     776 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,252.3 ns |  3.72 ns |  3.30 ns |  1.03 | 0.1297 |     - |     - |     272 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   573.2 ns |  9.72 ns |  8.61 ns |  0.47 | 0.1144 |     - |     - |     240 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,205.2 ns |  2.78 ns |  2.46 ns |  1.00 | 0.3700 |     - |     - |     776 B |
|               StructLinq_List_Value |                List_Value |   100 |   787.0 ns |  1.58 ns |  1.48 ns |  0.65 | 0.1144 |     - |     - |     240 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   864.1 ns |  5.16 ns |  4.57 ns |  0.72 | 0.1144 |     - |     - |     240 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 5,975.7 ns | 16.61 ns | 14.72 ns |  1.00 | 0.4578 |     - |     - |     960 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 6,089.1 ns | 13.45 ns | 11.92 ns |  1.02 | 0.4730 |     - |     - |     992 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   797.6 ns |  6.41 ns |  5.68 ns |  1.00 | 0.3710 |     - |     - |     776 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   806.1 ns |  1.28 ns |  1.07 ns |  1.01 | 0.1297 |     - |     - |     272 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   891.9 ns |  2.48 ns |  2.07 ns |  1.12 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   792.7 ns | 12.23 ns |  9.55 ns |  1.00 | 0.3710 |     - |     - |     776 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   804.3 ns |  1.83 ns |  1.63 ns |  1.02 | 0.1297 |     - |     - |     272 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   895.5 ns |  1.64 ns |  1.46 ns |  1.13 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   794.8 ns |  2.19 ns |  1.94 ns |  1.00 | 0.3710 |     - |     - |     776 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   810.0 ns |  2.25 ns |  2.11 ns |  1.02 | 0.1297 |     - |     - |     272 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   844.4 ns |  3.48 ns |  2.90 ns |  1.06 | 0.1144 |     - |     - |     240 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5,921.5 ns | 18.56 ns | 15.49 ns |  1.00 | 0.4578 |     - |     - |     960 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 6,269.7 ns | 14.95 ns | 13.98 ns |  1.06 | 0.4807 |     - |     - |    1008 B |
