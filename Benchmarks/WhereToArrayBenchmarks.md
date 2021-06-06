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
  Job-FXRHUT : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |       Mean |    Error |   StdDev |     Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|---------:|---------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   428.2 ns |  2.40 ns |  1.87 ns |   428.3 ns |  1.00 |    0.00 | 0.3519 |     - |     - |     736 B |
|                    StructLinq_Array |                     Array |   100 |   407.5 ns |  2.14 ns |  1.79 ns |   407.6 ns |  0.95 |    0.01 | 0.1144 |     - |     - |     240 B |
|                     Hyperlinq_Array |                     Array |   100 |   479.2 ns |  9.36 ns | 12.50 ns |   486.3 ns |  1.10 |    0.03 | 0.1144 |     - |     - |     240 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,263.4 ns |  5.52 ns |  5.16 ns | 1,262.6 ns |  1.00 |    0.00 | 0.3700 |     - |     - |     776 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,214.8 ns |  8.79 ns |  7.34 ns | 1,215.2 ns |  0.96 |    0.01 | 0.1297 |     - |     - |     272 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   521.3 ns |  3.21 ns |  3.00 ns |   522.0 ns |  0.41 |    0.00 | 0.1144 |     - |     - |     240 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,198.9 ns |  6.14 ns |  5.13 ns | 1,197.5 ns |  1.00 |    0.00 | 0.3700 |     - |     - |     776 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,219.9 ns |  7.23 ns |  6.77 ns | 1,219.3 ns |  1.02 |    0.01 | 0.1297 |     - |     - |     272 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   511.7 ns |  3.86 ns |  3.22 ns |   511.4 ns |  0.43 |    0.00 | 0.1144 |     - |     - |     240 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,204.2 ns | 11.07 ns |  9.81 ns | 1,201.8 ns |  1.00 |    0.00 | 0.3700 |     - |     - |     776 B |
|               StructLinq_List_Value |                List_Value |   100 |   784.4 ns |  4.47 ns |  3.73 ns |   782.6 ns |  0.65 |    0.01 | 0.1144 |     - |     - |     240 B |
|                Hyperlinq_List_Value |                List_Value |   100 | 1,378.5 ns |  7.58 ns |  7.09 ns | 1,377.8 ns |  1.14 |    0.01 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 5,166.4 ns | 63.82 ns | 56.57 ns | 5,169.3 ns |  1.00 |    0.00 | 0.4501 |     - |     - |     952 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,864.9 ns |  6.51 ns |  5.77 ns | 2,864.0 ns |  0.55 |    0.01 | 0.3433 |     - |     - |     720 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,272.1 ns | 23.51 ns | 20.84 ns | 1,276.1 ns |  1.00 |    0.00 | 0.3700 |     - |     - |     776 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,213.1 ns |  3.32 ns |  2.94 ns | 1,213.4 ns |  0.95 |    0.01 | 0.1297 |     - |     - |     272 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,276.6 ns |  5.85 ns |  5.19 ns | 1,275.2 ns |  1.00 |    0.02 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 1,209.8 ns |  7.05 ns |  6.25 ns | 1,208.3 ns |  1.00 |    0.00 | 0.3681 |     - |     - |     776 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 | 1,256.2 ns | 13.17 ns | 12.32 ns | 1,259.2 ns |  1.04 |    0.01 | 0.1297 |     - |     - |     272 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 | 1,253.4 ns |  4.26 ns |  3.55 ns | 1,253.6 ns |  1.04 |    0.01 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 | 1,250.0 ns | 24.34 ns | 25.00 ns | 1,259.9 ns |  1.00 |    0.00 | 0.3700 |     - |     - |     776 B |
|           StructLinq_List_Reference |            List_Reference |   100 | 1,227.7 ns | 23.37 ns | 22.95 ns | 1,215.7 ns |  0.98 |    0.04 | 0.1297 |     - |     - |     272 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 | 1,378.1 ns | 15.40 ns | 14.41 ns | 1,380.6 ns |  1.11 |    0.02 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 4,982.8 ns | 81.41 ns | 76.15 ns | 4,932.3 ns |  1.00 |    0.00 | 0.4501 |     - |     - |     952 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 3,509.2 ns |  9.72 ns |  7.59 ns | 3,509.3 ns |  0.70 |    0.01 | 0.3548 |     - |     - |     752 B |
