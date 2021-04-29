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
|                   Method | Count |      Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 | 113.45 ns | 0.463 ns | 0.433 ns |  1.00 |      - |     - |     - |         - |
|              ForeachLoop |   100 | 169.07 ns | 0.573 ns | 0.479 ns |  1.49 |      - |     - |     - |         - |
|                     Linq |   100 |  35.89 ns | 0.168 ns | 0.149 ns |  0.32 |      - |     - |     - |         - |
|               LinqFaster |   100 |  34.69 ns | 0.215 ns | 0.201 ns |  0.31 |      - |     - |     - |         - |
|             LinqFasterer |   100 |  71.99 ns | 0.789 ns | 0.738 ns |  0.63 | 0.2027 |     - |     - |     424 B |
|                   LinqAF |   100 |  30.86 ns | 0.135 ns | 0.113 ns |  0.27 |      - |     - |     - |         - |
|               StructLinq |   100 |  78.60 ns | 0.408 ns | 0.381 ns |  0.69 | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |  61.56 ns | 0.246 ns | 0.218 ns |  0.54 |      - |     - |     - |         - |
|                Hyperlinq |   100 |  34.03 ns | 0.549 ns | 0.429 ns |  0.30 |      - |     - |     - |         - |
|           Hyperlinq_SIMD |   100 |  24.12 ns | 0.096 ns | 0.090 ns |  0.21 |      - |     - |     - |         - |
