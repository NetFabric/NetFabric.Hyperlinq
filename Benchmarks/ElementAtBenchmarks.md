## ElementAtBenchmarks

### Source
[ElementAtBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ElementAtBenchmarks.cs)

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
|                          Linq_Array |                     Array |   100 |    19.08 ns | 0.122 ns | 0.108 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |    13.83 ns | 0.039 ns | 0.036 ns |  0.72 |    0.01 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |    12.00 ns | 0.033 ns | 0.029 ns |  0.63 |    0.00 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |    15.30 ns | 0.052 ns | 0.046 ns |  0.80 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   361.65 ns | 2.806 ns | 2.343 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   136.91 ns | 0.614 ns | 0.575 ns |  0.38 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |   362.13 ns | 2.782 ns | 2.467 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   143.03 ns | 0.543 ns | 0.482 ns |  0.39 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |    10.44 ns | 0.070 ns | 0.065 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |   425.22 ns | 1.548 ns | 1.448 ns | 40.74 |    0.34 |      - |     - |     - |         - |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,177.17 ns | 8.818 ns | 8.248 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,227.11 ns | 4.196 ns | 3.720 ns |  0.56 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   248.79 ns | 2.181 ns | 1.821 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   267.02 ns | 1.811 ns | 1.694 ns |  1.07 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   248.89 ns | 1.027 ns | 0.960 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   275.76 ns | 1.389 ns | 1.231 ns |  1.11 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |    10.41 ns | 0.046 ns | 0.036 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   358.46 ns | 2.572 ns | 2.406 ns | 34.45 |    0.32 |      - |     - |     - |         - |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,018.98 ns | 8.303 ns | 7.766 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,853.69 ns | 4.576 ns | 4.281 ns |  0.92 |    0.00 | 0.0191 |     - |     - |      40 B |
