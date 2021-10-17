## ImmutableArray.Int32.ImmutableArrayInt32Contains

### Source
[ImmutableArrayInt32Contains.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Contains.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.27.0](https://www.nuget.org/packages/StructLinq/0.27.0)
- NetFabric.Hyperlinq: [3.0.0-beta48](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta48)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1419) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.2.21505.57
  [Host]     : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 PGO : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT

Job=.NET 6 PGO  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |      Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |----------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|                  ForLoop |   100 |  48.59 ns | 0.161 ns | 0.142 ns |     baseline |         |      - |         - |
|              ForeachLoop |   100 |  49.18 ns | 0.187 ns | 0.166 ns | 1.01x slower |   0.00x |      - |         - |
|                     Linq |   100 |  24.16 ns | 0.131 ns | 0.122 ns | 2.01x faster |   0.01x |      - |         - |
|             LinqFasterer |   100 |  71.43 ns | 0.588 ns | 0.550 ns | 1.47x slower |   0.01x | 0.2142 |     448 B |
|               StructLinq |   100 | 105.57 ns | 0.429 ns | 0.401 ns | 2.17x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 |  86.85 ns | 0.475 ns | 0.444 ns | 1.79x slower |   0.01x |      - |         - |
|                Hyperlinq |   100 |  35.54 ns | 0.199 ns | 0.187 ns | 1.37x faster |   0.01x | 0.0153 |      32 B |
|           Hyperlinq_SIMD |   100 |  24.93 ns | 0.070 ns | 0.066 ns | 1.95x faster |   0.01x |      - |         - |
