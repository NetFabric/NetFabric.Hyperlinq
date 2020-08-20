## CountBenchmarks

### Source
[CountBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/CountBenchmarks.cs)

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
|                              Method |                Categories | Count |          Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |--------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |     9.2162 ns |  0.0720 ns |  0.0673 ns | 1.000 |    0.00 |      - |     - |     - |         - |
|                    StructLinq_Array |                     Array |   100 |     0.3560 ns |  0.0147 ns |  0.0164 ns | 0.039 |    0.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |     0.0464 ns |  0.0103 ns |  0.0086 ns | 0.005 |    0.00 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |     0.2289 ns |  0.0120 ns |  0.0112 ns | 0.025 |    0.00 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |     0.0103 ns |  0.0058 ns |  0.0051 ns | 0.001 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |            |            |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   372.2241 ns |  2.9226 ns |  2.4405 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   343.6181 ns |  1.6125 ns |  1.4294 ns |  0.92 |    0.01 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   144.0468 ns |  0.6876 ns |  0.6095 ns |  0.39 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |            |            |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |     4.3200 ns |  0.0246 ns |  0.0206 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   343.8271 ns |  2.2970 ns |  2.1486 ns | 79.67 |    0.60 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |     2.0902 ns |  0.0104 ns |  0.0093 ns |  0.48 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |            |            |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |     5.1126 ns |  0.0516 ns |  0.0483 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|               StructLinq_List_Value |                List_Value |   100 |   343.2197 ns |  1.9921 ns |  1.7659 ns | 67.10 |    0.79 | 0.0153 |     - |     - |      32 B |
|                Hyperlinq_List_Value |                List_Value |   100 |     1.7868 ns |  0.0266 ns |  0.0236 ns |  0.35 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |               |            |            |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,117.6747 ns | 20.7353 ns | 18.3813 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,256.7285 ns |  7.3072 ns |  6.4777 ns |  0.59 |    0.01 | 0.0191 |     - |     - |      40 B |
|                                     |                           |       |               |            |            |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   267.7147 ns |  1.5762 ns |  1.3973 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   233.7109 ns |  2.1285 ns |  1.8869 ns |  0.87 |    0.01 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   240.4962 ns |  2.0018 ns |  1.8725 ns |  0.90 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |               |            |            |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |     4.3296 ns |  0.0275 ns |  0.0257 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   234.2556 ns |  1.8298 ns |  1.7116 ns | 54.11 |    0.42 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |     1.6381 ns |  0.0214 ns |  0.0190 ns |  0.38 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |            |            |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |     5.1335 ns |  0.0240 ns |  0.0200 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|           StructLinq_List_Reference |            List_Reference |   100 |   233.9458 ns |  1.7232 ns |  1.5275 ns | 45.60 |    0.28 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |     1.7881 ns |  0.0065 ns |  0.0061 ns |  0.35 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |            |            |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,979.2860 ns |  8.5000 ns |  7.5350 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,808.0617 ns | 13.6896 ns | 12.8052 ns |  0.91 |    0.01 | 0.0305 |     - |     - |      64 B |
