## SumBenchmarks

### Source
[SumBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SumBenchmarks.cs)

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
|                              Method |                Categories | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   411.64 ns |  2.148 ns |  1.904 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|                    StructLinq_Array |                     Array |   100 |    60.79 ns |  0.234 ns |  0.196 ns |  0.15 |    0.00 |      - |     - |     - |         - |
|                LinqFasterSIMD_Array |                     Array |   100 |    10.55 ns |  0.057 ns |  0.051 ns |  0.03 |    0.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |    21.71 ns |  0.050 ns |  0.047 ns |  0.05 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   627.54 ns |  3.594 ns |  3.186 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   569.81 ns |  2.575 ns |  2.409 ns |  0.91 |    0.01 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   200.57 ns |  0.525 ns |  0.410 ns |  0.32 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |   623.95 ns |  6.534 ns |  5.792 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   596.64 ns |  1.989 ns |  1.661 ns |  0.96 |    0.01 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   208.77 ns |  0.537 ns |  0.448 ns |  0.33 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   620.76 ns |  2.622 ns |  2.190 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|               StructLinq_List_Value |                List_Value |   100 |   222.64 ns |  0.895 ns |  0.747 ns |  0.36 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |   637.95 ns |  5.100 ns |  4.521 ns |  1.03 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,605.31 ns |  3.396 ns |  3.011 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 |   827.90 ns |  0.962 ns |  0.853 ns |  0.52 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   629.08 ns | 11.723 ns | 12.039 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   568.72 ns |  3.007 ns |  2.813 ns |  0.90 |    0.02 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   626.02 ns |  2.194 ns |  2.052 ns |  1.00 |    0.02 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   626.42 ns |  4.324 ns |  3.833 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   569.32 ns |  3.324 ns |  3.109 ns |  0.91 |    0.01 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   600.52 ns |  3.186 ns |  2.981 ns |  0.96 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   621.36 ns |  3.587 ns |  2.995 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   572.35 ns |  7.993 ns |  6.674 ns |  0.92 |    0.01 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   631.71 ns |  2.343 ns |  2.192 ns |  1.02 |    0.00 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,614.63 ns |  5.232 ns |  4.894 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,637.74 ns |  4.182 ns |  3.912 ns |  1.01 |    0.00 | 0.0153 |     - |     - |      32 B |
