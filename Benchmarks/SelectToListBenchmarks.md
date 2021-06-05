## SelectToListBenchmarks

### Source
[SelectToListBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectToListBenchmarks.cs)

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
|                              Method |                Categories | Count |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|----------:|----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   301.67 ns |  1.742 ns |  1.629 ns |   301.60 ns |  1.00 |    0.00 | 0.2408 |     - |     - |     504 B |
|                    StructLinq_Array |                     Array |   100 |   266.28 ns |  2.173 ns |  2.033 ns |   265.63 ns |  0.88 |    0.01 | 0.2179 |     - |     - |     456 B |
|                     Hyperlinq_Array |                     Array |   100 |   263.51 ns |  2.980 ns |  2.642 ns |   262.95 ns |  0.87 |    0.01 | 0.2179 |     - |     - |     456 B |
|                Hyperlinq_Array_SIMD |                     Array |   100 |    95.55 ns |  1.976 ns |  4.619 ns |    93.11 ns |  0.31 |    0.01 | 0.2180 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,100.41 ns |  8.612 ns |  8.056 ns | 1,096.03 ns |  1.00 |    0.00 | 0.6065 |     - |     - |   1,272 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,096.06 ns |  8.405 ns |  7.019 ns | 1,092.46 ns |  1.00 |    0.01 | 0.2327 |     - |     - |     488 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   629.32 ns |  3.621 ns |  3.210 ns |   628.59 ns |  0.57 |    0.01 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,025.70 ns |  7.358 ns |  7.227 ns | 1,027.30 ns |  1.00 |    0.00 | 0.6065 |     - |     - |   1,272 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,091.53 ns |  7.158 ns |  6.346 ns | 1,090.35 ns |  1.06 |    0.01 | 0.2327 |     - |     - |     488 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   283.83 ns |  1.818 ns |  1.701 ns |   284.26 ns |  0.28 |    0.00 | 0.2179 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   467.84 ns |  2.783 ns |  2.467 ns |   467.65 ns |  1.00 |    0.00 | 0.2446 |     - |     - |     512 B |
|               StructLinq_List_Value |                List_Value |   100 |   410.14 ns |  2.882 ns |  2.407 ns |   410.02 ns |  0.88 |    0.00 | 0.2179 |     - |     - |     456 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   896.02 ns | 17.827 ns | 28.787 ns |   877.13 ns |  1.97 |    0.05 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 7,704.94 ns | 78.706 ns | 69.770 ns | 7,691.12 ns |  1.00 |    0.00 | 0.6104 |     - |     - |   1,280 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,479.47 ns | 48.187 ns | 49.484 ns | 2,506.42 ns |  0.32 |    0.01 | 0.5798 |     - |     - |   1,216 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,148.08 ns | 11.198 ns |  9.926 ns | 1,143.88 ns |  1.00 |    0.00 | 0.6065 |     - |     - |   1,272 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,141.10 ns |  7.857 ns |  7.349 ns | 1,138.74 ns |  0.99 |    0.01 | 0.2327 |     - |     - |     488 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,136.40 ns | 18.272 ns | 18.764 ns | 1,128.53 ns |  0.99 |    0.02 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 1,081.12 ns | 14.883 ns | 11.619 ns | 1,076.23 ns |  1.00 |    0.00 | 0.6065 |     - |     - |   1,272 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 | 1,096.40 ns |  9.292 ns |  8.237 ns | 1,093.87 ns |  1.01 |    0.01 | 0.2327 |     - |     - |     488 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   843.01 ns |  6.280 ns |  5.567 ns |   842.28 ns |  0.78 |    0.01 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   511.96 ns |  3.224 ns |  2.858 ns |   511.67 ns |  1.00 |    0.00 | 0.2441 |     - |     - |     512 B |
|           StructLinq_List_Reference |            List_Reference |   100 | 1,100.45 ns | 11.915 ns | 11.145 ns | 1,098.65 ns |  2.15 |    0.03 | 0.2327 |     - |     - |     488 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   894.44 ns | 17.363 ns | 17.052 ns |   898.46 ns |  1.75 |    0.04 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 7,508.51 ns | 29.243 ns | 24.419 ns | 7,510.76 ns |  1.00 |    0.00 | 0.6104 |     - |     - |   1,280 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 3,196.70 ns | 14.145 ns | 12.539 ns | 3,194.85 ns |  0.43 |    0.00 | 0.5951 |     - |     - |   1,248 B |
