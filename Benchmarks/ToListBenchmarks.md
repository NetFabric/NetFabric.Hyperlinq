## ToListBenchmarks

### Source
[ToListBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ToListBenchmarks.cs)

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
|                          Linq_Array |                     Array |   100 |    58.81 ns |  0.505 ns |  0.473 ns |    58.83 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|                    StructLinq_Array |                     Array |   100 |    94.06 ns |  1.231 ns |  1.151 ns |    93.99 ns |  1.60 |    0.02 | 0.2180 |     - |     - |     456 B |
|                     Hyperlinq_Array |                     Array |   100 |    48.82 ns |  1.053 ns |  2.661 ns |    47.60 ns |  0.85 |    0.05 | 0.2180 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   859.60 ns | 17.141 ns | 34.625 ns |   837.18 ns |  1.00 |    0.00 | 0.5808 |     - |     - |   1,216 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   972.46 ns |  7.019 ns |  6.565 ns |   973.93 ns |  1.09 |    0.04 | 0.2327 |     - |     - |     488 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   618.71 ns |  4.105 ns |  3.428 ns |   618.72 ns |  0.68 |    0.01 | 0.2365 |     - |     - |     496 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |    57.86 ns |  0.921 ns |  0.816 ns |    57.93 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   919.81 ns |  4.114 ns |  3.849 ns |   921.58 ns | 15.91 |    0.20 | 0.2327 |     - |     - |     488 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   147.30 ns |  2.179 ns |  2.038 ns |   146.28 ns |  2.54 |    0.06 | 0.2370 |     - |     - |     496 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |    54.34 ns |  0.603 ns |  0.535 ns |    54.40 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|               StructLinq_List_Value |                List_Value |   100 |   257.40 ns |  1.623 ns |  1.518 ns |   257.40 ns |  4.74 |    0.06 | 0.2179 |     - |     - |     456 B |
|                Hyperlinq_List_Value |                List_Value |   100 |    78.38 ns |  1.240 ns |  1.099 ns |    78.55 ns |  1.44 |    0.02 | 0.2295 |     - |     - |     480 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,933.29 ns | 37.450 ns | 48.695 ns | 1,962.87 ns |  1.00 |    0.00 | 0.5798 |     - |     - |   1,216 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,218.93 ns |  6.225 ns |  5.198 ns | 1,219.33 ns |  0.64 |    0.02 | 0.5798 |     - |     - |   1,216 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   836.68 ns |  3.132 ns |  2.776 ns |   836.44 ns |  1.00 |    0.00 | 0.5808 |     - |     - |   1,216 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   919.99 ns |  5.034 ns |  4.462 ns |   919.05 ns |  1.10 |    0.00 | 0.2327 |     - |     - |     488 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,041.93 ns | 20.075 ns | 24.653 ns | 1,046.08 ns |  1.24 |    0.03 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |    52.49 ns |  0.880 ns |  0.780 ns |    52.71 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   943.89 ns | 17.853 ns | 23.215 ns |   931.73 ns | 18.19 |    0.41 | 0.2327 |     - |     - |     488 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |    68.72 ns |  0.533 ns |  0.655 ns |    68.60 ns |  1.31 |    0.02 | 0.2295 |     - |     - |     480 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |    56.89 ns |  1.213 ns |  3.280 ns |    54.95 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   929.09 ns |  3.788 ns |  3.358 ns |   929.08 ns | 15.78 |    0.64 | 0.2327 |     - |     - |     488 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |    84.47 ns |  1.761 ns |  4.252 ns |    82.38 ns |  1.48 |    0.13 | 0.2295 |     - |     - |     480 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,954.13 ns | 37.510 ns | 36.840 ns | 1,969.88 ns |  1.00 |    0.00 | 0.5798 |     - |     - |   1,216 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,041.94 ns | 11.426 ns | 10.688 ns | 2,039.66 ns |  1.05 |    0.02 | 0.5951 |     - |     - |   1,248 B |
