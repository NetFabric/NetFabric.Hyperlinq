## ImmutableArray.Int32.ImmutableArrayInt32Sum

### Source
[ImmutableArrayInt32Sum.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Sum.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.27.0](https://www.nuget.org/packages/StructLinq/0.27.0)
- NetFabric.Hyperlinq: [3.0.0-beta46](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta46)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1417) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.1.21458.32
  [Host]     : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 PGO : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT

Job=.NET 6 PGO  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |         Mean |        Error |       StdDev |       Median |          Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |-------------:|-------------:|-------------:|-------------:|---------------:|--------:|-------:|----------:|
|                  ForLoop |   100 |     52.12 ns |     1.122 ns |     2.464 ns |     51.78 ns |       baseline |         |      - |         - |
|              ForeachLoop |   100 |     50.97 ns |     1.025 ns |     1.950 ns |     50.32 ns |   1.03x faster |   0.05x |      - |         - |
|                     Linq |   100 |    332.18 ns |     7.915 ns |    22.325 ns |    327.20 ns |   6.58x slower |   0.49x | 0.0267 |      56 B |
|             LinqFasterer |   100 |    164.86 ns |     5.171 ns |    14.837 ns |    160.07 ns |   3.29x slower |   0.33x | 0.2141 |     448 B |
|            LinqOptimizer |   100 | 33,577.81 ns | 1,043.238 ns | 2,890.808 ns | 33,228.02 ns | 648.56x slower |  63.28x | 8.3008 |  17,415 B |
|                  Streams |   100 |    445.41 ns |     8.988 ns |    19.917 ns |    438.04 ns |   8.56x slower |   0.52x | 0.1259 |     264 B |
|               StructLinq |   100 |     97.53 ns |     2.606 ns |     7.306 ns |     95.90 ns |   1.91x slower |   0.17x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 |     67.91 ns |     1.438 ns |     2.592 ns |     67.14 ns |   1.30x slower |   0.07x |      - |         - |
|                Hyperlinq |   100 |     19.93 ns |     0.470 ns |     0.859 ns |     19.96 ns |   2.63x faster |   0.13x |      - |         - |
