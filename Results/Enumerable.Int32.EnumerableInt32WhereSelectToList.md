## Enumerable.Int32.EnumerableInt32WhereSelectToList

### Source
[EnumerableInt32WhereSelectToList.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToList.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [](https://www.nuget.org/packages/LinqOptimizer.CSharp/)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host] : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT

EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  

```
|               Method |    Job |  Runtime | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |----------:|----------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |  5.843 μs | 0.0465 μs | 0.0412 μs |  5.843 μs |  1.00 |    0.00 |  2.0752 |     - |     - |      4 KB |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |  8.169 μs | 0.1632 μs | 0.2179 μs |  8.293 μs |  1.37 |    0.03 |  2.1210 |     - |     - |      4 KB |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 |  9.165 μs | 0.1767 μs | 0.2477 μs |  9.044 μs |  1.58 |    0.06 |  2.0752 |     - |     - |      4 KB |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 60.147 μs | 0.3901 μs | 0.3458 μs | 60.124 μs | 10.29 |    0.10 | 17.2119 |     - |     - |     35 KB |
|              Streams | .NET 5 | .NET 5.0 |  1000 | 14.651 μs | 0.0492 μs | 0.0460 μs | 14.661 μs |  2.51 |    0.02 |  2.3346 |     - |     - |      5 KB |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  8.153 μs | 0.0437 μs | 0.0365 μs |  8.159 μs |  1.40 |    0.01 |  1.0376 |     - |     - |      2 KB |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  5.902 μs | 0.0315 μs | 0.0280 μs |  5.905 μs |  1.01 |    0.01 |  0.9995 |     - |     - |      2 KB |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  8.098 μs | 0.0830 μs | 0.0693 μs |  8.092 μs |  1.39 |    0.01 |  0.9918 |     - |     - |      2 KB |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  6.366 μs | 0.1244 μs | 0.1481 μs |  6.279 μs |  1.10 |    0.03 |  0.9995 |     - |     - |      2 KB |
|                      |        |          |       |           |           |           |           |       |         |         |       |       |           |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |  3.787 μs | 0.0758 μs | 0.1598 μs |  3.695 μs |  1.00 |    0.00 |  2.0752 |     - |     - |      4 KB |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  5.371 μs | 0.0345 μs | 0.0288 μs |  5.368 μs |  1.39 |    0.06 |  2.1286 |     - |     - |      4 KB |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 |  6.516 μs | 0.1220 μs | 0.1356 μs |  6.573 μs |  1.67 |    0.05 |  2.0752 |     - |     - |      4 KB |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 58.244 μs | 0.5627 μs | 0.5263 μs | 58.155 μs | 15.02 |    0.71 | 16.9678 |     - |     - |     35 KB |
|              Streams | .NET 6 | .NET 6.0 |  1000 | 10.606 μs | 0.0508 μs | 0.0475 μs | 10.601 μs |  2.74 |    0.13 |  2.3346 |     - |     - |      5 KB |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  6.034 μs | 0.0516 μs | 0.0431 μs |  6.031 μs |  1.56 |    0.07 |  1.0376 |     - |     - |      2 KB |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  4.180 μs | 0.0228 μs | 0.0202 μs |  4.179 μs |  1.08 |    0.05 |  0.9995 |     - |     - |      2 KB |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  6.427 μs | 0.1232 μs | 0.1559 μs |  6.453 μs |  1.64 |    0.05 |  0.9995 |     - |     - |      2 KB |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  4.335 μs | 0.0370 μs | 0.0309 μs |  4.337 μs |  1.12 |    0.06 |  0.9995 |     - |     - |      2 KB |
