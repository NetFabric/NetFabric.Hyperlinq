## AnyPredicateBenchmarks

### Source
[AnyPredicateBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/AnyPredicateBenchmarks.cs)

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
|                          Linq_Array |                     Array |   100 |   610.71 ns |  5.464 ns |  4.562 ns |   609.01 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|                     Hyperlinq_Array |                     Array |   100 |   176.22 ns |  0.626 ns |  0.523 ns |   176.23 ns |  0.29 |    0.00 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |   200.15 ns |  1.066 ns |  0.832 ns |   199.94 ns |  0.33 |    0.00 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |   177.16 ns |  0.818 ns |  0.765 ns |   177.01 ns |  0.29 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   760.63 ns | 14.260 ns | 11.133 ns |   757.08 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   208.18 ns |  0.473 ns |  0.419 ns |   208.05 ns |  0.27 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |   766.35 ns | 12.439 ns | 12.774 ns |   763.74 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   212.12 ns |  0.714 ns |  0.668 ns |   212.21 ns |  0.28 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   824.99 ns | 13.927 ns | 30.275 ns |   813.90 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   677.93 ns |  2.871 ns |  2.546 ns |   677.71 ns |  0.81 |    0.03 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,228.86 ns | 11.643 ns | 10.891 ns | 2,227.38 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 |    88.42 ns |  0.351 ns |  0.328 ns |    88.42 ns |  0.04 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   529.71 ns |  2.971 ns |  2.779 ns |   529.51 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   560.47 ns |  1.045 ns |  0.873 ns |   560.40 ns |  1.06 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   542.07 ns | 10.316 ns | 27.712 ns |   529.10 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   593.33 ns | 11.609 ns | 13.820 ns |   588.05 ns |  1.02 |    0.04 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   559.22 ns |  2.587 ns |  2.419 ns |   558.60 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   696.95 ns | 28.283 ns | 82.504 ns |   651.97 ns |  1.23 |    0.16 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,134.68 ns |  5.559 ns |  4.928 ns | 2,134.93 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 |    91.28 ns |  0.553 ns |  0.491 ns |    91.41 ns |  0.04 |    0.00 | 0.0191 |     - |     - |      40 B |
