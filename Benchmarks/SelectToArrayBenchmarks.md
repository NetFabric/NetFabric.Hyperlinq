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
  Job-DUCAQD : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   240.17 ns |  1.474 ns |  1.306 ns |  1.00 |    0.00 | 0.2255 |     - |     - |     472 B |
|                    StructLinq_Array |                     Array |   100 |   228.00 ns |  1.364 ns |  1.276 ns |  0.95 |    0.01 | 0.2027 |     - |     - |     424 B |
|                LinqFasterSIMD_Array |                     Array |   100 |    63.28 ns |  0.716 ns |  0.635 ns |  0.26 |    0.00 | 0.2027 |     - |     - |     424 B |
|                     Hyperlinq_Array |                     Array |   100 |   250.31 ns |  1.640 ns |  1.370 ns |  1.04 |    0.01 | 0.2027 |     - |     - |     424 B |
|                Hyperlinq_Array_SIMD |                     Array |   100 |    80.24 ns |  0.918 ns |  0.859 ns |  0.33 |    0.00 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,061.43 ns | 11.789 ns |  9.844 ns |  1.00 |    0.00 | 0.5913 |     - |     - |   1,240 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,056.96 ns | 11.352 ns |  8.863 ns |  1.00 |    0.01 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   601.80 ns |  5.579 ns |  4.659 ns |  0.57 |    0.01 | 0.2022 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,093.15 ns |  6.813 ns |  6.373 ns |  1.00 |    0.00 | 0.5913 |     - |     - |   1,240 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,059.03 ns |  8.171 ns |  7.643 ns |  0.97 |    0.01 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   330.50 ns |  1.925 ns |  1.706 ns |  0.30 |    0.00 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   454.75 ns |  2.799 ns |  2.618 ns |  1.00 |    0.00 | 0.2294 |     - |     - |     480 B |
|               StructLinq_List_Value |                List_Value |   100 |   467.76 ns |  2.420 ns |  2.146 ns |  1.03 |    0.01 | 0.2027 |     - |     - |     424 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   860.83 ns |  4.320 ns |  4.041 ns |  1.89 |    0.01 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 7,405.26 ns | 59.048 ns | 46.101 ns |  1.00 |    0.00 | 0.7935 |     - |     - |   1,672 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,357.52 ns | 10.678 ns |  9.988 ns |  0.32 |    0.00 | 0.5646 |     - |     - |   1,184 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,052.08 ns |  6.421 ns |  6.006 ns |  1.00 |    0.00 | 0.5913 |     - |     - |   1,240 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,066.62 ns |  7.938 ns |  7.425 ns |  1.01 |    0.01 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,069.48 ns |  8.627 ns |  7.648 ns |  1.02 |    0.01 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 1,029.58 ns |  6.426 ns |  6.011 ns |  1.00 |    0.00 | 0.5913 |     - |     - |   1,240 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 | 1,055.36 ns |  7.970 ns |  7.455 ns |  1.03 |    0.01 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   847.53 ns | 16.213 ns | 15.923 ns |  0.82 |    0.02 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   402.58 ns |  2.603 ns |  2.435 ns |  1.00 |    0.00 | 0.2294 |     - |     - |     480 B |
|           StructLinq_List_Reference |            List_Reference |   100 | 1,058.00 ns |  9.785 ns |  9.153 ns |  2.63 |    0.03 | 0.2174 |     - |     - |     456 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   835.46 ns |  4.897 ns |  4.341 ns |  2.07 |    0.02 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 7,655.55 ns | 27.495 ns | 24.373 ns |  1.00 |    0.00 | 0.7935 |     - |     - |   1,672 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 3,145.23 ns | 10.203 ns |  9.044 ns |  0.41 |    0.00 | 0.5798 |     - |     - |   1,216 B |
