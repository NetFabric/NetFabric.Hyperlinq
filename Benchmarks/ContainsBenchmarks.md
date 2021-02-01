## ContainsBenchmarks

### Source
[ContainsBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ContainsBenchmarks.cs)

### References:
- Linq: 4.8.4300.0
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta29](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta29)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
  [Host]        : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                         Method |                Categories | Count |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |-------------------------- |------ |------------:|----------:|----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|                     Linq_Array |                     Array |   100 |    32.86 ns |  0.085 ns |  0.076 ns |    32.83 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_Array |                     Array |   100 |    26.35 ns |  0.037 ns |  0.034 ns |    26.36 ns |  0.80 |    0.00 |      - |     - |     - |         - |
|                 Hyperlinq_Span |                     Array |   100 |    70.17 ns |  0.122 ns |  0.108 ns |    70.16 ns |  2.14 |    0.01 |      - |     - |     - |         - |
|               Hyperlinq_Memory |                     Array |   100 |    72.32 ns |  0.145 ns |  0.135 ns |    72.33 ns |  2.20 |    0.01 |      - |     - |     - |         - |
|                                |                           |       |             |           |           |             |       |         |        |       |       |           |
|          Linq_Enumerable_Value |          Enumerable_Value |   100 |   684.09 ns |  4.105 ns |  3.639 ns |   682.59 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   339.55 ns |  0.681 ns |  0.637 ns |   339.67 ns |  0.50 |    0.00 | 0.0153 |     - |     - |      32 B |
|                                |                           |       |             |           |           |             |       |         |        |       |       |           |
|          Linq_Collection_Value |          Collection_Value |   100 |    31.91 ns |  0.077 ns |  0.072 ns |    31.92 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|     Hyperlinq_Collection_Value |          Collection_Value |   100 |   253.47 ns |  1.454 ns |  1.135 ns |   253.23 ns |  7.95 |    0.04 |      - |     - |     - |         - |
|                                |                           |       |             |           |           |             |       |         |        |       |       |           |
|                Linq_List_Value |                List_Value |   100 |    32.79 ns |  0.224 ns |  0.187 ns |    32.76 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|           Hyperlinq_List_Value |                List_Value |   100 |    32.92 ns |  0.073 ns |  0.069 ns |    32.92 ns |  1.00 |    0.01 |      - |     - |     - |         - |
|                                |                           |       |             |           |           |             |       |         |        |       |       |           |
|     Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,077.91 ns |  3.575 ns |  3.344 ns | 2,078.57 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                                |                           |       |             |           |           |             |       |         |        |       |       |           |
|      Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   410.46 ns |  0.952 ns |  0.844 ns |   410.40 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   543.85 ns | 15.885 ns | 46.084 ns |   516.25 ns |  1.31 |    0.09 | 0.0153 |     - |     - |      32 B |
|                                |                           |       |             |           |           |             |       |         |        |       |       |           |
|      Linq_Collection_Reference |      Collection_Reference |   100 |    30.37 ns |  0.103 ns |  0.091 ns |    30.39 ns |  1.00 |    0.00 |      - |     - |     - |         - |
| Hyperlinq_Collection_Reference |      Collection_Reference |   100 |    33.79 ns |  0.126 ns |  0.112 ns |    33.76 ns |  1.11 |    0.00 |      - |     - |     - |         - |
|                                |                           |       |             |           |           |             |       |         |        |       |       |           |
|            Linq_List_Reference |            List_Reference |   100 |    31.62 ns |  0.118 ns |  0.111 ns |    31.62 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|       Hyperlinq_List_Reference |            List_Reference |   100 |    34.31 ns |  0.118 ns |  0.105 ns |    34.31 ns |  1.09 |    0.00 |      - |     - |     - |         - |
|                                |                           |       |             |           |           |             |       |         |        |       |       |           |
| Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,930.67 ns |  6.462 ns |  5.728 ns | 1,930.55 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
