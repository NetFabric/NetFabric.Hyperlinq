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
  Job-FXRHUT : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|----------:|----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |    61.67 ns |  0.616 ns |  0.822 ns |    61.68 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|                    StructLinq_Array |                     Array |   100 |    92.58 ns |  1.076 ns |  0.954 ns |    92.80 ns |  1.50 |    0.03 | 0.2180 |     - |     - |     456 B |
|                     Hyperlinq_Array |                     Array |   100 |    47.53 ns |  0.750 ns |  0.626 ns |    47.56 ns |  0.77 |    0.01 | 0.2180 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   938.37 ns | 18.802 ns | 37.550 ns |   915.59 ns |  1.00 |    0.00 | 0.5808 |     - |     - |   1,216 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   923.96 ns |  4.179 ns |  3.263 ns |   924.89 ns |  0.97 |    0.04 | 0.2327 |     - |     - |     488 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   598.19 ns |  4.437 ns |  3.934 ns |   596.98 ns |  0.63 |    0.03 | 0.2365 |     - |     - |     496 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |    55.73 ns |  1.109 ns |  2.700 ns |    54.42 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   967.01 ns |  6.672 ns |  6.241 ns |   967.52 ns | 17.09 |    0.86 | 0.2327 |     - |     - |     488 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   146.33 ns |  2.101 ns |  1.862 ns |   145.92 ns |  2.60 |    0.13 | 0.2370 |     - |     - |     496 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |    58.00 ns |  1.225 ns |  2.888 ns |    56.54 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|               StructLinq_List_Value |                List_Value |   100 |   255.08 ns |  0.820 ns |  0.685 ns |   254.91 ns |  4.23 |    0.24 | 0.2179 |     - |     - |     456 B |
|                Hyperlinq_List_Value |                List_Value |   100 |    81.62 ns |  1.424 ns |  1.262 ns |    81.68 ns |  1.35 |    0.08 | 0.2295 |     - |     - |     480 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,980.45 ns |  6.761 ns |  6.324 ns | 1,979.57 ns |  1.00 |    0.00 | 0.5798 |     - |     - |   1,216 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,221.63 ns |  6.614 ns |  6.186 ns | 1,221.44 ns |  0.62 |    0.00 | 0.5798 |     - |     - |   1,216 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   885.62 ns |  5.734 ns |  4.788 ns |   884.69 ns |  1.00 |    0.00 | 0.5798 |     - |     - |   1,216 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   937.51 ns |  4.458 ns |  3.723 ns |   937.76 ns |  1.06 |    0.01 | 0.2327 |     - |     - |     488 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,073.53 ns |  4.959 ns |  4.639 ns | 1,073.45 ns |  1.21 |    0.01 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |    54.97 ns |  0.788 ns |  0.737 ns |    55.20 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   956.73 ns | 18.374 ns | 18.869 ns |   966.16 ns | 17.38 |    0.46 | 0.2327 |     - |     - |     488 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |    71.90 ns |  0.683 ns |  0.533 ns |    71.88 ns |  1.31 |    0.02 | 0.2295 |     - |     - |     480 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |    55.06 ns |  1.145 ns |  0.894 ns |    55.41 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   928.99 ns |  4.006 ns |  3.345 ns |   928.35 ns | 16.89 |    0.28 | 0.2327 |     - |     - |     488 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |    81.84 ns |  0.829 ns |  0.775 ns |    81.83 ns |  1.49 |    0.03 | 0.2295 |     - |     - |     480 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,981.10 ns | 13.008 ns | 12.167 ns | 1,975.18 ns |  1.00 |    0.00 | 0.5798 |     - |     - |   1,216 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,018.26 ns |  6.283 ns |  5.877 ns | 2,017.38 ns |  1.02 |    0.01 | 0.5951 |     - |     - |   1,248 B |
