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
|                   Method | Count |     Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |---------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 | 44.47 ns | 0.370 ns | 0.346 ns |  1.00 |      - |     - |     - |         - |
|              ForeachLoop |   100 | 44.63 ns | 0.145 ns | 0.128 ns |  1.00 |      - |     - |     - |         - |
|                     Linq |   100 | 39.80 ns | 0.137 ns | 0.114 ns |  0.90 |      - |     - |     - |         - |
|               LinqFaster |   100 | 32.08 ns | 0.387 ns | 0.362 ns |  0.72 |      - |     - |     - |         - |
|          LinqFaster_SIMD |   100 | 12.01 ns | 0.086 ns | 0.080 ns |  0.27 |      - |     - |     - |         - |
|             LinqFasterer |   100 | 39.97 ns | 0.182 ns | 0.162 ns |  0.90 |      - |     - |     - |         - |
|                   LinqAF |   100 | 33.70 ns | 0.108 ns | 0.085 ns |  0.76 |      - |     - |     - |         - |
|               StructLinq |   100 | 72.86 ns | 0.250 ns | 0.209 ns |  1.64 | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 | 58.30 ns | 0.257 ns | 0.241 ns |  1.31 |      - |     - |     - |         - |
|                Hyperlinq |   100 | 35.49 ns | 0.120 ns | 0.106 ns |  0.80 |      - |     - |     - |         - |
|           Hyperlinq_SIMD |   100 | 21.98 ns | 0.081 ns | 0.063 ns |  0.49 |      - |     - |     - |         - |
