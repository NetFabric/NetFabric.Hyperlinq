## SelectToListBenchmarks

### Source
[SelectToListBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectToListBenchmarks.cs)

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
|                              Method |                Categories | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                           Linq_List |                     Array |   100 |   298.1 ns |  0.71 ns |  0.63 ns |  1.00 |    0.00 | 0.2408 |     - |     - |     504 B |
|                     StructLinq_List |                     Array |   100 |   264.6 ns |  1.11 ns |  1.03 ns |  0.89 |    0.00 | 0.2179 |     - |     - |     456 B |
|                      Hyperlinq_List |                     Array |   100 |   255.8 ns |  0.83 ns |  0.73 ns |  0.86 |    0.00 | 0.2179 |     - |     - |     456 B |
|                      Hyperlinq_Span |                     Array |   100 |   232.7 ns |  0.97 ns |  0.81 ns |  0.78 |    0.00 | 0.2179 |     - |     - |     456 B |
|                    Hyperlinq_Memory |                     Array |   100 |   236.7 ns |  0.61 ns |  0.51 ns |  0.79 |    0.00 | 0.2179 |     - |     - |     456 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,083.4 ns |  3.01 ns |  2.67 ns |  1.00 |    0.00 | 0.6065 |     - |     - |    1272 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,068.2 ns |  5.31 ns |  4.71 ns |  0.99 |    0.01 | 0.2327 |     - |     - |     488 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   627.8 ns |  1.57 ns |  1.40 ns |  0.58 |    0.00 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,038.5 ns |  3.42 ns |  3.19 ns |  1.00 |    0.00 | 0.6065 |     - |     - |    1272 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,016.3 ns |  3.21 ns |  2.68 ns |  0.98 |    0.00 | 0.2327 |     - |     - |     488 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   337.2 ns |  1.53 ns |  1.27 ns |  0.32 |    0.00 | 0.2179 |     - |     - |     456 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   464.2 ns |  1.14 ns |  0.96 ns |  1.00 |    0.00 | 0.2446 |     - |     - |     512 B |
|               StructLinq_List_Value |                List_Value |   100 |   403.8 ns |  1.54 ns |  1.28 ns |  0.87 |    0.00 | 0.2179 |     - |     - |     456 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   705.7 ns |  1.82 ns |  1.61 ns |  1.52 |    0.01 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   847.6 ns |  1.51 ns |  1.26 ns |  1.00 |    0.00 | 0.6075 |     - |     - |    1272 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   883.0 ns |  2.62 ns |  2.32 ns |  1.04 |    0.00 | 0.2327 |     - |     - |     488 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   915.2 ns |  2.21 ns |  1.84 ns |  1.08 |    0.00 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   848.3 ns |  2.90 ns |  2.42 ns |  1.00 |    0.00 | 0.6075 |     - |     - |    1272 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   843.6 ns |  4.47 ns |  3.97 ns |  0.99 |    0.01 | 0.2327 |     - |     - |     488 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   620.6 ns |  1.53 ns |  1.36 ns |  0.73 |    0.00 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   503.9 ns |  1.50 ns |  1.40 ns |  1.00 |    0.00 | 0.2441 |     - |     - |     512 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   815.4 ns |  4.08 ns |  3.41 ns |  1.62 |    0.01 | 0.2327 |     - |     - |     488 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   780.7 ns |  1.03 ns |  0.86 ns |  1.55 |    0.00 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 9,081.8 ns | 28.65 ns | 25.40 ns |     ? |       ? | 0.6256 |     - |     - |    1320 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 9,175.0 ns | 24.52 ns | 21.74 ns |     ? |       ? | 0.6256 |     - |     - |    1336 B |
