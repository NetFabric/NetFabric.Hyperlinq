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
  Job-FXRHUT : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |     Mean |     Error |    StdDev |   Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |---------:|----------:|----------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 | 1.902 μs | 0.0095 μs | 0.0084 μs | 1.901 μs |  1.00 |    0.00 | 1.3294 |     - |     - |   2,784 B |
|                    StructLinq_Array |                     Array |   100 | 1.277 μs | 0.0123 μs | 0.0109 μs | 1.273 μs |  0.67 |    0.01 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 | 1.474 μs | 0.0062 μs | 0.0058 μs | 1.472 μs |  0.77 |    0.00 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 | 1.515 μs | 0.0088 μs | 0.0078 μs | 1.516 μs |  0.80 |    0.01 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 | 1.593 μs | 0.0055 μs | 0.0046 μs | 1.593 μs |  0.84 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |          |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 2.245 μs | 0.0141 μs | 0.0117 μs | 2.241 μs |  1.00 |    0.00 | 1.3275 |     - |     - |   2,784 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 2.232 μs | 0.0129 μs | 0.0115 μs | 2.234 μs |  0.99 |    0.01 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 | 1.544 μs | 0.0058 μs | 0.0054 μs | 1.544 μs |  0.69 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |          |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 2.279 μs | 0.0164 μs | 0.0137 μs | 2.275 μs |  1.00 |    0.00 | 1.3275 |     - |     - |   2,784 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 2.240 μs | 0.0204 μs | 0.0181 μs | 2.241 μs |  0.98 |    0.01 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 | 1.532 μs | 0.0069 μs | 0.0061 μs | 1.529 μs |  0.67 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |          |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 2.252 μs | 0.0257 μs | 0.0215 μs | 2.249 μs |  1.00 |    0.00 | 1.3275 |     - |     - |   2,784 B |
|               StructLinq_List_Value |                List_Value |   100 | 1.526 μs | 0.0071 μs | 0.0063 μs | 1.528 μs |  0.68 |    0.01 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 | 2.798 μs | 0.0095 μs | 0.0084 μs | 2.797 μs |  1.24 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |          |           |           |          |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 7.665 μs | 0.0404 μs | 0.0358 μs | 7.666 μs |  1.00 |    0.00 | 2.0599 |     - |     - |   4,320 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 4.387 μs | 0.0145 μs | 0.0136 μs | 4.384 μs |  0.57 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |          |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 2.206 μs | 0.0067 μs | 0.0056 μs | 2.208 μs |  1.00 |    0.00 | 1.3275 |     - |     - |   2,784 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 | 2.210 μs | 0.0134 μs | 0.0126 μs | 2.208 μs |  1.00 |    0.01 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 2.696 μs | 0.0103 μs | 0.0092 μs | 2.696 μs |  1.22 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |          |           |           |          |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 2.238 μs | 0.0134 μs | 0.0125 μs | 2.234 μs |  1.00 |    0.00 | 1.3275 |     - |     - |   2,784 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 | 2.218 μs | 0.0162 μs | 0.0144 μs | 2.225 μs |  0.99 |    0.01 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 | 2.623 μs | 0.0152 μs | 0.0135 μs | 2.624 μs |  1.17 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |          |           |           |          |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 | 2.270 μs | 0.0140 μs | 0.0117 μs | 2.264 μs |  1.00 |    0.00 | 1.3275 |     - |     - |   2,784 B |
|           StructLinq_List_Reference |            List_Reference |   100 | 2.208 μs | 0.0163 μs | 0.0152 μs | 2.204 μs |  0.97 |    0.01 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 | 2.752 μs | 0.0078 μs | 0.0069 μs | 2.754 μs |  1.21 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |          |           |           |          |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 7.447 μs | 0.1489 μs | 0.2183 μs | 7.293 μs |  1.00 |    0.00 | 2.0599 |     - |     - |   4,320 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 4.914 μs | 0.0167 μs | 0.0148 μs | 4.913 μs |  0.65 |    0.02 | 0.0153 |     - |     - |      32 B |
