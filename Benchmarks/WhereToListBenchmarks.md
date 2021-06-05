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
  Job-SUCOWF : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   395.9 ns |  1.46 ns |  2.23 ns |  1.00 |    0.00 | 0.3328 |     - |     - |     696 B |
|                    StructLinq_Array |                     Array |   100 |   427.0 ns |  2.38 ns |  2.11 ns |  1.08 |    0.01 | 0.1297 |     - |     - |     272 B |
|                     Hyperlinq_Array |                     Array |   100 |   487.7 ns |  2.52 ns |  2.24 ns |  1.23 |    0.01 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,188.2 ns |  5.73 ns |  5.36 ns |  1.00 |    0.00 | 0.3510 |     - |     - |     736 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,223.5 ns | 15.17 ns | 22.71 ns |  1.03 |    0.02 | 0.1450 |     - |     - |     304 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   552.2 ns |  9.09 ns |  8.06 ns |  0.46 |    0.01 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,130.1 ns |  5.41 ns |  4.79 ns |  1.00 |    0.00 | 0.3510 |     - |     - |     736 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,232.5 ns |  7.81 ns |  7.31 ns |  1.09 |    0.01 | 0.1450 |     - |     - |     304 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   580.9 ns | 10.97 ns | 10.26 ns |  0.51 |    0.01 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,135.3 ns |  5.03 ns |  4.20 ns |  1.00 |    0.00 | 0.3510 |     - |     - |     736 B |
|               StructLinq_List_Value |                List_Value |   100 |   819.8 ns |  3.41 ns |  2.84 ns |  0.72 |    0.00 | 0.1297 |     - |     - |     272 B |
|                Hyperlinq_List_Value |                List_Value |   100 | 1,375.5 ns |  8.27 ns |  7.33 ns |  1.21 |    0.01 | 0.1450 |     - |     - |     304 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 5,116.5 ns | 21.33 ns | 19.95 ns |  1.00 |    0.00 | 0.3510 |     - |     - |     744 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,956.4 ns | 44.63 ns | 41.75 ns |  0.58 |    0.01 | 0.3586 |     - |     - |     752 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,201.5 ns |  8.47 ns |  7.08 ns |  1.00 |    0.00 | 0.3510 |     - |     - |     736 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,200.7 ns |  4.88 ns |  4.33 ns |  1.00 |    0.01 | 0.1450 |     - |     - |     304 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,297.9 ns | 20.30 ns | 19.94 ns |  1.08 |    0.02 | 0.1450 |     - |     - |     304 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 1,165.1 ns |  3.84 ns |  3.60 ns |  1.00 |    0.00 | 0.3510 |     - |     - |     736 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 | 1,221.9 ns | 21.50 ns | 20.11 ns |  1.05 |    0.02 | 0.1450 |     - |     - |     304 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 | 1,366.8 ns |  3.97 ns |  3.52 ns |  1.17 |    0.00 | 0.1450 |     - |     - |     304 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 | 1,137.7 ns |  7.08 ns |  6.62 ns |  1.00 |    0.00 | 0.3510 |     - |     - |     736 B |
|           StructLinq_List_Reference |            List_Reference |   100 | 1,241.5 ns | 22.59 ns | 17.63 ns |  1.09 |    0.02 | 0.1450 |     - |     - |     304 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 | 1,363.4 ns |  4.61 ns |  3.60 ns |  1.20 |    0.01 | 0.1450 |     - |     - |     304 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5,112.7 ns | 20.47 ns | 18.14 ns |  1.00 |    0.00 | 0.3510 |     - |     - |     744 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 3,583.1 ns | 45.80 ns | 42.84 ns |  0.70 |    0.01 | 0.3738 |     - |     - |     784 B |
