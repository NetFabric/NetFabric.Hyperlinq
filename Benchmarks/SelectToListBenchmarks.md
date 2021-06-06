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
  Job-FXRHUT : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   320.50 ns |  6.400 ns |  9.773 ns |  1.00 |    0.00 | 0.2408 |     - |     - |     504 B |
|                    StructLinq_Array |                     Array |   100 |   289.97 ns |  5.679 ns |  7.582 ns |  0.91 |    0.03 | 0.2179 |     - |     - |     456 B |
|                     Hyperlinq_Array |                     Array |   100 |   261.91 ns |  0.801 ns |  0.669 ns |  0.84 |    0.03 | 0.2179 |     - |     - |     456 B |
|                Hyperlinq_Array_SIMD |                     Array |   100 |    95.19 ns |  0.595 ns |  0.465 ns |  0.31 |    0.01 | 0.2180 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,032.92 ns |  9.620 ns |  7.511 ns |  1.00 |    0.00 | 0.6065 |     - |     - |   1,272 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,067.34 ns |  5.047 ns |  4.721 ns |  1.03 |    0.01 | 0.2327 |     - |     - |     488 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   665.69 ns |  4.053 ns |  3.384 ns |  0.64 |    0.01 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,083.62 ns | 20.187 ns | 33.727 ns |  1.00 |    0.00 | 0.6065 |     - |     - |   1,272 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,099.09 ns |  4.668 ns |  4.367 ns |  1.03 |    0.04 | 0.2327 |     - |     - |     488 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   324.91 ns |  2.071 ns |  1.729 ns |  0.30 |    0.01 | 0.2179 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   493.88 ns |  3.038 ns |  2.372 ns |  1.00 |    0.00 | 0.2441 |     - |     - |     512 B |
|               StructLinq_List_Value |                List_Value |   100 |   435.24 ns |  2.380 ns |  2.110 ns |  0.88 |    0.01 | 0.2179 |     - |     - |     456 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   794.59 ns |  2.815 ns |  2.633 ns |  1.61 |    0.01 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 7,304.85 ns | 22.550 ns | 19.990 ns |  1.00 |    0.00 | 0.6104 |     - |     - |   1,280 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,538.83 ns | 20.180 ns | 18.876 ns |  0.35 |    0.00 | 0.5798 |     - |     - |   1,216 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,033.12 ns |  7.173 ns |  5.601 ns |  1.00 |    0.00 | 0.6065 |     - |     - |   1,272 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,089.03 ns | 21.115 ns | 25.931 ns |  1.04 |    0.03 | 0.2327 |     - |     - |     488 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,128.37 ns |  6.318 ns |  5.910 ns |  1.09 |    0.01 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 1,111.77 ns |  6.977 ns |  6.185 ns |  1.00 |    0.00 | 0.6065 |     - |     - |   1,272 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 | 1,111.52 ns | 22.062 ns | 28.687 ns |  1.01 |    0.03 | 0.2327 |     - |     - |     488 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   784.16 ns |  3.117 ns |  2.763 ns |  0.71 |    0.01 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   509.97 ns |  2.207 ns |  1.957 ns |  1.00 |    0.00 | 0.2441 |     - |     - |     512 B |
|           StructLinq_List_Reference |            List_Reference |   100 | 1,064.95 ns |  5.469 ns |  5.116 ns |  2.09 |    0.01 | 0.2327 |     - |     - |     488 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   885.68 ns |  2.860 ns |  2.535 ns |  1.74 |    0.01 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 7,530.75 ns | 26.527 ns | 23.515 ns |  1.00 |    0.00 | 0.6104 |     - |     - |   1,280 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 3,319.93 ns | 26.025 ns | 23.071 ns |  0.44 |    0.00 | 0.5951 |     - |     - |   1,248 B |
