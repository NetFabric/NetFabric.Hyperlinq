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

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19043.985 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Start | Count |      Mean |    Error |   StdDev |         Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------ |----------:|---------:|---------:|--------------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |     0 |   100 |  50.07 ns | 0.209 ns | 0.175 ns |      baseline |         |      - |     - |     - |         - |
|                     Linq |     0 |   100 | 515.54 ns | 3.946 ns | 3.498 ns | 10.29x slower |   0.09x | 0.0420 |     - |     - |      88 B |
|               LinqFaster |     0 |   100 | 321.26 ns | 3.361 ns | 3.301 ns |  6.42x slower |   0.07x | 0.4053 |     - |     - |     848 B |
|          LinqFaster_SIMD |     0 |   100 | 158.78 ns | 2.169 ns | 1.923 ns |  3.16x slower |   0.03x | 0.4053 |     - |     - |     848 B |
|                   LinqAF |     0 |   100 | 511.82 ns | 3.623 ns | 3.212 ns | 10.21x slower |   0.06x |      - |     - |     - |         - |
|               StructLinq |     0 |   100 | 214.65 ns | 3.467 ns | 3.243 ns |  4.30x slower |   0.06x | 0.0114 |     - |     - |      24 B |
| StructLinq_ValueDelegate |     0 |   100 | 195.92 ns | 0.657 ns | 0.615 ns |  3.91x slower |   0.02x |      - |     - |     - |         - |
|                Hyperlinq |     0 |   100 | 218.41 ns | 2.786 ns | 2.606 ns |  4.38x slower |   0.03x |      - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |     0 |   100 | 202.06 ns | 1.672 ns | 1.564 ns |  4.04x slower |   0.02x |      - |     - |     - |         - |
