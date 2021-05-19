## List.Int32.ListInt32WhereSelect

### Source
[ListInt32WhereSelect.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelect.cs)

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
|                   Method | Count |         Mean |      Error |       StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|-----------:|-------------:|-------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |    130.06 ns |   0.599 ns |     0.531 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|              ForeachLoop |   100 |     80.74 ns |   0.316 ns |     0.296 ns |   0.62 |    0.00 |       - |     - |     - |         - |
|                     Linq |   100 |    782.99 ns |   2.855 ns |     2.531 ns |   6.02 |    0.03 |  0.0725 |     - |     - |     152 B |
|               LinqFaster |   100 |    509.33 ns |   2.218 ns |     1.966 ns |   3.92 |    0.02 |  0.3090 |     - |     - |     648 B |
|             LinqFasterer |   100 |    508.16 ns |   3.802 ns |     3.556 ns |   3.91 |    0.04 |  0.4473 |     - |     - |     936 B |
|                   LinqAF |   100 |    920.32 ns |   7.409 ns |     5.785 ns |   7.08 |    0.07 |       - |     - |     - |         - |
|            LinqOptimizer |   100 | 48,969.72 ns | 940.871 ns | 1,155.474 ns | 376.91 |   10.91 | 14.6484 |     - |     - |  30,787 B |
|                  Streams |   100 |  1,489.35 ns |   6.520 ns |     5.780 ns |  11.45 |    0.07 |  0.3624 |     - |     - |     760 B |
|               StructLinq |   100 |    342.92 ns |   2.011 ns |     1.881 ns |   2.64 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_ValueDelegate |   100 |    198.72 ns |   0.861 ns |     0.719 ns |   1.53 |    0.01 |       - |     - |     - |         - |
|                Hyperlinq |   100 |    351.84 ns |   3.472 ns |     2.711 ns |   2.71 |    0.02 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    228.94 ns |   1.702 ns |     1.592 ns |   1.76 |    0.01 |       - |     - |     - |         - |
