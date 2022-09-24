## CountBenchmarks

### Source
[CountBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/CountBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.5.21301.5
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.13.0.1555-nightly, OS=Windows 10.0.19043.1055 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.5.21302.13
  [Host]     : .NET 6.0.0 (6.0.21.30105), X64 RyuJIT
  Job-UNTOJZ : .NET 6.0.0 (6.0.21.30105), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |          Mean |     Error |    StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |--------------:|----------:|----------:|-------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |     8.6538 ns | 0.0562 ns | 0.0498 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|                    StructLinq_Array |                     Array |   100 |     0.7170 ns | 0.0126 ns | 0.0112 ns |   0.08 |    0.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |     7.9852 ns | 0.0270 ns | 0.0253 ns |   0.92 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |               |           |           |        |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   349.4069 ns | 2.8233 ns | 2.3575 ns |   1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   619.7720 ns | 4.5373 ns | 4.0222 ns |   1.77 |    0.01 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   140.7260 ns | 0.2846 ns | 0.2523 ns |   0.40 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |           |           |        |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |     4.1117 ns | 0.0213 ns | 0.0199 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   618.7262 ns | 3.1791 ns | 2.6547 ns | 150.49 |    0.88 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |     7.5543 ns | 0.0264 ns | 0.0247 ns |   1.84 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |               |           |           |        |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |     4.9752 ns | 0.0545 ns | 0.0483 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|               StructLinq_List_Value |                List_Value |   100 |     2.3856 ns | 0.0229 ns | 0.0214 ns |   0.48 |    0.01 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |     1.6012 ns | 0.0116 ns | 0.0109 ns |   0.32 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |           |           |        |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,624.5794 ns | 6.4122 ns | 5.6842 ns |   1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 |   778.0014 ns | 2.2398 ns | 1.9856 ns |   0.48 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |           |           |        |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   345.5721 ns | 1.6528 ns | 1.3802 ns |   1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   622.3207 ns | 6.1665 ns | 5.4665 ns |   1.80 |    0.02 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   399.7432 ns | 3.6850 ns | 3.0771 ns |   1.16 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |               |           |           |        |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |     4.1547 ns | 0.0307 ns | 0.0272 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   617.2308 ns | 1.6776 ns | 1.4871 ns | 148.57 |    1.08 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |     1.7886 ns | 0.0117 ns | 0.0104 ns |   0.43 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |           |           |        |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |     4.9597 ns | 0.0286 ns | 0.0268 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|           StructLinq_List_Reference |            List_Reference |   100 |   620.5949 ns | 3.4575 ns | 3.2342 ns | 125.13 |    0.90 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |     1.7393 ns | 0.0310 ns | 0.0275 ns |   0.35 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |               |           |           |        |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,630.2851 ns | 4.5997 ns | 4.3025 ns |   1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,419.2966 ns | 3.7573 ns | 3.3308 ns |   0.87 |    0.00 | 0.0153 |     - |     - |      32 B |
