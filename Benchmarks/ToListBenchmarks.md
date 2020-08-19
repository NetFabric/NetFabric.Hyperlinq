## ToListBenchmarks

### References:
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta25](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta25)

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
|                          Linq_Array |                     Array |   100 |    60.70 ns |  0.823 ns |  0.643 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|                     Hyperlinq_Array |                     Array |   100 |    50.75 ns |  0.672 ns |  0.628 ns |  0.83 |    0.02 | 0.2334 |     - |     - |     488 B |
|                      Hyperlinq_Span |                     Array |   100 |   168.55 ns |  1.374 ns |  1.285 ns |  2.78 |    0.04 | 0.2179 |     - |     - |     456 B |
|                    Hyperlinq_Memory |                     Array |   100 |    47.89 ns |  0.564 ns |  0.528 ns |  0.79 |    0.02 | 0.2372 |     - |     - |     496 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   853.35 ns |  4.888 ns |  4.333 ns |  1.00 |    0.00 | 0.5770 |     - |     - |    1208 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   511.03 ns |  2.812 ns |  2.348 ns |  0.60 |    0.00 | 0.2518 |     - |     - |     528 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |    95.47 ns |  0.597 ns |  0.499 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   110.20 ns |  0.720 ns |  0.638 ns |  1.15 |    0.01 | 0.2333 |     - |     - |     488 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |    96.81 ns |  0.664 ns |  0.621 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|                Hyperlinq_List_Value |                List_Value |   100 |    99.54 ns |  0.745 ns |  0.622 ns |  1.03 |    0.01 | 0.2180 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,396.54 ns | 11.395 ns | 10.659 ns |  1.00 |    0.00 | 0.5798 |     - |     - |    1216 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,263.87 ns | 17.543 ns | 15.552 ns |  0.94 |    0.01 | 0.6294 |     - |     - |    1320 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   660.87 ns |  4.899 ns |  4.343 ns |  1.00 |    0.00 | 0.5846 |     - |     - |    1224 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   869.47 ns |  5.452 ns |  5.100 ns |  1.32 |    0.01 | 0.2708 |     - |     - |     568 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |    94.95 ns |  0.636 ns |  0.564 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   107.83 ns |  0.635 ns |  0.531 ns |  1.14 |    0.01 | 0.2295 |     - |     - |     480 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |    96.50 ns |  0.714 ns |  0.633 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   100.31 ns |  0.882 ns |  0.782 ns |  1.04 |    0.01 | 0.2180 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 4,501.23 ns | 37.392 ns | 34.977 ns |  1.00 |    0.00 | 0.5646 |     - |     - |    1184 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 4,599.46 ns | 18.841 ns | 16.702 ns |  1.02 |    0.01 | 0.6256 |     - |     - |    1312 B |
