## SelectToListBenchmarks

### Source
[SelectToListBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectToListBenchmarks.cs)

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
|                              Method |                Categories | Count |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|----------:|----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   328.41 ns |  1.343 ns |  1.190 ns |   328.28 ns |  1.00 |    0.00 | 0.2408 |     - |     - |     504 B |
|                    StructLinq_Array |                     Array |   100 |   250.78 ns |  1.578 ns |  1.398 ns |   250.56 ns |  0.76 |    0.00 | 0.2179 |     - |     - |     456 B |
|                     Hyperlinq_Array |                     Array |   100 |   238.97 ns |  0.796 ns |  0.705 ns |   238.75 ns |  0.73 |    0.00 | 0.2179 |     - |     - |     456 B |
|                Hyperlinq_Array_SIMD |                     Array |   100 |    91.71 ns |  0.274 ns |  0.229 ns |    91.75 ns |  0.28 |    0.00 | 0.2180 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,077.53 ns |  3.826 ns |  3.391 ns | 1,077.96 ns |  1.00 |    0.00 | 0.6065 |     - |     - |   1,272 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,086.74 ns |  4.359 ns |  3.864 ns | 1,087.33 ns |  1.01 |    0.00 | 0.2327 |     - |     - |     488 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   584.68 ns |  1.477 ns |  1.233 ns |   584.39 ns |  0.54 |    0.00 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,075.27 ns |  5.659 ns |  4.418 ns | 1,073.35 ns |  1.00 |    0.00 | 0.6065 |     - |     - |   1,272 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,090.71 ns |  4.000 ns |  3.546 ns | 1,092.31 ns |  1.01 |    0.00 | 0.2327 |     - |     - |     488 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   284.67 ns |  0.905 ns |  0.802 ns |   284.70 ns |  0.26 |    0.00 | 0.2179 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   494.15 ns |  2.027 ns |  1.693 ns |   494.24 ns |  1.00 |    0.00 | 0.2441 |     - |     - |     512 B |
|               StructLinq_List_Value |                List_Value |   100 |   421.75 ns |  2.045 ns |  1.913 ns |   421.72 ns |  0.85 |    0.00 | 0.2179 |     - |     - |     456 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   699.97 ns |  2.857 ns |  2.385 ns |   700.04 ns |  1.42 |    0.01 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 8,072.61 ns | 63.935 ns | 49.916 ns | 8,072.89 ns |  1.00 |    0.00 | 0.6104 |     - |     - |   1,280 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,752.00 ns | 10.470 ns |  9.281 ns | 2,749.44 ns |  0.34 |    0.00 | 0.5798 |     - |     - |   1,216 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,057.57 ns |  6.568 ns |  5.823 ns | 1,056.86 ns |  1.00 |    0.00 | 0.6065 |     - |     - |   1,272 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,070.48 ns |  3.387 ns |  3.168 ns | 1,070.46 ns |  1.01 |    0.01 | 0.2327 |     - |     - |     488 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,130.56 ns |  6.983 ns |  6.190 ns | 1,129.37 ns |  1.07 |    0.01 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 1,056.31 ns |  4.561 ns |  3.808 ns | 1,056.26 ns |  1.00 |    0.00 | 0.6065 |     - |     - |   1,272 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 | 1,045.65 ns |  4.994 ns |  4.671 ns | 1,045.30 ns |  0.99 |    0.01 | 0.2327 |     - |     - |     488 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   863.54 ns | 17.211 ns | 40.229 ns |   848.88 ns |  0.85 |    0.05 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   507.48 ns |  2.043 ns |  1.811 ns |   507.20 ns |  1.00 |    0.00 | 0.2441 |     - |     - |     512 B |
|           StructLinq_List_Reference |            List_Reference |   100 | 1,047.64 ns |  3.631 ns |  3.397 ns | 1,046.74 ns |  2.06 |    0.01 | 0.2327 |     - |     - |     488 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   696.65 ns |  2.076 ns |  1.734 ns |   697.20 ns |  1.37 |    0.01 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 8,329.45 ns | 30.382 ns | 26.933 ns | 8,333.65 ns |  1.00 |    0.00 | 0.6104 |     - |     - |   1,280 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 3,534.33 ns |  6.510 ns |  5.436 ns | 3,532.52 ns |  0.42 |    0.00 | 0.5951 |     - |     - |   1,248 B |
