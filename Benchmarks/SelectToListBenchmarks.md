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
|                           Linq_List |                     Array |   100 |   298.5 ns |  1.81 ns |  1.61 ns |  1.00 |    0.00 | 0.2408 |     - |     - |     504 B |
|                     StructLinq_List |                     Array |   100 |   243.6 ns |  2.36 ns |  2.20 ns |  0.82 |    0.01 | 0.2179 |     - |     - |     456 B |
|                      Hyperlinq_List |                     Array |   100 |   237.3 ns |  3.04 ns |  2.84 ns |  0.80 |    0.01 | 0.2179 |     - |     - |     456 B |
|                      Hyperlinq_Span |                     Array |   100 |   236.1 ns |  0.80 ns |  0.67 ns |  0.79 |    0.00 | 0.2179 |     - |     - |     456 B |
|                    Hyperlinq_Memory |                     Array |   100 |   238.7 ns |  1.74 ns |  1.63 ns |  0.80 |    0.01 | 0.2179 |     - |     - |     456 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,105.5 ns |  8.39 ns |  7.01 ns |  1.00 |    0.00 | 0.6065 |     - |     - |    1272 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,078.4 ns |  5.23 ns |  4.63 ns |  0.98 |    0.01 | 0.2327 |     - |     - |     488 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 | 1,137.5 ns |  4.65 ns |  3.63 ns |  1.03 |    0.01 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,094.4 ns |  8.33 ns |  6.96 ns |  1.00 |    0.00 | 0.6065 |     - |     - |    1272 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,035.1 ns |  5.15 ns |  4.82 ns |  0.95 |    0.01 | 0.2327 |     - |     - |     488 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   794.1 ns |  3.42 ns |  3.04 ns |  0.73 |    0.01 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   486.8 ns |  1.85 ns |  1.64 ns |  1.00 |    0.00 | 0.2441 |     - |     - |     512 B |
|               StructLinq_List_Value |                List_Value |   100 |   384.8 ns |  2.17 ns |  2.03 ns |  0.79 |    0.00 | 0.2179 |     - |     - |     456 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   788.6 ns |  2.38 ns |  1.99 ns |  1.62 |    0.01 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   872.6 ns |  3.34 ns |  2.96 ns |  1.00 |    0.00 | 0.6075 |     - |     - |    1272 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   880.9 ns | 14.39 ns | 25.57 ns |  1.02 |    0.05 | 0.2327 |     - |     - |     488 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   938.0 ns |  2.75 ns |  2.44 ns |  1.07 |    0.00 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   866.5 ns |  4.28 ns |  3.34 ns |  1.00 |    0.00 | 0.6075 |     - |     - |    1272 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   842.3 ns |  4.06 ns |  3.17 ns |  0.97 |    0.01 | 0.2327 |     - |     - |     488 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   615.9 ns |  3.00 ns |  2.66 ns |  0.71 |    0.00 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   489.9 ns |  2.08 ns |  1.95 ns |  1.00 |    0.00 | 0.2441 |     - |     - |     512 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   811.0 ns |  2.60 ns |  2.30 ns |  1.66 |    0.01 | 0.2327 |     - |     - |     488 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   718.9 ns |  2.98 ns |  2.79 ns |  1.47 |    0.01 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 9,230.4 ns | 37.73 ns | 35.30 ns |     ? |       ? | 0.6256 |     - |     - |    1336 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 9,122.5 ns | 34.01 ns | 31.82 ns |     ? |       ? | 0.6256 |     - |     - |    1336 B |
