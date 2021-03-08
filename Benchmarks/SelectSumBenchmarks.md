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
|                          Linq_Array |                     Array |   100 |   692.87 ns |  2.767 ns |  2.453 ns |  1.00 | 0.0229 |     - |     - |      48 B |
|                    StructLinq_Array |                     Array |   100 |   214.73 ns |  0.767 ns |  0.718 ns |  0.31 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |   207.47 ns |  0.416 ns |  0.368 ns |  0.30 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |   205.35 ns |  0.644 ns |  0.603 ns |  0.30 |      - |     - |     - |         - |
|                 Hyperlinq_Span_SIMD |                     Array |   100 |    66.61 ns |  0.207 ns |  0.173 ns |  0.10 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |   209.77 ns |  0.661 ns |  0.618 ns |  0.30 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,194.20 ns |  6.599 ns |  6.173 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   793.78 ns |  5.633 ns |  5.270 ns |  0.66 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   240.76 ns |  1.062 ns |  0.829 ns |  0.20 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,195.53 ns |  6.403 ns |  5.989 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   835.87 ns |  3.811 ns |  3.378 ns |  0.70 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   224.06 ns |  2.454 ns |  2.049 ns |  0.19 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,200.10 ns |  4.455 ns |  3.720 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|               StructLinq_List_Value |                List_Value |   100 |   356.72 ns |  1.266 ns |  1.184 ns |  0.30 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |   646.35 ns |  3.514 ns |  3.287 ns |  0.54 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 9,275.54 ns | 24.267 ns | 22.700 ns |  1.00 | 0.0458 |     - |     - |     104 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 8,938.92 ns | 46.794 ns | 41.482 ns |  0.96 | 0.0610 |     - |     - |     144 B |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,023.73 ns |  5.340 ns |  4.995 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   599.32 ns |  7.009 ns |  6.213 ns |  0.59 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   565.16 ns |  3.169 ns |  2.474 ns |  0.55 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 1,077.24 ns |  3.703 ns |  3.282 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   591.05 ns |  2.156 ns |  1.800 ns |  0.55 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   626.33 ns |  2.498 ns |  2.086 ns |  0.58 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 | 1,030.33 ns |  4.186 ns |  3.711 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   555.65 ns | 10.817 ns | 10.118 ns |  0.54 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   666.81 ns |  2.437 ns |  2.035 ns |  0.65 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 8,964.39 ns | 19.509 ns | 17.294 ns |  1.00 | 0.0458 |     - |     - |     104 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 9,496.24 ns | 30.034 ns | 28.094 ns |  1.06 | 0.0610 |     - |     - |     152 B |
