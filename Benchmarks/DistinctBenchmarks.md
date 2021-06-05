## DistinctBenchmarks

### Source
[DistinctBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/DistinctBenchmarks.cs)

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
|                              Method |                Categories | Count |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 | 1.902 μs | 0.0359 μs | 0.0336 μs |  1.00 |    0.00 | 1.3294 |     - |     - |   2,784 B |
|                    StructLinq_Array |                     Array |   100 | 1.271 μs | 0.0052 μs | 0.0046 μs |  0.67 |    0.01 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 | 1.476 μs | 0.0065 μs | 0.0060 μs |  0.78 |    0.01 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 | 1.529 μs | 0.0074 μs | 0.0065 μs |  0.80 |    0.02 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 | 1.562 μs | 0.0064 μs | 0.0057 μs |  0.82 |    0.02 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 2.260 μs | 0.0111 μs | 0.0093 μs |  1.00 |    0.00 | 1.3275 |     - |     - |   2,784 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 2.186 μs | 0.0113 μs | 0.0106 μs |  0.97 |    0.01 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 | 1.556 μs | 0.0041 μs | 0.0037 μs |  0.69 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 2.251 μs | 0.0163 μs | 0.0144 μs |  1.00 |    0.00 | 1.3275 |     - |     - |   2,784 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 2.176 μs | 0.0138 μs | 0.0129 μs |  0.97 |    0.01 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 | 1.518 μs | 0.0092 μs | 0.0081 μs |  0.67 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 2.205 μs | 0.0162 μs | 0.0152 μs |  1.00 |    0.00 | 1.3275 |     - |     - |   2,784 B |
|               StructLinq_List_Value |                List_Value |   100 | 1.514 μs | 0.0065 μs | 0.0061 μs |  0.69 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 | 2.732 μs | 0.0129 μs | 0.0114 μs |  1.24 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |          |           |           |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 7.589 μs | 0.1489 μs | 0.1828 μs |  1.00 |    0.00 | 2.0599 |     - |     - |   4,320 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 4.450 μs | 0.0323 μs | 0.0286 μs |  0.59 |    0.02 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 2.195 μs | 0.0094 μs | 0.0083 μs |  1.00 |    0.00 | 1.3275 |     - |     - |   2,784 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 | 2.191 μs | 0.0144 μs | 0.0127 μs |  1.00 |    0.01 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 2.576 μs | 0.0078 μs | 0.0061 μs |  1.17 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |          |           |           |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 2.284 μs | 0.0135 μs | 0.0112 μs |  1.00 |    0.00 | 1.3275 |     - |     - |   2,784 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 | 2.191 μs | 0.0158 μs | 0.0148 μs |  0.96 |    0.01 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 | 2.663 μs | 0.0179 μs | 0.0140 μs |  1.17 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |          |           |           |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 | 2.432 μs | 0.0137 μs | 0.0129 μs |  1.00 |    0.00 | 1.3275 |     - |     - |   2,784 B |
|           StructLinq_List_Reference |            List_Reference |   100 | 2.153 μs | 0.0155 μs | 0.0130 μs |  0.89 |    0.01 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 | 2.765 μs | 0.0202 μs | 0.0179 μs |  1.14 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |          |           |           |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 8.357 μs | 0.1664 μs | 0.2590 μs |  1.00 |    0.00 | 2.0599 |     - |     - |   4,320 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 4.899 μs | 0.0221 μs | 0.0196 μs |  0.59 |    0.02 | 0.0153 |     - |     - |      32 B |
