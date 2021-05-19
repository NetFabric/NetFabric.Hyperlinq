## ImmutableArray.Int32.ImmutableArrayInt32Contains

### Source
[ImmutableArrayInt32Contains.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Contains.cs)

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
|                   Method | Count |     Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |---------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 | 44.62 ns | 0.161 ns | 0.143 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|              ForeachLoop |   100 | 46.10 ns | 0.169 ns | 0.150 ns |  1.03 |    0.00 |      - |     - |     - |         - |
|                     Linq |   100 | 32.74 ns | 0.211 ns | 0.187 ns |  0.73 |    0.01 |      - |     - |     - |         - |
|             LinqFasterer |   100 | 84.02 ns | 1.740 ns | 1.934 ns |  1.89 |    0.04 | 0.2142 |     - |     - |     448 B |
|               StructLinq |   100 | 95.94 ns | 0.412 ns | 0.385 ns |  2.15 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 | 58.93 ns | 0.275 ns | 0.257 ns |  1.32 |    0.01 |      - |     - |     - |         - |
|                Hyperlinq |   100 | 33.43 ns | 0.213 ns | 0.189 ns |  0.75 |    0.00 |      - |     - |     - |         - |
|           Hyperlinq_SIMD |   100 | 24.15 ns | 0.098 ns | 0.087 ns |  0.54 |    0.00 |      - |     - |     - |         - |
