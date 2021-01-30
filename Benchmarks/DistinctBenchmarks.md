## DistinctBenchmarks

### Source
[DistinctBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/DistinctBenchmarks.cs)

### References:
- Linq: 4.8.4300.0
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.19.3](https://www.nuget.org/packages/StructLinq/0.19.3)
- NetFabric.Hyperlinq: [3.0.0-beta27](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta27)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
  [Host]        : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                              Method |                Categories | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |----------:|----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |  5.105 μs | 0.1594 μs | 0.4675 μs |  5.269 μs |  1.00 |    0.00 | 2.0599 |     - |     - |    4312 B |
|                    StructLinq_Array |                     Array |   100 |  3.333 μs | 0.0634 μs | 0.0678 μs |  3.328 μs |  0.76 |    0.05 | 1.3962 |     - |     - |    2928 B |
|                     Hyperlinq_Array |                     Array |   100 |  2.084 μs | 0.0408 μs | 0.0516 μs |  2.095 μs |  0.48 |    0.03 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |  2.222 μs | 0.0378 μs | 0.0335 μs |  2.231 μs |  0.50 |    0.03 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |  2.375 μs | 0.0458 μs | 0.0450 μs |  2.364 μs |  0.55 |    0.03 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |           |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |  5.921 μs | 0.1153 μs | 0.1416 μs |  5.901 μs |  1.00 |    0.00 | 2.0599 |     - |     - |    4312 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |  2.803 μs | 0.0366 μs | 0.0343 μs |  2.797 μs |  0.47 |    0.01 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |  2.182 μs | 0.0429 μs | 0.0460 μs |  2.173 μs |  0.37 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |           |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |  5.103 μs | 0.2116 μs | 0.6238 μs |  5.218 μs |  1.00 |    0.00 | 2.0599 |     - |     - |    4312 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |  2.814 μs | 0.0371 μs | 0.0329 μs |  2.814 μs |  0.48 |    0.02 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |  2.129 μs | 0.0416 μs | 0.0369 μs |  2.133 μs |  0.36 |    0.02 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |           |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |  4.377 μs | 0.0593 μs | 0.0525 μs |  4.380 μs |  1.00 |    0.00 | 2.0599 |     - |     - |    4312 B |
|               StructLinq_List_Value |                List_Value |   100 |  2.810 μs | 0.0424 μs | 0.0376 μs |  2.798 μs |  0.64 |    0.01 | 0.0153 |     - |     - |      32 B |
|                Hyperlinq_List_Value |                List_Value |   100 |  2.528 μs | 0.0501 μs | 0.0469 μs |  2.520 μs |  0.58 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |           |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 10.244 μs | 0.2033 μs | 0.1802 μs | 10.223 μs |  1.00 |    0.00 | 2.0905 |     - |     - |    4400 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 |  5.965 μs | 0.1035 μs | 0.1016 μs |  5.954 μs |  0.58 |    0.01 | 0.0305 |     - |     - |      72 B |
|                                     |                           |       |           |           |           |           |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |  3.967 μs | 0.0731 μs | 0.0870 μs |  3.955 μs |  1.00 |    0.00 | 2.0599 |     - |     - |    4312 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |  2.277 μs | 0.0277 μs | 0.0245 μs |  2.280 μs |  0.57 |    0.01 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |  2.887 μs | 0.0518 μs | 0.0485 μs |  2.897 μs |  0.73 |    0.02 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |           |           |           |           |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |  3.977 μs | 0.0627 μs | 0.1065 μs |  3.963 μs |  1.00 |    0.00 | 2.0599 |     - |     - |    4312 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |  2.270 μs | 0.0421 μs | 0.0394 μs |  2.263 μs |  0.57 |    0.03 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |  2.908 μs | 0.0580 μs | 0.0570 μs |  2.900 μs |  0.73 |    0.03 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |           |           |           |           |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |  3.992 μs | 0.0768 μs | 0.0853 μs |  3.988 μs |  1.00 |    0.00 | 2.0599 |     - |     - |    4312 B |
|           StructLinq_List_Reference |            List_Reference |   100 |  2.273 μs | 0.0265 μs | 0.0207 μs |  2.272 μs |  0.57 |    0.01 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |  2.627 μs | 0.0484 μs | 0.0557 μs |  2.609 μs |  0.66 |    0.02 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |           |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 |  9.779 μs | 0.1291 μs | 0.1008 μs |  9.784 μs |  1.00 |    0.00 | 2.0905 |     - |     - |    4400 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 |  6.486 μs | 0.0938 μs | 0.0878 μs |  6.479 μs |  0.66 |    0.01 | 0.0534 |     - |     - |     112 B |
