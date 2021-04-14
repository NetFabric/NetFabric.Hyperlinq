## Enumerable.Int32.EnumerableInt32Sum

### Source
[EnumerableInt32Sum.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Sum.cs)

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
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |  4.508 μs | 0.0334 μs | 0.0296 μs |  1.00 |    0.00 | 0.0153 |     - |     - |      40 B |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |  4.799 μs | 0.0283 μs | 0.0265 μs |  1.06 |    0.01 | 0.0153 |     - |     - |      40 B |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 |  5.041 μs | 0.0488 μs | 0.0433 μs |  1.12 |    0.01 | 0.0153 |     - |     - |      40 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 31.647 μs | 0.1817 μs | 0.1611 μs |  7.02 |    0.03 | 8.3008 |     - |     - |  17,377 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 |  5.917 μs | 0.0357 μs | 0.0334 μs |  1.31 |    0.01 | 0.1144 |     - |     - |     248 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  4.511 μs | 0.0205 μs | 0.0182 μs |  1.00 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  4.496 μs | 0.0192 μs | 0.0160 μs |  1.00 |    0.01 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  4.774 μs | 0.0237 μs | 0.0185 μs |  1.06 |    0.01 | 0.0153 |     - |     - |      40 B |
|                      |        |          |       |           |           |           |       |         |        |       |       |           |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |  2.667 μs | 0.0122 μs | 0.0102 μs |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  2.023 μs | 0.0177 μs | 0.0157 μs |  0.76 |    0.01 | 0.0191 |     - |     - |      40 B |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 |  3.449 μs | 0.0172 μs | 0.0153 μs |  1.29 |    0.01 | 0.0191 |     - |     - |      40 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 30.070 μs | 0.2554 μs | 0.4124 μs | 11.27 |    0.16 | 8.0566 |     - |     - |  17,133 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 |  2.884 μs | 0.0099 μs | 0.0077 μs |  1.08 |    0.00 | 0.1183 |     - |     - |     248 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  2.421 μs | 0.0074 μs | 0.0069 μs |  0.91 |    0.00 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  2.421 μs | 0.0122 μs | 0.0114 μs |  0.91 |    0.00 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  2.929 μs | 0.0086 μs | 0.0076 μs |  1.10 |    0.01 | 0.0191 |     - |     - |      40 B |
