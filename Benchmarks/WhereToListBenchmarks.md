## WhereToListBenchmarks

### Source
[WhereToListBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereToListBenchmarks.cs)

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
|                              Method |                Categories | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   400.6 ns |  2.94 ns |  2.60 ns |  1.00 |    0.00 | 0.3328 |     - |     - |     696 B |
|                    StructLinq_Array |                     Array |   100 |   431.3 ns |  5.80 ns |  4.85 ns |  1.08 |    0.01 | 0.1297 |     - |     - |     272 B |
|                     Hyperlinq_Array |                     Array |   100 |   514.6 ns |  4.31 ns |  3.82 ns |  1.28 |    0.01 | 0.1297 |     - |     - |     272 B |
|                      Hyperlinq_Span |                     Array |   100 |   505.9 ns |  5.18 ns |  4.85 ns |  1.26 |    0.01 | 0.1297 |     - |     - |     272 B |
|                    Hyperlinq_Memory |                     Array |   100 |   484.4 ns |  5.52 ns |  4.90 ns |  1.21 |    0.01 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,340.7 ns | 15.61 ns | 13.84 ns |  1.00 |    0.00 | 0.3510 |     - |     - |     736 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,269.4 ns | 10.89 ns |  9.10 ns |  0.95 |    0.01 | 0.1450 |     - |     - |     304 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   592.3 ns |  9.60 ns |  8.51 ns |  0.44 |    0.01 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,246.4 ns | 11.41 ns | 10.68 ns |  1.00 |    0.00 | 0.3510 |     - |     - |     736 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,298.3 ns | 21.72 ns | 19.25 ns |  1.04 |    0.01 | 0.1450 |     - |     - |     304 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   553.5 ns |  8.56 ns |  8.00 ns |  0.44 |    0.01 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,228.4 ns |  4.36 ns |  3.86 ns |  1.00 |    0.00 | 0.3510 |     - |     - |     736 B |
|               StructLinq_List_Value |                List_Value |   100 |   823.2 ns |  4.09 ns |  3.41 ns |  0.67 |    0.00 | 0.1297 |     - |     - |     272 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   912.7 ns |  6.66 ns |  6.23 ns |  0.74 |    0.00 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 6,239.2 ns | 28.51 ns | 23.81 ns |  1.00 |    0.00 | 0.3586 |     - |     - |     752 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 6,028.3 ns | 40.70 ns | 33.98 ns |  0.97 |    0.00 | 0.3738 |     - |     - |     784 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   923.7 ns |  9.56 ns |  8.94 ns |  1.00 |    0.00 | 0.3519 |     - |     - |     736 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   870.5 ns |  6.22 ns |  4.86 ns |  0.94 |    0.01 | 0.1450 |     - |     - |     304 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   951.5 ns | 12.88 ns | 12.05 ns |  1.03 |    0.02 | 0.1450 |     - |     - |     304 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   825.7 ns |  6.73 ns |  6.30 ns |  1.00 |    0.00 | 0.3519 |     - |     - |     736 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   856.7 ns |  8.19 ns |  7.66 ns |  1.04 |    0.01 | 0.1450 |     - |     - |     304 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   954.3 ns |  6.18 ns |  5.47 ns |  1.16 |    0.01 | 0.1450 |     - |     - |     304 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 | 1,044.1 ns | 10.54 ns |  8.80 ns |  1.00 |    0.00 | 0.3510 |     - |     - |     736 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   868.8 ns | 14.72 ns | 13.05 ns |  0.83 |    0.01 | 0.1450 |     - |     - |     304 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   914.0 ns |  4.03 ns |  3.15 ns |  0.88 |    0.01 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 6,083.8 ns | 25.51 ns | 21.30 ns |  1.00 |    0.00 | 0.3586 |     - |     - |     752 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 6,889.0 ns | 23.42 ns | 20.76 ns |  1.13 |    0.00 | 0.3815 |     - |     - |     800 B |
