## SelectToArrayBenchmarks

### Source
[SelectToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectToArrayBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.4.21253.7
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.13.0.1555-nightly, OS=Windows 10.0.19043.1023 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21255.9
  [Host]     : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT
  Job-FXRHUT : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|----------:|----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   263.39 ns |  1.174 ns |  1.041 ns |   263.24 ns |  1.00 |    0.00 | 0.2255 |     - |     - |     472 B |
|                    StructLinq_Array |                     Array |   100 |   233.94 ns |  4.618 ns |  8.787 ns |   229.90 ns |  0.93 |    0.04 | 0.2027 |     - |     - |     424 B |
|                LinqFasterSIMD_Array |                     Array |   100 |    66.14 ns |  0.757 ns |  0.671 ns |    66.26 ns |  0.25 |    0.00 | 0.2027 |     - |     - |     424 B |
|                     Hyperlinq_Array |                     Array |   100 |   272.16 ns |  1.452 ns |  1.358 ns |   271.94 ns |  1.03 |    0.01 | 0.2027 |     - |     - |     424 B |
|                Hyperlinq_Array_SIMD |                     Array |   100 |    83.63 ns |  0.812 ns |  0.720 ns |    83.73 ns |  0.32 |    0.00 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,043.22 ns |  4.723 ns |  4.187 ns | 1,043.66 ns |  1.00 |    0.00 | 0.5913 |     - |     - |   1,240 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,067.19 ns |  7.687 ns |  6.814 ns | 1,066.65 ns |  1.02 |    0.01 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   592.14 ns |  2.533 ns |  2.369 ns |   592.28 ns |  0.57 |    0.00 | 0.2022 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,044.28 ns |  4.906 ns |  4.589 ns | 1,042.96 ns |  1.00 |    0.00 | 0.5913 |     - |     - |   1,240 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,070.18 ns |  7.330 ns |  6.121 ns | 1,069.23 ns |  1.02 |    0.01 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   300.70 ns |  1.466 ns |  1.300 ns |   300.77 ns |  0.29 |    0.00 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   474.07 ns |  9.454 ns | 17.988 ns |   461.17 ns |  1.00 |    0.00 | 0.2294 |     - |     - |     480 B |
|               StructLinq_List_Value |                List_Value |   100 |   496.84 ns |  8.562 ns |  8.009 ns |   499.34 ns |  1.06 |    0.04 | 0.2027 |     - |     - |     424 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   926.74 ns | 18.420 ns | 24.590 ns |   933.41 ns |  1.94 |    0.07 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 7,448.67 ns | 26.093 ns | 23.131 ns | 7,454.25 ns |  1.00 |    0.00 | 0.7935 |     - |     - |   1,672 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,347.19 ns |  6.148 ns |  5.450 ns | 2,347.48 ns |  0.32 |    0.00 | 0.5646 |     - |     - |   1,184 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,039.00 ns |  5.957 ns |  5.573 ns | 1,038.81 ns |  1.00 |    0.00 | 0.5913 |     - |     - |   1,240 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,068.03 ns |  5.654 ns |  5.012 ns | 1,066.01 ns |  1.03 |    0.01 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,066.39 ns |  4.384 ns |  3.886 ns | 1,066.37 ns |  1.03 |    0.01 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 1,038.34 ns |  6.737 ns |  5.972 ns | 1,037.87 ns |  1.00 |    0.00 | 0.5913 |     - |     - |   1,240 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 | 1,061.14 ns |  7.619 ns |  6.754 ns | 1,058.89 ns |  1.02 |    0.01 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   852.00 ns | 16.759 ns | 13.994 ns |   855.63 ns |  0.82 |    0.01 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   441.69 ns |  8.744 ns | 15.542 ns |   432.00 ns |  1.00 |    0.00 | 0.2294 |     - |     - |     480 B |
|           StructLinq_List_Reference |            List_Reference |   100 | 1,071.63 ns |  5.571 ns |  5.211 ns | 1,069.65 ns |  2.33 |    0.06 | 0.2174 |     - |     - |     456 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   831.73 ns |  2.493 ns |  1.946 ns |   831.83 ns |  1.80 |    0.02 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 7,684.56 ns | 48.657 ns | 45.514 ns | 7,685.18 ns |  1.00 |    0.00 | 0.7935 |     - |     - |   1,672 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 3,149.51 ns |  8.486 ns |  7.523 ns | 3,149.03 ns |  0.41 |    0.00 | 0.5798 |     - |     - |   1,216 B |
