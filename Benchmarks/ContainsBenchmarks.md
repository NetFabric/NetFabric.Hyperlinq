## ContainsBenchmarks

### Source
[ContainsBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ContainsBenchmarks.cs)

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
|                              Method |                Categories | Count |        Mean |    Error |    StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|---------:|----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |    38.79 ns | 0.076 ns |  0.064 ns |    38.80 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |    32.36 ns | 0.115 ns |  0.096 ns |    32.36 ns |  0.83 |    0.00 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |    76.10 ns | 0.435 ns |  0.407 ns |    76.02 ns |  1.96 |    0.01 |      - |     - |     - |         - |
|                 Hyperlinq_Span_SIMD |                     Array |   100 |    25.26 ns | 0.119 ns |  0.111 ns |    25.22 ns |  0.65 |    0.00 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |    83.07 ns | 0.245 ns |  0.229 ns |    83.05 ns |  2.14 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |             |          |           |             |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   669.84 ns | 5.921 ns |  5.249 ns |   667.71 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   360.90 ns | 6.238 ns | 14.458 ns |   354.79 ns |  0.54 |    0.03 | 0.0191 |     - |     - |      40 B |
|                                     |                           |       |             |          |           |             |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |    34.71 ns | 0.167 ns |  0.148 ns |    34.68 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |    38.51 ns | 0.283 ns |  0.236 ns |    38.44 ns |  1.11 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |             |          |           |             |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |    35.17 ns | 0.166 ns |  0.155 ns |    35.20 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |    39.37 ns | 0.182 ns |  0.170 ns |    39.36 ns |  1.12 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |             |          |           |             |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,153.11 ns | 6.444 ns |  6.028 ns | 2,154.90 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,502.52 ns | 3.738 ns |  3.497 ns | 1,502.19 ns |  0.70 |    0.00 | 0.0191 |     - |     - |      40 B |
|                                     |                           |       |             |          |           |             |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   426.56 ns | 1.798 ns |  1.593 ns |   426.40 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   594.52 ns | 2.926 ns |  2.444 ns |   594.18 ns |  1.39 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |          |           |             |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |    34.27 ns | 0.156 ns |  0.139 ns |    34.28 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |    36.80 ns | 0.116 ns |  0.108 ns |    36.77 ns |  1.07 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |             |          |           |             |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |    35.33 ns | 0.184 ns |  0.144 ns |    35.32 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq_List_Reference |            List_Reference |   100 |    37.91 ns | 0.112 ns |  0.094 ns |    37.87 ns |  1.07 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |             |          |           |             |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,015.64 ns | 5.966 ns |  5.580 ns | 2,014.86 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,157.52 ns | 6.314 ns |  5.906 ns | 2,156.86 ns |  1.07 |    0.00 | 0.0305 |     - |     - |      64 B |
