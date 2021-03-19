## SkipTakeBenchmarks

### Source
[SkipTakeBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SkipTakeBenchmarks.cs)

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
|                              Method |                Categories | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |----- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |  100 |   100 |   902.71 ns |  2.658 ns |  2.219 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|                    StructLinq_Array |                     Array |  100 |   100 |   112.12 ns |  0.192 ns |  0.160 ns |  0.12 |    0.00 |      - |     - |     - |         - |
|                 Hyperlinq_Array_For |                     Array |  100 |   100 |   107.79 ns |  0.367 ns |  0.287 ns |  0.12 |    0.00 |      - |     - |     - |         - |
|             Hyperlinq_Array_Foreach |                     Array |  100 |   100 |   186.24 ns |  0.505 ns |  0.448 ns |  0.21 |    0.00 |      - |     - |     - |         - |
|                  Hyperlinq_Span_For |                     Array |  100 |   100 |    81.25 ns |  0.248 ns |  0.219 ns |  0.09 |    0.00 |      - |     - |     - |         - |
|              Hyperlinq_Span_Foreach |                     Array |  100 |   100 |   172.23 ns |  0.336 ns |  0.298 ns |  0.19 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_Memory_For |                     Array |  100 |   100 |   230.42 ns |  0.646 ns |  0.539 ns |  0.26 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq_Memory_Foreach |                     Array |  100 |   100 |   183.45 ns |  0.349 ns |  0.310 ns |  0.20 |    0.00 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |  100 |   100 | 1,559.15 ns |  6.211 ns |  5.506 ns |  1.00 |    0.00 | 0.0687 |     - |     - |     144 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |  100 |   100 |   994.03 ns |  4.729 ns |  3.692 ns |  0.64 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |  100 |   100 |   475.14 ns |  0.961 ns |  0.852 ns |  0.30 |    0.00 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |  100 |   100 | 1,558.00 ns |  7.834 ns |  6.945 ns |  1.00 |    0.00 | 0.0687 |     - |     - |     144 B |
|         StructLinq_Collection_Value |          Collection_Value |  100 |   100 |   994.20 ns |  3.863 ns |  3.226 ns |  0.64 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |  100 |   100 |   597.12 ns |  3.689 ns |  3.270 ns |  0.38 |    0.00 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |  100 |   100 |   841.66 ns |  2.832 ns |  2.211 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|               StructLinq_List_Value |                List_Value |  100 |   100 |   252.80 ns |  1.332 ns |  1.040 ns |  0.30 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq_List_Value_For |                List_Value |  100 |   100 |   249.39 ns |  1.399 ns |  1.309 ns |  0.30 |    0.00 |      - |     - |     - |         - |
|        Hyperlinq_List_Value_Foreach |                List_Value |  100 |   100 |   220.75 ns |  0.740 ns |  0.618 ns |  0.26 |    0.00 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |  100 |   100 | 8,763.59 ns | 33.055 ns | 30.920 ns |  1.00 |    0.00 | 0.0763 |     - |     - |     176 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |  100 |   100 | 4,701.30 ns | 15.689 ns | 14.676 ns |  0.54 |    0.00 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |  100 |   100 | 1,560.19 ns |  9.015 ns |  7.992 ns |  1.00 |    0.00 | 0.0687 |     - |     - |     144 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |  100 |   100 |   997.33 ns |  3.544 ns |  3.141 ns |  0.64 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |  100 |   100 | 1,098.92 ns |  3.134 ns |  2.778 ns |  0.70 |    0.00 | 0.0153 |     - |     - |      32 B |
|                                     |                           |      |       |             |           |           |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |  100 |   100 | 1,564.56 ns | 10.457 ns |  9.782 ns |  1.00 |    0.00 | 0.0687 |     - |     - |     144 B |
|     StructLinq_Collection_Reference |      Collection_Reference |  100 |   100 |   992.69 ns |  4.468 ns |  4.180 ns |  0.63 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |  100 |   100 | 1,395.36 ns | 24.772 ns | 23.171 ns |  0.89 |    0.02 | 0.0153 |     - |     - |      32 B |
|                                     |                           |      |       |             |           |           |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |  100 |   100 |   839.72 ns |  3.032 ns |  2.532 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|           StructLinq_List_Reference |            List_Reference |  100 |   100 |   993.12 ns |  5.039 ns |  4.467 ns |  1.18 |    0.01 | 0.0153 |     - |     - |      32 B |
|        Hyperlinq_List_Reference_For |            List_Reference |  100 |   100 |   247.86 ns |  0.783 ns |  0.694 ns |  0.30 |    0.00 |      - |     - |     - |         - |
|    Hyperlinq_List_Reference_Foreach |            List_Reference |  100 |   100 |   220.54 ns |  0.657 ns |  0.548 ns |  0.26 |    0.00 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |  100 |   100 | 8,813.65 ns | 35.743 ns | 31.685 ns |  1.00 |    0.00 | 0.0763 |     - |     - |     176 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |  100 |   100 | 5,739.89 ns | 18.257 ns | 17.078 ns |  0.65 |    0.00 | 0.0153 |     - |     - |      32 B |
