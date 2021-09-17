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
|                   Method | Start | Count |      Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |------ |----------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|                  ForLoop |     0 |   100 |  48.86 ns | 0.319 ns | 0.249 ns |     baseline |         |      - |         - |
|                     Linq |     0 |   100 | 411.55 ns | 1.726 ns | 1.614 ns | 8.42x slower |   0.06x | 0.0420 |      88 B |
|               LinqFaster |     0 |   100 | 392.39 ns | 4.786 ns | 4.476 ns | 8.02x slower |   0.10x | 0.4053 |     848 B |
|          LinqFaster_SIMD |     0 |   100 | 171.45 ns | 2.551 ns | 2.387 ns | 3.51x slower |   0.06x | 0.4053 |     848 B |
|                   LinqAF |     0 |   100 | 259.00 ns | 1.023 ns | 0.907 ns | 5.30x slower |   0.03x |      - |         - |
|               StructLinq |     0 |   100 | 194.70 ns | 0.652 ns | 0.610 ns | 3.98x slower |   0.01x | 0.0114 |      24 B |
| StructLinq_ValueDelegate |     0 |   100 | 180.48 ns | 0.347 ns | 0.324 ns | 3.69x slower |   0.02x |      - |         - |
|                Hyperlinq |     0 |   100 | 201.52 ns | 0.696 ns | 0.651 ns | 4.12x slower |   0.02x |      - |         - |
|  Hyperlinq_ValueDelegate |     0 |   100 | 186.30 ns | 0.218 ns | 0.204 ns | 3.81x slower |   0.02x |      - |         - |
