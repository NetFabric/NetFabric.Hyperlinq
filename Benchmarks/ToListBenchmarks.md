## ToListBenchmarks

### Source
[ToListBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ToListBenchmarks.cs)

### References:
- Linq: 5.0.0-preview.7.20364.11
- System.Linq.Async: [4.1.1](https://www.nuget.org/packages/System.Linq.Async/4.1.1)
- System.Interactive: [4.1.1](https://www.nuget.org/packages/System.Interactive/4.1.1)
- System.Interactive.Async: [4.1.1](https://www.nuget.org/packages/System.Interactive.Async/4.1.1)
- StructLinq: [0.19.2](https://www.nuget.org/packages/StructLinq/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                              Method |                Categories | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |    59.85 ns |  1.197 ns |  1.119 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|                    StructLinq_Array |                     Array |   100 |   242.28 ns |  1.290 ns |  1.206 ns |  4.05 |    0.08 | 0.2179 |     - |     - |     456 B |
|                     Hyperlinq_Array |                     Array |   100 |    52.98 ns |  0.682 ns |  0.605 ns |  0.89 |    0.02 | 0.2334 |     - |     - |     488 B |
|                      Hyperlinq_Span |                     Array |   100 |   164.61 ns |  1.073 ns |  0.951 ns |  2.75 |    0.06 | 0.2179 |     - |     - |     456 B |
|                    Hyperlinq_Memory |                     Array |   100 |    50.23 ns |  0.482 ns |  0.427 ns |  0.84 |    0.02 | 0.2372 |     - |     - |     496 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   888.97 ns | 11.146 ns |  9.881 ns |  1.00 |    0.00 | 0.5808 |     - |     - |    1216 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   951.98 ns |  7.191 ns |  6.727 ns |  1.07 |    0.02 | 0.2327 |     - |     - |     488 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   647.87 ns |  2.565 ns |  2.142 ns |  0.73 |    0.01 | 0.2518 |     - |     - |     528 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |    52.60 ns |  0.311 ns |  0.259 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   924.46 ns |  7.475 ns |  6.992 ns | 17.59 |    0.15 | 0.2327 |     - |     - |     488 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |    69.31 ns |  0.755 ns |  0.670 ns |  1.32 |    0.02 | 0.2333 |     - |     - |     488 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |    52.75 ns |  0.721 ns |  0.675 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|               StructLinq_List_Value |                List_Value |   100 |   919.22 ns |  7.111 ns |  6.652 ns | 17.43 |    0.25 | 0.2327 |     - |     - |     488 B |
|                Hyperlinq_List_Value |                List_Value |   100 |    55.27 ns |  0.634 ns |  0.562 ns |  1.05 |    0.01 | 0.2180 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   673.14 ns |  6.006 ns |  5.324 ns |  1.00 |    0.00 | 0.5808 |     - |     - |    1216 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   717.59 ns |  3.642 ns |  3.229 ns |  1.07 |    0.01 | 0.2327 |     - |     - |     488 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   874.17 ns |  5.934 ns |  5.260 ns |  1.30 |    0.01 | 0.2670 |     - |     - |     560 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |    52.25 ns |  0.665 ns |  0.622 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   717.29 ns |  7.228 ns |  5.643 ns | 13.69 |    0.19 | 0.2327 |     - |     - |     488 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |    64.09 ns |  0.984 ns |  0.872 ns |  1.23 |    0.01 | 0.2295 |     - |     - |     480 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |    52.90 ns |  0.633 ns |  0.592 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   767.37 ns |  5.329 ns |  4.724 ns | 14.51 |    0.23 | 0.2327 |     - |     - |     488 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |    55.45 ns |  0.854 ns |  0.799 ns |  1.05 |    0.01 | 0.2180 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,766.12 ns |  6.363 ns |  5.641 ns |     ? |       ? | 0.6332 |     - |     - |    1328 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 3,381.15 ns | 16.515 ns | 14.640 ns |     ? |       ? | 0.6447 |     - |     - |    1352 B |
