## ContainsBenchmarks

### Source
[ContainsBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ContainsBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.2.21154.6
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1521-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.2.21155.3
  [Host]     : .NET 6.0.0 (6.0.21.15406), X64 RyuJIT
  Job-XHOKQA : .NET 6.0.0 (6.0.21.15406), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |        Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |    40.65 ns | 0.211 ns | 0.176 ns |  1.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |    30.31 ns | 0.198 ns | 0.176 ns |  0.75 |      - |     - |     - |         - |
|                Hyperlinq_Array_SIMD |                     Array |   100 |    25.58 ns | 0.120 ns | 0.106 ns |  0.63 |      - |     - |     - |         - |
|                                     |                           |       |             |          |          |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   656.14 ns | 1.460 ns | 1.366 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   295.03 ns | 1.379 ns | 1.290 ns |  0.45 | 0.0191 |     - |     - |      40 B |
|                                     |                           |       |             |          |          |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |    36.24 ns | 0.165 ns | 0.146 ns |  1.00 |      - |     - |     - |         - |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |    39.45 ns | 0.147 ns | 0.131 ns |  1.09 |      - |     - |     - |         - |
|                                     |                           |       |             |          |          |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |    36.89 ns | 0.126 ns | 0.112 ns |  1.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |    40.04 ns | 0.165 ns | 0.155 ns |  1.08 |      - |     - |     - |         - |
|                                     |                           |       |             |          |          |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,818.57 ns | 3.937 ns | 3.288 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,118.84 ns | 2.749 ns | 2.295 ns |  0.62 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |          |          |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   658.64 ns | 5.196 ns | 4.057 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   660.32 ns | 3.563 ns | 3.158 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |          |          |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |    35.92 ns | 0.107 ns | 0.095 ns |  1.00 |      - |     - |     - |         - |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |    39.33 ns | 0.105 ns | 0.088 ns |  1.10 |      - |     - |     - |         - |
|                                     |                           |       |             |          |          |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |    37.08 ns | 0.130 ns | 0.122 ns |  1.00 |      - |     - |     - |         - |
|            Hyperlinq_List_Reference |            List_Reference |   100 |    39.94 ns | 0.186 ns | 0.165 ns |  1.08 |      - |     - |     - |         - |
|                                     |                           |       |             |          |          |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,821.71 ns | 4.026 ns | 3.569 ns |  1.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,889.72 ns | 6.468 ns | 6.050 ns |  1.04 | 0.0267 |     - |     - |      56 B |
