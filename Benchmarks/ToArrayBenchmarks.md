## ToArrayBenchmarks

### Source
[ToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ToArrayBenchmarks.cs)

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
|                          Linq_Array |                     Array |   100 |    59.88 ns |  1.195 ns |  1.227 ns |    60.23 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                    StructLinq_Array |                     Array |   100 |    85.69 ns |  1.549 ns |  1.449 ns |    85.96 ns |  1.43 |    0.04 | 0.2027 |     - |     - |     424 B |
|                     Hyperlinq_Array |                     Array |   100 |    38.84 ns |  0.832 ns |  0.925 ns |    38.72 ns |  0.65 |    0.02 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   964.16 ns | 19.141 ns | 22.786 ns |   969.43 ns |  1.00 |    0.00 | 0.5655 |     - |     - |   1,184 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   940.39 ns |  3.655 ns |  3.419 ns |   940.89 ns |  0.98 |    0.03 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   549.45 ns |  2.348 ns |  2.197 ns |   550.01 ns |  0.57 |    0.02 | 0.2022 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |    47.70 ns |  0.554 ns |  0.519 ns |    47.74 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   897.71 ns |  7.573 ns |  6.713 ns |   894.91 ns | 18.81 |    0.24 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   284.85 ns |  1.007 ns |  0.942 ns |   284.32 ns |  5.97 |    0.06 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |    56.08 ns |  0.551 ns |  0.488 ns |    56.11 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|               StructLinq_List_Value |                List_Value |   100 |   265.05 ns |  5.273 ns |  7.729 ns |   268.00 ns |  4.65 |    0.17 | 0.2027 |     - |     - |     424 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   699.93 ns |  3.692 ns |  3.273 ns |   699.75 ns | 12.48 |    0.10 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   903.06 ns |  5.220 ns |  4.627 ns |   901.71 ns |  1.00 |    0.00 | 0.5655 |     - |     - |   1,184 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   888.17 ns |  5.147 ns |  4.814 ns |   887.75 ns |  0.98 |    0.01 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,038.64 ns |  5.813 ns |  5.153 ns | 1,038.27 ns |  1.15 |    0.01 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |    47.91 ns |  0.828 ns |  0.646 ns |    47.94 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   894.16 ns |  2.240 ns |  1.749 ns |   893.90 ns | 18.67 |    0.25 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   757.71 ns |  4.528 ns |  4.014 ns |   757.37 ns | 15.82 |    0.20 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |    49.13 ns |  0.740 ns |  0.822 ns |    48.89 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   909.31 ns | 17.445 ns | 23.879 ns |   895.84 ns | 18.61 |    0.61 | 0.2174 |     - |     - |     456 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   714.93 ns |  3.366 ns |  2.984 ns |   713.96 ns | 14.53 |    0.24 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,157.19 ns |  3.927 ns |  3.066 ns | 1,157.21 ns |     ? |       ? | 0.5646 |     - |     - |   1,184 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,974.38 ns | 12.564 ns | 11.137 ns | 1,974.81 ns |     ? |       ? | 0.5798 |     - |     - |   1,216 B |
