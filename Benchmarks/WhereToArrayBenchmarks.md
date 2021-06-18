## WhereToArrayBenchmarks

### Source
[WhereToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereToArrayBenchmarks.cs)

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
|                              Method |                Categories | Count |       Mean |    Error |   StdDev |     Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|---------:|---------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   424.1 ns |  8.54 ns | 16.45 ns |   415.1 ns |  1.00 |    0.00 | 0.3519 |     - |     - |     736 B |
|                    StructLinq_Array |                     Array |   100 |   410.3 ns |  7.67 ns | 13.23 ns |   403.1 ns |  0.97 |    0.02 | 0.1144 |     - |     - |     240 B |
|                     Hyperlinq_Array |                     Array |   100 |   513.2 ns |  5.71 ns |  5.06 ns |   512.0 ns |  1.16 |    0.05 | 0.1144 |     - |     - |     240 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,389.3 ns |  8.52 ns |  7.55 ns | 1,387.9 ns |  1.00 |    0.00 | 0.3700 |     - |     - |     776 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,179.6 ns |  6.07 ns |  5.68 ns | 1,179.8 ns |  0.85 |    0.01 | 0.1297 |     - |     - |     272 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   545.9 ns |  5.84 ns |  5.47 ns |   545.0 ns |  0.39 |    0.00 | 0.1144 |     - |     - |     240 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,300.4 ns |  8.52 ns |  7.97 ns | 1,300.4 ns |  1.00 |    0.00 | 0.3700 |     - |     - |     776 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,185.6 ns |  5.33 ns |  4.72 ns | 1,186.7 ns |  0.91 |    0.01 | 0.1297 |     - |     - |     272 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   522.6 ns |  2.02 ns |  1.69 ns |   522.5 ns |  0.40 |    0.00 | 0.1144 |     - |     - |     240 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,355.6 ns | 25.15 ns | 27.96 ns | 1,367.7 ns |  1.00 |    0.00 | 0.3700 |     - |     - |     776 B |
|               StructLinq_List_Value |                List_Value |   100 |   812.9 ns |  3.54 ns |  3.14 ns |   813.1 ns |  0.60 |    0.01 | 0.1144 |     - |     - |     240 B |
|                Hyperlinq_List_Value |                List_Value |   100 | 1,370.0 ns |  8.07 ns |  7.15 ns | 1,366.5 ns |  1.02 |    0.02 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 5,086.6 ns | 49.27 ns | 43.68 ns | 5,070.8 ns |  1.00 |    0.00 | 0.4501 |     - |     - |     952 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,883.8 ns | 10.40 ns |  9.22 ns | 2,883.1 ns |  0.57 |    0.01 | 0.3357 |     - |     - |     720 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,282.7 ns |  4.93 ns |  4.37 ns | 1,282.7 ns |  1.00 |    0.00 | 0.3700 |     - |     - |     776 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,192.7 ns |  8.80 ns |  7.80 ns | 1,191.1 ns |  0.93 |    0.01 | 0.1297 |     - |     - |     272 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,327.2 ns | 20.85 ns | 19.50 ns | 1,329.5 ns |  1.03 |    0.02 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 1,355.8 ns |  7.95 ns |  7.43 ns | 1,354.1 ns |  1.00 |    0.00 | 0.3700 |     - |     - |     776 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 | 1,190.5 ns |  9.14 ns |  7.13 ns | 1,188.1 ns |  0.88 |    0.01 | 0.1297 |     - |     - |     272 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 | 1,324.2 ns | 22.65 ns | 21.19 ns | 1,331.9 ns |  0.98 |    0.02 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 | 1,283.1 ns |  7.13 ns |  6.32 ns | 1,281.3 ns |  1.00 |    0.00 | 0.3700 |     - |     - |     776 B |
|           StructLinq_List_Reference |            List_Reference |   100 | 1,226.3 ns | 10.26 ns |  9.60 ns | 1,225.4 ns |  0.96 |    0.01 | 0.1297 |     - |     - |     272 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 | 1,343.9 ns |  7.08 ns |  6.28 ns | 1,344.4 ns |  1.05 |    0.01 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5,045.7 ns | 22.45 ns | 17.53 ns | 5,052.5 ns |  1.00 |    0.00 | 0.4501 |     - |     - |     952 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 3,620.7 ns | 12.19 ns | 11.40 ns | 3,622.7 ns |  0.72 |    0.00 | 0.3548 |     - |     - |     752 B |
