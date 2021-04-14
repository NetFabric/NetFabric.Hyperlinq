## Enumerable.Int32.EnumerableInt32WhereCount

### Source
[EnumerableInt32WhereCount.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereCount.cs)

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
|               Method |    Job |  Runtime | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |  4.627 μs | 0.0175 μs | 0.0155 μs |  1.00 |    0.00 | 0.0153 |     - |     - |      40 B |
|                 Linq | .NET 5 | .NET 5.0 |  1000 | 10.079 μs | 0.0381 μs | 0.0357 μs |  2.18 |    0.01 | 0.0153 |     - |     - |      40 B |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 |  6.450 μs | 0.0157 μs | 0.0139 μs |  1.39 |    0.01 | 0.0153 |     - |     - |      40 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 61.195 μs | 1.1092 μs | 1.0375 μs | 13.21 |    0.22 | 9.8267 |     - |     - |  20,582 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 |  8.358 μs | 0.0580 μs | 0.0542 μs |  1.81 |    0.01 | 0.1831 |     - |     - |     400 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  5.854 μs | 0.0284 μs | 0.0222 μs |  1.26 |    0.01 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  5.026 μs | 0.0211 μs | 0.0187 μs |  1.09 |    0.01 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  5.852 μs | 0.0218 μs | 0.0193 μs |  1.26 |    0.00 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  4.684 μs | 0.0427 μs | 0.0379 μs |  1.01 |    0.01 | 0.0153 |     - |     - |      40 B |
|                      |        |          |       |           |           |           |       |         |        |       |       |           |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |  3.020 μs | 0.0092 μs | 0.0086 μs |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  3.693 μs | 0.0249 μs | 0.0194 μs |  1.22 |    0.01 | 0.0191 |     - |     - |      40 B |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 |  4.284 μs | 0.0261 μs | 0.0232 μs |  1.42 |    0.01 | 0.0153 |     - |     - |      40 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 48.656 μs | 0.3146 μs | 0.2943 μs | 16.11 |    0.12 | 9.7046 |     - |     - |  20,333 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 |  6.092 μs | 0.0392 μs | 0.0367 μs |  2.02 |    0.01 | 0.1907 |     - |     - |     400 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  4.013 μs | 0.0303 μs | 0.0269 μs |  1.33 |    0.01 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  2.666 μs | 0.0105 μs | 0.0082 μs |  0.88 |    0.00 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  3.973 μs | 0.0194 μs | 0.0181 μs |  1.32 |    0.01 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  2.917 μs | 0.0107 μs | 0.0101 μs |  0.97 |    0.00 | 0.0191 |     - |     - |      40 B |
