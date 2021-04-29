## ImmutableArray.Int32.ImmutableArrayInt32Where

### Source
[ImmutableArrayInt32Where.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Where.cs)

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
|                  ForLoop |   100 |     69.28 ns |   0.436 ns |   0.386 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|              ForeachLoop |   100 |     69.96 ns |   0.756 ns |   0.707 ns |   1.01 |    0.01 |       - |     - |     - |         - |
|                     Linq |   100 |    443.08 ns |   3.572 ns |   3.342 ns |   6.40 |    0.06 |  0.0229 |     - |     - |      48 B |
|             LinqFasterer |   100 |    507.70 ns |   5.412 ns |   4.225 ns |   7.33 |    0.08 |  0.3443 |     - |     - |     720 B |
|            LinqOptimizer |   100 | 45,405.00 ns | 592.240 ns | 973.067 ns | 656.80 |   20.32 | 13.9160 |     - |     - |  29,195 B |
|                  Streams |   100 |  1,754.40 ns |  27.450 ns |  25.676 ns |  25.30 |    0.45 |  0.2899 |     - |     - |     608 B |
|               StructLinq |   100 |    324.26 ns |   5.659 ns |   5.016 ns |   4.68 |    0.07 |  0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |    195.99 ns |   3.029 ns |   2.833 ns |   2.84 |    0.02 |       - |     - |     - |         - |
|                Hyperlinq |   100 |    368.51 ns |   4.448 ns |   4.161 ns |   5.32 |    0.08 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    210.65 ns |   0.720 ns |   0.638 ns |   3.04 |    0.02 |       - |     - |     - |         - |
