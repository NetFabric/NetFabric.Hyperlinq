## CountBenchmarks

### References:
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta25](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta25)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                              Method |                Categories | Count |          Mean |      Error |     StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |--------------:|-----------:|-----------:|-------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |    10.4993 ns |  0.1158 ns |  0.1026 ns |  1.000 |    0.00 |      - |     - |     - |         - |
|                    StructLinq_Count |                     Array |   100 |   155.4772 ns |  1.5736 ns |  1.4720 ns | 14.824 |    0.14 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |     0.0416 ns |  0.0127 ns |  0.0113 ns |  0.004 |    0.00 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |     0.2946 ns |  0.0106 ns |  0.0094 ns |  0.028 |    0.00 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |     0.0471 ns |  0.0068 ns |  0.0064 ns |  0.005 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |            |            |        |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   347.9984 ns |  3.1494 ns |  2.9459 ns |   1.00 |    0.00 | 0.0114 |     - |     - |      24 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   163.1662 ns |  1.4905 ns |  1.3942 ns |   0.47 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |               |            |            |        |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |     4.1681 ns |  0.0266 ns |  0.0236 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |     2.1684 ns |  0.0220 ns |  0.0195 ns |   0.52 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |               |            |            |        |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |     4.9504 ns |  0.0464 ns |  0.0412 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |     1.5567 ns |  0.0278 ns |  0.0247 ns |   0.31 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |               |            |            |        |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,096.7322 ns |  9.6816 ns |  9.0562 ns |   1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,761.0286 ns | 12.6118 ns | 11.7971 ns |   0.84 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |               |            |            |        |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   328.3490 ns |  1.2772 ns |  1.1947 ns |   1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   293.9245 ns |  1.4960 ns |  1.2492 ns |   0.89 |    0.00 | 0.0191 |     - |     - |      40 B |
|                                     |                           |       |               |            |            |        |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |     4.0545 ns |  0.0272 ns |  0.0242 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |     1.5536 ns |  0.0186 ns |  0.0164 ns |   0.38 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |            |            |        |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |     5.0560 ns |  0.0444 ns |  0.0415 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq_List_Reference |            List_Reference |   100 |     1.6272 ns |  0.0102 ns |  0.0090 ns |   0.32 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |            |            |        |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 4,126.1110 ns | 22.2213 ns | 20.7858 ns |   1.00 |    0.00 |      - |     - |     - |         - |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 3,966.9733 ns | 28.8916 ns | 27.0252 ns |   0.96 |    0.01 | 0.0076 |     - |     - |      24 B |
