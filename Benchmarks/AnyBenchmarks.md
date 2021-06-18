## AnyBenchmarks

### Source
[AnyBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/AnyBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.5.21301.5
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.13.0.1555-nightly, OS=Windows 10.0.19043.1055 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.5.21302.13
  [Host]     : .NET 6.0.0 (6.0.21.30105), X64 RyuJIT
  Job-UNTOJZ : .NET 6.0.0 (6.0.21.30105), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |----------:|----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |  8.522 ns | 0.1072 ns | 0.0950 ns |  8.489 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |  8.337 ns | 0.1458 ns | 0.2591 ns |  8.220 ns |  0.99 |    0.04 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |           |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 20.939 ns | 0.3606 ns | 0.3196 ns | 20.920 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 | 10.763 ns | 0.0420 ns | 0.0372 ns | 10.761 ns |  0.51 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |           |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |  4.172 ns | 0.0261 ns | 0.0232 ns |  4.170 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |  8.238 ns | 0.0348 ns | 0.0308 ns |  8.232 ns |  1.97 |    0.02 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |           |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |  5.244 ns | 0.0159 ns | 0.0141 ns |  5.245 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |  1.570 ns | 0.0114 ns | 0.0101 ns |  1.570 ns |  0.30 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |           |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 56.214 ns | 0.3040 ns | 0.2539 ns | 56.183 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 50.317 ns | 0.1716 ns | 0.1433 ns | 50.332 ns |  0.90 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |           |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 20.843 ns | 0.2172 ns | 0.1814 ns | 20.827 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 13.088 ns | 0.0794 ns | 0.0704 ns | 13.070 ns |  0.63 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |           |           |           |           |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |  4.156 ns | 0.0202 ns | 0.0189 ns |  4.153 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |  1.564 ns | 0.0159 ns | 0.0141 ns |  1.562 ns |  0.38 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |           |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |  5.329 ns | 0.1381 ns | 0.1224 ns |  5.288 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq_List_Reference |            List_Reference |   100 |  1.811 ns | 0.0220 ns | 0.0195 ns |  1.804 ns |  0.34 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |           |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 56.362 ns | 0.1850 ns | 0.1640 ns | 56.408 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 54.655 ns | 0.1620 ns | 0.1436 ns | 54.680 ns |  0.97 |    0.00 | 0.0153 |     - |     - |      32 B |
