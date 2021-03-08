## SelectSumBenchmarks

### Source
[SelectSumBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectSumBenchmarks.cs)

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
|                              Method |                Categories | Count |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|----------:|----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   654.18 ns |  3.445 ns |  2.877 ns |   653.02 ns |  1.00 |    0.00 | 0.0229 |     - |     - |      48 B |
|                    StructLinq_Array |                     Array |   100 |   181.81 ns |  0.777 ns |  0.689 ns |   181.78 ns |  0.28 |    0.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |   198.64 ns |  0.591 ns |  0.493 ns |   198.51 ns |  0.30 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_Array_SIMD |                     Array |   100 |    66.12 ns |  0.259 ns |  0.242 ns |    66.06 ns |  0.10 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,157.21 ns |  7.054 ns |  5.891 ns | 1,158.61 ns |  1.00 |    0.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   824.79 ns | 16.388 ns | 32.348 ns |   808.26 ns |  0.73 |    0.03 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   205.29 ns |  0.779 ns |  0.651 ns |   205.36 ns |  0.18 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,196.57 ns |  5.153 ns |  4.568 ns | 1,197.16 ns |  1.00 |    0.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   781.53 ns |  1.587 ns |  1.239 ns |   781.40 ns |  0.65 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   241.25 ns |  0.687 ns |  0.609 ns |   241.33 ns |  0.20 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,215.92 ns |  5.309 ns |  4.433 ns | 1,214.85 ns |  1.00 |    0.00 | 0.0420 |     - |     - |      88 B |
|               StructLinq_List_Value |                List_Value |   100 |   343.30 ns |  1.155 ns |  1.080 ns |   343.05 ns |  0.28 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |   638.69 ns |  1.304 ns |  1.089 ns |   638.68 ns |  0.53 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 9,248.73 ns | 32.956 ns | 29.215 ns | 9,246.09 ns |  1.00 |    0.00 | 0.0458 |     - |     - |     104 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,832.96 ns |  3.763 ns |  3.142 ns | 2,832.44 ns |  0.31 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   931.83 ns |  3.446 ns |  3.055 ns |   932.08 ns |  1.00 |    0.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   575.52 ns |  1.889 ns |  1.578 ns |   575.47 ns |  0.62 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   547.15 ns |  2.083 ns |  1.847 ns |   546.84 ns |  0.59 |    0.00 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   972.85 ns |  4.653 ns |  4.352 ns |   970.63 ns |  1.00 |    0.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   580.05 ns |  2.791 ns |  2.610 ns |   579.80 ns |  0.60 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   541.45 ns |  2.817 ns |  2.497 ns |   540.77 ns |  0.56 |    0.00 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   967.52 ns |  3.570 ns |  3.165 ns |   967.75 ns |  1.00 |    0.00 | 0.0420 |     - |     - |      88 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   573.72 ns |  2.226 ns |  1.973 ns |   573.90 ns |  0.59 |    0.00 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   638.77 ns |  2.185 ns |  1.825 ns |   639.27 ns |  0.66 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 8,606.46 ns | 23.219 ns | 20.583 ns | 8,604.72 ns |  1.00 |    0.00 | 0.0458 |     - |     - |     104 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 3,493.55 ns |  8.193 ns |  7.664 ns | 3,492.49 ns |  0.41 |    0.00 | 0.0191 |     - |     - |      40 B |
