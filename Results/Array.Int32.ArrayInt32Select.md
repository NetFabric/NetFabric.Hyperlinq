## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

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
|                   Method | Count |          Mean |        Error |        StdDev |        Median |            Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |--------------:|-------------:|--------------:|--------------:|-----------------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 |      61.75 ns |     0.515 ns |      0.482 ns |      61.62 ns |         baseline |         |      - |     - |     - |         - |
|              ForeachLoop |   100 |      61.67 ns |     0.434 ns |      0.362 ns |      61.53 ns |     1.00x slower |   0.01x |      - |     - |     - |         - |
|                     Linq |   100 |     519.87 ns |     3.723 ns |      3.301 ns |     519.95 ns |     8.42x slower |   0.09x | 0.0229 |     - |     - |      48 B |
|               LinqFaster |   100 |     276.65 ns |     2.153 ns |      2.014 ns |     277.01 ns |     4.48x slower |   0.05x | 0.2027 |     - |     - |     424 B |
|          LinqFaster_SIMD |   100 |     115.22 ns |     1.158 ns |      1.084 ns |     115.24 ns |     1.87x slower |   0.02x | 0.2027 |     - |     - |     424 B |
|             LinqFasterer |   100 |     396.48 ns |     1.968 ns |      1.644 ns |     396.28 ns |     6.43x slower |   0.05x | 0.2179 |     - |     - |     456 B |
|                   LinqAF |   100 |     563.84 ns |    10.950 ns |     16.050 ns |     557.91 ns |     9.23x slower |   0.22x |      - |     - |     - |         - |
|            LinqOptimizer |   100 | 175,333.33 ns | 9,891.306 ns | 27,077.291 ns | 162,800.00 ns | 3,189.01x slower | 576.44x |      - |     - |     - |  28,056 B |
|                 SpanLinq |   100 |     262.38 ns |     3.167 ns |      2.807 ns |     262.47 ns |     4.25x slower |   0.05x |      - |     - |     - |         - |
|                  Streams |   100 |   1,359.54 ns |    11.067 ns |      9.811 ns |   1,360.33 ns |    22.03x slower |   0.23x | 0.2785 |     - |     - |     584 B |
|               StructLinq |   100 |     212.50 ns |     1.840 ns |      1.631 ns |     212.46 ns |     3.44x slower |   0.03x | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |     180.05 ns |     0.967 ns |      0.857 ns |     179.84 ns |     2.92x slower |   0.03x |      - |     - |     - |         - |
|                Hyperlinq |   100 |     238.40 ns |     1.807 ns |      1.690 ns |     238.78 ns |     3.86x slower |   0.05x |      - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |     204.82 ns |     1.198 ns |      1.000 ns |     204.57 ns |     3.32x slower |   0.02x |      - |     - |     - |         - |
