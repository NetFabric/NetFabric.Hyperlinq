## SelectSumBenchmarks

### Source
[SelectSumBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectSumBenchmarks.cs)

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
|                              Method |                Categories | Count |        Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   624.04 ns |  3.238 ns |  3.029 ns |  1.00 | 0.0229 |     - |     - |      48 B |
|                    StructLinq_Array |                     Array |   100 |   206.45 ns |  0.546 ns |  0.456 ns |  0.33 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |   200.01 ns |  0.456 ns |  0.404 ns |  0.32 |      - |     - |     - |         - |
|                Hyperlinq_Array_SIMD |                     Array |   100 |    66.82 ns |  0.265 ns |  0.234 ns |  0.11 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,160.78 ns |  6.146 ns |  5.448 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   776.38 ns |  4.821 ns |  4.509 ns |  0.67 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   204.93 ns |  0.518 ns |  0.433 ns |  0.18 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,164.42 ns |  2.973 ns |  2.781 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   795.29 ns |  2.956 ns |  2.468 ns |  0.68 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   213.97 ns |  0.790 ns |  0.700 ns |  0.18 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,174.97 ns |  7.585 ns |  7.095 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|               StructLinq_List_Value |                List_Value |   100 |   347.10 ns |  1.846 ns |  1.636 ns |  0.30 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |   619.75 ns |  2.497 ns |  2.085 ns |  0.53 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 7,626.26 ns | 25.790 ns | 22.863 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,295.19 ns |  6.061 ns |  5.373 ns |  0.30 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,166.44 ns |  2.742 ns |  2.430 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   780.54 ns |  4.485 ns |  4.196 ns |  0.67 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   769.02 ns |  3.871 ns |  3.431 ns |  0.66 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 1,160.10 ns |  6.752 ns |  5.985 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   791.96 ns |  2.826 ns |  2.360 ns |  0.68 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   744.96 ns |  3.601 ns |  3.192 ns |  0.64 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 | 1,170.01 ns |  6.032 ns |  5.347 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   772.95 ns |  4.429 ns |  3.926 ns |  0.66 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   692.92 ns |  3.153 ns |  2.950 ns |  0.59 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 7,577.98 ns | 27.143 ns | 24.062 ns |  1.00 | 0.0458 |     - |     - |      96 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 3,061.96 ns |  6.833 ns |  6.057 ns |  0.40 | 0.0153 |     - |     - |      32 B |
