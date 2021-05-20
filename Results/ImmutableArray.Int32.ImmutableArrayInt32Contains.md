## ImmutableArray.Int32.ImmutableArrayInt32Contains

### Source
[ImmutableArrayInt32Contains.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Contains.cs)

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
|                  ForLoop |   100 | 46.25 ns | 0.279 ns | 0.248 ns |     baseline |         |      - |     - |     - |         - |
|              ForeachLoop |   100 | 47.81 ns | 0.342 ns | 0.303 ns | 1.03x slower |   0.01x |      - |     - |     - |         - |
|                     Linq |   100 | 36.76 ns | 0.171 ns | 0.143 ns | 1.26x faster |   0.01x |      - |     - |     - |         - |
|             LinqFasterer |   100 | 92.47 ns | 0.908 ns | 0.805 ns | 2.00x slower |   0.02x | 0.2142 |     - |     - |     448 B |
|               StructLinq |   100 | 95.74 ns | 0.738 ns | 0.654 ns | 2.07x slower |   0.02x | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 | 61.40 ns | 0.492 ns | 0.436 ns | 1.33x slower |   0.01x |      - |     - |     - |         - |
|                Hyperlinq |   100 | 35.14 ns | 0.177 ns | 0.156 ns | 1.32x faster |   0.01x |      - |     - |     - |         - |
|           Hyperlinq_SIMD |   100 | 26.46 ns | 0.234 ns | 0.219 ns | 1.75x faster |   0.01x |      - |     - |     - |         - |
