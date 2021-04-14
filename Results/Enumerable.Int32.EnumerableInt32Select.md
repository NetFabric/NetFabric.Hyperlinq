## Enumerable.Int32.EnumerableInt32Select

### Source
[EnumerableInt32Select.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Select.cs)

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
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |  4.798 μs | 0.0276 μs | 0.0245 μs |  4.803 μs |  1.00 |    0.00 |  0.0153 |     - |     - |      40 B |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |  9.520 μs | 0.0302 μs | 0.0268 μs |  9.524 μs |  1.98 |    0.01 |  0.0458 |     - |     - |      96 B |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 |  7.466 μs | 0.0450 μs | 0.0399 μs |  7.470 μs |  1.56 |    0.01 |  0.0153 |     - |     - |      40 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 52.340 μs | 0.2847 μs | 0.4834 μs | 52.319 μs | 10.88 |    0.09 | 15.3809 |     - |     - |  32,337 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 | 17.368 μs | 0.0973 μs | 0.0812 μs | 17.389 μs |  3.62 |    0.03 |  0.2747 |     - |     - |     592 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  5.050 μs | 0.0316 μs | 0.0264 μs |  5.044 μs |  1.05 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  4.534 μs | 0.0298 μs | 0.0264 μs |  4.525 μs |  0.94 |    0.01 |  0.0153 |     - |     - |      40 B |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  5.714 μs | 0.0279 μs | 0.0247 μs |  5.709 μs |  1.19 |    0.01 |  0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  4.533 μs | 0.0355 μs | 0.0277 μs |  4.530 μs |  0.94 |    0.01 |  0.0153 |     - |     - |      40 B |
|                      |        |          |       |           |           |           |           |       |         |         |       |       |           |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |  3.196 μs | 0.0198 μs | 0.0165 μs |  3.197 μs |  1.00 |    0.00 |  0.0191 |     - |     - |      40 B |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  5.613 μs | 0.0241 μs | 0.0213 μs |  5.614 μs |  1.76 |    0.01 |  0.0458 |     - |     - |      96 B |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 |  5.451 μs | 0.0195 μs | 0.0163 μs |  5.450 μs |  1.71 |    0.01 |  0.0153 |     - |     - |      40 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 48.245 μs | 1.2693 μs | 3.7425 μs | 45.761 μs | 15.33 |    1.17 | 15.1978 |     - |     - |  31,897 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 | 13.790 μs | 0.0654 μs | 0.0580 μs | 13.787 μs |  4.31 |    0.03 |  0.2747 |     - |     - |     592 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  3.915 μs | 0.0220 μs | 0.0206 μs |  3.918 μs |  1.23 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  2.424 μs | 0.0132 μs | 0.0124 μs |  2.418 μs |  0.76 |    0.01 |  0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  3.828 μs | 0.0240 μs | 0.0224 μs |  3.832 μs |  1.20 |    0.01 |  0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  3.215 μs | 0.0226 μs | 0.0211 μs |  3.210 μs |  1.01 |    0.01 |  0.0191 |     - |     - |      40 B |
