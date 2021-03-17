## WhereFirstBenchmarks

### Source
[WhereFirstBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereFirstBenchmarks.cs)

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
  Job-TQOBKL : .NET 6.0.0 (6.0.21.15406), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |       Mean |    Error |    StdDev |     Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|---------:|----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   650.6 ns |  5.75 ns |   4.49 ns |   651.1 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|                     Hyperlinq_Array |                     Array |   100 |   198.5 ns |  3.99 ns |   6.55 ns |   195.7 ns |  0.31 |    0.01 | 0.0305 |     - |     - |      64 B |
|                                     |                           |       |            |          |           |            |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   808.7 ns | 12.89 ns |  11.43 ns |   807.9 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   230.4 ns |  3.54 ns |   2.76 ns |   230.0 ns |  0.28 |    0.01 | 0.0305 |     - |     - |      64 B |
|                                     |                           |       |            |          |           |            |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |   833.0 ns | 16.62 ns |  39.18 ns |   819.0 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   265.0 ns |  5.19 ns |  13.85 ns |   258.3 ns |  0.32 |    0.02 | 0.0305 |     - |     - |      64 B |
|                                     |                           |       |            |          |           |            |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   870.0 ns | 21.85 ns |  63.03 ns |   847.6 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   645.5 ns | 12.66 ns |  17.75 ns |   639.0 ns |  0.71 |    0.06 | 0.0305 |     - |     - |      64 B |
|                                     |                           |       |            |          |           |            |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,989.3 ns | 36.09 ns |  32.00 ns | 1,973.8 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 3,029.3 ns | 60.12 ns |  59.04 ns | 3,007.0 ns |  1.52 |    0.04 | 0.0305 |     - |     - |      64 B |
|                                     |                           |       |            |          |           |            |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   836.0 ns | 23.27 ns |  66.38 ns |   825.5 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   877.0 ns | 17.50 ns |  41.25 ns |   858.1 ns |  1.06 |    0.08 | 0.0458 |     - |     - |      96 B |
|                                     |                           |       |            |          |           |            |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   858.2 ns | 27.33 ns |  78.85 ns |   829.2 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   891.4 ns | 22.61 ns |  66.67 ns |   877.6 ns |  1.05 |    0.12 | 0.0458 |     - |     - |      96 B |
|                                     |                           |       |            |          |           |            |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   782.1 ns | 15.12 ns |  13.40 ns |   775.3 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   782.2 ns | 15.48 ns |  31.26 ns |   780.2 ns |  1.00 |    0.05 | 0.0305 |     - |     - |      64 B |
|                                     |                           |       |            |          |           |            |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,057.0 ns | 41.10 ns | 103.12 ns | 2,010.2 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 3,424.3 ns | 53.95 ns |  50.47 ns | 3,427.0 ns |  1.60 |    0.09 | 0.0458 |     - |     - |      96 B |
