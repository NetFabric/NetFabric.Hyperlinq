## CountBenchmarks

### Source
[CountBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/CountBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.4.21253.7
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.13.0.1555-nightly, OS=Windows 10.0.19043.1023 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21255.9
  [Host]     : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT
  Job-SUCOWF : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |          Mean |     Error |    StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |--------------:|----------:|----------:|-------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |     9.1074 ns | 0.0784 ns | 0.0655 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|                    StructLinq_Array |                     Array |   100 |     0.6715 ns | 0.0133 ns | 0.0125 ns |   0.07 |    0.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |     7.9661 ns | 0.0225 ns | 0.0210 ns |   0.87 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |               |           |           |        |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   349.7961 ns | 3.6308 ns | 3.3963 ns |   1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   598.2427 ns | 2.5847 ns | 2.0180 ns |   1.71 |    0.02 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   141.0781 ns | 0.2799 ns | 0.2618 ns |   0.40 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |           |           |        |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |     4.0306 ns | 0.0247 ns | 0.0207 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   651.6739 ns | 4.1784 ns | 3.4892 ns | 161.69 |    1.35 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |     7.7398 ns | 0.0236 ns | 0.0209 ns |   1.92 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |               |           |           |        |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |     5.0033 ns | 0.0309 ns | 0.0274 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|               StructLinq_List_Value |                List_Value |   100 |     2.0895 ns | 0.0152 ns | 0.0143 ns |   0.42 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |     1.7885 ns | 0.0177 ns | 0.0157 ns |   0.36 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |           |           |        |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,617.7575 ns | 5.5046 ns | 4.2976 ns |   1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 |   776.3272 ns | 2.0551 ns | 1.7161 ns |   0.48 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |           |           |        |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   347.5843 ns | 1.2942 ns | 1.1473 ns |   1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   648.1673 ns | 3.0979 ns | 2.7462 ns |   1.86 |    0.01 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   382.5596 ns | 3.7097 ns | 3.2886 ns |   1.10 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |               |           |           |        |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |     4.1545 ns | 0.0403 ns | 0.0377 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   596.9610 ns | 1.8706 ns | 1.6583 ns | 143.75 |    1.49 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |     1.7762 ns | 0.0103 ns | 0.0091 ns |   0.43 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |           |           |        |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |     4.9565 ns | 0.0651 ns | 0.0577 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|           StructLinq_List_Reference |            List_Reference |   100 |   604.8412 ns | 3.4385 ns | 3.2164 ns | 122.05 |    1.78 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |     1.7892 ns | 0.0157 ns | 0.0140 ns |   0.36 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |           |           |        |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,617.0364 ns | 4.1368 ns | 3.8696 ns |   1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,416.2269 ns | 3.3714 ns | 2.9887 ns |   0.88 |    0.00 | 0.0153 |     - |     - |      32 B |
