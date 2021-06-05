## WhereToArrayBenchmarks

### Source
[WhereToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereToArrayBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.4.21253.7
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.13.0.1555-nightly, OS=Windows 10.0.19043.1023 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21255.9
  [Host]     : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT
  Job-SUCOWF : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   508.9 ns | 23.93 ns | 70.18 ns |  1.00 |    0.00 | 0.3519 |     - |     - |     736 B |
|                    StructLinq_Array |                     Array |   100 |   420.0 ns |  8.31 ns |  9.89 ns |  0.80 |    0.05 | 0.1144 |     - |     - |     240 B |
|                     Hyperlinq_Array |                     Array |   100 |   483.7 ns |  2.73 ns |  2.56 ns |  0.91 |    0.09 | 0.1144 |     - |     - |     240 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,360.0 ns | 21.55 ns | 20.16 ns |  1.00 |    0.00 | 0.3700 |     - |     - |     776 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,235.3 ns |  3.55 ns |  2.77 ns |  0.91 |    0.01 | 0.1297 |     - |     - |     272 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   548.7 ns |  3.04 ns |  2.70 ns |  0.40 |    0.01 | 0.1144 |     - |     - |     240 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,295.6 ns |  6.24 ns |  5.21 ns |  1.00 |    0.00 | 0.3700 |     - |     - |     776 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,218.2 ns |  6.60 ns |  5.85 ns |  0.94 |    0.01 | 0.1297 |     - |     - |     272 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   569.5 ns |  3.02 ns |  2.68 ns |  0.44 |    0.00 | 0.1144 |     - |     - |     240 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,294.1 ns |  4.14 ns |  3.46 ns |  1.00 |    0.00 | 0.3700 |     - |     - |     776 B |
|               StructLinq_List_Value |                List_Value |   100 |   824.5 ns |  5.59 ns |  5.23 ns |  0.64 |    0.00 | 0.1144 |     - |     - |     240 B |
|                Hyperlinq_List_Value |                List_Value |   100 | 1,307.7 ns |  6.50 ns |  6.08 ns |  1.01 |    0.01 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 5,111.2 ns | 34.86 ns | 30.90 ns |  1.00 |    0.00 | 0.4501 |     - |     - |     952 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,868.6 ns | 13.02 ns | 10.87 ns |  0.56 |    0.00 | 0.3433 |     - |     - |     720 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,264.1 ns | 10.27 ns |  9.61 ns |  1.00 |    0.00 | 0.3700 |     - |     - |     776 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,212.4 ns |  5.85 ns |  5.19 ns |  0.96 |    0.01 | 0.1297 |     - |     - |     272 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,308.1 ns |  7.94 ns |  7.04 ns |  1.04 |    0.01 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 1,284.0 ns |  9.48 ns |  8.87 ns |  1.00 |    0.00 | 0.3681 |     - |     - |     776 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 | 1,217.6 ns |  6.08 ns |  5.08 ns |  0.95 |    0.01 | 0.1297 |     - |     - |     272 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 | 1,292.9 ns |  5.11 ns |  4.53 ns |  1.01 |    0.01 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 | 1,287.8 ns |  8.44 ns |  7.48 ns |  1.00 |    0.00 | 0.3700 |     - |     - |     776 B |
|           StructLinq_List_Reference |            List_Reference |   100 | 1,268.3 ns |  4.33 ns |  3.84 ns |  0.98 |    0.01 | 0.1297 |     - |     - |     272 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 | 1,400.0 ns | 14.89 ns | 13.20 ns |  1.09 |    0.01 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 4,972.6 ns | 62.02 ns | 54.98 ns |  1.00 |    0.00 | 0.4501 |     - |     - |     952 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 3,526.4 ns | 39.59 ns | 37.04 ns |  0.71 |    0.01 | 0.3548 |     - |     - |     752 B |
