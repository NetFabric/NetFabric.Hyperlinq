## AnyPredicateBenchmarks

### Source
[AnyPredicateBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/AnyPredicateBenchmarks.cs)

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
|                              Method |                Categories | Count |        Mean |     Error |    StdDev |      Median | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|----------:|----------:|------------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   537.58 ns |  3.047 ns |  2.701 ns |   537.74 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|                     Hyperlinq_Array |                     Array |   100 |   166.76 ns |  0.534 ns |  0.499 ns |   166.71 ns |  0.31 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |             |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   767.35 ns |  2.732 ns |  2.422 ns |   766.53 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   249.94 ns |  0.932 ns |  0.827 ns |   249.91 ns |  0.33 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |             |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |   792.83 ns |  2.970 ns |  2.480 ns |   792.78 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   227.64 ns |  0.582 ns |  0.545 ns |   227.63 ns |  0.29 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |             |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   763.82 ns |  1.738 ns |  1.541 ns |   763.47 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   779.76 ns |  3.727 ns |  3.112 ns |   779.99 ns |  1.02 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |           |           |             |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,702.31 ns |  2.336 ns |  2.185 ns | 1,702.68 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 |    73.88 ns |  0.269 ns |  0.225 ns |    73.90 ns |  0.04 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |             |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   725.40 ns |  1.927 ns |  1.708 ns |   725.53 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   723.70 ns |  2.657 ns |  2.356 ns |   723.45 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |           |           |             |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   724.58 ns |  2.336 ns |  2.186 ns |   724.67 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   781.68 ns |  2.340 ns |  1.954 ns |   781.48 ns |  1.08 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |           |           |             |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   749.57 ns |  2.836 ns |  2.653 ns |   749.41 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   735.02 ns |  5.117 ns |  4.536 ns |   733.78 ns |  0.98 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |           |           |             |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,744.06 ns | 34.593 ns | 63.255 ns | 1,711.18 ns |  1.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 |    76.47 ns |  0.218 ns |  0.204 ns |    76.39 ns |  0.04 | 0.0153 |     - |     - |      32 B |
