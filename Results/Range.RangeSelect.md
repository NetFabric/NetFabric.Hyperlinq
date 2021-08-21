## Range.RangeSelect

### Source
[RangeSelect.cs](../LinqBenchmarks/Range/RangeSelect.cs)

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
|                   Method | Start | Count |      Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------ |----------:|---------:|---------:|-------------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |     0 |   100 |  48.74 ns | 0.053 ns | 0.047 ns |     baseline |         |      - |     - |     - |         - |
|                     Linq |     0 |   100 | 386.53 ns | 0.578 ns | 0.540 ns | 7.93x slower |   0.01x | 0.0420 |     - |     - |      88 B |
|               LinqFaster |     0 |   100 | 367.80 ns | 2.325 ns | 2.061 ns | 7.55x slower |   0.04x | 0.4053 |     - |     - |     848 B |
|          LinqFaster_SIMD |     0 |   100 | 173.80 ns | 0.974 ns | 0.761 ns | 3.57x slower |   0.02x | 0.4053 |     - |     - |     848 B |
|                   LinqAF |     0 |   100 | 229.71 ns | 0.177 ns | 0.148 ns | 4.71x slower |   0.01x |      - |     - |     - |         - |
|               StructLinq |     0 |   100 | 194.80 ns | 0.190 ns | 0.169 ns | 4.00x slower |   0.00x | 0.0114 |     - |     - |      24 B |
| StructLinq_ValueDelegate |     0 |   100 | 180.39 ns | 0.121 ns | 0.108 ns | 3.70x slower |   0.00x |      - |     - |     - |         - |
|                Hyperlinq |     0 |   100 | 223.85 ns | 0.115 ns | 0.096 ns | 4.59x slower |   0.01x |      - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |     0 |   100 | 186.50 ns | 0.053 ns | 0.047 ns | 3.83x slower |   0.00x |      - |     - |     - |         - |
