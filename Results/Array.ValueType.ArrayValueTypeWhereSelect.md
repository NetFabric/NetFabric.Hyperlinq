## Array.ValueType.ArrayValueTypeWhereSelect

### Source
[ArrayValueTypeWhereSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelect.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |    928.8 ns |   2.33 ns |   2.06 ns |  1.00 |    0.00 |       - |     - |     - |         - |
|              ForeachLoop |   100 |  1,028.4 ns |   3.96 ns |   3.71 ns |  1.11 |    0.01 |       - |     - |     - |         - |
|                     Linq |   100 |  1,632.3 ns |  20.16 ns |  16.83 ns |  1.76 |    0.02 |  0.1030 |     - |     - |     216 B |
|               LinqFaster |   100 |  1,877.5 ns |  36.04 ns |  58.20 ns |  2.05 |    0.09 |  4.7264 |     - |     - |   9,904 B |
|             LinqFasterer |   100 |  3,586.9 ns |  49.45 ns |  43.84 ns |  3.86 |    0.05 |  6.0234 |     - |     - |  12,624 B |
|                   LinqAF |   100 |  2,297.1 ns |  45.87 ns |  52.82 ns |  2.48 |    0.07 |       - |     - |     - |         - |
|            LinqOptimizer |   100 | 51,606.5 ns | 274.67 ns | 243.48 ns | 55.56 |    0.26 | 74.0356 |     - |     - | 156,351 B |
|                  Streams |   100 |  6,953.4 ns |  61.65 ns |  51.48 ns |  7.49 |    0.06 |  0.4654 |     - |     - |     976 B |
|               StructLinq |   100 |  1,207.9 ns |   7.37 ns |   6.16 ns |  1.30 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_ValueDelegate |   100 |  1,078.9 ns |   5.03 ns |   4.70 ns |  1.16 |    0.01 |       - |     - |     - |         - |
|                Hyperlinq |   100 |  1,556.9 ns |   4.99 ns |   4.16 ns |  1.68 |    0.00 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |  1,309.5 ns |   7.87 ns |   7.36 ns |  1.41 |    0.01 |       - |     - |     - |         - |
