## Array.Int32.ArrayInt32WhereSelect

### Source
[ArrayInt32WhereSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelect.cs)

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
|                   Method | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|-------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |     70.13 ns |   0.655 ns |   0.580 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|              ForeachLoop |   100 |     70.31 ns |   1.175 ns |   1.099 ns |   1.00 |    0.01 |       - |     - |     - |         - |
|                     Linq |   100 |    523.96 ns |   5.563 ns |   5.204 ns |   7.46 |    0.08 |  0.0496 |     - |     - |     104 B |
|               LinqFaster |   100 |    414.84 ns |   3.703 ns |   3.463 ns |   5.92 |    0.07 |  0.3171 |     - |     - |     664 B |
|             LinqFasterer |   100 |    651.25 ns |   8.472 ns |   7.075 ns |   9.28 |    0.13 |  0.4129 |     - |     - |     864 B |
|                   LinqAF |   100 |    454.66 ns |   4.663 ns |   4.133 ns |   6.48 |    0.07 |       - |     - |     - |         - |
|            LinqOptimizer |   100 | 43,102.50 ns | 175.508 ns | 164.170 ns | 614.49 |    4.71 | 14.2212 |     - |     - |  29,775 B |
|                  Streams |   100 |  1,523.76 ns |   7.588 ns |   5.924 ns |  21.72 |    0.22 |  0.3510 |     - |     - |     736 B |
|               StructLinq |   100 |    322.77 ns |   1.559 ns |   1.302 ns |   4.60 |    0.05 |  0.0305 |     - |     - |      64 B |
| StructLinq_ValueDelegate |   100 |    185.69 ns |   0.603 ns |   0.564 ns |   2.65 |    0.02 |       - |     - |     - |         - |
|                Hyperlinq |   100 |    349.67 ns |   3.140 ns |   2.937 ns |   4.99 |    0.06 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    215.82 ns |   0.350 ns |   0.310 ns |   3.08 |    0.03 |       - |     - |     - |         - |
