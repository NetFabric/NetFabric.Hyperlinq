## ContainsComparerBenchmarks

### Source
[ContainsComparerBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ContainsComparerBenchmarks.cs)

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
  Job-AXHCLI : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |        Mean |      Error |     StdDev |      Median |         Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|-----------:|-----------:|------------:|--------------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 | 1,048.66 ns | 107.295 ns | 316.361 ns |   903.87 ns |      baseline |         | 0.0153 |     - |     - |      32 B |
|                     Hyperlinq_Array |                     Array |   100 |   268.14 ns |   2.061 ns |   1.827 ns |   267.28 ns |  4.81x faster |   1.19x |      - |     - |     - |         - |
|                                     |                           |       |             |            |            |             |               |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   881.92 ns |   6.470 ns |   5.735 ns |   880.29 ns |      baseline |         | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   302.87 ns |   1.992 ns |   1.864 ns |   302.07 ns |  2.91x faster |   0.03x |      - |     - |     - |         - |
|                                     |                           |       |             |            |            |             |               |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |   938.13 ns |   9.760 ns |   9.129 ns |   936.36 ns |      baseline |         | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |    48.95 ns |   0.239 ns |   0.212 ns |    48.90 ns | 19.18x faster |   0.20x |      - |     - |     - |         - |
|                                     |                           |       |             |            |            |             |               |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   933.26 ns |   9.635 ns |   8.046 ns |   929.66 ns |      baseline |         | 0.0153 |     - |     - |      32 B |
|                Hyperlinq_List_Value |                List_Value |   100 |    48.66 ns |   0.173 ns |   0.144 ns |    48.65 ns | 19.18x faster |   0.20x |      - |     - |     - |         - |
|                                     |                           |       |             |            |            |             |               |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,158.84 ns |   9.131 ns |   8.542 ns | 2,155.35 ns |      baseline |         | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,191.03 ns |   3.012 ns |   2.670 ns | 1,189.75 ns |  1.81x faster |   0.01x |      - |     - |     - |         - |
|                                     |                           |       |             |            |            |             |               |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   882.52 ns |   5.452 ns |   4.833 ns |   881.50 ns |      baseline |         | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   857.25 ns |   3.404 ns |   2.842 ns |   856.86 ns |  1.03x faster |   0.01x | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |            |            |             |               |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   889.74 ns |  13.979 ns |  12.392 ns |   887.60 ns |      baseline |         | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |    47.00 ns |   0.515 ns |   0.457 ns |    46.82 ns | 18.93x faster |   0.31x |      - |     - |     - |         - |
|                                     |                           |       |             |            |            |             |               |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   932.31 ns |   6.806 ns |   5.314 ns |   930.35 ns |      baseline |         | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |    47.98 ns |   0.277 ns |   0.217 ns |    47.97 ns | 19.43x faster |   0.10x |      - |     - |     - |         - |
|                                     |                           |       |             |            |            |             |               |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,159.99 ns |   7.158 ns |   6.695 ns | 2,158.15 ns |      baseline |         | 0.0153 |     - |     - |      32 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,157.65 ns |   6.057 ns |   5.369 ns | 2,156.09 ns |  1.00x faster |   0.00x | 0.0153 |     - |     - |      32 B |
