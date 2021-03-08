## SelectToArrayBenchmarks

### Source
[SelectToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectToArrayBenchmarks.cs)

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
|                              Method |                Categories | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   223.23 ns |  1.560 ns |  1.383 ns |  1.00 |    0.00 | 0.2255 |     - |     - |     472 B |
|                    StructLinq_Array |                     Array |   100 |   205.67 ns |  0.680 ns |  0.602 ns |  0.92 |    0.01 | 0.2027 |     - |     - |     424 B |
|                LinqFasterSIMD_Array |                     Array |   100 |    59.81 ns |  0.435 ns |  0.407 ns |  0.27 |    0.00 | 0.2027 |     - |     - |     424 B |
|                     Hyperlinq_Array |                     Array |   100 |   226.80 ns |  1.353 ns |  1.199 ns |  1.02 |    0.01 | 0.2027 |     - |     - |     424 B |
|                      Hyperlinq_Span |                     Array |   100 |   224.74 ns |  1.118 ns |  0.991 ns |  1.01 |    0.01 | 0.2027 |     - |     - |     424 B |
|                 Hyperlinq_Span_SIMD |                     Array |   100 |    79.81 ns |  0.522 ns |  0.436 ns |  0.36 |    0.00 | 0.2027 |     - |     - |     424 B |
|                    Hyperlinq_Memory |                     Array |   100 |   227.81 ns |  1.037 ns |  0.810 ns |  1.02 |    0.01 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,075.44 ns |  4.990 ns |  4.668 ns |  1.00 |    0.00 | 0.5913 |     - |     - |    1240 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,042.42 ns |  4.995 ns |  4.428 ns |  0.97 |    0.01 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 | 1,129.65 ns |  5.108 ns |  4.778 ns |  1.05 |    0.01 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,104.49 ns |  6.788 ns |  6.350 ns |  1.00 |    0.00 | 0.5913 |     - |     - |    1240 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,046.35 ns |  6.026 ns |  5.636 ns |  0.95 |    0.01 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   810.39 ns |  2.472 ns |  2.064 ns |  0.73 |    0.01 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   416.57 ns |  2.308 ns |  2.159 ns |  1.00 |    0.00 | 0.2294 |     - |     - |     480 B |
|               StructLinq_List_Value |                List_Value |   100 |   399.19 ns |  1.977 ns |  1.752 ns |  0.96 |    0.01 | 0.2027 |     - |     - |     424 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   707.03 ns |  2.711 ns |  2.264 ns |  1.70 |    0.01 | 0.2022 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 9,243.09 ns | 48.639 ns | 40.615 ns |  1.00 |    0.00 | 0.7935 |     - |     - |    1680 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 9,346.30 ns | 56.150 ns | 52.522 ns |  1.01 |    0.01 | 0.8240 |     - |     - |    1728 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   867.74 ns |  3.468 ns |  2.896 ns |  1.00 |    0.00 | 0.5922 |     - |     - |    1240 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   871.03 ns |  4.051 ns |  3.592 ns |  1.00 |    0.01 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   931.05 ns |  3.232 ns |  2.698 ns |  1.07 |    0.01 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   899.98 ns |  2.583 ns |  2.157 ns |  1.00 |    0.00 | 0.5922 |     - |     - |    1240 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   889.57 ns |  3.921 ns |  3.476 ns |  0.99 |    0.00 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   565.60 ns |  2.817 ns |  2.199 ns |  0.63 |    0.00 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   393.59 ns |  2.501 ns |  2.088 ns |  1.00 |    0.00 | 0.2294 |     - |     - |     480 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   817.16 ns |  3.243 ns |  3.033 ns |  2.08 |    0.01 | 0.2174 |     - |     - |     456 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   757.72 ns |  4.361 ns |  3.866 ns |  1.92 |    0.02 | 0.2022 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 9,061.28 ns | 44.217 ns | 41.360 ns |  1.00 |    0.00 | 0.7935 |     - |     - |    1680 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 9,243.27 ns | 50.297 ns | 44.587 ns |  1.02 |    0.01 | 0.8240 |     - |     - |    1728 B |
