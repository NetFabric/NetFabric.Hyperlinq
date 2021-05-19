## List.Int32.ListInt32Contains

### Source
[ListInt32Contains.cs](../LinqBenchmarks/List/Int32/ListInt32Contains.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [1.0.0](https://www.nuget.org/packages/SpanLinq/1.0.0)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1538-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |      Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 | 110.50 ns | 0.555 ns | 0.519 ns |  1.00 |      - |     - |     - |         - |
|              ForeachLoop |   100 | 137.65 ns | 0.461 ns | 0.409 ns |  1.25 |      - |     - |     - |         - |
|                     Linq |   100 |  31.54 ns | 0.244 ns | 0.216 ns |  0.29 |      - |     - |     - |         - |
|               LinqFaster |   100 |  29.52 ns | 0.253 ns | 0.237 ns |  0.27 |      - |     - |     - |         - |
|             LinqFasterer |   100 |  74.65 ns | 1.319 ns | 1.234 ns |  0.68 | 0.2027 |     - |     - |     424 B |
|                   LinqAF |   100 |  29.66 ns | 0.372 ns | 0.311 ns |  0.27 |      - |     - |     - |         - |
|               StructLinq |   100 |  78.56 ns | 0.570 ns | 0.505 ns |  0.71 | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |  60.06 ns | 0.254 ns | 0.212 ns |  0.54 |      - |     - |     - |         - |
|                Hyperlinq |   100 |  33.40 ns | 0.319 ns | 0.283 ns |  0.30 |      - |     - |     - |         - |
|           Hyperlinq_SIMD |   100 |  25.83 ns | 0.267 ns | 0.236 ns |  0.23 |      - |     - |     - |         - |
