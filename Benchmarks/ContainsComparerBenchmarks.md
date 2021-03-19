## ContainsComparerBenchmarks

### Source
[ContainsComparerBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ContainsComparerBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.2.21154.6
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1521-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.2.21155.3
  [Host]     : .NET 6.0.0 (6.0.21.15406), X64 RyuJIT
  Job-XHOKQA : .NET 6.0.0 (6.0.21.15406), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |       Mean |    Error |   StdDev |     Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|---------:|---------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   578.2 ns |  3.96 ns |  3.51 ns |   577.6 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|                     Hyperlinq_Array |                     Array |   100 |   202.2 ns |  4.07 ns |  3.61 ns |   200.9 ns |  0.35 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   791.8 ns |  4.20 ns |  3.72 ns |   790.5 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   331.3 ns |  1.38 ns |  1.22 ns |   331.7 ns |  0.42 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |   762.0 ns |  2.87 ns |  2.69 ns |   761.8 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   334.3 ns |  1.35 ns |  1.20 ns |   333.9 ns |  0.44 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   792.8 ns |  7.00 ns |  6.20 ns |   790.8 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   651.0 ns |  2.01 ns |  1.88 ns |   651.6 ns |  0.82 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,881.0 ns | 24.51 ns | 42.93 ns | 1,865.7 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,130.2 ns |  6.01 ns |  4.69 ns | 1,129.5 ns |  0.59 |    0.02 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   799.4 ns | 13.46 ns | 23.58 ns |   790.3 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   796.2 ns | 15.83 ns | 15.55 ns |   789.4 ns |  0.99 |    0.05 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   763.8 ns |  3.89 ns |  3.45 ns |   763.3 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   839.9 ns | 16.22 ns | 21.66 ns |   827.3 ns |  1.10 |    0.03 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   760.8 ns |  2.52 ns |  2.23 ns |   760.6 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   679.7 ns |  5.17 ns |  4.58 ns |   679.4 ns |  0.89 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,866.1 ns |  3.78 ns |  3.35 ns | 1,866.0 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,870.3 ns |  3.93 ns |  3.48 ns | 1,871.0 ns |  1.00 |    0.00 | 0.0267 |     - |     - |      56 B |
