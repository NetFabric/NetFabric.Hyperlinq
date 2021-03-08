## ToArrayBenchmarks

### Source
[ToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ToArrayBenchmarks.cs)

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
|                              Method |                Categories | Count |        Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |    49.55 ns | 0.656 ns | 0.582 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                    StructLinq_Array |                     Array |   100 |    79.60 ns | 0.239 ns | 0.200 ns |  1.61 |    0.02 | 0.2027 |     - |     - |     424 B |
|                     Hyperlinq_Array |                     Array |   100 |    37.57 ns | 0.124 ns | 0.110 ns |  0.76 |    0.01 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   942.82 ns | 4.818 ns | 3.762 ns |  1.00 |    0.00 | 0.5646 |     - |     - |    1184 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   940.98 ns | 2.934 ns | 2.450 ns |  1.00 |    0.00 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   506.45 ns | 2.280 ns | 2.133 ns |  0.54 |    0.00 | 0.2213 |     - |     - |     464 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |    43.92 ns | 0.171 ns | 0.143 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   886.16 ns | 3.552 ns | 3.323 ns | 20.17 |    0.07 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   132.67 ns | 1.076 ns | 1.007 ns |  3.02 |    0.02 | 0.2217 |     - |     - |     464 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |    45.17 ns | 0.369 ns | 0.308 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|               StructLinq_List_Value |                List_Value |   100 |   272.36 ns | 0.609 ns | 0.475 ns |  6.03 |    0.04 | 0.2027 |     - |     - |     424 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   524.33 ns | 2.163 ns | 1.807 ns | 11.61 |    0.09 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   717.70 ns | 3.132 ns | 2.777 ns |  1.00 |    0.00 | 0.5655 |     - |     - |    1184 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   691.29 ns | 3.306 ns | 2.930 ns |  0.96 |    0.00 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   794.63 ns | 4.396 ns | 3.897 ns |  1.11 |    0.01 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |    43.62 ns | 0.555 ns | 0.519 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   726.35 ns | 3.630 ns | 3.218 ns | 16.66 |    0.25 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   486.52 ns | 3.939 ns | 3.491 ns | 11.16 |    0.16 | 0.2289 |     - |     - |     480 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |    45.43 ns | 0.153 ns | 0.136 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   681.49 ns | 3.162 ns | 2.803 ns | 15.00 |    0.08 | 0.2174 |     - |     - |     456 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   555.79 ns | 2.546 ns | 2.126 ns | 12.24 |    0.05 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,648.08 ns | 4.695 ns | 4.162 ns |     ? |       ? | 0.5646 |     - |     - |    1184 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,283.01 ns | 5.415 ns | 4.800 ns |     ? |       ? | 0.5836 |     - |     - |    1224 B |
