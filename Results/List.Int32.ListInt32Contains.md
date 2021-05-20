## List.Int32.ListInt32Contains

### Source
[ListInt32Contains.cs](../LinqBenchmarks/List/Int32/ListInt32Contains.cs)

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
|                   Method | Count |      Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |----------:|---------:|---------:|-------------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 | 113.66 ns | 0.397 ns | 0.332 ns |     baseline |         |      - |     - |     - |         - |
|              ForeachLoop |   100 | 170.83 ns | 1.341 ns | 1.120 ns | 1.50x slower |   0.01x |      - |     - |     - |         - |
|                     Linq |   100 |  32.54 ns | 0.199 ns | 0.176 ns | 3.50x faster |   0.02x |      - |     - |     - |         - |
|               LinqFaster |   100 |  30.99 ns | 0.167 ns | 0.156 ns | 3.67x faster |   0.02x |      - |     - |     - |         - |
|             LinqFasterer |   100 |  86.84 ns | 1.429 ns | 1.267 ns | 1.31x faster |   0.02x | 0.2027 |     - |     - |     424 B |
|                   LinqAF |   100 |  30.62 ns | 0.461 ns | 0.385 ns | 3.71x faster |   0.05x |      - |     - |     - |         - |
|               StructLinq |   100 |  77.64 ns | 0.287 ns | 0.255 ns | 1.46x faster |   0.01x | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |  63.10 ns | 0.487 ns | 0.432 ns | 1.80x faster |   0.01x |      - |     - |     - |         - |
|                Hyperlinq |   100 |  33.80 ns | 0.359 ns | 0.336 ns | 3.36x faster |   0.03x |      - |     - |     - |         - |
|           Hyperlinq_SIMD |   100 |  26.26 ns | 0.416 ns | 0.369 ns | 4.32x faster |   0.06x |      - |     - |     - |         - |
