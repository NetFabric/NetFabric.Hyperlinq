## Array.Int32.ArrayInt32Contains

### Source
[ArrayInt32Contains.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Contains.cs)

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
|                   Method | Count |     Mean |    Error |   StdDev |   Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |---------:|---------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 | 44.31 ns | 0.438 ns | 0.388 ns | 44.25 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|              ForeachLoop |   100 | 44.00 ns | 0.223 ns | 0.198 ns | 43.95 ns |  0.99 |    0.01 |      - |     - |     - |         - |
|                     Linq |   100 | 36.71 ns | 0.512 ns | 0.428 ns | 36.51 ns |  0.83 |    0.01 |      - |     - |     - |         - |
|               LinqFaster |   100 | 34.33 ns | 0.684 ns | 1.124 ns | 33.75 ns |  0.80 |    0.03 |      - |     - |     - |         - |
|          LinqFaster_SIMD |   100 | 12.78 ns | 0.077 ns | 0.069 ns | 12.75 ns |  0.29 |    0.00 |      - |     - |     - |         - |
|             LinqFasterer |   100 | 35.25 ns | 0.206 ns | 0.193 ns | 35.27 ns |  0.80 |    0.01 |      - |     - |     - |         - |
|                   LinqAF |   100 | 33.93 ns | 0.194 ns | 0.181 ns | 33.91 ns |  0.77 |    0.01 |      - |     - |     - |         - |
|               StructLinq |   100 | 73.87 ns | 1.443 ns | 1.205 ns | 74.14 ns |  1.67 |    0.03 | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 | 57.58 ns | 0.281 ns | 0.249 ns | 57.53 ns |  1.30 |    0.01 |      - |     - |     - |         - |
|                Hyperlinq |   100 | 35.17 ns | 0.273 ns | 0.242 ns | 35.15 ns |  0.79 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_SIMD |   100 | 23.67 ns | 0.163 ns | 0.145 ns | 23.63 ns |  0.53 |    0.01 |      - |     - |     - |         - |
