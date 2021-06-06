## SelectSumBenchmarks

### Source
[SelectSumBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectSumBenchmarks.cs)

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
|                              Method |                Categories | Count |        Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   657.60 ns |  4.578 ns |  4.282 ns |  1.00 | 0.0229 |     - |     - |      48 B |
|                    StructLinq_Array |                     Array |   100 |   224.13 ns |  0.642 ns |  0.569 ns |  0.34 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |   198.21 ns |  0.524 ns |  0.464 ns |  0.30 |      - |     - |     - |         - |
|                Hyperlinq_Array_SIMD |                     Array |   100 |    64.92 ns |  0.260 ns |  0.243 ns |  0.10 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,170.10 ns |  3.796 ns |  2.964 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   789.21 ns |  4.604 ns |  4.307 ns |  0.67 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   203.36 ns |  0.654 ns |  0.580 ns |  0.17 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,159.29 ns |  4.584 ns |  4.288 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   784.62 ns |  5.638 ns |  4.998 ns |  0.68 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   232.75 ns |  0.688 ns |  0.610 ns |  0.20 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,171.90 ns |  7.967 ns |  7.452 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|               StructLinq_List_Value |                List_Value |   100 |   367.04 ns |  3.394 ns |  3.009 ns |  0.31 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |   770.35 ns |  4.159 ns |  3.890 ns |  0.66 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 6,928.20 ns | 14.613 ns | 12.202 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,994.54 ns |  2.713 ns |  2.537 ns |  0.29 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,180.52 ns |  6.566 ns |  5.821 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   787.10 ns |  4.083 ns |  3.819 ns |  0.67 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   758.40 ns |  3.926 ns |  3.480 ns |  0.64 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 1,254.95 ns |  8.594 ns |  7.619 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   755.09 ns |  1.902 ns |  1.779 ns |  0.60 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   763.83 ns |  3.592 ns |  3.184 ns |  0.61 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 | 1,248.97 ns |  4.253 ns |  3.770 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   757.15 ns |  3.574 ns |  3.343 ns |  0.61 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   813.48 ns |  1.671 ns |  1.563 ns |  0.65 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 7,076.05 ns | 16.861 ns | 14.947 ns |  1.00 | 0.0458 |     - |     - |      96 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,834.07 ns |  6.980 ns |  6.529 ns |  0.40 | 0.0153 |     - |     - |      32 B |
