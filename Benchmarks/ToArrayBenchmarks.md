## ToArrayBenchmarks

### Source
[ToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ToArrayBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.7.21377.19
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.27.0](https://www.nuget.org/packages/StructLinq/0.27.0)
- NetFabric.Hyperlinq: [3.0.0-beta45](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta45)

### Results:
``` ini

BenchmarkDotNet=v0.13.0.1561-nightly, OS=macOS Catalina 10.15.7 (19H1323) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host]     : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT
  Job-NRTSBV : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT

Runtime=.NET 6.0  

```
|                                        Method |                Categories | Count |        Mean |      Error |      StdDev |      Median |         Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |-------------------------- |------ |------------:|-----------:|------------:|------------:|--------------:|--------:|-------:|------:|------:|----------:|
|                                    Linq_Array |                     Array |   100 |   163.04 ns |  17.071 ns |    48.43 ns |   151.20 ns |      baseline |         | 0.2027 |     - |     - |     424 B |
|                              StructLinq_Array |                     Array |   100 |   306.86 ns |  14.754 ns |    43.04 ns |   310.49 ns |  2.04x slower |   0.59x | 0.2027 |     - |     - |     424 B |
|                               Hyperlinq_Array |                     Array |   100 |    88.98 ns |   6.099 ns |    17.98 ns |    84.58 ns |  1.86x faster |   0.65x | 0.2027 |     - |     - |     424 B |
|                     Hyperlinq_Array_ArrayPool |                     Array |   100 |   163.95 ns |  14.690 ns |    41.43 ns |   148.74 ns |  1.09x slower |   0.41x |      - |     - |     - |         - |
|                                               |                           |       |             |            |             |             |               |         |        |       |       |           |
|                         Linq_Enumerable_Value |          Enumerable_Value |   100 | 2,354.70 ns | 237.865 ns |   701.35 ns | 2,088.55 ns |      baseline |         | 0.5646 |     - |     - |   1,184 B |
|                   StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 3,409.14 ns | 191.945 ns |   553.80 ns | 3,355.16 ns |  1.56x slower |   0.51x | 0.2136 |     - |     - |     456 B |
|                    Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 | 1,247.87 ns | 116.048 ns |   342.17 ns | 1,124.28 ns |  2.01x faster |   0.76x | 0.2213 |     - |     - |     464 B |
|          Hyperlinq_Enumerable_Value_ArrayPool |          Enumerable_Value |   100 | 1,262.16 ns | 153.002 ns |   431.54 ns | 1,170.54 ns |  2.03x faster |   0.72x |      - |     - |     - |         - |
|                                               |                           |       |             |            |             |             |               |         |        |       |       |           |
|                         Linq_Collection_Value |          Collection_Value |   100 |   128.85 ns |  12.178 ns |    35.52 ns |   114.80 ns |      baseline |         | 0.2027 |     - |     - |     424 B |
|                   StructLinq_Collection_Value |          Collection_Value |   100 | 2,101.36 ns | 175.955 ns |   518.81 ns | 1,884.01 ns | 17.03x slower |   5.13x | 0.2174 |     - |     - |     456 B |
|                    Hyperlinq_Collection_Value |          Collection_Value |   100 |   348.20 ns |  27.074 ns |    78.55 ns |   326.34 ns |  2.87x slower |   0.91x | 0.2213 |     - |     - |     464 B |
|          Hyperlinq_Collection_Value_ArrayPool |          Collection_Value |   100 |   420.59 ns |  39.264 ns |   112.66 ns |   408.15 ns |  3.54x slower |   1.46x |      - |     - |     - |         - |
|                                               |                           |       |             |            |             |             |               |         |        |       |       |           |
|                               Linq_List_Value |                List_Value |   100 |   136.70 ns |  14.382 ns |    42.41 ns |   121.74 ns |      baseline |         | 0.2027 |     - |     - |     424 B |
|                         StructLinq_List_Value |                List_Value |   100 |   654.04 ns |  57.795 ns |   170.41 ns |   569.22 ns |  5.25x slower |   2.10x | 0.2022 |     - |     - |     424 B |
|                          Hyperlinq_List_Value |                List_Value |   100 |   141.58 ns |  14.635 ns |    41.04 ns |   133.28 ns |  1.09x slower |   0.42x | 0.2136 |     - |     - |     448 B |
|                Hyperlinq_List_Value_ArrayPool |                List_Value |   100 | 2,639.47 ns | 343.889 ns |   969.94 ns | 2,341.53 ns | 20.96x slower |  10.56x | 0.0153 |     - |     - |      32 B |
|                                               |                           |       |             |            |             |             |               |         |        |       |       |           |
|                    Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 4,433.84 ns | 280.479 ns |   818.17 ns | 4,172.04 ns |      baseline |         | 0.7668 |     - |     - |   1,608 B |
|               Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,986.15 ns | 210.448 ns |   607.19 ns | 2,804.33 ns |  1.55x faster |   0.43x | 0.5646 |     - |     - |   1,184 B |
|     Hyperlinq_AsyncEnumerable_Value_ArrayPool |     AsyncEnumerable_Value |   100 | 4,198.43 ns | 440.451 ns | 1,205.73 ns | 3,826.17 ns |  1.15x faster |   0.35x | 0.3624 |     - |     - |     760 B |
|                                               |                           |       |             |            |             |             |               |         |        |       |       |           |
|                     Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 2,189.65 ns | 194.003 ns |   572.02 ns | 1,999.68 ns |      baseline |         | 0.5646 |     - |     - |   1,184 B |
|               StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 | 2,393.79 ns | 227.705 ns |   671.39 ns | 2,364.41 ns |  1.17x slower |   0.46x | 0.2136 |     - |     - |     456 B |
|                Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 2,799.73 ns | 284.878 ns |   821.94 ns | 2,585.37 ns |  1.34x slower |   0.49x | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Enumerable_Reference_ArrayPool |      Enumerable_Reference |   100 | 2,360.88 ns | 161.513 ns |   476.22 ns | 2,396.03 ns |  1.14x slower |   0.34x | 0.0153 |     - |     - |      32 B |
|                                               |                           |       |             |            |             |             |               |         |        |       |       |           |
|                     Linq_Collection_Reference |      Collection_Reference |   100 |   115.65 ns |   8.905 ns |    25.41 ns |   106.26 ns |      baseline |         | 0.2027 |     - |     - |     424 B |
|               StructLinq_Collection_Reference |      Collection_Reference |   100 | 2,091.15 ns | 217.124 ns |   640.19 ns | 1,745.16 ns | 19.18x slower |   7.50x | 0.2174 |     - |     - |     456 B |
|                Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   193.10 ns |  25.659 ns |    74.03 ns |   171.64 ns |  1.75x slower |   0.72x | 0.2141 |     - |     - |     448 B |
|      Hyperlinq_Collection_Reference_ArrayPool |      Collection_Reference |   100 | 1,402.92 ns | 105.127 ns |   309.97 ns | 1,237.28 ns | 12.84x slower |   3.86x | 0.0153 |     - |     - |      32 B |
|                                               |                           |       |             |            |             |             |               |         |        |       |       |           |
|                           Linq_List_Reference |            List_Reference |   100 |   164.70 ns |  13.638 ns |    40.21 ns |   161.30 ns |      baseline |         | 0.2027 |     - |     - |     424 B |
|                     StructLinq_List_Reference |            List_Reference |   100 | 2,247.33 ns | 206.354 ns |   601.94 ns | 2,141.67 ns | 14.50x slower |   5.23x | 0.2174 |     - |     - |     456 B |
|                      Hyperlinq_List_Reference |            List_Reference |   100 |   155.51 ns |  19.107 ns |    55.13 ns |   143.08 ns |  1.00x slower |   0.40x | 0.2142 |     - |     - |     448 B |
|            Hyperlinq_List_Reference_ArrayPool |            List_Reference |   100 | 1,517.09 ns | 120.567 ns |   355.49 ns | 1,462.84 ns |  9.78x slower |   3.37x | 0.0153 |     - |     - |      32 B |
|                                               |                           |       |             |            |             |             |               |         |        |       |       |           |
|                Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5,261.83 ns | 271.077 ns |   790.75 ns | 5,092.51 ns |      baseline |         | 0.7629 |     - |     - |   1,608 B |
|           Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 6,319.42 ns | 795.422 ns | 2,320.28 ns | 5,607.97 ns |  1.22x slower |   0.46x | 0.5798 |     - |     - |   1,216 B |
| Hyperlinq_AsyncEnumerable_Reference_ArrayPool | AsyncEnumerable_Reference |   100 | 4,795.02 ns | 619.269 ns | 1,746.66 ns | 4,093.43 ns |  1.19x faster |   0.33x | 0.3738 |     - |     - |     792 B |
