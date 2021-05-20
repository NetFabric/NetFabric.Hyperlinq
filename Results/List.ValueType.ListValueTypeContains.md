## List.ValueType.ListValueTypeContains

### Source
[ListValueTypeContains.cs](../LinqBenchmarks/List/ValueType/ListValueTypeContains.cs)

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
|                   Method | Count |     Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |---------:|---------:|---------:|-------------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 | 609.7 ns |  2.52 ns |  2.23 ns |     baseline |         |      - |     - |     - |         - |
|              ForeachLoop |   100 | 823.2 ns | 16.19 ns | 22.70 ns | 1.35x slower |   0.04x |      - |     - |     - |         - |
|                     Linq |   100 | 181.7 ns |  1.39 ns |  1.23 ns | 3.36x faster |   0.03x |      - |     - |     - |         - |
|               LinqFaster |   100 | 181.9 ns |  1.82 ns |  1.70 ns | 3.35x faster |   0.03x |      - |     - |     - |         - |
|             LinqFasterer |   100 | 635.0 ns |  8.98 ns |  7.96 ns | 1.04x slower |   0.01x | 3.0670 |     - |     - |   6,424 B |
|                   LinqAF |   100 | 205.4 ns |  2.50 ns |  2.09 ns | 2.97x faster |   0.03x |      - |     - |     - |         - |
|               StructLinq |   100 | 470.4 ns |  6.96 ns |  6.17 ns | 1.30x faster |   0.02x | 0.0191 |     - |     - |      40 B |
| StructLinq_ValueDelegate |   100 | 462.5 ns |  4.33 ns |  4.05 ns | 1.32x faster |   0.01x |      - |     - |     - |         - |
|                Hyperlinq |   100 | 183.9 ns |  1.57 ns |  1.39 ns | 3.32x faster |   0.02x |      - |     - |     - |         - |
