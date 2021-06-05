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
  Job-SUCOWF : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |        Mean |      Error |    StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|-----------:|----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   318.54 ns |   2.104 ns |  1.968 ns |   319.01 ns |  1.00 |    0.00 | 0.2408 |     - |     - |     504 B |
|                    StructLinq_Array |                     Array |   100 |   274.49 ns |   5.546 ns | 10.552 ns |   268.35 ns |  0.90 |    0.03 | 0.2179 |     - |     - |     456 B |
|                     Hyperlinq_Array |                     Array |   100 |   263.28 ns |   1.527 ns |  1.275 ns |   263.23 ns |  0.83 |    0.01 | 0.2179 |     - |     - |     456 B |
|                Hyperlinq_Array_SIMD |                     Array |   100 |    94.63 ns |   1.226 ns |  0.958 ns |    94.58 ns |  0.30 |    0.00 | 0.2180 |     - |     - |     456 B |
|                                     |                           |       |             |            |           |             |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,031.86 ns |   5.098 ns |  4.769 ns | 1,032.46 ns |  1.00 |    0.00 | 0.6065 |     - |     - |   1,272 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,117.67 ns |  19.198 ns | 23.577 ns | 1,130.15 ns |  1.08 |    0.03 | 0.2327 |     - |     - |     488 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   656.82 ns |   2.735 ns |  2.424 ns |   657.04 ns |  0.64 |    0.00 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |            |           |             |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,039.83 ns |   4.234 ns |  3.536 ns | 1,039.80 ns |  1.00 |    0.00 | 0.6065 |     - |     - |   1,272 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,073.25 ns |  20.361 ns | 21.786 ns | 1,062.53 ns |  1.04 |    0.02 | 0.2327 |     - |     - |     488 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   335.40 ns |   1.856 ns |  1.646 ns |   335.36 ns |  0.32 |    0.00 | 0.2179 |     - |     - |     456 B |
|                                     |                           |       |             |            |           |             |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   491.66 ns |   1.910 ns |  1.787 ns |   491.87 ns |  1.00 |    0.00 | 0.2441 |     - |     - |     512 B |
|               StructLinq_List_Value |                List_Value |   100 |   433.96 ns |   2.390 ns |  2.119 ns |   433.79 ns |  0.88 |    0.01 | 0.2179 |     - |     - |     456 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   877.39 ns |  16.359 ns | 14.502 ns |   881.65 ns |  1.79 |    0.03 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |             |            |           |             |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 7,728.30 ns |  25.213 ns | 22.351 ns | 7,721.39 ns |  1.00 |    0.00 | 0.6104 |     - |     - |   1,280 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,401.31 ns |   7.980 ns |  6.663 ns | 2,399.46 ns |  0.31 |    0.00 | 0.5798 |     - |     - |   1,216 B |
|                                     |                           |       |             |            |           |             |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,032.95 ns |   4.367 ns |  3.871 ns | 1,033.26 ns |  1.00 |    0.00 | 0.6065 |     - |     - |   1,272 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,086.31 ns |  21.295 ns | 23.669 ns | 1,089.19 ns |  1.04 |    0.02 | 0.2327 |     - |     - |     488 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,162.20 ns |   5.644 ns |  5.279 ns | 1,160.66 ns |  1.13 |    0.01 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |             |            |           |             |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 1,037.77 ns |   4.895 ns |  4.088 ns | 1,037.80 ns |  1.00 |    0.00 | 0.6065 |     - |     - |   1,272 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 | 1,071.48 ns |  19.183 ns | 26.892 ns | 1,054.76 ns |  1.05 |    0.03 | 0.2327 |     - |     - |     488 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   885.80 ns |  17.755 ns | 20.447 ns |   893.39 ns |  0.84 |    0.02 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |             |            |           |             |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   514.96 ns |   2.669 ns |  2.496 ns |   515.25 ns |  1.00 |    0.00 | 0.2441 |     - |     - |     512 B |
|           StructLinq_List_Reference |            List_Reference |   100 | 1,068.53 ns |   6.080 ns |  5.687 ns | 1,066.40 ns |  2.08 |    0.02 | 0.2327 |     - |     - |     488 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   890.36 ns |   2.653 ns |  2.216 ns |   890.99 ns |  1.73 |    0.01 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |             |            |           |             |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 7,740.03 ns | 104.055 ns | 92.242 ns | 7,689.45 ns |  1.00 |    0.00 | 0.6104 |     - |     - |   1,280 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 3,188.25 ns |   7.847 ns |  6.956 ns | 3,188.34 ns |  0.41 |    0.00 | 0.5951 |     - |     - |   1,248 B |
