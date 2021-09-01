## ToArrayArrayPoolBenchmarks

### Source
[ToArrayArrayPoolBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ToArrayArrayPoolBenchmarks.cs)

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
  Job-WKXHDN : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT

Runtime=.NET 6.0  

```
|                                        Method |                Categories | Count |        Mean |     Error |    StdDev |        Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |-------------------------- |------ |------------:|----------:|----------:|-------------:|--------:|-------:|------:|------:|----------:|
|                               Hyperlinq_Array |                     Array |   100 |    71.55 ns |  0.539 ns |  0.504 ns |     baseline |         | 0.2027 |     - |     - |     424 B |
|                     Hyperlinq_Array_ArrayPool |                     Array |   100 |    88.19 ns |  1.409 ns |  1.249 ns | 1.23x slower |   0.02x |      - |     - |     - |         - |
|                                               |                           |       |             |           |           |              |         |        |       |       |           |
|                    Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   574.98 ns |  6.409 ns |  5.681 ns |     baseline |         | 0.2022 |     - |     - |     424 B |
|          Hyperlinq_Enumerable_Value_ArrayPool |          Enumerable_Value |   100 |   592.11 ns | 11.686 ns | 12.000 ns | 1.03x slower |   0.02x |      - |     - |     - |         - |
|                                               |                           |       |             |           |           |              |         |        |       |       |           |
|                    Hyperlinq_Collection_Value |          Collection_Value |   100 |   194.76 ns |  2.327 ns |  1.943 ns |     baseline |         | 0.2217 |     - |     - |     464 B |
|          Hyperlinq_Collection_Value_ArrayPool |          Collection_Value |   100 |   198.94 ns |  3.513 ns |  3.286 ns | 1.02x slower |   0.02x | 0.0191 |     - |     - |      40 B |
|                                               |                           |       |             |           |           |              |         |        |       |       |           |
|                          Hyperlinq_List_Value |                List_Value |   100 |    81.78 ns |  1.630 ns |  1.878 ns |     baseline |         | 0.2142 |     - |     - |     448 B |
|                Hyperlinq_List_Value_ArrayPool |                List_Value |   100 |    90.87 ns |  1.200 ns |  1.064 ns | 1.11x slower |   0.03x | 0.0114 |     - |     - |      24 B |
|                                               |                           |       |             |           |           |              |         |        |       |       |           |
|               Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,581.94 ns |  7.917 ns |  6.611 ns |     baseline |         | 0.5646 |     - |     - |   1,184 B |
|     Hyperlinq_AsyncEnumerable_Value_ArrayPool |     AsyncEnumerable_Value |   100 | 1,595.35 ns |  9.042 ns |  7.550 ns | 1.01x slower |   0.01x | 0.3624 |     - |     - |     760 B |
|                                               |                           |       |             |           |           |              |         |        |       |       |           |
|                Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,176.25 ns |  9.371 ns |  8.766 ns |     baseline |         | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Enumerable_Reference_ArrayPool |      Enumerable_Reference |   100 | 1,160.29 ns | 16.363 ns | 15.306 ns | 1.01x faster |   0.02x | 0.0153 |     - |     - |      32 B |
|                                               |                           |       |             |           |           |              |         |        |       |       |           |
|                Hyperlinq_Collection_Reference |      Collection_Reference |   100 |    85.97 ns |  1.027 ns |  0.961 ns |     baseline |         | 0.2142 |     - |     - |     448 B |
|      Hyperlinq_Collection_Reference_ArrayPool |      Collection_Reference |   100 |    96.72 ns |  1.965 ns |  2.103 ns | 1.12x slower |   0.02x | 0.0114 |     - |     - |      24 B |
|                                               |                           |       |             |           |           |              |         |        |       |       |           |
|                      Hyperlinq_List_Reference |            List_Reference |   100 |    81.42 ns |  1.266 ns |  1.184 ns |     baseline |         | 0.2142 |     - |     - |     448 B |
|            Hyperlinq_List_Reference_ArrayPool |            List_Reference |   100 |    90.73 ns |  1.831 ns |  1.880 ns | 1.11x slower |   0.02x | 0.0114 |     - |     - |      24 B |
|                                               |                           |       |             |           |           |              |         |        |       |       |           |
|           Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,605.91 ns | 11.347 ns | 10.614 ns |     baseline |         | 0.5798 |     - |     - |   1,216 B |
| Hyperlinq_AsyncEnumerable_Reference_ArrayPool | AsyncEnumerable_Reference |   100 | 2,670.44 ns | 37.433 ns | 35.015 ns | 1.02x slower |   0.01x | 0.3777 |     - |     - |     792 B |
