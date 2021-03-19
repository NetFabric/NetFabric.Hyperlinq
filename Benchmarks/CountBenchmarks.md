## CountBenchmarks

### Source
[CountBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/CountBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.2.21154.6
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1521-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.2.21155.3
  [Host]     : .NET 6.0.0 (6.0.21.15406), X64 RyuJIT
  Job-XHOKQA : .NET 6.0.0 (6.0.21.15406), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |          Mean |     Error |    StdDev |        Median |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |--------------:|----------:|----------:|--------------:|-------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |    10.3993 ns | 0.0441 ns | 0.0368 ns |    10.3876 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|                    StructLinq_Array |                     Array |   100 |     0.9824 ns | 0.0801 ns | 0.2324 ns |     0.8387 ns |   0.10 |    0.01 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |     7.7113 ns | 0.0235 ns | 0.0220 ns |     7.7153 ns |   0.74 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |           |           |               |        |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   356.9077 ns | 1.8740 ns | 1.6612 ns |   356.6942 ns |   1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   576.8413 ns | 2.4870 ns | 2.2046 ns |   576.5287 ns |   1.62 |    0.01 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   142.7680 ns | 0.3979 ns | 0.3722 ns |   142.7317 ns |   0.40 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |           |           |               |        |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |     4.6516 ns | 0.0187 ns | 0.0156 ns |     4.6471 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   602.4877 ns | 3.4145 ns | 3.1939 ns |   602.2316 ns | 129.35 |    0.83 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |     7.5152 ns | 0.0144 ns | 0.0134 ns |     7.5154 ns |   1.62 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |               |           |           |               |        |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |     5.5309 ns | 0.0427 ns | 0.0378 ns |     5.5097 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|               StructLinq_List_Value |                List_Value |   100 |     2.1173 ns | 0.0114 ns | 0.0095 ns |     2.1155 ns |   0.38 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |     1.5830 ns | 0.0067 ns | 0.0056 ns |     1.5826 ns |   0.29 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |           |           |               |        |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,798.5748 ns | 4.3133 ns | 3.8236 ns | 1,798.4897 ns |   1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 |   937.4144 ns | 2.1488 ns | 2.0100 ns |   937.4766 ns |   0.52 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |           |           |               |        |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   348.9051 ns | 1.3518 ns | 1.1288 ns |   349.2017 ns |   1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   604.3288 ns | 1.6966 ns | 1.3246 ns |   604.4109 ns |   1.73 |    0.01 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   365.9486 ns | 2.2888 ns | 2.0290 ns |   365.5504 ns |   1.05 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |               |           |           |               |        |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |     4.6149 ns | 0.0363 ns | 0.0322 ns |     4.6059 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   576.8288 ns | 1.9345 ns | 1.7149 ns |   576.9421 ns | 125.00 |    0.98 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |     1.5439 ns | 0.0139 ns | 0.0116 ns |     1.5435 ns |   0.33 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |           |           |               |        |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |     5.4194 ns | 0.0493 ns | 0.0385 ns |     5.4114 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|           StructLinq_List_Reference |            List_Reference |   100 |   576.9825 ns | 3.0149 ns | 2.6726 ns |   576.4323 ns | 106.53 |    0.70 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |     1.6144 ns | 0.0079 ns | 0.0066 ns |     1.6134 ns |   0.30 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |           |           |               |        |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,793.2356 ns | 5.6385 ns | 5.2742 ns | 1,790.5483 ns |   1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,562.0711 ns | 5.7935 ns | 5.1358 ns | 1,561.1134 ns |   0.87 |    0.00 | 0.0153 |     - |     - |      32 B |
