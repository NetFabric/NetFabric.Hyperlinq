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
  Job-DUCAQD : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   357.3 ns |  2.79 ns |  2.61 ns |  1.00 |    0.00 | 0.3328 |     - |     - |     696 B |
|                    StructLinq_Array |                     Array |   100 |   416.0 ns |  3.34 ns |  2.96 ns |  1.16 |    0.01 | 0.1297 |     - |     - |     272 B |
|                     Hyperlinq_Array |                     Array |   100 |   495.6 ns |  3.58 ns |  3.34 ns |  1.39 |    0.02 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,164.2 ns |  7.83 ns |  6.94 ns |  1.00 |    0.00 | 0.3510 |     - |     - |     736 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,210.6 ns |  7.88 ns |  7.37 ns |  1.04 |    0.01 | 0.1450 |     - |     - |     304 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   562.4 ns |  4.80 ns |  4.49 ns |  0.48 |    0.01 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,167.3 ns |  9.75 ns |  9.12 ns |  1.00 |    0.00 | 0.3510 |     - |     - |     736 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,211.0 ns |  7.99 ns |  7.47 ns |  1.04 |    0.01 | 0.1450 |     - |     - |     304 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   533.1 ns |  5.77 ns |  4.81 ns |  0.46 |    0.01 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,162.8 ns | 10.44 ns |  9.77 ns |  1.00 |    0.00 | 0.3510 |     - |     - |     736 B |
|               StructLinq_List_Value |                List_Value |   100 |   796.9 ns |  4.09 ns |  3.83 ns |  0.69 |    0.01 | 0.1297 |     - |     - |     272 B |
|                Hyperlinq_List_Value |                List_Value |   100 | 1,372.0 ns |  9.32 ns |  8.27 ns |  1.18 |    0.01 | 0.1450 |     - |     - |     304 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 5,113.3 ns | 21.94 ns | 20.52 ns |  1.00 |    0.00 | 0.3510 |     - |     - |     744 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,916.5 ns | 13.42 ns | 11.89 ns |  0.57 |    0.00 | 0.3586 |     - |     - |     752 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,144.9 ns |  9.20 ns |  8.61 ns |  1.00 |    0.00 | 0.3510 |     - |     - |     736 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,194.5 ns |  7.04 ns |  6.59 ns |  1.04 |    0.01 | 0.1450 |     - |     - |     304 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,360.4 ns |  6.28 ns |  5.87 ns |  1.19 |    0.01 | 0.1450 |     - |     - |     304 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 1,165.1 ns |  5.31 ns |  4.44 ns |  1.00 |    0.00 | 0.3510 |     - |     - |     736 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 | 1,228.7 ns | 24.06 ns | 21.33 ns |  1.06 |    0.02 | 0.1450 |     - |     - |     304 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 | 1,325.4 ns |  9.43 ns |  8.36 ns |  1.14 |    0.01 | 0.1450 |     - |     - |     304 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 | 1,163.3 ns | 10.51 ns |  8.20 ns |  1.00 |    0.00 | 0.3510 |     - |     - |     736 B |
|           StructLinq_List_Reference |            List_Reference |   100 | 1,188.0 ns |  8.48 ns |  7.94 ns |  1.02 |    0.01 | 0.1450 |     - |     - |     304 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 | 1,377.3 ns |  6.38 ns |  5.33 ns |  1.18 |    0.01 | 0.1450 |     - |     - |     304 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 4,962.1 ns | 25.57 ns | 23.92 ns |  1.00 |    0.00 | 0.3510 |     - |     - |     744 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 3,583.2 ns | 11.66 ns | 10.34 ns |  0.72 |    0.00 | 0.3738 |     - |     - |     784 B |
