## SelectCountBenchmarks

### Source
[SelectCountBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectCountBenchmarks.cs)

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
|                              Method |                Categories | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   219.134 ns |  0.8228 ns |  0.6870 ns |  1.00 |    0.00 | 0.0229 |     - |     - |      48 B |
|                    StructLinq_Array |                     Array |   100 |    10.007 ns |  0.0146 ns |  0.0130 ns |  0.05 |    0.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |     8.946 ns |  0.0141 ns |  0.0125 ns |  0.04 |    0.00 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |     8.940 ns |  0.0145 ns |  0.0135 ns |  0.04 |    0.00 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |     9.489 ns |  0.0204 ns |  0.0170 ns |  0.04 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   803.504 ns |  3.4588 ns |  3.0661 ns |  1.00 |    0.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   796.036 ns |  1.6843 ns |  1.4065 ns |  0.99 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   149.788 ns |  0.2333 ns |  0.2068 ns |  0.19 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |   805.356 ns |  2.4730 ns |  2.3133 ns |  1.00 |    0.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   774.031 ns |  1.2887 ns |  1.0761 ns |  0.96 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |    11.941 ns |  0.0139 ns |  0.0123 ns |  0.01 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   379.943 ns |  0.8789 ns |  0.7791 ns |  1.00 |    0.00 | 0.0267 |     - |     - |      56 B |
|               StructLinq_List_Value |                List_Value |   100 |    10.201 ns |  0.0244 ns |  0.0229 ns |  0.03 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |     7.511 ns |  0.0271 ns |  0.0254 ns |  0.02 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 8,902.444 ns | 23.6333 ns | 19.7349 ns |  1.00 |    0.00 | 0.0458 |     - |     - |     104 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 8,968.740 ns | 17.1138 ns | 14.2908 ns |  1.01 |    0.00 | 0.0610 |     - |     - |     136 B |
|                                     |                           |       |              |            |            |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   594.794 ns |  0.9684 ns |  0.8585 ns |  1.00 |    0.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   566.260 ns |  0.9518 ns |  0.8903 ns |  0.95 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   258.161 ns |  0.8138 ns |  0.7613 ns |  0.43 |    0.00 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |              |            |            |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   597.569 ns |  3.9864 ns |  3.5338 ns | 1.000 |    0.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   572.285 ns |  1.3061 ns |  1.2217 ns | 0.958 |    0.01 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |     4.136 ns |  0.0051 ns |  0.0043 ns | 0.007 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   360.074 ns |  1.2968 ns |  1.1495 ns |  1.00 |    0.00 | 0.0267 |     - |     - |      56 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   526.575 ns |  7.2842 ns |  8.0964 ns |  1.47 |    0.02 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |     7.479 ns |  0.0248 ns |  0.0207 ns |  0.02 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 8,636.721 ns | 29.1881 ns | 24.3733 ns |  1.00 |    0.00 | 0.0458 |     - |     - |     104 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 8,940.788 ns | 23.7462 ns | 22.2122 ns |  1.04 |    0.00 | 0.0610 |     - |     - |     152 B |
