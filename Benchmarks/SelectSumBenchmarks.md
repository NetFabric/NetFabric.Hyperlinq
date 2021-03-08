## SelectSumBenchmarks

### Source
[SelectSumBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectSumBenchmarks.cs)

### References:
- Linq: 5.0.3
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=6.0.100-preview.1.21103.13
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                              Method |                Categories | Count |        Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   659.75 ns |  4.467 ns |  4.178 ns |  1.00 | 0.0229 |     - |     - |      48 B |
|                    StructLinq_Array |                     Array |   100 |   207.43 ns |  0.844 ns |  0.705 ns |  0.31 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |   201.15 ns |  0.823 ns |  0.770 ns |  0.30 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |   175.19 ns |  0.582 ns |  0.516 ns |  0.27 |      - |     - |     - |         - |
|                 Hyperlinq_Span_SIMD |                     Array |   100 |    64.57 ns |  0.205 ns |  0.171 ns |  0.10 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |   202.96 ns |  0.998 ns |  0.885 ns |  0.31 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,150.40 ns | 10.628 ns |  8.298 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   765.10 ns |  2.783 ns |  2.467 ns |  0.67 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   786.88 ns |  2.525 ns |  2.238 ns |  0.68 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,151.31 ns |  7.958 ns |  6.645 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   805.43 ns |  3.794 ns |  3.168 ns |  0.70 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   744.76 ns |  2.968 ns |  2.478 ns |  0.65 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,152.50 ns |  5.398 ns |  4.508 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|               StructLinq_List_Value |                List_Value |   100 |   346.43 ns |  1.681 ns |  1.404 ns |  0.30 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |   713.29 ns |  2.239 ns |  1.984 ns |  0.62 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 8,810.80 ns | 38.159 ns | 33.827 ns |  1.00 | 0.0458 |     - |     - |     104 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 9,316.79 ns | 32.877 ns | 27.454 ns |  1.06 | 0.0610 |     - |     - |     152 B |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   983.48 ns |  5.646 ns |  5.005 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   575.43 ns |  2.783 ns |  2.467 ns |  0.59 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   532.98 ns |  2.514 ns |  2.228 ns |  0.54 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 1,040.60 ns |  7.677 ns |  7.181 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   558.74 ns |  2.137 ns |  1.894 ns |  0.54 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   603.72 ns |  3.923 ns |  3.477 ns |  0.58 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 | 1,036.29 ns |  4.121 ns |  3.654 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   525.83 ns |  2.909 ns |  2.429 ns |  0.51 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   634.12 ns |  1.165 ns |  1.033 ns |  0.61 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 8,826.89 ns | 24.950 ns | 22.118 ns |  1.00 | 0.0458 |     - |     - |     104 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 8,926.71 ns | 28.612 ns | 26.764 ns |  1.01 | 0.0610 |     - |     - |     152 B |
