## SingleBenchmarks

### Source
[SingleBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SingleBenchmarks.cs)

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
  Job-QTIORM : .NET 6.0.0 (6.0.21.15406), X64 RyuJIT

Runtime=.NET 6.0  

```
|                         Method |                Categories |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |-------------------------- |----------:|----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                     Linq_Array |                     Array | 11.111 ns | 0.1723 ns | 0.2783 ns | 11.048 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_Array |                     Array | 14.543 ns | 0.1511 ns | 0.1339 ns | 14.520 ns |  1.31 |    0.03 |      - |     - |     - |         - |
|                                |                           |           |           |           |           |       |         |        |       |       |           |
|          Linq_Enumerable_Value |          Enumerable_Value | 31.916 ns | 1.9593 ns | 5.7769 ns | 29.905 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_Enumerable_Value |          Enumerable_Value | 17.802 ns | 0.0964 ns | 0.0805 ns | 17.776 ns |  0.58 |    0.08 |      - |     - |     - |         - |
|                                |                           |           |           |           |           |       |         |        |       |       |           |
|          Linq_Collection_Value |          Collection_Value | 33.340 ns | 1.2638 ns | 3.7263 ns | 33.084 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_Collection_Value |          Collection_Value | 21.505 ns | 0.4538 ns | 0.8299 ns | 21.617 ns |  0.67 |    0.06 |      - |     - |     - |         - |
|                                |                           |           |           |           |           |       |         |        |       |       |           |
|                Linq_List_Value |                List_Value |  8.142 ns | 0.1845 ns | 0.1895 ns |  8.073 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|           Hyperlinq_List_Value |                List_Value | 17.170 ns | 0.5859 ns | 1.7275 ns | 16.305 ns |  2.11 |    0.25 |      - |     - |     - |         - |
|                                |                           |           |           |           |           |       |         |        |       |       |           |
|     Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value | 87.198 ns | 0.7828 ns | 0.6940 ns | 87.109 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|                                |                           |           |           |           |           |       |         |        |       |       |           |
|      Linq_Enumerable_Reference |      Enumerable_Reference | 27.682 ns | 0.5862 ns | 0.6751 ns | 27.613 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_Enumerable_Reference |      Enumerable_Reference | 29.365 ns | 1.7127 ns | 5.0498 ns | 27.674 ns |  1.11 |    0.22 | 0.0153 |     - |     - |      32 B |
|                                |                           |           |           |           |           |       |         |        |       |       |           |
|      Linq_Collection_Reference |      Collection_Reference | 29.387 ns | 0.6172 ns | 1.6152 ns | 28.745 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_Collection_Reference |      Collection_Reference | 26.202 ns | 0.7604 ns | 2.1447 ns | 26.031 ns |  0.89 |    0.10 | 0.0153 |     - |     - |      32 B |
|                                |                           |           |           |           |           |       |         |        |       |       |           |
|            Linq_List_Reference |            List_Reference |  7.951 ns | 0.1252 ns | 0.1171 ns |  7.915 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|       Hyperlinq_List_Reference |            List_Reference | 16.146 ns | 0.3480 ns | 0.6276 ns | 16.051 ns |  2.03 |    0.08 |      - |     - |     - |         - |
|                                |                           |           |           |           |           |       |         |        |       |       |           |
| Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference | 89.215 ns | 1.7324 ns | 2.2526 ns | 88.796 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
