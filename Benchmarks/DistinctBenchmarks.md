## DistinctBenchmarks

### Source
[DistinctBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/DistinctBenchmarks.cs)

### References:
- Linq: 5.0.0-preview.7.20364.11
- System.Linq.Async: [4.1.1](https://www.nuget.org/packages/System.Linq.Async/4.1.1)
- System.Interactive: [4.1.1](https://www.nuget.org/packages/System.Interactive/4.1.1)
- System.Interactive.Async: [4.1.1](https://www.nuget.org/packages/System.Interactive.Async/4.1.1)
- StructLinq: [0.19.2](https://www.nuget.org/packages/StructLinq/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                              Method |                Categories | Count |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 | 2.918 μs | 0.0200 μs | 0.0187 μs |  1.00 | 2.0599 |     - |     - |    4312 B |
|                    StructLinq_Array |                     Array |   100 | 2.423 μs | 0.0109 μs | 0.0102 μs |  0.83 | 1.4000 |     - |     - |    2928 B |
|                     Hyperlinq_Array |                     Array |   100 | 1.618 μs | 0.0102 μs | 0.0090 μs |  0.55 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 | 1.675 μs | 0.0085 μs | 0.0076 μs |  0.57 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 | 1.666 μs | 0.0090 μs | 0.0080 μs |  0.57 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 3.217 μs | 0.0201 μs | 0.0178 μs |  1.00 | 2.0599 |     - |     - |    4312 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 2.619 μs | 0.0105 μs | 0.0093 μs |  0.81 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 | 1.613 μs | 0.0144 μs | 0.0127 μs |  0.50 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 3.216 μs | 0.0223 μs | 0.0197 μs |  1.00 | 2.0599 |     - |     - |    4312 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 2.645 μs | 0.0077 μs | 0.0064 μs |  0.82 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 | 1.595 μs | 0.0037 μs | 0.0032 μs |  0.50 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 3.222 μs | 0.0253 μs | 0.0237 μs |  1.00 | 2.0599 |     - |     - |    4312 B |
|               StructLinq_List_Value |                List_Value |   100 | 2.585 μs | 0.0173 μs | 0.0144 μs |  0.80 | 0.0153 |     - |     - |      32 B |
|                Hyperlinq_List_Value |                List_Value |   100 | 1.989 μs | 0.0164 μs | 0.0145 μs |  0.62 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 8.228 μs | 0.0451 μs | 0.0422 μs |  1.00 | 2.0905 |     - |     - |    4400 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 4.882 μs | 0.0545 μs | 0.0425 μs |  0.59 | 0.0305 |     - |     - |      72 B |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 2.991 μs | 0.0154 μs | 0.0128 μs |  1.00 | 2.0599 |     - |     - |    4312 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 | 2.024 μs | 0.0121 μs | 0.0101 μs |  0.68 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 2.289 μs | 0.0220 μs | 0.0195 μs |  0.76 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 3.008 μs | 0.0176 μs | 0.0147 μs |  1.00 | 2.0599 |     - |     - |    4312 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 | 1.985 μs | 0.0142 μs | 0.0132 μs |  0.66 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 | 2.191 μs | 0.0150 μs | 0.0133 μs |  0.73 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 | 2.995 μs | 0.0173 μs | 0.0154 μs |  1.00 | 2.0599 |     - |     - |    4312 B |
|           StructLinq_List_Reference |            List_Reference |   100 | 1.977 μs | 0.0169 μs | 0.0158 μs |  0.66 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 | 1.973 μs | 0.0129 μs | 0.0121 μs |  0.66 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 8.048 μs | 0.0608 μs | 0.0508 μs |  1.00 | 2.0905 |     - |     - |    4400 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5.268 μs | 0.0260 μs | 0.0217 μs |  0.65 | 0.0534 |     - |     - |     112 B |
