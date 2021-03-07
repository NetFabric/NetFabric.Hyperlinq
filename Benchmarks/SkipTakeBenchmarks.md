## SkipTakeBenchmarks

### Source
[SkipTakeBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SkipTakeBenchmarks.cs)

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
|                              Method |                Categories | Skip | Count |        Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |----- |------ |------------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |  100 |   100 |   846.48 ns |  3.804 ns |  3.177 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|                    StructLinq_Array |                     Array |  100 |   100 |   111.68 ns |  0.246 ns |  0.218 ns |  0.13 |      - |     - |     - |         - |
|                 Hyperlinq_Array_For |                     Array |  100 |   100 |   145.65 ns |  0.518 ns |  0.459 ns |  0.17 |      - |     - |     - |         - |
|             Hyperlinq_Array_Foreach |                     Array |  100 |   100 |   189.99 ns |  0.272 ns |  0.241 ns |  0.22 |      - |     - |     - |         - |
|                  Hyperlinq_Span_For |                     Array |  100 |   100 |    79.05 ns |  0.276 ns |  0.244 ns |  0.09 |      - |     - |     - |         - |
|              Hyperlinq_Span_Foreach |                     Array |  100 |   100 |   170.71 ns |  0.342 ns |  0.320 ns |  0.20 |      - |     - |     - |         - |
|                Hyperlinq_Memory_For |                     Array |  100 |   100 |   228.00 ns |  0.720 ns |  0.639 ns |  0.27 |      - |     - |     - |         - |
|            Hyperlinq_Memory_Foreach |                     Array |  100 |   100 |   182.67 ns |  0.344 ns |  0.287 ns |  0.22 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |  100 |   100 | 1,494.82 ns |  6.351 ns |  5.303 ns |  1.00 | 0.0687 |     - |     - |     144 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |  100 |   100 |   945.83 ns |  2.901 ns |  2.423 ns |  0.63 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |  100 |   100 |   463.76 ns |  1.433 ns |  2.315 ns |  0.31 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |  100 |   100 | 1,501.40 ns |  5.567 ns |  5.207 ns |  1.00 | 0.0687 |     - |     - |     144 B |
|         StructLinq_Collection_Value |          Collection_Value |  100 |   100 |   979.17 ns |  6.112 ns |  5.418 ns |  0.65 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |  100 |   100 |   582.81 ns |  3.473 ns |  3.249 ns |  0.39 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |  100 |   100 |   799.22 ns |  2.044 ns |  1.812 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|               StructLinq_List_Value |                List_Value |  100 |   100 |   225.79 ns |  0.645 ns |  0.572 ns |  0.28 |      - |     - |     - |         - |
|            Hyperlinq_List_Value_For |                List_Value |  100 |   100 |   272.12 ns |  1.604 ns |  1.422 ns |  0.34 |      - |     - |     - |         - |
|        Hyperlinq_List_Value_Foreach |                List_Value |  100 |   100 |   218.83 ns |  0.800 ns |  0.748 ns |  0.27 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |  100 |   100 | 9,847.17 ns | 37.430 ns | 29.223 ns |  1.00 | 0.0763 |     - |     - |     184 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |  100 |   100 | 5,320.57 ns | 15.831 ns | 14.034 ns |  0.54 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |  100 |   100 | 1,207.93 ns |  6.363 ns |  5.641 ns |  1.00 | 0.0687 |     - |     - |     144 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |  100 |   100 |   688.33 ns |  1.229 ns |  1.090 ns |  0.57 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |  100 |   100 |   786.62 ns |  2.724 ns |  2.415 ns |  0.65 | 0.0153 |     - |     - |      32 B |
|                                     |                           |      |       |             |           |           |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |  100 |   100 | 1,207.22 ns |  5.200 ns |  4.610 ns |  1.00 | 0.0687 |     - |     - |     144 B |
|     StructLinq_Collection_Reference |      Collection_Reference |  100 |   100 |   687.22 ns |  2.674 ns |  2.501 ns |  0.57 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |  100 |   100 |   865.87 ns |  4.442 ns |  4.155 ns |  0.72 | 0.0153 |     - |     - |      32 B |
|                                     |                           |      |       |             |           |           |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |  100 |   100 |   843.55 ns |  2.449 ns |  2.171 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|           StructLinq_List_Reference |            List_Reference |  100 |   100 |   687.43 ns |  2.511 ns |  2.097 ns |  0.81 | 0.0153 |     - |     - |      32 B |
|        Hyperlinq_List_Reference_For |            List_Reference |  100 |   100 |   264.36 ns |  1.727 ns |  1.615 ns |  0.31 |      - |     - |     - |         - |
|    Hyperlinq_List_Reference_Foreach |            List_Reference |  100 |   100 |   218.84 ns |  0.611 ns |  0.542 ns |  0.26 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |  100 |   100 | 9,706.23 ns | 34.481 ns | 32.253 ns |  1.00 | 0.0763 |     - |     - |     184 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |  100 |   100 | 6,202.58 ns | 16.734 ns | 15.653 ns |  0.64 | 0.0153 |     - |     - |      40 B |
