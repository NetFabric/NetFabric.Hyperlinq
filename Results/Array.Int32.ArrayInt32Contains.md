## Array.Int32.ArrayInt32Contains

### Source
[ArrayInt32Contains.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Contains.cs)

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
|                  ForLoop |   100 | 45.65 ns | 0.409 ns | 0.341 ns |     baseline |         |      - |     - |     - |         - |
|              ForeachLoop |   100 | 45.63 ns | 0.263 ns | 0.233 ns | 1.00x slower |   0.01x |      - |     - |     - |         - |
|                     Linq |   100 | 41.09 ns | 0.497 ns | 0.440 ns | 1.11x faster |   0.01x |      - |     - |     - |         - |
|               LinqFaster |   100 | 35.78 ns | 0.209 ns | 0.185 ns | 1.28x faster |   0.01x |      - |     - |     - |         - |
|          LinqFaster_SIMD |   100 | 17.00 ns | 0.116 ns | 0.102 ns | 2.69x faster |   0.02x |      - |     - |     - |         - |
|             LinqFasterer |   100 | 32.23 ns | 0.152 ns | 0.127 ns | 1.42x faster |   0.01x |      - |     - |     - |         - |
|                   LinqAF |   100 | 35.22 ns | 0.343 ns | 0.304 ns | 1.30x faster |   0.01x |      - |     - |     - |         - |
|               StructLinq |   100 | 74.50 ns | 0.367 ns | 0.326 ns | 1.63x slower |   0.02x | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 | 59.50 ns | 0.439 ns | 0.411 ns | 1.30x slower |   0.01x |      - |     - |     - |         - |
|                Hyperlinq |   100 | 35.99 ns | 0.271 ns | 0.240 ns | 1.27x faster |   0.01x |      - |     - |     - |         - |
|           Hyperlinq_SIMD |   100 | 25.96 ns | 0.152 ns | 0.135 ns | 1.76x faster |   0.02x |      - |     - |     - |         - |
