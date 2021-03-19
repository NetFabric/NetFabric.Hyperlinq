## ToListBenchmarks

### Source
[ToListBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ToListBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.2.21154.6
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1521-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.2.21155.3
  [Host]     : .NET 6.0.0 (6.0.21.15406), X64 RyuJIT
  Job-XHOKQA : .NET 6.0.0 (6.0.21.15406), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |    57.07 ns |  0.628 ns |  0.556 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|                    StructLinq_Array |                     Array |   100 |   117.12 ns |  0.639 ns |  0.598 ns |  2.05 |    0.02 | 0.2179 |     - |     - |     456 B |
|                     Hyperlinq_Array |                     Array |   100 |    48.40 ns |  0.729 ns |  0.682 ns |  0.85 |    0.02 | 0.2180 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   880.19 ns |  3.297 ns |  2.922 ns |  1.00 |    0.00 | 0.5808 |     - |     - |   1,216 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   881.63 ns |  3.729 ns |  3.306 ns |  1.00 |    0.00 | 0.2327 |     - |     - |     488 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   548.65 ns |  6.695 ns | 10.224 ns |  0.62 |    0.01 | 0.2365 |     - |     - |     496 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |    51.04 ns |  0.384 ns |  0.340 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   883.85 ns |  5.757 ns |  4.807 ns | 17.33 |    0.15 | 0.2327 |     - |     - |     488 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   149.37 ns |  0.969 ns |  0.809 ns |  2.93 |    0.02 | 0.2370 |     - |     - |     496 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |    53.30 ns |  0.464 ns |  0.412 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|               StructLinq_List_Value |                List_Value |   100 |   256.68 ns |  1.914 ns |  1.598 ns |  4.82 |    0.05 | 0.2179 |     - |     - |     456 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   600.97 ns |  2.968 ns |  2.776 ns | 11.27 |    0.10 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,045.94 ns |  9.630 ns |  8.042 ns |  1.00 |    0.00 | 0.5798 |     - |     - |   1,216 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,402.94 ns |  4.992 ns |  4.669 ns |  0.69 |    0.00 | 0.5798 |     - |     - |   1,216 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   880.06 ns |  4.079 ns |  3.616 ns |  1.00 |    0.00 | 0.5808 |     - |     - |   1,216 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   910.87 ns |  3.254 ns |  2.885 ns |  1.04 |    0.00 | 0.2327 |     - |     - |     488 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,019.00 ns |  3.928 ns |  3.674 ns |  1.16 |    0.01 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |    50.64 ns |  0.554 ns |  0.519 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   886.92 ns |  6.848 ns |  5.719 ns | 17.50 |    0.17 | 0.2327 |     - |     - |     488 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   748.21 ns |  9.986 ns |  8.339 ns | 14.76 |    0.23 | 0.2441 |     - |     - |     512 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |    52.48 ns |  0.279 ns |  0.248 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   886.53 ns |  4.900 ns |  4.344 ns | 16.89 |    0.08 | 0.2327 |     - |     - |     488 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   562.00 ns |  3.656 ns |  3.419 ns | 10.71 |    0.09 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,070.35 ns | 11.109 ns |  9.276 ns |  1.00 |    0.00 | 0.5798 |     - |     - |   1,216 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,190.63 ns |  6.834 ns |  6.392 ns |  1.06 |    0.00 | 0.5951 |     - |     - |   1,248 B |
