## List.Int32.ListInt32Contains

### Source
[ListInt32Contains.cs](../LinqBenchmarks/List/Int32/ListInt32Contains.cs)

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
|                   Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 | 110.24 ns | 0.409 ns | 0.363 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|              ForeachLoop |   100 | 165.94 ns | 1.242 ns | 1.162 ns |  1.51 |    0.01 |      - |     - |     - |         - |
|                     Linq |   100 |  34.46 ns | 0.121 ns | 0.107 ns |  0.31 |    0.00 |      - |     - |     - |         - |
|               LinqFaster |   100 |  33.62 ns | 0.125 ns | 0.111 ns |  0.30 |    0.00 |      - |     - |     - |         - |
|                   LinqAF |   100 |  29.28 ns | 0.334 ns | 0.279 ns |  0.27 |    0.00 |      - |     - |     - |         - |
|               StructLinq |   100 |  76.18 ns | 1.552 ns | 1.787 ns |  0.69 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |  59.88 ns | 0.249 ns | 0.208 ns |  0.54 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq |   100 |  32.81 ns | 0.147 ns | 0.130 ns |  0.30 |    0.00 |      - |     - |     - |         - |
|           Hyperlinq_SIMD |   100 |  23.40 ns | 0.436 ns | 0.340 ns |  0.21 |    0.00 |      - |     - |     - |         - |
