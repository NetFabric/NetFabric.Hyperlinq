## ContainsBenchmarks

### Source
[ContainsBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ContainsBenchmarks.cs)

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
|                              Method |                Categories | Count |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|----------:|----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |    33.84 ns |  0.132 ns |  0.117 ns |    33.87 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |    31.08 ns |  0.277 ns |  0.232 ns |    31.00 ns |  0.92 |    0.01 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |    73.97 ns |  0.237 ns |  0.210 ns |    73.91 ns |  2.19 |    0.01 |      - |     - |     - |         - |
|                 Hyperlinq_Span_SIMD |                     Array |   100 |    24.62 ns |  0.064 ns |  0.057 ns |    24.60 ns |  0.73 |    0.00 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |    82.58 ns |  0.226 ns |  0.189 ns |    82.61 ns |  2.44 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   635.88 ns | 12.358 ns | 13.736 ns |   630.18 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   350.67 ns |  1.172 ns |  1.096 ns |   350.21 ns |  0.55 |    0.01 | 0.0191 |     - |     - |      40 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |    33.81 ns |  0.359 ns |  0.318 ns |    33.78 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |    37.33 ns |  0.116 ns |  0.103 ns |    37.32 ns |  1.10 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |    34.36 ns |  0.118 ns |  0.092 ns |    34.37 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |    35.39 ns |  0.144 ns |  0.135 ns |    35.38 ns |  1.03 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,061.59 ns |  3.937 ns |  3.683 ns | 2,061.51 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,455.35 ns | 28.959 ns | 41.532 ns | 1,428.59 ns |  0.72 |    0.02 | 0.0191 |     - |     - |      40 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   415.88 ns |  0.961 ns |  0.852 ns |   415.94 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   554.66 ns |  2.067 ns |  1.934 ns |   554.13 ns |  1.33 |    0.00 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |    33.54 ns |  0.070 ns |  0.059 ns |    33.56 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |    34.08 ns |  0.062 ns |  0.055 ns |    34.07 ns |  1.02 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |    33.05 ns |  0.155 ns |  0.121 ns |    33.09 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq_List_Reference |            List_Reference |   100 |    34.78 ns |  0.151 ns |  0.134 ns |    34.71 ns |  1.05 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,956.68 ns |  5.391 ns |  4.779 ns | 1,954.51 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,077.59 ns |  4.927 ns |  4.609 ns | 2,078.38 ns |  1.06 |    0.00 | 0.0305 |     - |     - |      64 B |
