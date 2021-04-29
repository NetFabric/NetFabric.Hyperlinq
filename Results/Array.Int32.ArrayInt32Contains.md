## Array.Int32.ArrayInt32Contains

### Source
[ArrayInt32Contains.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Contains.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [](https://www.nuget.org/packages/LinqOptimizer.CSharp/)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |     Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |---------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 | 45.31 ns | 0.200 ns | 0.177 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|              ForeachLoop |   100 | 45.46 ns | 0.197 ns | 0.164 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                     Linq |   100 | 41.00 ns | 0.163 ns | 0.144 ns |  0.90 |    0.00 |      - |     - |     - |         - |
|               LinqFaster |   100 | 35.91 ns | 0.292 ns | 0.274 ns |  0.79 |    0.01 |      - |     - |     - |         - |
|          LinqFaster_SIMD |   100 | 13.65 ns | 0.077 ns | 0.136 ns |  0.30 |    0.00 |      - |     - |     - |         - |
|             LinqFasterer |   100 | 33.33 ns | 0.163 ns | 0.153 ns |  0.74 |    0.00 |      - |     - |     - |         - |
|                   LinqAF |   100 | 34.65 ns | 0.222 ns | 0.185 ns |  0.76 |    0.01 |      - |     - |     - |         - |
|               StructLinq |   100 | 69.97 ns | 0.362 ns | 0.339 ns |  1.54 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 | 58.73 ns | 1.221 ns | 1.789 ns |  1.33 |    0.04 |      - |     - |     - |         - |
|                Hyperlinq |   100 | 37.03 ns | 0.244 ns | 0.216 ns |  0.82 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_SIMD |   100 | 22.63 ns | 0.266 ns | 0.207 ns |  0.50 |    0.00 |      - |     - |     - |         - |
