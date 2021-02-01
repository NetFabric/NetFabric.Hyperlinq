## DistinctBenchmarks

### Source
[DistinctBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/DistinctBenchmarks.cs)

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
|                              Method |                Categories | Count |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 | 2.909 μs | 0.0101 μs | 0.0094 μs |  1.00 | 2.0599 |     - |     - |    4312 B |
|                    StructLinq_Array |                     Array |   100 | 2.459 μs | 0.0091 μs | 0.0076 μs |  0.84 | 1.4000 |     - |     - |    2928 B |
|                     Hyperlinq_Array |                     Array |   100 | 1.601 μs | 0.0039 μs | 0.0037 μs |  0.55 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 | 1.557 μs | 0.0034 μs | 0.0032 μs |  0.54 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 | 1.669 μs | 0.0026 μs | 0.0023 μs |  0.57 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 3.190 μs | 0.0064 μs | 0.0057 μs |  1.00 | 2.0599 |     - |     - |    4312 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 2.272 μs | 0.0076 μs | 0.0067 μs |  0.71 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 | 1.651 μs | 0.0029 μs | 0.0026 μs |  0.52 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 3.170 μs | 0.0118 μs | 0.0105 μs |  1.00 | 2.0599 |     - |     - |    4312 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 2.245 μs | 0.0123 μs | 0.0115 μs |  0.71 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 | 1.575 μs | 0.0047 μs | 0.0044 μs |  0.50 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 3.214 μs | 0.0092 μs | 0.0086 μs |  1.00 | 2.0599 |     - |     - |    4312 B |
|               StructLinq_List_Value |                List_Value |   100 | 1.445 μs | 0.0041 μs | 0.0034 μs |  0.45 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 | 1.922 μs | 0.0041 μs | 0.0036 μs |  0.60 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 7.912 μs | 0.0213 μs | 0.0189 μs |  1.00 | 2.0905 |     - |     - |    4400 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 4.850 μs | 0.0157 μs | 0.0131 μs |  0.61 | 0.0305 |     - |     - |      72 B |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 2.891 μs | 0.0121 μs | 0.0113 μs |  1.00 | 2.0599 |     - |     - |    4312 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1.594 μs | 0.0035 μs | 0.0031 μs |  0.55 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 2.134 μs | 0.0053 μs | 0.0049 μs |  0.74 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 2.885 μs | 0.0106 μs | 0.0094 μs |  1.00 | 2.0599 |     - |     - |    4312 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 | 1.584 μs | 0.0026 μs | 0.0024 μs |  0.55 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 | 2.126 μs | 0.0089 μs | 0.0083 μs |  0.74 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 | 2.869 μs | 0.0117 μs | 0.0098 μs |  1.00 | 2.0599 |     - |     - |    4312 B |
|           StructLinq_List_Reference |            List_Reference |   100 | 1.589 μs | 0.0053 μs | 0.0047 μs |  0.55 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 | 1.879 μs | 0.0047 μs | 0.0042 μs |  0.65 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 7.882 μs | 0.0441 μs | 0.0368 μs |  1.00 | 2.0905 |     - |     - |    4400 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5.114 μs | 0.0120 μs | 0.0113 μs |  0.65 | 0.0534 |     - |     - |     112 B |
