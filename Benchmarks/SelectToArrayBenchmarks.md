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
|                              Method |                Categories | Count |        Mean |      Error |     StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|-----------:|-----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   266.30 ns |   0.996 ns |   0.883 ns |   266.33 ns |  1.00 |    0.00 | 0.2255 |     - |     - |     472 B |
|                    StructLinq_Array |                     Array |   100 |   230.11 ns |   0.430 ns |   0.402 ns |   230.07 ns |  0.86 |    0.00 | 0.2027 |     - |     - |     424 B |
|                LinqFasterSIMD_Array |                     Array |   100 |    61.06 ns |   0.906 ns |   0.848 ns |    61.18 ns |  0.23 |    0.00 | 0.2027 |     - |     - |     424 B |
|                     Hyperlinq_Array |                     Array |   100 |   228.43 ns |   4.636 ns |   6.795 ns |   225.50 ns |  0.87 |    0.03 | 0.2027 |     - |     - |     424 B |
|                Hyperlinq_Array_SIMD |                     Array |   100 |    80.84 ns |   0.477 ns |   0.422 ns |    80.85 ns |  0.30 |    0.00 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |             |            |            |             |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,087.02 ns |   4.618 ns |   4.320 ns | 1,086.41 ns |  1.00 |    0.00 | 0.5913 |     - |     - |    1240 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,027.28 ns |   3.503 ns |   3.105 ns | 1,026.13 ns |  0.95 |    0.00 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   577.04 ns |   7.168 ns |   6.354 ns |   574.94 ns |  0.53 |    0.01 | 0.2022 |     - |     - |     424 B |
|                                     |                           |       |             |            |            |             |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,016.00 ns |   4.421 ns |   3.919 ns | 1,015.71 ns |  1.00 |    0.00 | 0.5913 |     - |     - |    1240 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,003.42 ns |   3.857 ns |   3.608 ns | 1,003.91 ns |  0.99 |    0.01 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   329.29 ns |   6.231 ns |  10.238 ns |   326.48 ns |  0.33 |    0.01 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |             |            |            |             |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   450.50 ns |   1.984 ns |   1.856 ns |   450.73 ns |  1.00 |    0.00 | 0.2294 |     - |     - |     480 B |
|               StructLinq_List_Value |                List_Value |   100 |   420.33 ns |   0.768 ns |   0.600 ns |   420.47 ns |  0.93 |    0.00 | 0.2027 |     - |     - |     424 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   710.39 ns |   2.213 ns |   2.070 ns |   710.80 ns |  1.58 |    0.01 | 0.2022 |     - |     - |     424 B |
|                                     |                           |       |             |            |            |             |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 9,100.44 ns | 173.408 ns | 269.975 ns | 8,970.54 ns |  1.00 |    0.00 | 0.7935 |     - |     - |    1680 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 3,243.73 ns |   5.176 ns |   4.588 ns | 3,242.45 ns |  0.36 |    0.01 | 0.5646 |     - |     - |    1184 B |
|                                     |                           |       |             |            |            |             |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   880.15 ns |  17.540 ns |  38.502 ns |   859.06 ns |  1.00 |    0.00 | 0.5922 |     - |     - |    1240 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   848.52 ns |   2.958 ns |   2.622 ns |   848.33 ns |  0.97 |    0.04 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   870.31 ns |   4.246 ns |   3.764 ns |   870.27 ns |  1.00 |    0.04 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |            |            |             |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   809.89 ns |   4.995 ns |   4.428 ns |   809.57 ns |  1.00 |    0.00 | 0.5922 |     - |     - |    1240 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   817.48 ns |   3.859 ns |   3.421 ns |   817.35 ns |  1.01 |    0.01 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   603.54 ns |   2.087 ns |   1.952 ns |   603.40 ns |  0.75 |    0.00 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |            |            |             |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   411.50 ns |   3.098 ns |   2.587 ns |   411.04 ns |  1.00 |    0.00 | 0.2294 |     - |     - |     480 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   864.78 ns |   6.857 ns |   6.079 ns |   864.46 ns |  2.10 |    0.02 | 0.2174 |     - |     - |     456 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   725.33 ns |   1.868 ns |   1.656 ns |   725.76 ns |  1.76 |    0.01 | 0.2022 |     - |     - |     424 B |
|                                     |                           |       |             |            |            |             |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 9,888.42 ns |  33.364 ns |  29.576 ns | 9,880.00 ns |  1.00 |    0.00 | 0.7935 |     - |     - |    1680 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 4,841.00 ns |  11.640 ns |  10.318 ns | 4,841.20 ns |  0.49 |    0.00 | 0.5798 |     - |     - |    1224 B |
