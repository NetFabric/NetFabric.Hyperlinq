## DistinctBenchmarks

### Source
[DistinctBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/DistinctBenchmarks.cs)

### References:
- Linq: 5.0.3
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=6.0.100-preview.1.21103.13
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                              Method |                Categories | Count |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 | 2.946 μs | 0.0232 μs | 0.0217 μs |  1.00 | 2.0599 |     - |     - |    4312 B |
|                    StructLinq_Array |                     Array |   100 | 1.271 μs | 0.0033 μs | 0.0026 μs |  0.43 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 | 1.520 μs | 0.0063 μs | 0.0052 μs |  0.52 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 | 1.463 μs | 0.0050 μs | 0.0047 μs |  0.50 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 | 1.545 μs | 0.0047 μs | 0.0044 μs |  0.52 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 3.273 μs | 0.0077 μs | 0.0068 μs |  1.00 | 2.0599 |     - |     - |    4312 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 2.138 μs | 0.0127 μs | 0.0119 μs |  0.65 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 | 1.492 μs | 0.0042 μs | 0.0037 μs |  0.46 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 3.267 μs | 0.0078 μs | 0.0073 μs |  1.00 | 2.0599 |     - |     - |    4312 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 2.157 μs | 0.0122 μs | 0.0114 μs |  0.66 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 | 1.484 μs | 0.0032 μs | 0.0028 μs |  0.45 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 3.273 μs | 0.0100 μs | 0.0078 μs |  1.00 | 2.0599 |     - |     - |    4312 B |
|               StructLinq_List_Value |                List_Value |   100 | 1.463 μs | 0.0052 μs | 0.0049 μs |  0.45 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 | 1.869 μs | 0.0025 μs | 0.0019 μs |  0.57 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 7.863 μs | 0.0375 μs | 0.0332 μs |  1.00 | 2.0599 |     - |     - |    4328 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 4.634 μs | 0.0108 μs | 0.0090 μs |  0.59 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 2.911 μs | 0.0097 μs | 0.0086 μs |  1.00 | 2.0599 |     - |     - |    4312 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1.726 μs | 0.0113 μs | 0.0105 μs |  0.59 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1.901 μs | 0.0121 μs | 0.0101 μs |  0.65 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 2.897 μs | 0.0096 μs | 0.0085 μs |  1.00 | 2.0599 |     - |     - |    4312 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 | 1.724 μs | 0.0111 μs | 0.0104 μs |  0.60 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 | 1.940 μs | 0.0053 μs | 0.0047 μs |  0.67 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 | 2.913 μs | 0.0181 μs | 0.0151 μs |  1.00 | 2.0599 |     - |     - |    4312 B |
|           StructLinq_List_Reference |            List_Reference |   100 | 1.776 μs | 0.0073 μs | 0.0069 μs |  0.61 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 | 1.847 μs | 0.0075 μs | 0.0070 μs |  0.63 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 7.864 μs | 0.0220 μs | 0.0206 μs |  1.00 | 2.0599 |     - |     - |    4328 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 4.945 μs | 0.0087 μs | 0.0077 μs |  0.63 | 0.0153 |     - |     - |      40 B |
