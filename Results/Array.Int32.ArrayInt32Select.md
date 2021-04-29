## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

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
|                   Method | Count |          Mean |         Error |        StdDev |    Ratio |  RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |--------------:|--------------:|--------------:|---------:|---------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 |      59.24 ns |      0.700 ns |      0.620 ns |     1.00 |     0.00 |      - |     - |     - |         - |
|              ForeachLoop |   100 |      57.91 ns |      0.206 ns |      0.161 ns |     0.98 |     0.01 |      - |     - |     - |         - |
|                     Linq |   100 |     467.02 ns |      1.882 ns |      1.668 ns |     7.88 |     0.08 | 0.0229 |     - |     - |      48 B |
|               LinqFaster |   100 |     252.47 ns |      2.009 ns |      1.678 ns |     4.26 |     0.05 | 0.2027 |     - |     - |     424 B |
|          LinqFaster_SIMD |   100 |     112.70 ns |      1.238 ns |      1.158 ns |     1.91 |     0.03 | 0.2027 |     - |     - |     424 B |
|             LinqFasterer |   100 |     421.17 ns |      1.520 ns |      1.347 ns |     7.11 |     0.08 | 0.2179 |     - |     - |     456 B |
|                   LinqAF |   100 |     487.19 ns |      7.588 ns |      6.727 ns |     8.23 |     0.15 |      - |     - |     - |         - |
|            LinqOptimizer |   100 | 237,161.86 ns | 14,776.368 ns | 42,868.922 ns | 4,245.06 | 1,019.03 |      - |     - |     - |  28,056 B |
|                  Streams |   100 |   1,353.65 ns |      8.817 ns |      8.247 ns |    22.83 |     0.26 | 0.2785 |     - |     - |     584 B |
|               StructLinq |   100 |     234.81 ns |      0.829 ns |      0.735 ns |     3.96 |     0.05 | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |     164.60 ns |      0.727 ns |      0.680 ns |     2.78 |     0.03 |      - |     - |     - |         - |
|                Hyperlinq |   100 |     213.95 ns |      2.707 ns |      4.293 ns |     3.63 |     0.06 |      - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |     193.80 ns |      2.313 ns |      2.164 ns |     3.27 |     0.04 |      - |     - |     - |         - |
