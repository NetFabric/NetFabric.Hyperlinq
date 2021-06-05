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
  Job-GYHESW : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |    57.37 ns |  0.391 ns |  0.347 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|                    StructLinq_Array |                     Array |   100 |    89.36 ns |  0.638 ns |  0.533 ns |  1.56 |    0.01 | 0.2180 |     - |     - |     456 B |
|                     Hyperlinq_Array |                     Array |   100 |    44.93 ns |  0.294 ns |  0.229 ns |  0.78 |    0.01 | 0.2180 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   903.35 ns |  6.611 ns |  6.184 ns |  1.00 |    0.00 | 0.5808 |     - |     - |   1,216 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   911.17 ns |  4.143 ns |  3.673 ns |  1.01 |    0.01 | 0.2327 |     - |     - |     488 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   587.79 ns |  3.092 ns |  2.741 ns |  0.65 |    0.00 | 0.2365 |     - |     - |     496 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |    51.89 ns |  0.784 ns |  0.733 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   922.14 ns |  7.969 ns |  7.454 ns | 17.78 |    0.32 | 0.2327 |     - |     - |     488 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   141.96 ns |  0.786 ns |  0.656 ns |  2.73 |    0.04 | 0.2370 |     - |     - |     496 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |    53.18 ns |  0.580 ns |  0.514 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|               StructLinq_List_Value |                List_Value |   100 |   253.74 ns |  3.019 ns |  2.824 ns |  4.77 |    0.08 | 0.2179 |     - |     - |     456 B |
|                Hyperlinq_List_Value |                List_Value |   100 |    77.76 ns |  0.632 ns |  0.560 ns |  1.46 |    0.02 | 0.2295 |     - |     - |     480 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,862.15 ns |  8.393 ns |  7.851 ns |  1.00 |    0.00 | 0.5798 |     - |     - |   1,216 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,210.80 ns |  4.677 ns |  3.906 ns |  0.65 |    0.00 | 0.5798 |     - |     - |   1,216 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   879.43 ns |  8.114 ns |  6.335 ns |  1.00 |    0.00 | 0.5808 |     - |     - |   1,216 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   921.20 ns |  4.572 ns |  4.277 ns |  1.05 |    0.01 | 0.2327 |     - |     - |     488 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,036.35 ns |  7.064 ns |  6.262 ns |  1.18 |    0.01 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |    52.01 ns |  0.397 ns |  0.331 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   910.52 ns |  3.786 ns |  3.356 ns | 17.50 |    0.12 | 0.2327 |     - |     - |     488 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |    68.43 ns |  0.609 ns |  0.540 ns |  1.32 |    0.01 | 0.2295 |     - |     - |     480 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |    52.21 ns |  0.408 ns |  0.361 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   914.68 ns |  6.522 ns |  6.101 ns | 17.53 |    0.15 | 0.2327 |     - |     - |     488 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |    77.22 ns |  1.111 ns |  0.928 ns |  1.48 |    0.02 | 0.2295 |     - |     - |     480 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,862.73 ns |  9.873 ns |  8.244 ns |  1.00 |    0.00 | 0.5798 |     - |     - |   1,216 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,032.68 ns | 18.738 ns | 17.527 ns |  1.09 |    0.01 | 0.5951 |     - |     - |   1,248 B |
