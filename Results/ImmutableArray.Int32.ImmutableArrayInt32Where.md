## ImmutableArray.Int32.ImmutableArrayInt32Where

### Source
[ImmutableArrayInt32Where.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Where.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [](https://www.nuget.org/packages/LinqOptimizer.CSharp/)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host] : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT

EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  

```
|               Method |    Job |  Runtime | Count |        Mean |       Error |      StdDev |      Median |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |------------:|------------:|------------:|------------:|-------:|--------:|--------:|------:|------:|----------:|
|              ForLoop | .NET 5 | .NET 5.0 |  1000 |    631.6 ns |     3.98 ns |     3.53 ns |    631.5 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |    922.6 ns |     3.54 ns |     2.95 ns |    921.8 ns |   1.46 |    0.00 |       - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |  6,448.6 ns |    22.33 ns |    19.80 ns |  6,449.4 ns |  10.21 |    0.06 |  0.0229 |     - |     - |      48 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 62,920.3 ns | 1,810.44 ns | 5,338.13 ns | 59,290.9 ns | 109.81 |    3.10 | 15.0146 |     - |     - |  31,535 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 | 18,521.1 ns |   121.09 ns |   101.12 ns | 18,497.6 ns |  29.30 |    0.23 |  0.2747 |     - |     - |     608 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  7,308.3 ns |    29.98 ns |    26.58 ns |  7,309.0 ns |  11.57 |    0.08 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  5,285.8 ns |    17.83 ns |    14.89 ns |  5,288.9 ns |   8.36 |    0.04 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  5,109.3 ns |    24.88 ns |    23.27 ns |  5,103.2 ns |   8.09 |    0.04 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  2,076.6 ns |     7.88 ns |     7.37 ns |  2,078.2 ns |   3.29 |    0.02 |       - |     - |     - |         - |
|                      |        |          |       |             |             |             |             |        |         |         |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 |    740.4 ns |     2.89 ns |     2.26 ns |    740.3 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |    831.4 ns |     5.91 ns |     5.53 ns |    830.8 ns |   1.12 |    0.01 |       - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  7,035.9 ns |    22.16 ns |    19.65 ns |  7,040.2 ns |   9.50 |    0.05 |  0.0229 |     - |     - |      48 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 56,867.7 ns | 2,067.41 ns | 5,997.92 ns | 52,832.8 ns |  78.47 |    5.76 | 14.8315 |     - |     - |  31,092 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 | 16,168.6 ns |   141.79 ns |   118.40 ns | 16,149.6 ns |  21.86 |    0.15 |  0.2747 |     - |     - |     608 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  6,254.3 ns |    26.42 ns |    23.42 ns |  6,258.2 ns |   8.45 |    0.05 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  1,738.3 ns |     3.53 ns |     2.94 ns |  1,737.7 ns |   2.35 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  3,648.6 ns |    21.29 ns |    19.91 ns |  3,642.3 ns |   4.93 |    0.04 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  2,014.1 ns |     7.79 ns |     7.28 ns |  2,013.7 ns |   2.72 |    0.01 |       - |     - |     - |         - |
