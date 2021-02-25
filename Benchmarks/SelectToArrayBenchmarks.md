## SelectToArrayBenchmarks

### Source
[SelectToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectToArrayBenchmarks.cs)

### References:
- Linq: 5.0.3
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta39](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta39)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=6.0.100-preview.1.21103.13
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                              Method |                Categories | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   267.88 ns |  2.668 ns |  2.365 ns |  1.00 |    0.00 | 0.2255 |     - |     - |     472 B |
|                    StructLinq_Array |                     Array |   100 |   273.06 ns |  4.607 ns |  4.084 ns |  1.02 |    0.01 | 0.2027 |     - |     - |     424 B |
|                LinqFasterSIMD_Array |                     Array |   100 |    99.65 ns |  1.953 ns |  1.827 ns |  0.37 |    0.01 | 0.2027 |     - |     - |     424 B |
|                     Hyperlinq_Array |                     Array |   100 |   269.94 ns |  4.902 ns |  4.585 ns |  1.01 |    0.02 | 0.2027 |     - |     - |     424 B |
|                      Hyperlinq_Span |                     Array |   100 |   239.28 ns |  2.553 ns |  2.388 ns |  0.89 |    0.01 | 0.2027 |     - |     - |     424 B |
|                 Hyperlinq_Span_SIMD |                     Array |   100 |   109.47 ns |  1.910 ns |  1.693 ns |  0.41 |    0.01 | 0.2027 |     - |     - |     424 B |
|                    Hyperlinq_Memory |                     Array |   100 |   274.17 ns |  5.390 ns |  5.991 ns |  1.02 |    0.02 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,285.51 ns | 25.581 ns | 26.270 ns |  1.00 |    0.00 | 0.5913 |     - |     - |    1240 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,129.23 ns |  8.712 ns |  7.723 ns |  0.88 |    0.02 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   663.26 ns |  6.979 ns |  6.528 ns |  0.52 |    0.01 | 0.2022 |     - |     - |     424 B |
|     Hyperlinq_Enumerable_Value_SIMD |          Enumerable_Value |   100 |   700.52 ns |  9.899 ns | 10.591 ns |  0.55 |    0.01 | 0.2289 |     - |     - |     480 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,273.49 ns | 18.642 ns | 16.526 ns |  1.00 |    0.00 | 0.5913 |     - |     - |    1240 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,153.21 ns |  6.918 ns |  6.133 ns |  0.91 |    0.01 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   406.46 ns |  6.649 ns |  6.219 ns |  0.32 |    0.01 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   468.99 ns |  4.210 ns |  3.516 ns |  1.00 |    0.00 | 0.2294 |     - |     - |     480 B |
|               StructLinq_List_Value |                List_Value |   100 |   445.91 ns |  5.327 ns |  4.159 ns |  0.95 |    0.01 | 0.2027 |     - |     - |     424 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   511.99 ns |  5.562 ns |  4.931 ns |  1.09 |    0.01 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   964.21 ns | 17.884 ns | 15.854 ns |  1.00 |    0.00 | 0.5922 |     - |     - |    1240 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   936.40 ns | 10.404 ns |  8.688 ns |  0.97 |    0.02 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,000.13 ns |  5.117 ns |  4.273 ns |  1.04 |    0.02 | 0.2174 |     - |     - |     456 B |
| Hyperlinq_Enumerable_Reference_SIMD |      Enumerable_Reference |   100 |   978.08 ns |  6.965 ns |  6.515 ns |  1.02 |    0.02 | 0.2441 |     - |     - |     512 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   958.07 ns | 11.892 ns |  9.930 ns |  1.00 |    0.00 | 0.5922 |     - |     - |    1240 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   938.89 ns |  9.194 ns |  7.178 ns |  0.98 |    0.01 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   645.53 ns |  8.129 ns |  7.604 ns |  0.67 |    0.01 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   470.57 ns |  6.943 ns |  6.155 ns |  1.00 |    0.00 | 0.2294 |     - |     - |     480 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   942.82 ns |  5.208 ns |  4.066 ns |  2.01 |    0.02 | 0.2174 |     - |     - |     456 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   483.23 ns |  3.540 ns |  3.312 ns |  1.03 |    0.01 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 9,811.24 ns | 52.535 ns | 49.142 ns |     ? |       ? | 0.8087 |     - |     - |    1712 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 9,564.61 ns | 61.404 ns | 57.437 ns |     ? |       ? | 0.8240 |     - |     - |    1728 B |
