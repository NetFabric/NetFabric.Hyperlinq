## CountBenchmarks

### Source
[CountBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/CountBenchmarks.cs)

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
|                              Method |                Categories | Count |          Mean |     Error |    StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |--------------:|----------:|----------:|-------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |     8.9989 ns | 0.0181 ns | 0.0141 ns |  1.000 |    0.00 |      - |     - |     - |         - |
|                    StructLinq_Array |                     Array |   100 |     0.9332 ns | 0.0091 ns | 0.0081 ns |  0.104 |    0.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |     0.0000 ns | 0.0000 ns | 0.0000 ns |  0.000 |    0.00 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |     0.2514 ns | 0.0047 ns | 0.0041 ns |  0.028 |    0.00 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |     0.0000 ns | 0.0000 ns | 0.0000 ns |  0.000 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |           |           |        |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   339.9804 ns | 0.7672 ns | 0.6801 ns |   1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   591.7192 ns | 1.8374 ns | 1.6288 ns |   1.74 |    0.01 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   147.5369 ns | 0.3168 ns | 0.2963 ns |   0.43 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |           |           |        |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |     4.6490 ns | 0.0391 ns | 0.0305 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   619.6203 ns | 0.9017 ns | 0.7530 ns | 133.29 |    0.89 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |     4.1855 ns | 0.0207 ns | 0.0184 ns |   0.90 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |               |           |           |        |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |     5.3257 ns | 0.0091 ns | 0.0085 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|               StructLinq_List_Value |                List_Value |   100 |     2.3656 ns | 0.0092 ns | 0.0086 ns |   0.44 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |     1.5443 ns | 0.0211 ns | 0.0176 ns |   0.29 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |           |           |        |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,041.1344 ns | 3.3812 ns | 2.8234 ns |   1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,187.2774 ns | 1.6964 ns | 1.5038 ns |   0.58 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |           |           |        |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   248.8358 ns | 1.4702 ns | 1.3033 ns |   1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   384.4841 ns | 2.5870 ns | 2.1603 ns |   1.55 |    0.01 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   254.0431 ns | 0.7041 ns | 0.5880 ns |   1.02 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |               |           |           |        |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |     4.6522 ns | 0.0152 ns | 0.0127 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   383.2519 ns | 0.8476 ns | 0.7928 ns |  82.37 |    0.32 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |     1.5303 ns | 0.0101 ns | 0.0090 ns |   0.33 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |           |           |        |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |     5.4791 ns | 0.0141 ns | 0.0125 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|           StructLinq_List_Reference |            List_Reference |   100 |   383.6696 ns | 0.7411 ns | 0.6932 ns |  70.01 |    0.20 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |     1.5162 ns | 0.0048 ns | 0.0043 ns |   0.28 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |           |           |        |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,948.7201 ns | 7.2494 ns | 6.0535 ns |   1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,786.5839 ns | 2.9349 ns | 2.6017 ns |   0.92 |    0.00 | 0.0191 |     - |     - |      40 B |
