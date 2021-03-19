## WhereSingleBenchmarks

### Source
[WhereSingleBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereSingleBenchmarks.cs)

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
|                         Method |                Categories | Count |       Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |-------------------------- |------ |-----------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|                     Linq_Array |                     Array |   100 |   599.1 ns | 3.34 ns | 2.97 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|                Hyperlinq_Array |                     Array |   100 |   187.4 ns | 0.61 ns | 0.54 ns |  0.31 | 0.0305 |     - |     - |      64 B |
|                                |                           |       |            |         |         |       |        |       |       |           |
|          Linq_Enumerable_Value |          Enumerable_Value |   100 |   803.8 ns | 3.14 ns | 2.78 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|     Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   225.4 ns | 0.87 ns | 0.77 ns |  0.28 | 0.0305 |     - |     - |      64 B |
|                                |                           |       |            |         |         |       |        |       |       |           |
|          Linq_Collection_Value |          Collection_Value |   100 |   770.7 ns | 4.53 ns | 4.02 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|     Hyperlinq_Collection_Value |          Collection_Value |   100 |   226.8 ns | 0.82 ns | 0.72 ns |  0.29 | 0.0305 |     - |     - |      64 B |
|                                |                           |       |            |         |         |       |        |       |       |           |
|                Linq_List_Value |                List_Value |   100 |   770.0 ns | 3.13 ns | 2.77 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|           Hyperlinq_List_Value |                List_Value |   100 |   699.6 ns | 1.56 ns | 1.38 ns |  0.91 | 0.0305 |     - |     - |      64 B |
|                                |                           |       |            |         |         |       |        |       |       |           |
|     Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,910.7 ns | 4.99 ns | 4.67 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|                                |                           |       |            |         |         |       |        |       |       |           |
|      Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   770.5 ns | 4.03 ns | 3.37 ns |  1.00 | 0.0458 |     - |     - |      96 B |
| Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   779.4 ns | 3.55 ns | 3.15 ns |  1.01 | 0.0458 |     - |     - |      96 B |
|                                |                           |       |            |         |         |       |        |       |       |           |
|      Linq_Collection_Reference |      Collection_Reference |   100 |   821.6 ns | 3.66 ns | 3.25 ns |  1.00 | 0.0458 |     - |     - |      96 B |
| Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   752.5 ns | 3.27 ns | 3.06 ns |  0.92 | 0.0458 |     - |     - |      96 B |
|                                |                           |       |            |         |         |       |        |       |       |           |
|            Linq_List_Reference |            List_Reference |   100 |   801.4 ns | 3.33 ns | 3.12 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|       Hyperlinq_List_Reference |            List_Reference |   100 |   635.3 ns | 1.86 ns | 1.56 ns |  0.79 | 0.0305 |     - |     - |      64 B |
|                                |                           |       |            |         |         |       |        |       |       |           |
| Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,938.1 ns | 6.93 ns | 6.14 ns |  1.00 | 0.0458 |     - |     - |      96 B |
