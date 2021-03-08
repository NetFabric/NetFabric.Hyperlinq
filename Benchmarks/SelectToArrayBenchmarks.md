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
|                          Linq_Array |                     Array |   100 |   228.83 ns |  1.354 ns |  1.130 ns |  1.00 |    0.00 | 0.2255 |     - |     - |     472 B |
|                    StructLinq_Array |                     Array |   100 |   239.85 ns |  1.168 ns |  1.036 ns |  1.05 |    0.01 | 0.2027 |     - |     - |     424 B |
|                LinqFasterSIMD_Array |                     Array |   100 |    64.34 ns |  0.508 ns |  0.424 ns |  0.28 |    0.00 | 0.2027 |     - |     - |     424 B |
|                     Hyperlinq_Array |                     Array |   100 |   238.51 ns |  2.816 ns |  2.351 ns |  1.04 |    0.01 | 0.2027 |     - |     - |     424 B |
|                      Hyperlinq_Span |                     Array |   100 |   233.72 ns |  1.028 ns |  0.961 ns |  1.02 |    0.00 | 0.2027 |     - |     - |     424 B |
|                 Hyperlinq_Span_SIMD |                     Array |   100 |    83.35 ns |  0.778 ns |  0.689 ns |  0.36 |    0.00 | 0.2027 |     - |     - |     424 B |
|                    Hyperlinq_Memory |                     Array |   100 |   214.62 ns |  0.814 ns |  0.722 ns |  0.94 |    0.01 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,133.33 ns |  6.215 ns |  5.190 ns |  1.00 |    0.00 | 0.5913 |     - |     - |    1240 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,093.34 ns |  6.996 ns |  6.202 ns |  0.97 |    0.01 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   601.66 ns |  1.928 ns |  1.804 ns |  0.53 |    0.00 | 0.2022 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,133.14 ns |  8.410 ns |  7.866 ns |  1.00 |    0.00 | 0.5913 |     - |     - |    1240 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,146.18 ns | 10.781 ns |  9.003 ns |  1.01 |    0.01 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   341.26 ns |  1.621 ns |  1.354 ns |  0.30 |    0.00 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   477.97 ns |  1.926 ns |  1.707 ns |  1.00 |    0.00 | 0.2289 |     - |     - |     480 B |
|               StructLinq_List_Value |                List_Value |   100 |   415.51 ns |  2.476 ns |  2.195 ns |  0.87 |    0.00 | 0.2027 |     - |     - |     424 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   743.36 ns |  3.788 ns |  3.163 ns |  1.55 |    0.01 | 0.2022 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 9,320.94 ns | 47.216 ns | 44.165 ns |  1.00 |    0.00 | 0.7935 |     - |     - |    1680 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 9,874.14 ns | 29.582 ns | 26.223 ns |  1.06 |    0.01 | 0.8087 |     - |     - |    1720 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   858.99 ns |  6.055 ns |  5.664 ns |  1.00 |    0.00 | 0.5922 |     - |     - |    1240 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   893.07 ns |  4.462 ns |  3.956 ns |  1.04 |    0.01 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   976.22 ns |  7.520 ns |  7.035 ns |  1.14 |    0.01 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   853.96 ns |  3.350 ns |  2.970 ns |  1.00 |    0.00 | 0.5922 |     - |     - |    1240 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   898.54 ns |  5.156 ns |  4.570 ns |  1.05 |    0.01 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   592.25 ns |  2.568 ns |  2.277 ns |  0.69 |    0.00 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   413.32 ns |  2.603 ns |  2.174 ns |  1.00 |    0.00 | 0.2294 |     - |     - |     480 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   918.91 ns |  4.664 ns |  4.363 ns |  2.22 |    0.02 | 0.2174 |     - |     - |     456 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   787.17 ns |  4.135 ns |  3.665 ns |  1.91 |    0.01 | 0.2022 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 9,872.54 ns | 53.753 ns | 50.281 ns |  1.00 |    0.00 | 0.7935 |     - |     - |    1680 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 9,457.01 ns | 42.034 ns | 39.319 ns |  0.96 |    0.00 | 0.8240 |     - |     - |    1728 B |
