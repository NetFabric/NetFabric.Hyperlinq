## Enumerable.Int32.EnumerableInt32Contains

### Source
[EnumerableInt32Contains.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Contains.cs)

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
|                   Method | Count |     Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |---------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|              ForeachLoop |   100 | 232.1 ns | 0.90 ns | 0.80 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|                     Linq |   100 | 341.4 ns | 1.62 ns | 1.35 ns |  1.47 | 0.0191 |     - |     - |      40 B |
|                   LinqAF |   100 | 301.0 ns | 1.40 ns | 1.31 ns |  1.30 | 0.0191 |     - |     - |      40 B |
|               StructLinq |   100 | 378.4 ns | 2.86 ns | 2.67 ns |  1.63 | 0.0305 |     - |     - |      64 B |
| StructLinq_ValueDelegate |   100 | 367.2 ns | 1.95 ns | 1.82 ns |  1.58 | 0.0191 |     - |     - |      40 B |
|                Hyperlinq |   100 | 399.0 ns | 1.43 ns | 1.27 ns |  1.72 | 0.0191 |     - |     - |      40 B |
