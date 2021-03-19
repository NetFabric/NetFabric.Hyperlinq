## SumBenchmarks

### Source
[SumBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SumBenchmarks.cs)

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
|                              Method |                Categories | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   425.27 ns |  2.881 ns |  2.695 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|                    StructLinq_Array |                     Array |   100 |    65.84 ns |  0.273 ns |  0.242 ns |  0.15 |    0.00 |      - |     - |     - |         - |
|                LinqFasterSIMD_Array |                     Array |   100 |    10.69 ns |  0.044 ns |  0.041 ns |  0.03 |    0.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |    23.66 ns |  0.072 ns |  0.068 ns |  0.06 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   634.67 ns |  2.631 ns |  2.054 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   605.39 ns |  3.714 ns |  3.474 ns |  0.95 |    0.01 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   219.93 ns |  0.603 ns |  0.534 ns |  0.35 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |   634.89 ns |  3.052 ns |  2.706 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   602.10 ns |  2.106 ns |  1.867 ns |  0.95 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   219.81 ns |  0.299 ns |  0.265 ns |  0.35 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   633.89 ns |  4.020 ns |  3.761 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|               StructLinq_List_Value |                List_Value |   100 |   225.58 ns |  3.444 ns |  4.939 ns |  0.36 |    0.01 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |   538.85 ns |  1.711 ns |  1.517 ns |  0.85 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,758.59 ns |  4.769 ns |  4.227 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 |   991.61 ns |  3.324 ns |  2.947 ns |  0.56 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   630.94 ns |  2.925 ns |  2.736 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   604.48 ns |  2.336 ns |  2.071 ns |  0.96 |    0.01 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   634.73 ns |  2.188 ns |  1.939 ns |  1.01 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   632.99 ns |  3.984 ns |  3.532 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   603.76 ns |  2.819 ns |  2.354 ns |  0.95 |    0.01 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   627.49 ns |  1.632 ns |  1.447 ns |  0.99 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   647.44 ns | 11.664 ns | 19.806 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   604.37 ns |  1.283 ns |  1.137 ns |  0.92 |    0.03 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   494.88 ns |  2.268 ns |  1.894 ns |  0.75 |    0.03 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,757.92 ns |  4.957 ns |  4.139 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,776.30 ns |  4.838 ns |  4.288 ns |  1.01 |    0.00 | 0.0153 |     - |     - |      32 B |
