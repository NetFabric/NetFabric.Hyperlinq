## SkipTakeBenchmarks

### Source
[SkipTakeBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SkipTakeBenchmarks.cs)

### References:
- Linq: 5.0.0-preview.7.20364.11
- System.Linq.Async: [4.1.1](https://www.nuget.org/packages/System.Linq.Async/4.1.1)
- System.Interactive: [4.1.1](https://www.nuget.org/packages/System.Interactive/4.1.1)
- System.Interactive.Async: [4.1.1](https://www.nuget.org/packages/System.Interactive.Async/4.1.1)
- StructLinq: [0.19.2](https://www.nuget.org/packages/StructLinq/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                              Method |                Categories | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |----- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |  100 |   100 |   882.03 ns |  4.288 ns |  3.580 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|                    StructLinq_Array |                     Array |  100 |   100 |    50.50 ns |  0.183 ns |  0.153 ns |  0.06 |    0.00 |      - |     - |     - |         - |
|                 Hyperlinq_Array_For |                     Array |  100 |   100 |    64.35 ns |  0.542 ns |  0.507 ns |  0.07 |    0.00 |      - |     - |     - |         - |
|             Hyperlinq_Array_Foreach |                     Array |  100 |   100 |   309.32 ns |  2.518 ns |  2.355 ns |  0.35 |    0.00 |      - |     - |     - |         - |
|                  Hyperlinq_Span_For |                     Array |  100 |   100 |   114.42 ns |  0.371 ns |  0.329 ns |  0.13 |    0.00 |      - |     - |     - |         - |
|              Hyperlinq_Span_Foreach |                     Array |  100 |   100 |    50.41 ns |  0.269 ns |  0.251 ns |  0.06 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_Memory_For |                     Array |  100 |   100 |    65.94 ns |  0.335 ns |  0.313 ns |  0.07 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq_Memory_Foreach |                     Array |  100 |   100 |    53.96 ns |  0.257 ns |  0.228 ns |  0.06 |    0.00 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |  100 |   100 | 1,513.98 ns |  8.018 ns |  7.500 ns |  1.00 |    0.00 | 0.0687 |     - |     - |     144 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |  100 |   100 | 1,087.50 ns |  6.837 ns |  6.395 ns |  0.72 |    0.01 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |  100 |   100 |   442.49 ns |  2.364 ns |  1.974 ns |  0.29 |    0.00 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |  100 |   100 | 1,506.33 ns |  7.955 ns |  7.052 ns |  1.00 |    0.00 | 0.0687 |     - |     - |     144 B |
|         StructLinq_Collection_Value |          Collection_Value |  100 |   100 | 1,075.43 ns |  7.924 ns |  7.024 ns |  0.71 |    0.01 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |  100 |   100 |   605.61 ns |  6.020 ns |  5.631 ns |  0.40 |    0.00 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |  100 |   100 |   805.01 ns |  4.916 ns |  4.358 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|               StructLinq_List_Value |                List_Value |  100 |   100 | 1,081.14 ns | 11.562 ns | 10.815 ns |  1.34 |    0.02 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Value_For |                List_Value |  100 |   100 |   385.57 ns |  2.414 ns |  2.016 ns |  0.48 |    0.00 |      - |     - |     - |         - |
|        Hyperlinq_List_Value_Foreach |                List_Value |  100 |   100 |   254.97 ns |  1.897 ns |  1.682 ns |  0.32 |    0.00 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |  100 |   100 | 9,969.12 ns | 43.532 ns | 38.590 ns |  1.00 |    0.00 | 0.1221 |     - |     - |     256 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |  100 |   100 | 5,381.01 ns | 24.437 ns | 20.406 ns |  0.54 |    0.00 | 0.0305 |     - |     - |      72 B |
|                                     |                           |      |       |             |           |           |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |  100 |   100 | 1,199.91 ns |  9.332 ns |  8.730 ns |  1.00 |    0.00 | 0.0687 |     - |     - |     144 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |  100 |   100 |   775.38 ns |  5.587 ns |  4.665 ns |  0.65 |    0.01 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |  100 |   100 |   860.30 ns |  6.250 ns |  5.847 ns |  0.72 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |      |       |             |           |           |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |  100 |   100 | 1,202.78 ns |  7.195 ns |  6.730 ns |  1.00 |    0.00 | 0.0687 |     - |     - |     144 B |
|     StructLinq_Collection_Reference |      Collection_Reference |  100 |   100 |   776.91 ns |  8.023 ns |  6.699 ns |  0.65 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |  100 |   100 |   870.66 ns |  7.764 ns |  6.484 ns |  0.72 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |      |       |             |           |           |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |  100 |   100 |   800.49 ns |  6.140 ns |  5.443 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|           StructLinq_List_Reference |            List_Reference |  100 |   100 |   773.54 ns |  4.623 ns |  4.098 ns |  0.97 |    0.01 | 0.0153 |     - |     - |      32 B |
|        Hyperlinq_List_Reference_For |            List_Reference |  100 |   100 |   389.07 ns |  1.969 ns |  1.842 ns |  0.49 |    0.00 |      - |     - |     - |         - |
|    Hyperlinq_List_Reference_Foreach |            List_Reference |  100 |   100 |   253.48 ns |  2.256 ns |  1.884 ns |  0.32 |    0.00 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |  100 |   100 | 9,917.00 ns | 92.831 ns | 86.835 ns |  1.00 |    0.00 | 0.1221 |     - |     - |     256 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |  100 |   100 | 6,270.09 ns | 20.287 ns | 18.977 ns |  0.63 |    0.01 | 0.0534 |     - |     - |     112 B |
