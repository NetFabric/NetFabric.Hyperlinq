## Array.ValueType.ArrayValueTypeSelectSum

### Source
[ArrayValueTypeSelectSum.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelectSum.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.27.0](https://www.nuget.org/packages/StructLinq/0.27.0)
- NetFabric.Hyperlinq: [3.0.0-beta46](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta46)
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
|                   Method | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|---------------:|--------:|-------:|----------:|
|                  ForLoop |   100 |     71.00 ns |   0.082 ns |   0.077 ns |       baseline |         |      - |         - |
|              ForeachLoop |   100 |    141.42 ns |   1.502 ns |   1.332 ns |   1.99x slower |   0.02x |      - |         - |
|                     Linq |   100 |    601.60 ns |   0.981 ns |   0.869 ns |   8.47x slower |   0.01x | 0.0153 |      32 B |
|               LinqFaster |   100 |    358.70 ns |   0.274 ns |   0.256 ns |   5.05x slower |   0.01x |      - |         - |
|             LinqFasterer |   100 |    262.42 ns |   0.638 ns |   0.566 ns |   3.70x slower |   0.01x |      - |         - |
|                   LinqAF |   100 |    704.27 ns |   0.796 ns |   0.665 ns |   9.92x slower |   0.01x |      - |         - |
|            LinqOptimizer |   100 | 30,144.76 ns | 159.982 ns | 149.647 ns | 424.59x slower |   2.22x | 9.0332 |  18,930 B |
|                  Streams |   100 |    626.78 ns |   1.086 ns |   0.848 ns |   8.83x slower |   0.01x | 0.1717 |     360 B |
|               StructLinq |   100 |    242.76 ns |   1.605 ns |   1.423 ns |   3.42x slower |   0.02x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 |     84.04 ns |   0.069 ns |   0.057 ns |   1.18x slower |   0.00x |      - |         - |
|                Hyperlinq |   100 |    525.49 ns |   0.698 ns |   0.618 ns |   7.40x slower |   0.01x |      - |         - |
|  Hyperlinq_ValueDelegate |   100 |    292.56 ns |   0.449 ns |   0.420 ns |   4.12x slower |   0.01x |      - |         - |
