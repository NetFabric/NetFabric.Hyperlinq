## SelectToListBenchmarks

### Source
[SelectToListBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectToListBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.5.21301.5
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.13.0.1555-nightly, OS=Windows 10.0.19043.1055 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.5.21302.13
  [Host]     : .NET 6.0.0 (6.0.21.30105), X64 RyuJIT
  Job-UNTOJZ : .NET 6.0.0 (6.0.21.30105), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|----------:|----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   338.38 ns |  2.006 ns |  1.876 ns |   338.43 ns |  1.00 |    0.00 | 0.2408 |     - |     - |     504 B |
|                    StructLinq_Array |                     Array |   100 |   263.67 ns |  5.286 ns |  7.056 ns |   265.41 ns |  0.77 |    0.03 | 0.2179 |     - |     - |     456 B |
|                     Hyperlinq_Array |                     Array |   100 |   285.53 ns |  1.874 ns |  1.565 ns |   285.41 ns |  0.84 |    0.01 | 0.2179 |     - |     - |     456 B |
|                Hyperlinq_Array_SIMD |                     Array |   100 |    91.48 ns |  1.203 ns |  1.126 ns |    91.78 ns |  0.27 |    0.00 | 0.2180 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,033.64 ns |  5.686 ns |  5.318 ns | 1,033.44 ns |  1.00 |    0.00 | 0.6065 |     - |     - |   1,272 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,083.62 ns |  5.790 ns |  5.416 ns | 1,083.91 ns |  1.05 |    0.01 | 0.2327 |     - |     - |     488 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   627.44 ns |  9.992 ns | 20.185 ns |   618.87 ns |  0.59 |    0.01 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,035.14 ns |  7.299 ns |  6.470 ns | 1,033.06 ns |  1.00 |    0.00 | 0.6065 |     - |     - |   1,272 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,068.83 ns |  5.827 ns |  5.165 ns | 1,069.30 ns |  1.03 |    0.01 | 0.2327 |     - |     - |     488 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   282.33 ns |  0.968 ns |  0.858 ns |   282.33 ns |  0.27 |    0.00 | 0.2179 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   464.89 ns |  1.236 ns |  1.096 ns |   464.88 ns |  1.00 |    0.00 | 0.2446 |     - |     - |     512 B |
|               StructLinq_List_Value |                List_Value |   100 |   443.45 ns |  2.158 ns |  1.913 ns |   443.73 ns |  0.95 |    0.00 | 0.2179 |     - |     - |     456 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   844.44 ns |  5.911 ns |  5.240 ns |   845.39 ns |  1.82 |    0.01 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 7,488.02 ns | 54.654 ns | 51.124 ns | 7,503.97 ns |  1.00 |    0.00 | 0.6104 |     - |     - |   1,280 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,433.89 ns | 20.006 ns | 18.713 ns | 2,437.28 ns |  0.33 |    0.00 | 0.5798 |     - |     - |   1,216 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,043.46 ns |  4.850 ns |  4.050 ns | 1,042.38 ns |  1.00 |    0.00 | 0.6065 |     - |     - |   1,272 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,080.29 ns |  4.157 ns |  3.685 ns | 1,079.25 ns |  1.04 |    0.01 | 0.2327 |     - |     - |     488 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,144.40 ns |  7.280 ns |  6.810 ns | 1,145.30 ns |  1.10 |    0.01 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 1,044.52 ns |  4.615 ns |  4.317 ns | 1,043.08 ns |  1.00 |    0.00 | 0.6065 |     - |     - |   1,272 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 | 1,062.79 ns |  6.705 ns |  5.944 ns | 1,061.99 ns |  1.02 |    0.01 | 0.2327 |     - |     - |     488 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   837.38 ns |  3.721 ns |  3.107 ns |   836.64 ns |  0.80 |    0.00 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   508.62 ns |  2.907 ns |  2.720 ns |   507.65 ns |  1.00 |    0.00 | 0.2441 |     - |     - |     512 B |
|           StructLinq_List_Reference |            List_Reference |   100 | 1,083.30 ns |  6.355 ns |  4.962 ns | 1,082.39 ns |  2.13 |    0.02 | 0.2327 |     - |     - |     488 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   838.80 ns | 16.450 ns | 20.804 ns |   849.94 ns |  1.63 |    0.05 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 7,339.88 ns | 20.278 ns | 16.933 ns | 7,342.17 ns |  1.00 |    0.00 | 0.6104 |     - |     - |   1,280 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 3,191.47 ns | 11.989 ns | 10.628 ns | 3,191.26 ns |  0.43 |    0.00 | 0.5951 |     - |     - |   1,248 B |
