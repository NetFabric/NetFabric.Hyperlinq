## ToListBenchmarks

### Source
[ToListBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ToListBenchmarks.cs)

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
  Job-SUCOWF : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|----------:|----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |    59.28 ns |  1.254 ns |  1.288 ns |    59.79 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|                    StructLinq_Array |                     Array |   100 |    92.73 ns |  0.843 ns |  0.747 ns |    92.66 ns |  1.56 |    0.04 | 0.2180 |     - |     - |     456 B |
|                     Hyperlinq_Array |                     Array |   100 |    49.88 ns |  1.064 ns |  2.629 ns |    48.68 ns |  0.83 |    0.05 | 0.2180 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   948.74 ns | 18.850 ns | 36.317 ns |   925.55 ns |  1.00 |    0.00 | 0.5808 |     - |     - |   1,216 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   938.74 ns |  3.250 ns |  2.537 ns |   938.82 ns |  0.98 |    0.03 | 0.2327 |     - |     - |     488 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   558.80 ns | 11.170 ns | 18.037 ns |   566.01 ns |  0.58 |    0.03 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |    54.69 ns |  1.149 ns |  2.732 ns |    53.34 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   943.48 ns |  8.286 ns |  6.919 ns |   940.54 ns | 17.62 |    0.44 | 0.2327 |     - |     - |     488 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   293.56 ns |  4.750 ns |  6.659 ns |   291.01 ns |  5.25 |    0.33 | 0.2179 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |    58.06 ns |  1.221 ns |  3.017 ns |    57.68 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|               StructLinq_List_Value |                List_Value |   100 |   255.44 ns |  1.213 ns |  0.947 ns |   255.64 ns |  4.27 |    0.21 | 0.2179 |     - |     - |     456 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   744.41 ns |  6.725 ns |  6.291 ns |   743.00 ns | 12.39 |    0.55 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,870.70 ns |  5.179 ns |  4.591 ns | 1,870.29 ns |  1.00 |    0.00 | 0.5798 |     - |     - |   1,216 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,208.58 ns |  6.498 ns |  5.760 ns | 1,208.21 ns |  0.65 |    0.00 | 0.5798 |     - |     - |   1,216 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   939.71 ns | 18.708 ns | 37.361 ns |   913.84 ns |  1.00 |    0.00 | 0.5808 |     - |     - |   1,216 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   992.53 ns |  7.155 ns |  5.975 ns |   991.79 ns |  1.04 |    0.04 | 0.2327 |     - |     - |     488 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,009.21 ns |  8.154 ns |  7.627 ns | 1,008.90 ns |  1.05 |    0.04 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |    56.80 ns |  1.201 ns |  3.144 ns |    56.97 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   932.65 ns |  7.394 ns |  5.773 ns |   931.02 ns | 16.72 |    0.80 | 0.2327 |     - |     - |     488 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   706.73 ns | 12.697 ns | 19.004 ns |   716.63 ns | 12.33 |    0.53 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |    54.98 ns |  1.086 ns |  0.848 ns |    55.10 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   969.38 ns | 14.223 ns | 18.988 ns |   975.80 ns | 17.70 |    0.40 | 0.2327 |     - |     - |     488 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   743.46 ns |  3.592 ns |  2.999 ns |   743.35 ns | 13.53 |    0.23 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,983.00 ns | 13.421 ns | 12.554 ns | 1,978.37 ns |  1.00 |    0.00 | 0.5798 |     - |     - |   1,216 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,033.51 ns | 12.827 ns | 10.711 ns | 2,028.62 ns |  1.03 |    0.01 | 0.5951 |     - |     - |   1,248 B |
