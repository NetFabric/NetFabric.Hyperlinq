## WhereToListBenchmarks

### Source
[WhereToListBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereToListBenchmarks.cs)

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
|                          Linq_Array |                     Array |   100 |   373.3 ns |  2.27 ns |  2.01 ns |   372.5 ns |  1.00 |    0.00 | 0.3328 |     - |     - |     696 B |
|                    StructLinq_Array |                     Array |   100 |   433.8 ns |  8.41 ns | 10.94 ns |   437.8 ns |  1.15 |    0.03 | 0.1297 |     - |     - |     272 B |
|                     Hyperlinq_Array |                     Array |   100 |   505.5 ns |  4.81 ns |  4.26 ns |   505.0 ns |  1.35 |    0.01 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,214.5 ns | 24.06 ns | 32.12 ns | 1,229.1 ns |  1.00 |    0.00 | 0.3510 |     - |     - |     736 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,215.9 ns |  4.24 ns |  3.76 ns | 1,217.0 ns |  1.02 |    0.03 | 0.1450 |     - |     - |     304 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   595.6 ns | 11.89 ns | 15.03 ns |   601.2 ns |  0.49 |    0.01 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,134.4 ns | 17.77 ns | 16.62 ns | 1,129.1 ns |  1.00 |    0.00 | 0.3510 |     - |     - |     736 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,204.6 ns |  5.24 ns |  4.64 ns | 1,204.5 ns |  1.06 |    0.02 | 0.1450 |     - |     - |     304 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   547.6 ns | 10.83 ns | 14.83 ns |   539.4 ns |  0.49 |    0.01 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,185.0 ns |  5.28 ns |  4.94 ns | 1,186.8 ns |  1.00 |    0.00 | 0.3510 |     - |     - |     736 B |
|               StructLinq_List_Value |                List_Value |   100 |   833.5 ns | 12.80 ns | 11.35 ns |   838.7 ns |  0.70 |    0.01 | 0.1297 |     - |     - |     272 B |
|                Hyperlinq_List_Value |                List_Value |   100 | 1,341.0 ns |  4.99 ns |  4.16 ns | 1,340.4 ns |  1.13 |    0.01 | 0.1450 |     - |     - |     304 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 5,001.7 ns | 12.64 ns | 11.83 ns | 4,997.4 ns |  1.00 |    0.00 | 0.3510 |     - |     - |     744 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,917.6 ns |  8.45 ns |  7.90 ns | 2,916.6 ns |  0.58 |    0.00 | 0.3586 |     - |     - |     752 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,195.3 ns |  5.12 ns |  4.54 ns | 1,194.5 ns |  1.00 |    0.00 | 0.3510 |     - |     - |     736 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,209.6 ns |  4.29 ns |  3.81 ns | 1,208.7 ns |  1.01 |    0.00 | 0.1450 |     - |     - |     304 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,340.5 ns | 15.32 ns | 14.33 ns | 1,343.2 ns |  1.12 |    0.01 | 0.1450 |     - |     - |     304 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 1,130.9 ns |  6.35 ns |  5.63 ns | 1,130.3 ns |  1.00 |    0.00 | 0.3510 |     - |     - |     736 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 | 1,282.0 ns | 15.81 ns | 14.02 ns | 1,283.2 ns |  1.13 |    0.02 | 0.1450 |     - |     - |     304 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 | 1,328.9 ns |  6.41 ns |  5.35 ns | 1,328.5 ns |  1.18 |    0.01 | 0.1450 |     - |     - |     304 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 | 1,136.4 ns |  5.65 ns |  5.28 ns | 1,135.3 ns |  1.00 |    0.00 | 0.3510 |     - |     - |     736 B |
|           StructLinq_List_Reference |            List_Reference |   100 | 1,239.8 ns | 23.55 ns | 22.03 ns | 1,246.9 ns |  1.09 |    0.02 | 0.1450 |     - |     - |     304 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 | 1,323.3 ns |  3.51 ns |  3.11 ns | 1,323.2 ns |  1.16 |    0.01 | 0.1450 |     - |     - |     304 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 4,943.3 ns | 23.97 ns | 21.25 ns | 4,938.7 ns |  1.00 |    0.00 | 0.3510 |     - |     - |     744 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 3,667.0 ns | 34.22 ns | 30.34 ns | 3,672.5 ns |  0.74 |    0.01 | 0.3738 |     - |     - |     784 B |
