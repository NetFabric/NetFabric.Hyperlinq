## DistinctBenchmarks

### Source
[DistinctBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/DistinctBenchmarks.cs)

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
  Job-KXCEYC : .NET 6.0.0 (6.0.21.15406), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 | 2.917 μs | 0.0135 μs | 0.0119 μs |  1.00 | 2.0599 |     - |     - |   4,312 B |
|                    StructLinq_Array |                     Array |   100 | 1.325 μs | 0.0056 μs | 0.0049 μs |  0.45 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 | 1.494 μs | 0.0095 μs | 0.0084 μs |  0.51 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 | 1.520 μs | 0.0054 μs | 0.0048 μs |  0.52 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 | 1.602 μs | 0.0040 μs | 0.0031 μs |  0.55 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 3.196 μs | 0.0194 μs | 0.0172 μs |  1.00 | 2.0599 |     - |     - |   4,312 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 2.227 μs | 0.0177 μs | 0.0148 μs |  0.70 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 | 1.513 μs | 0.0045 μs | 0.0040 μs |  0.47 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 3.208 μs | 0.0151 μs | 0.0134 μs |  1.00 | 2.0599 |     - |     - |   4,312 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 2.222 μs | 0.0092 μs | 0.0077 μs |  0.69 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 | 1.591 μs | 0.0111 μs | 0.0103 μs |  0.50 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 3.196 μs | 0.0131 μs | 0.0109 μs |  1.00 | 2.0599 |     - |     - |   4,312 B |
|               StructLinq_List_Value |                List_Value |   100 | 1.486 μs | 0.0061 μs | 0.0051 μs |  0.47 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 | 1.939 μs | 0.0130 μs | 0.0115 μs |  0.61 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 7.568 μs | 0.0196 μs | 0.0164 μs |  1.00 | 2.0599 |     - |     - |   4,320 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 4.515 μs | 0.0255 μs | 0.0239 μs |  0.60 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 3.206 μs | 0.0117 μs | 0.0109 μs |  1.00 | 2.0599 |     - |     - |   4,312 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 | 2.211 μs | 0.0129 μs | 0.0114 μs |  0.69 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 2.678 μs | 0.0103 μs | 0.0091 μs |  0.84 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 3.206 μs | 0.0098 μs | 0.0087 μs |  1.00 | 2.0599 |     - |     - |   4,312 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 | 2.264 μs | 0.0071 μs | 0.0063 μs |  0.71 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 | 2.747 μs | 0.0141 μs | 0.0125 μs |  0.86 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 | 3.197 μs | 0.0147 μs | 0.0131 μs |  1.00 | 2.0599 |     - |     - |   4,312 B |
|           StructLinq_List_Reference |            List_Reference |   100 | 2.259 μs | 0.0107 μs | 0.0100 μs |  0.71 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 | 1.946 μs | 0.0174 μs | 0.0154 μs |  0.61 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 7.581 μs | 0.0228 μs | 0.0202 μs |  1.00 | 2.0599 |     - |     - |   4,320 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5.285 μs | 0.0824 μs | 0.0731 μs |  0.70 | 0.0153 |     - |     - |      32 B |
