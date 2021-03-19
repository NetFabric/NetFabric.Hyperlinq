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
  Job-XHOKQA : .NET 6.0.0 (6.0.21.15406), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |       Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   592.0 ns | 2.18 ns | 1.82 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|                     Hyperlinq_Array |                     Array |   100 |   193.8 ns | 1.53 ns | 1.28 ns |  0.33 |      - |     - |     - |         - |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   757.1 ns | 9.53 ns | 8.92 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   228.8 ns | 1.41 ns | 1.25 ns |  0.30 |      - |     - |     - |         - |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |   750.8 ns | 2.92 ns | 2.74 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   206.9 ns | 1.60 ns | 1.34 ns |  0.28 |      - |     - |     - |         - |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   729.5 ns | 6.13 ns | 5.12 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   614.8 ns | 6.33 ns | 5.92 ns |  0.84 |      - |     - |     - |         - |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,847.2 ns | 9.89 ns | 8.77 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 |   273.3 ns | 1.04 ns | 0.92 ns |  0.15 |      - |     - |     - |         - |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   726.7 ns | 3.21 ns | 3.00 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   780.2 ns | 6.27 ns | 5.23 ns |  1.07 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   754.7 ns | 7.32 ns | 6.11 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   757.3 ns | 3.90 ns | 3.65 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   724.9 ns | 4.12 ns | 3.85 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   611.9 ns | 2.85 ns | 2.66 ns |  0.84 |      - |     - |     - |         - |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,846.2 ns | 6.31 ns | 5.90 ns |  1.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 |   301.6 ns | 2.90 ns | 2.27 ns |  0.16 | 0.0153 |     - |     - |      32 B |
