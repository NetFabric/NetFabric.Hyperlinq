## CountBenchmarks

### Source
[CountBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/CountBenchmarks.cs)

### References:
- Linq: 4.8.4300.0
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.19.3](https://www.nuget.org/packages/StructLinq/0.19.3)
- NetFabric.Hyperlinq: [3.0.0-beta27](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta27)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
  [Host]        : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                              Method |                Categories | Count |          Mean |      Error |     StdDev |        Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |--------------:|-----------:|-----------:|--------------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |    19.6976 ns |  0.4290 ns |  0.7168 ns |    19.7577 ns | 1.000 |    0.00 |      - |     - |     - |         - |
|                    StructLinq_Array |                     Array |   100 |     0.8952 ns |  0.0152 ns |  0.0134 ns |     0.8954 ns | 0.046 |    0.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |     0.0007 ns |  0.0029 ns |  0.0024 ns |     0.0000 ns | 0.000 |    0.00 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |     0.6029 ns |  0.0206 ns |  0.0183 ns |     0.5989 ns | 0.031 |    0.00 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |     0.0000 ns |  0.0000 ns |  0.0000 ns |     0.0000 ns | 0.000 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |            |            |               |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   355.2011 ns |  4.0421 ns |  7.6905 ns |   353.0962 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   320.2009 ns |  1.7671 ns |  1.3797 ns |   320.0548 ns |  0.91 |    0.01 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   150.0925 ns |  0.7138 ns |  0.6328 ns |   150.0484 ns |  0.42 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |               |            |            |               |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |     4.9006 ns |  0.1164 ns |  0.1032 ns |     4.8579 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   347.9247 ns |  3.6921 ns |  3.0830 ns |   346.6035 ns | 71.09 |    1.75 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |     4.5297 ns |  0.0388 ns |  0.0344 ns |     4.5287 ns |  0.92 |    0.02 |      - |     - |     - |         - |
|                                     |                           |       |               |            |            |               |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |     5.4396 ns |  0.1232 ns |  0.1153 ns |     5.4154 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|               StructLinq_List_Value |                List_Value |   100 |   318.3762 ns |  1.3248 ns |  1.1744 ns |   318.0281 ns | 58.66 |    1.18 | 0.0153 |     - |     - |      32 B |
|                Hyperlinq_List_Value |                List_Value |   100 |     1.5939 ns |  0.0161 ns |  0.0143 ns |     1.5976 ns |  0.29 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |               |            |            |               |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,130.2106 ns |  8.9608 ns |  7.9435 ns | 2,133.0330 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,220.4107 ns |  7.8693 ns |  7.3609 ns | 1,220.6538 ns |  0.57 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |            |            |               |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   270.3764 ns |  2.3557 ns |  1.9671 ns |   270.0449 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   238.0843 ns |  4.6337 ns |  4.3343 ns |   236.5528 ns |  0.88 |    0.02 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   257.4844 ns |  3.0478 ns |  2.8509 ns |   258.0962 ns |  0.95 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |               |            |            |               |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |     4.8032 ns |  0.0334 ns |  0.0279 ns |     4.8132 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   259.5699 ns |  1.4457 ns |  1.2815 ns |   259.3522 ns | 54.06 |    0.47 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |     1.5906 ns |  0.0169 ns |  0.0150 ns |     1.5911 ns |  0.33 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |            |            |               |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |     5.6664 ns |  0.0402 ns |  0.0336 ns |     5.6643 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|           StructLinq_List_Reference |            List_Reference |   100 |   258.6688 ns |  1.2747 ns |  1.0644 ns |   258.7528 ns | 45.65 |    0.31 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |     1.6288 ns |  0.0105 ns |  0.0093 ns |     1.6290 ns |  0.29 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |            |            |               |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,015.6929 ns | 16.9993 ns | 15.9012 ns | 2,009.4822 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,825.9598 ns |  8.4232 ns |  7.8791 ns | 1,826.7358 ns |  0.91 |    0.01 | 0.0191 |     - |     - |      40 B |
