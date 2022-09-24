## DistinctBenchmarks

### Source
[DistinctBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/DistinctBenchmarks.cs)

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
|                              Method |                Categories | Count |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 | 1.762 μs | 0.0060 μs | 0.0050 μs |  1.00 |    0.00 | 1.3294 |     - |     - |   2,784 B |
|                    StructLinq_Array |                     Array |   100 | 1.253 μs | 0.0074 μs | 0.0061 μs |  0.71 |    0.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 | 1.468 μs | 0.0061 μs | 0.0054 μs |  0.83 |    0.00 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 | 1.546 μs | 0.0082 μs | 0.0076 μs |  0.88 |    0.00 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 | 1.561 μs | 0.0080 μs | 0.0071 μs |  0.89 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 2.381 μs | 0.0472 μs | 0.0775 μs |  1.00 |    0.00 | 1.3275 |     - |     - |   2,784 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 2.206 μs | 0.0220 μs | 0.0206 μs |  0.95 |    0.04 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 | 1.495 μs | 0.0074 μs | 0.0069 μs |  0.65 |    0.02 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 2.249 μs | 0.0102 μs | 0.0096 μs |  1.00 |    0.00 | 1.3275 |     - |     - |   2,784 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 2.210 μs | 0.0175 μs | 0.0163 μs |  0.98 |    0.01 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 | 1.472 μs | 0.0064 μs | 0.0053 μs |  0.65 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 2.305 μs | 0.0117 μs | 0.0104 μs |  1.00 |    0.00 | 1.3275 |     - |     - |   2,784 B |
|               StructLinq_List_Value |                List_Value |   100 | 1.490 μs | 0.0110 μs | 0.0102 μs |  0.65 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 | 2.725 μs | 0.0121 μs | 0.0113 μs |  1.18 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |          |           |           |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 7.732 μs | 0.0411 μs | 0.0364 μs |  1.00 |    0.00 | 2.0599 |     - |     - |   4,320 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 4.331 μs | 0.0281 μs | 0.0263 μs |  0.56 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 2.316 μs | 0.0227 μs | 0.0189 μs |  1.00 |    0.00 | 1.3275 |     - |     - |   2,784 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 | 2.209 μs | 0.0186 μs | 0.0174 μs |  0.95 |    0.01 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 2.636 μs | 0.0155 μs | 0.0137 μs |  1.14 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |          |           |           |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 2.250 μs | 0.0091 μs | 0.0085 μs |  1.00 |    0.00 | 1.3275 |     - |     - |   2,784 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 | 2.199 μs | 0.0201 μs | 0.0188 μs |  0.98 |    0.01 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 | 2.661 μs | 0.0150 μs | 0.0125 μs |  1.18 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |          |           |           |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 | 2.307 μs | 0.0134 μs | 0.0119 μs |  1.00 |    0.00 | 1.3275 |     - |     - |   2,784 B |
|           StructLinq_List_Reference |            List_Reference |   100 | 2.175 μs | 0.0134 μs | 0.0125 μs |  0.94 |    0.01 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 | 2.781 μs | 0.0236 μs | 0.0209 μs |  1.21 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |          |           |           |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 7.339 μs | 0.1288 μs | 0.1888 μs |  1.00 |    0.00 | 2.0599 |     - |     - |   4,320 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5.030 μs | 0.0163 μs | 0.0152 μs |  0.68 |    0.02 | 0.0153 |     - |     - |      32 B |
