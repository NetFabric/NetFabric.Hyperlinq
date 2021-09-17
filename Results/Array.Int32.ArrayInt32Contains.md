## Array.Int32.ArrayInt32Contains

### Source
[ArrayInt32Contains.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Contains.cs)

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
|                  ForLoop |   100 |  48.58 ns | 0.196 ns | 0.164 ns |     baseline |         |      - |         - |
|              ForeachLoop |   100 |  48.53 ns | 0.216 ns | 0.202 ns | 1.00x faster |   0.01x |      - |         - |
|                     Linq |   100 |  22.92 ns | 0.171 ns | 0.160 ns | 2.12x faster |   0.02x |      - |         - |
|               LinqFaster |   100 |  22.20 ns | 0.144 ns | 0.127 ns | 2.19x faster |   0.02x |      - |         - |
|          LinqFaster_SIMD |   100 |  11.48 ns | 0.198 ns | 0.336 ns | 4.20x faster |   0.18x |      - |         - |
|             LinqFasterer |   100 |  22.43 ns | 0.101 ns | 0.095 ns | 2.16x faster |   0.01x |      - |         - |
|                   LinqAF |   100 |  28.67 ns | 0.134 ns | 0.125 ns | 1.70x faster |   0.01x |      - |         - |
|               StructLinq |   100 | 162.10 ns | 0.149 ns | 0.116 ns | 3.34x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 |  71.64 ns | 0.298 ns | 0.279 ns | 1.48x slower |   0.01x |      - |         - |
|                Hyperlinq |   100 |  29.65 ns | 0.094 ns | 0.073 ns | 1.64x faster |   0.01x |      - |         - |
|           Hyperlinq_SIMD |   100 |  24.31 ns | 0.076 ns | 0.067 ns | 2.00x faster |   0.01x |      - |         - |
