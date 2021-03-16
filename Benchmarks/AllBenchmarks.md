## AllBenchmarks

### Source
[AllBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/AllBenchmarks.cs)

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
  Job-KXCEYC : .NET 6.0.0 (6.0.21.15406), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |       Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   595.0 ns | 4.34 ns | 4.06 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|                     Hyperlinq_Array |                     Array |   100 |   192.7 ns | 0.61 ns | 0.51 ns |  0.32 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |         |         |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   749.5 ns | 2.53 ns | 2.37 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   228.9 ns | 2.89 ns | 2.42 ns |  0.31 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |         |         |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |   754.4 ns | 7.67 ns | 7.17 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   206.9 ns | 1.72 ns | 1.34 ns |  0.27 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |         |         |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   748.2 ns | 3.10 ns | 2.90 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   611.6 ns | 2.82 ns | 2.50 ns |  0.82 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |         |         |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,871.6 ns | 3.28 ns | 3.07 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 |   274.0 ns | 0.63 ns | 0.59 ns |  0.15 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |         |         |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   731.6 ns | 9.35 ns | 8.75 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   777.0 ns | 3.04 ns | 2.54 ns |  1.06 |    0.02 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |         |         |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   723.4 ns | 2.88 ns | 2.55 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   757.4 ns | 4.79 ns | 4.48 ns |  1.05 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |         |         |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   726.2 ns | 4.17 ns | 3.69 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   610.9 ns | 1.23 ns | 1.15 ns |  0.84 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |         |         |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,866.5 ns | 4.85 ns | 3.79 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 |   302.5 ns | 1.93 ns | 1.80 ns |  0.16 |    0.00 | 0.0153 |     - |     - |      32 B |
