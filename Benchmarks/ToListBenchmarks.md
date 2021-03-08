## ToListBenchmarks

### Source
[ToListBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ToListBenchmarks.cs)

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
|                              Method |                Categories | Count |        Mean |     Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|----------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |    55.04 ns |  0.451 ns | 0.400 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|                    StructLinq_Array |                     Array |   100 |   116.57 ns |  0.959 ns | 0.850 ns |  2.12 |    0.02 | 0.2179 |     - |     - |     456 B |
|                     Hyperlinq_Array |                     Array |   100 |    45.72 ns |  0.347 ns | 0.308 ns |  0.83 |    0.01 | 0.2180 |     - |     - |     456 B |
|                      Hyperlinq_Span |                     Array |   100 |    44.31 ns |  0.674 ns | 0.597 ns |  0.81 |    0.01 | 0.2180 |     - |     - |     456 B |
|                    Hyperlinq_Memory |                     Array |   100 |    46.67 ns |  0.343 ns | 0.304 ns |  0.85 |    0.01 | 0.2180 |     - |     - |     456 B |
|                                     |                           |       |             |           |          |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   880.12 ns |  3.852 ns | 3.216 ns |  1.00 |    0.00 | 0.5808 |     - |     - |    1216 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   956.25 ns |  5.687 ns | 4.749 ns |  1.09 |    0.01 | 0.2327 |     - |     - |     488 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 | 1,000.42 ns |  5.564 ns | 5.205 ns |  1.14 |    0.01 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |             |           |          |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |    48.59 ns |  0.330 ns | 0.292 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   930.14 ns |  2.879 ns | 2.552 ns | 19.14 |    0.14 | 0.2327 |     - |     - |     488 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   716.74 ns |  2.882 ns | 2.555 ns | 14.75 |    0.11 | 0.2441 |     - |     - |     512 B |
|                                     |                           |       |             |           |          |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |    50.08 ns |  0.692 ns | 0.648 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|               StructLinq_List_Value |                List_Value |   100 |   233.14 ns |  1.925 ns | 1.608 ns |  4.65 |    0.05 | 0.2179 |     - |     - |     456 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   608.85 ns |  2.480 ns | 2.199 ns | 12.15 |    0.17 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |             |           |          |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   669.26 ns |  2.885 ns | 2.698 ns |  1.00 |    0.00 | 0.5808 |     - |     - |    1216 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   707.61 ns |  3.130 ns | 2.928 ns |  1.06 |    0.01 | 0.2327 |     - |     - |     488 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   779.24 ns |  4.089 ns | 3.825 ns |  1.16 |    0.01 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |             |           |          |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |    48.62 ns |  0.200 ns | 0.177 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   749.17 ns |  6.407 ns | 5.680 ns | 15.41 |    0.13 | 0.2327 |     - |     - |     488 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   499.43 ns |  2.979 ns | 2.641 ns | 10.27 |    0.06 | 0.2441 |     - |     - |     512 B |
|                                     |                           |       |             |           |          |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |    49.79 ns |  0.493 ns | 0.412 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   706.10 ns |  4.999 ns | 4.175 ns | 14.18 |    0.14 | 0.2327 |     - |     - |     488 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   547.48 ns |  1.803 ns | 1.598 ns | 10.99 |    0.09 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |             |           |          |       |         |        |       |       |           |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,525.31 ns |  7.127 ns | 6.666 ns |     ? |       ? | 0.5989 |     - |     - |    1256 B |
|                                     |                           |       |             |           |          |       |         |        |       |       |           |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,391.20 ns | 10.707 ns | 8.941 ns |     ? |       ? | 0.5989 |     - |     - |    1256 B |
