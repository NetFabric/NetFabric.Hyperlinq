## ImmutableArray.Int32.ImmutableArrayInt32Contains

### Source
[ImmutableArrayInt32Contains.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Contains.cs)

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
|                   Method | Count |     Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |---------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 | 39.93 ns | 0.316 ns | 0.616 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|              ForeachLoop |   100 | 45.77 ns | 0.188 ns | 0.167 ns |  1.15 |    0.03 |      - |     - |     - |         - |
|                     Linq |   100 | 33.10 ns | 0.315 ns | 0.280 ns |  0.83 |    0.02 |      - |     - |     - |         - |
|               StructLinq |   100 | 95.70 ns | 1.911 ns | 1.963 ns |  2.40 |    0.07 | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 | 58.44 ns | 0.280 ns | 0.262 ns |  1.46 |    0.03 |      - |     - |     - |         - |
|                Hyperlinq |   100 | 31.06 ns | 0.386 ns | 0.361 ns |  0.78 |    0.02 |      - |     - |     - |         - |
|           Hyperlinq_SIMD |   100 | 22.02 ns | 0.389 ns | 0.345 ns |  0.55 |    0.02 |      - |     - |     - |         - |
