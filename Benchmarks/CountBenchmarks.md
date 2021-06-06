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
  Job-FXRHUT : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |          Mean |     Error |    StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |--------------:|----------:|----------:|-------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |     9.3540 ns | 0.0399 ns | 0.0353 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|                    StructLinq_Array |                     Array |   100 |     0.7840 ns | 0.0100 ns | 0.0093 ns |   0.08 |    0.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |     7.7322 ns | 0.0259 ns | 0.0242 ns |   0.83 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |           |           |        |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   349.3511 ns | 2.4083 ns | 2.1349 ns |   1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   597.3489 ns | 2.3495 ns | 2.1978 ns |   1.71 |    0.01 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   140.6946 ns | 0.3631 ns | 0.3396 ns |   0.40 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |           |           |        |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |     4.1085 ns | 0.0220 ns | 0.0195 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   604.9679 ns | 5.7949 ns | 5.4206 ns | 147.31 |    1.75 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |     7.4980 ns | 0.0233 ns | 0.0206 ns |   1.83 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |               |           |           |        |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |     4.9597 ns | 0.0216 ns | 0.0202 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|               StructLinq_List_Value |                List_Value |   100 |     2.3068 ns | 0.0209 ns | 0.0195 ns |   0.47 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |     1.7986 ns | 0.0170 ns | 0.0150 ns |   0.36 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |           |           |        |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,631.2288 ns | 5.2514 ns | 4.9121 ns |   1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 |   775.6346 ns | 1.3539 ns | 1.2664 ns |   0.48 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |           |           |        |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   348.0530 ns | 2.2995 ns | 1.9202 ns |   1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   597.0186 ns | 3.3703 ns | 2.9877 ns |   1.71 |    0.01 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   392.4467 ns | 2.1130 ns | 1.8731 ns |   1.13 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |               |           |           |        |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |     4.1574 ns | 0.0297 ns | 0.0278 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   596.4288 ns | 2.9400 ns | 2.6063 ns | 143.60 |    1.07 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |     1.8501 ns | 0.0173 ns | 0.0153 ns |   0.45 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |           |           |        |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |     4.9423 ns | 0.0317 ns | 0.0281 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|           StructLinq_List_Reference |            List_Reference |   100 |   600.4904 ns | 4.4677 ns | 3.9605 ns | 121.50 |    0.84 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |     1.7823 ns | 0.0152 ns | 0.0135 ns |   0.36 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |           |           |        |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,615.1213 ns | 3.2752 ns | 2.9034 ns |   1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,390.1995 ns | 3.0343 ns | 2.6898 ns |   0.86 |    0.00 | 0.0153 |     - |     - |      32 B |
