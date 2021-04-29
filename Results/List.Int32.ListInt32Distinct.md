## List.Int32.ListInt32Distinct

### Source
[ListInt32Distinct.cs](../LinqBenchmarks/List/Int32/ListInt32Distinct.cs)

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
|                   Method | Duplicates | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |----------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |          4 |   100 | 3,529.7 ns | 57.16 ns | 47.73 ns |  1.00 |    0.00 | 2.8648 |     - |     - |   6,000 B |
|              ForeachLoop |          4 |   100 | 3,842.6 ns | 50.10 ns | 44.41 ns |  1.09 |    0.02 | 2.8610 |     - |     - |   6,000 B |
|                     Linq |          4 |   100 | 6,246.2 ns | 33.85 ns | 31.66 ns |  1.77 |    0.02 | 2.8610 |     - |     - |   6,000 B |
|               LinqFaster |          4 |   100 |   635.1 ns |  8.42 ns |  7.03 ns |  0.18 |    0.00 |      - |     - |     - |         - |
|             LinqFasterer |          4 |   100 | 4,222.7 ns | 31.81 ns | 29.75 ns |  1.20 |    0.02 | 5.2032 |     - |     - |  10,896 B |
|                   LinqAF |          4 |   100 | 9,318.3 ns | 54.96 ns | 51.41 ns |  2.64 |    0.04 | 5.9204 |     - |     - |  12,400 B |
|               StructLinq |          4 |   100 | 3,556.0 ns | 17.26 ns | 16.14 ns |  1.01 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |          4 |   100 | 3,679.7 ns | 13.25 ns | 12.40 ns |  1.04 |    0.01 |      - |     - |     - |         - |
|                Hyperlinq |          4 |   100 | 3,595.5 ns | 17.18 ns | 16.07 ns |  1.02 |    0.01 |      - |     - |     - |         - |
