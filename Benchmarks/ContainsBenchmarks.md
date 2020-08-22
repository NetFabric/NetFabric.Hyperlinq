## ContainsBenchmarks

### Source
[ContainsBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ContainsBenchmarks.cs)

### References:
- Linq: 5.0.0-preview.7.20364.11
- System.Linq.Async: [4.1.1](https://www.nuget.org/packages/System.Linq.Async/4.1.1)
- System.Interactive: [4.1.1](https://www.nuget.org/packages/System.Interactive/4.1.1)
- System.Interactive.Async: [4.1.1](https://www.nuget.org/packages/System.Interactive.Async/4.1.1)
- StructLinq: [0.19.2](https://www.nuget.org/packages/StructLinq/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                         Method |                Categories | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |-------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                     Linq_Array |                     Array |   100 |    36.38 ns |  0.182 ns |  0.161 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_Array |                     Array |   100 |    28.10 ns |  0.244 ns |  0.228 ns |  0.77 |    0.01 |      - |     - |     - |         - |
|                 Hyperlinq_Span |                     Array |   100 |    72.09 ns |  0.421 ns |  0.351 ns |  1.98 |    0.01 |      - |     - |     - |         - |
|               Hyperlinq_Memory |                     Array |   100 |    76.73 ns |  0.521 ns |  0.435 ns |  2.11 |    0.02 |      - |     - |     - |         - |
|                                |                           |       |             |           |           |       |         |        |       |       |           |
|          Linq_Enumerable_Value |          Enumerable_Value |   100 |   673.30 ns |  4.794 ns |  4.249 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   347.53 ns |  1.525 ns |  1.274 ns |  0.52 |    0.00 | 0.0153 |     - |     - |      32 B |
|                                |                           |       |             |           |           |       |         |        |       |       |           |
|          Linq_Collection_Value |          Collection_Value |   100 |    31.30 ns |  0.252 ns |  0.224 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|     Hyperlinq_Collection_Value |          Collection_Value |   100 |   248.74 ns |  1.584 ns |  1.481 ns |  7.94 |    0.08 | 0.0153 |     - |     - |      32 B |
|                                |                           |       |             |           |           |       |         |        |       |       |           |
|                Linq_List_Value |                List_Value |   100 |    32.10 ns |  0.288 ns |  0.255 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|           Hyperlinq_List_Value |                List_Value |   100 |    50.27 ns |  0.339 ns |  0.300 ns |  1.57 |    0.02 | 0.0114 |     - |     - |      24 B |
|                                |                           |       |             |           |           |       |         |        |       |       |           |
|     Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,147.02 ns | 11.937 ns | 11.166 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                                |                           |       |             |           |           |       |         |        |       |       |           |
|      Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   450.67 ns |  2.600 ns |  2.305 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   554.91 ns |  4.913 ns |  3.835 ns |  1.23 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                |                           |       |             |           |           |       |         |        |       |       |           |
|      Linq_Collection_Reference |      Collection_Reference |   100 |    31.37 ns |  0.252 ns |  0.235 ns |  1.00 |    0.00 |      - |     - |     - |         - |
| Hyperlinq_Collection_Reference |      Collection_Reference |   100 |    44.17 ns |  0.583 ns |  0.517 ns |  1.41 |    0.02 | 0.0114 |     - |     - |      24 B |
|                                |                           |       |             |           |           |       |         |        |       |       |           |
|            Linq_List_Reference |            List_Reference |   100 |    32.49 ns |  0.165 ns |  0.154 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|       Hyperlinq_List_Reference |            List_Reference |   100 |    49.95 ns |  0.133 ns |  0.111 ns |  1.54 |    0.01 | 0.0114 |     - |     - |      24 B |
|                                |                           |       |             |           |           |       |         |        |       |       |           |
| Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,999.04 ns |  9.467 ns |  8.392 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
