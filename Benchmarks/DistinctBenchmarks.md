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
|                          Linq_Array |                     Array |   100 | 3.008 μs | 0.0072 μs | 0.0060 μs |  1.00 | 2.0599 |     - |     - |    4312 B |
|                    StructLinq_Array |                     Array |   100 | 1.289 μs | 0.0074 μs | 0.0065 μs |  0.43 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 | 1.523 μs | 0.0056 μs | 0.0049 μs |  0.51 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 | 1.501 μs | 0.0051 μs | 0.0046 μs |  0.50 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 | 1.560 μs | 0.0071 μs | 0.0060 μs |  0.52 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 3.393 μs | 0.0254 μs | 0.0212 μs |  1.00 | 2.0599 |     - |     - |    4312 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 2.177 μs | 0.0158 μs | 0.0140 μs |  0.64 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 | 2.697 μs | 0.0221 μs | 0.0185 μs |  0.80 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 3.382 μs | 0.0210 μs | 0.0196 μs |  1.00 | 2.0599 |     - |     - |    4312 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 2.161 μs | 0.0134 μs | 0.0112 μs |  0.64 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 | 2.718 μs | 0.0186 μs | 0.0165 μs |  0.80 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 3.389 μs | 0.0263 μs | 0.0233 μs |  1.00 | 2.0599 |     - |     - |    4312 B |
|               StructLinq_List_Value |                List_Value |   100 | 1.563 μs | 0.0065 μs | 0.0058 μs |  0.46 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 | 1.840 μs | 0.0069 μs | 0.0057 μs |  0.54 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 8.043 μs | 0.0481 μs | 0.0450 μs |  1.00 | 2.0599 |     - |     - |    4328 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 5.350 μs | 0.0219 μs | 0.0194 μs |  0.67 | 0.0153 |     - |     - |      40 B |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 2.986 μs | 0.0101 μs | 0.0079 μs |  1.00 | 2.0599 |     - |     - |    4312 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1.774 μs | 0.0087 μs | 0.0081 μs |  0.59 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 2.049 μs | 0.0111 μs | 0.0104 μs |  0.69 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 2.998 μs | 0.0151 μs | 0.0134 μs |  1.00 | 2.0599 |     - |     - |    4312 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 | 1.727 μs | 0.0099 μs | 0.0082 μs |  0.58 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 | 1.997 μs | 0.0141 μs | 0.0125 μs |  0.67 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 | 2.995 μs | 0.0096 μs | 0.0085 μs |  1.00 | 2.0599 |     - |     - |    4312 B |
|           StructLinq_List_Reference |            List_Reference |   100 | 1.780 μs | 0.0132 μs | 0.0117 μs |  0.59 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 | 1.916 μs | 0.0065 μs | 0.0061 μs |  0.64 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 7.934 μs | 0.0296 μs | 0.0262 μs |  1.00 | 2.0599 |     - |     - |    4328 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5.052 μs | 0.0165 μs | 0.0146 μs |  0.64 | 0.0153 |     - |     - |      40 B |
