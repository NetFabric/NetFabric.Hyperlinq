## List.Int32.ListInt32Contains

### Source
[ListInt32Contains.cs](../LinqBenchmarks/List/Int32/ListInt32Contains.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.27.0](https://www.nuget.org/packages/StructLinq/0.27.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1417) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.1.21458.32
  [Host]     : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 PGO : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT

Job=.NET 6 PGO  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |      Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |----------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|                  ForLoop |   100 | 118.74 ns | 0.224 ns | 0.187 ns |     baseline |         |      - |         - |
|              ForeachLoop |   100 | 176.92 ns | 0.518 ns | 0.484 ns | 1.49x slower |   0.01x |      - |         - |
|                     Linq |   100 |  23.75 ns | 0.097 ns | 0.091 ns | 5.00x faster |   0.02x |      - |         - |
|               LinqFaster |   100 |  24.74 ns | 0.125 ns | 0.111 ns | 4.80x faster |   0.02x |      - |         - |
|             LinqFasterer |   100 |  65.53 ns | 0.506 ns | 0.474 ns | 1.81x faster |   0.01x | 0.2027 |     424 B |
|                   LinqAF |   100 |  24.07 ns | 0.214 ns | 0.190 ns | 4.93x faster |   0.04x |      - |         - |
|               StructLinq |   100 |  85.15 ns | 0.357 ns | 0.317 ns | 1.39x faster |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 |  69.95 ns | 0.235 ns | 0.208 ns | 1.70x faster |   0.01x |      - |         - |
|                Hyperlinq |   100 |  31.35 ns | 0.157 ns | 0.147 ns | 3.79x faster |   0.02x |      - |         - |
|           Hyperlinq_SIMD |   100 |  25.65 ns | 0.093 ns | 0.087 ns | 4.63x faster |   0.02x |      - |         - |
