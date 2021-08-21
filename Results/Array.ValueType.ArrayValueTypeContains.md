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
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.0, OS=macOS Catalina 10.15.7 (19H1323) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |     Mean |   Error |  StdDev |        Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |---------:|--------:|--------:|-------------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 | 494.2 ns | 0.30 ns | 0.27 ns |     baseline |         |      - |     - |     - |         - |
|              ForeachLoop |   100 | 496.3 ns | 0.70 ns | 0.58 ns | 1.00x slower |   0.00x |      - |     - |     - |         - |
|                     Linq |   100 | 140.8 ns | 0.20 ns | 0.17 ns | 3.51x faster |   0.00x |      - |     - |     - |         - |
|               LinqFaster |   100 | 166.3 ns | 0.66 ns | 0.59 ns | 2.97x faster |   0.01x |      - |     - |     - |         - |
|             LinqFasterer |   100 | 143.0 ns | 0.84 ns | 0.66 ns | 3.46x faster |   0.02x |      - |     - |     - |         - |
|                   LinqAF |   100 | 148.3 ns | 0.39 ns | 0.35 ns | 3.33x faster |   0.01x |      - |     - |     - |         - |
|               StructLinq |   100 | 532.6 ns | 0.59 ns | 0.49 ns | 1.08x slower |   0.00x | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 | 545.9 ns | 0.19 ns | 0.17 ns | 1.10x slower |   0.00x |      - |     - |     - |         - |
|                Hyperlinq |   100 | 143.0 ns | 0.11 ns | 0.10 ns | 3.46x faster |   0.00x |      - |     - |     - |         - |
