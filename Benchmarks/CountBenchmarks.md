## CountBenchmarks

### Source
[CountBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/CountBenchmarks.cs)

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
|                              Method |                Categories | Count |          Mean |      Error |     StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |--------------:|-----------:|-----------:|-------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |     9.4726 ns |  0.0922 ns |  0.0770 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|                    StructLinq_Array |                     Array |   100 |     0.4798 ns |  0.0077 ns |  0.0068 ns |   0.05 |    0.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |     7.7675 ns |  0.0283 ns |  0.0265 ns |   0.82 |    0.01 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |     7.4672 ns |  0.0226 ns |  0.0211 ns |   0.79 |    0.01 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |    10.6289 ns |  0.0298 ns |  0.0264 ns |   1.12 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |               |            |            |        |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   375.1266 ns |  1.2614 ns |  1.1800 ns |   1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   605.3862 ns |  2.5706 ns |  2.2788 ns |   1.61 |    0.01 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   367.2216 ns |  2.4282 ns |  2.1525 ns |   0.98 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |               |            |            |        |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |     4.5997 ns |  0.0344 ns |  0.0305 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   606.8765 ns |  5.2184 ns |  4.6260 ns | 131.94 |    1.21 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |     1.5976 ns |  0.0093 ns |  0.0078 ns |   0.35 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |            |            |        |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |     5.3262 ns |  0.0297 ns |  0.0248 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|               StructLinq_List_Value |                List_Value |   100 |     2.7888 ns |  0.0226 ns |  0.0211 ns |   0.52 |    0.01 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |     1.8591 ns |  0.0149 ns |  0.0139 ns |   0.35 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |            |            |        |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,130.7004 ns | 13.6496 ns | 12.1000 ns |   1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,869.1548 ns |  5.7116 ns |  5.0632 ns |   0.88 |    0.01 | 0.0191 |     - |     - |      40 B |
|                                     |                           |       |               |            |            |        |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   268.1840 ns |  2.2092 ns |  2.0664 ns |   1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   392.7960 ns |  1.6420 ns |  1.5360 ns |   1.46 |    0.01 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   259.4105 ns |  1.1252 ns |  1.0526 ns |   0.97 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |               |            |            |        |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |     4.5680 ns |  0.0190 ns |  0.0159 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   393.2527 ns |  1.7621 ns |  1.3757 ns |  86.08 |    0.37 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |     1.6373 ns |  0.0102 ns |  0.0096 ns |   0.36 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |            |            |        |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |     5.3524 ns |  0.0373 ns |  0.0311 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|           StructLinq_List_Reference |            List_Reference |   100 |   392.4854 ns |  1.5978 ns |  1.3342 ns |  73.33 |    0.59 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |     1.8441 ns |  0.0264 ns |  0.0234 ns |   0.34 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |               |            |            |        |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,004.1888 ns |  9.6982 ns |  9.0717 ns |   1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,833.6994 ns |  4.4405 ns |  3.9364 ns |   0.91 |    0.00 | 0.0191 |     - |     - |      40 B |
