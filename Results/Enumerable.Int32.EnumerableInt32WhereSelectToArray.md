## Enumerable.Int32.EnumerableInt32WhereSelectToArray

### Source
[EnumerableInt32WhereSelectToArray.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToArray.cs)

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
|               Method |    Job |  Runtime | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |----------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |  6.011 μs | 0.0549 μs | 0.0486 μs |  1.00 |    0.00 |  3.0441 |     - |     - |      6 KB |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |  7.756 μs | 0.0764 μs | 0.0678 μs |  1.29 |    0.02 |  2.1820 |     - |     - |      4 KB |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 |  9.135 μs | 0.0652 μs | 0.0578 μs |  1.52 |    0.01 |  3.0212 |     - |     - |      6 KB |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 71.465 μs | 0.7681 μs | 0.7185 μs | 11.88 |    0.15 | 16.2354 |     - |     - |     33 KB |
|              Streams | .NET 5 | .NET 5.0 |  1000 | 11.640 μs | 0.0764 μs | 0.0715 μs |  1.94 |    0.02 |  3.2806 |     - |     - |      7 KB |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  7.743 μs | 0.0354 μs | 0.0296 μs |  1.29 |    0.01 |  1.0223 |     - |     - |      2 KB |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  5.657 μs | 0.0306 μs | 0.0256 μs |  0.94 |    0.01 |  0.9842 |     - |     - |      2 KB |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  8.165 μs | 0.0356 μs | 0.0316 μs |  1.36 |    0.01 |  0.9766 |     - |     - |      2 KB |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  5.824 μs | 0.0332 μs | 0.0259 μs |  0.97 |    0.01 |  0.9842 |     - |     - |      2 KB |
|                      |        |          |       |           |           |           |       |         |         |       |       |           |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |  3.817 μs | 0.0235 μs | 0.0220 μs |  1.00 |    0.00 |  3.0441 |     - |     - |      6 KB |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  5.908 μs | 0.0353 μs | 0.0330 μs |  1.55 |    0.01 |  2.1896 |     - |     - |      4 KB |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 |  6.695 μs | 0.1327 μs | 0.2620 μs |  1.73 |    0.06 |  3.0289 |     - |     - |      6 KB |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 56.913 μs | 0.5712 μs | 1.2418 μs | 15.06 |    0.52 | 16.0522 |     - |     - |     33 KB |
|              Streams | .NET 6 | .NET 6.0 |  1000 |  9.828 μs | 0.1752 μs | 0.2927 μs |  2.51 |    0.08 |  3.2806 |     - |     - |      7 KB |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  5.771 μs | 0.0434 μs | 0.0406 μs |  1.51 |    0.01 |  1.0223 |     - |     - |      2 KB |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  4.123 μs | 0.0133 μs | 0.0111 μs |  1.08 |    0.01 |  0.9842 |     - |     - |      2 KB |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  6.405 μs | 0.1254 μs | 0.1173 μs |  1.68 |    0.03 |  0.9842 |     - |     - |      2 KB |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  3.862 μs | 0.0673 μs | 0.1048 μs |  1.03 |    0.03 |  0.9842 |     - |     - |      2 KB |
