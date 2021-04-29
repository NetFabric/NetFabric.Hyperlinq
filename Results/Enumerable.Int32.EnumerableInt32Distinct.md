## Enumerable.Int32.EnumerableInt32Distinct

### Source
[EnumerableInt32Distinct.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Distinct.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [](https://www.nuget.org/packages/LinqOptimizer.CSharp/)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForeachLoop |   100 |   923.3 ns |  2.44 ns |  2.03 ns |  1.00 |    0.00 | 0.0992 |     - |     - |     208 B |
|                     Linq |   100 |   934.2 ns |  5.19 ns |  4.60 ns |  1.01 |    0.01 | 0.1602 |     - |     - |     336 B |
|                   LinqAF |   100 | 2,011.9 ns | 39.40 ns | 38.70 ns |  2.17 |    0.05 | 1.2531 |     - |     - |   2,624 B |
|               StructLinq |   100 |   875.6 ns |  1.90 ns |  1.68 ns |  0.95 |    0.00 | 0.0305 |     - |     - |      64 B |
| StructLinq_ValueDelegate |   100 |   838.3 ns |  2.74 ns |  2.28 ns |  0.91 |    0.00 | 0.0191 |     - |     - |      40 B |
|                Hyperlinq |   100 | 1,036.1 ns |  7.80 ns |  7.30 ns |  1.12 |    0.01 | 0.0191 |     - |     - |      40 B |
