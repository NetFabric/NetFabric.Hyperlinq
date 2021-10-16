## Array.ValueType.ArrayValueTypeContains

### Source
[ArrayValueTypeContains.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeContains.cs)

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
|                   Method | Count |     Mean |   Error |  StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |---------:|--------:|--------:|-------------:|--------:|-------:|----------:|
|                  ForLoop |   100 | 509.9 ns | 1.74 ns | 1.46 ns |     baseline |         |      - |         - |
|              ForeachLoop |   100 | 521.2 ns | 0.43 ns | 0.38 ns | 1.02x slower |   0.00x |      - |         - |
|                     Linq |   100 | 141.4 ns | 0.24 ns | 0.22 ns | 3.61x faster |   0.01x |      - |         - |
|               LinqFaster |   100 | 169.5 ns | 0.32 ns | 0.27 ns | 3.01x faster |   0.01x |      - |         - |
|             LinqFasterer |   100 | 141.1 ns | 0.15 ns | 0.14 ns | 3.61x faster |   0.01x |      - |         - |
|                   LinqAF |   100 | 152.4 ns | 1.98 ns | 1.76 ns | 3.34x faster |   0.04x |      - |         - |
|               StructLinq |   100 | 590.7 ns | 4.10 ns | 3.42 ns | 1.16x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 | 534.1 ns | 1.55 ns | 1.21 ns | 1.05x slower |   0.00x |      - |         - |
|                Hyperlinq |   100 | 149.7 ns | 0.30 ns | 0.25 ns | 3.41x faster |   0.01x | 0.0153 |      32 B |
