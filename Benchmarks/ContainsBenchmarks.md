## ContainsBenchmarks

### Source
[ContainsBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ContainsBenchmarks.cs)

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
  Job-PWZZUK : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |        Mean |     Error |    StdDev |        Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|----------:|----------:|-------------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |    40.84 ns |  0.155 ns |  0.137 ns |     baseline |         |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |    39.48 ns |  0.544 ns |  0.509 ns | 1.04x faster |   0.01x |      - |     - |     - |         - |
|                Hyperlinq_Array_SIMD |                     Array |   100 |    24.73 ns |  0.106 ns |  0.094 ns | 1.65x faster |   0.01x |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |              |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   698.87 ns |  4.071 ns |  3.808 ns |     baseline |         | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   131.79 ns |  0.836 ns |  0.699 ns | 5.30x faster |   0.04x |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |              |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |    41.31 ns |  0.190 ns |  0.178 ns |     baseline |         |      - |     - |     - |         - |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |    48.15 ns |  0.182 ns |  0.161 ns | 1.17x slower |   0.01x |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |              |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |    42.47 ns |  0.369 ns |  0.327 ns |     baseline |         |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |    48.39 ns |  0.315 ns |  0.263 ns | 1.14x slower |   0.01x |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |              |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,117.62 ns | 24.109 ns | 22.552 ns |     baseline |         | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,065.50 ns |  3.295 ns |  2.572 ns | 1.99x faster |   0.02x |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |              |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   701.55 ns | 11.099 ns |  9.839 ns |     baseline |         | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   723.25 ns |  3.170 ns |  2.965 ns | 1.03x slower |   0.01x | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |           |           |              |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |    44.63 ns |  0.412 ns |  0.344 ns |     baseline |         |      - |     - |     - |         - |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |    46.06 ns |  0.179 ns |  0.140 ns | 1.03x slower |   0.01x |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |              |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |    44.93 ns |  0.386 ns |  0.342 ns |     baseline |         |      - |     - |     - |         - |
|            Hyperlinq_List_Reference |            List_Reference |   100 |    47.14 ns |  0.188 ns |  0.167 ns | 1.05x slower |   0.01x |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |              |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,104.73 ns |  7.920 ns |  6.183 ns |     baseline |         | 0.0153 |     - |     - |      32 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,061.42 ns |  4.170 ns |  3.697 ns | 1.02x faster |   0.00x | 0.0153 |     - |     - |      32 B |
