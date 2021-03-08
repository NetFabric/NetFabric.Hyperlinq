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
|                          Linq_Array |                     Array |   100 |    55.46 ns |  0.762 ns | 0.675 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|                    StructLinq_Array |                     Array |   100 |   114.42 ns |  0.588 ns | 0.521 ns |  2.06 |    0.03 | 0.2180 |     - |     - |     456 B |
|                     Hyperlinq_Array |                     Array |   100 |    46.29 ns |  0.394 ns | 0.329 ns |  0.84 |    0.01 | 0.2180 |     - |     - |     456 B |
|                                     |                           |       |             |           |          |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   879.10 ns |  3.996 ns | 3.337 ns |  1.00 |    0.00 | 0.5808 |     - |     - |    1216 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   950.25 ns |  7.034 ns | 6.235 ns |  1.08 |    0.01 | 0.2327 |     - |     - |     488 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   535.21 ns |  1.916 ns | 1.698 ns |  0.61 |    0.00 | 0.2365 |     - |     - |     496 B |
|                                     |                           |       |             |           |          |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |    47.68 ns |  0.359 ns | 0.336 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   953.11 ns | 11.902 ns | 9.939 ns | 20.02 |    0.18 | 0.2327 |     - |     - |     488 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   147.80 ns |  1.565 ns | 1.307 ns |  3.10 |    0.03 | 0.2370 |     - |     - |     496 B |
|                                     |                           |       |             |           |          |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |    49.68 ns |  0.454 ns | 0.402 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|               StructLinq_List_Value |                List_Value |   100 |   252.02 ns |  0.966 ns | 0.904 ns |  5.07 |    0.04 | 0.2179 |     - |     - |     456 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   613.03 ns |  3.689 ns | 3.270 ns | 12.34 |    0.15 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |             |           |          |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,375.78 ns | 10.666 ns | 9.455 ns |  1.00 |    0.00 | 0.5836 |     - |     - |    1224 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,694.93 ns |  8.596 ns | 7.620 ns |  0.71 |    0.00 | 0.5798 |     - |     - |    1216 B |
|                                     |                           |       |             |           |          |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   658.08 ns |  3.375 ns | 2.992 ns |  1.00 |    0.00 | 0.5808 |     - |     - |    1216 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   696.58 ns |  3.669 ns | 3.064 ns |  1.06 |    0.01 | 0.2327 |     - |     - |     488 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   807.41 ns |  4.501 ns | 4.210 ns |  1.23 |    0.01 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |             |           |          |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |    47.90 ns |  0.709 ns | 0.592 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   743.68 ns |  3.335 ns | 2.956 ns | 15.53 |    0.18 | 0.2327 |     - |     - |     488 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   492.61 ns |  1.405 ns | 1.245 ns | 10.29 |    0.14 | 0.2441 |     - |     - |     512 B |
|                                     |                           |       |             |           |          |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |    49.95 ns |  0.224 ns | 0.198 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   743.40 ns |  2.663 ns | 2.491 ns | 14.88 |    0.07 | 0.2327 |     - |     - |     488 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   602.74 ns |  2.613 ns | 2.317 ns | 12.07 |    0.08 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |             |           |          |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,211.75 ns |  6.184 ns | 5.164 ns |  1.00 |    0.00 | 0.5836 |     - |     - |    1224 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,367.85 ns |  6.742 ns | 5.630 ns |  1.07 |    0.00 | 0.5989 |     - |     - |    1256 B |
