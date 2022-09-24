## SelectToArrayBenchmarks

### Source
[SelectToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectToArrayBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.7.21377.19
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.27.0](https://www.nuget.org/packages/StructLinq/0.27.0)
- NetFabric.Hyperlinq: [3.0.0-beta45](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta45)

### Results:
``` ini

BenchmarkDotNet=v0.13.1.1606-nightly, OS=macOS Catalina 10.15.7 (19H1323) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host]     : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT
  .NET 6 PGO : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT

Job=.NET 6 PGO  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |        Mean |      Error |     StdDev |      Median |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|-----------:|-----------:|------------:|-------------:|--------:|-------:|----------:|
|                          Linq_Array |                     Array |   100 |   473.47 ns |   8.574 ns |  13.093 ns |   474.67 ns |     baseline |         | 0.2251 |     472 B |
|                    StructLinq_Array |                     Array |   100 |   279.61 ns |   4.617 ns |   4.093 ns |   282.23 ns | 1.72x faster |   0.04x | 0.2027 |     424 B |
|                LinqFasterSIMD_Array |                     Array |   100 |    85.80 ns |   1.640 ns |   2.455 ns |    85.24 ns | 5.53x faster |   0.21x | 0.2027 |     424 B |
|                     Hyperlinq_Array |                     Array |   100 |   280.63 ns |   5.198 ns |   7.115 ns |   277.93 ns | 1.70x faster |   0.05x | 0.2027 |     424 B |
|                Hyperlinq_Array_SIMD |                     Array |   100 |   102.08 ns |   1.429 ns |   1.336 ns |   102.36 ns | 4.70x faster |   0.09x | 0.2027 |     424 B |
|                                     |                           |       |             |            |            |             |              |         |        |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,201.02 ns | 102.339 ns | 298.527 ns | 1,025.14 ns |     baseline |         | 0.5913 |   1,240 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   805.17 ns |   3.606 ns |   3.011 ns |   804.47 ns | 1.52x faster |   0.38x | 0.2174 |     456 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   715.93 ns |  14.451 ns |  14.840 ns |   711.77 ns | 1.63x faster |   0.42x | 0.2022 |     424 B |
|                                     |                           |       |             |            |            |             |              |         |        |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,183.52 ns |  77.980 ns | 229.924 ns | 1,133.48 ns |     baseline |         | 0.5913 |   1,240 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   805.63 ns |   3.765 ns |   3.522 ns |   804.45 ns | 1.39x faster |   0.27x | 0.2174 |     456 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   289.68 ns |   1.739 ns |   1.542 ns |   289.81 ns | 3.86x faster |   0.78x | 0.2027 |     424 B |
|                                     |                           |       |             |            |            |             |              |         |        |           |
|                     Linq_List_Value |                List_Value |   100 |   394.66 ns |  27.126 ns |  75.166 ns |   353.41 ns |     baseline |         | 0.2289 |     480 B |
|               StructLinq_List_Value |                List_Value |   100 |   403.84 ns |   8.158 ns |   7.631 ns |   404.80 ns | 1.21x faster |   0.06x | 0.2027 |     424 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   524.14 ns |  10.475 ns |  11.643 ns |   524.80 ns | 1.09x slower |   0.07x | 0.2174 |     456 B |
|                                     |                           |       |             |            |            |             |              |         |        |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 8,846.07 ns | 165.241 ns | 176.806 ns | 8,888.90 ns |     baseline |         | 0.7935 |   1,672 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 3,086.01 ns |   8.120 ns |   7.198 ns | 3,083.77 ns | 2.87x faster |   0.06x | 0.5646 |   1,184 B |
|                                     |                           |       |             |            |            |             |              |         |        |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   702.52 ns |  14.093 ns |  18.814 ns |   695.92 ns |     baseline |         | 0.5922 |   1,240 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   805.96 ns |  12.195 ns |  12.523 ns |   802.69 ns | 1.15x slower |   0.03x | 0.2174 |     456 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   872.85 ns |  14.855 ns |  13.895 ns |   871.81 ns | 1.25x slower |   0.04x | 0.2174 |     456 B |
|                                     |                           |       |             |            |            |             |              |         |        |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   692.92 ns |  13.428 ns |  17.925 ns |   690.88 ns |     baseline |         | 0.5922 |   1,240 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   804.78 ns |   2.292 ns |   2.032 ns |   804.27 ns | 1.16x slower |   0.04x | 0.2174 |     456 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   439.96 ns |   7.570 ns |   7.081 ns |   442.66 ns | 1.57x faster |   0.05x | 0.2179 |     456 B |
|                                     |                           |       |             |            |            |             |              |         |        |           |
|                 Linq_List_Reference |            List_Reference |   100 |   336.83 ns |   1.248 ns |   1.106 ns |   336.54 ns |     baseline |         | 0.2294 |     480 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   870.21 ns |  30.533 ns |  89.066 ns |   817.73 ns | 3.07x slower |   0.10x | 0.2174 |     456 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   523.11 ns |  10.507 ns |  12.904 ns |   520.44 ns | 1.56x slower |   0.04x | 0.2174 |     456 B |
|                                     |                           |       |             |            |            |             |              |         |        |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 8,857.84 ns | 146.367 ns | 136.912 ns | 8,931.34 ns |     baseline |         | 0.7935 |   1,672 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 3,237.06 ns |  56.426 ns |  50.020 ns | 3,214.50 ns | 2.73x faster |   0.07x | 0.5798 |   1,216 B |
