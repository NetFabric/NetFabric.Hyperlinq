## Array.Int32.ArrayInt32Distinct

### Source
[ArrayInt32Distinct.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Distinct.cs)

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
|                   Method | Duplicates | Count |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |----------- |------ |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |          4 |   100 | 3.497 μs | 0.0281 μs | 0.0263 μs |  1.00 |    0.00 | 2.8648 |     - |     - |   6,000 B |
|              ForeachLoop |          4 |   100 | 3.463 μs | 0.0344 μs | 0.0287 μs |  0.99 |    0.01 | 2.8648 |     - |     - |   6,000 B |
|                     Linq |          4 |   100 | 4.212 μs | 0.0173 μs | 0.0153 μs |  1.20 |    0.01 | 2.8610 |     - |     - |   5,992 B |
|             LinqFasterer |          4 |   100 | 4.070 μs | 0.0237 μs | 0.0222 μs |  1.16 |    0.01 | 4.4174 |     - |     - |   9,272 B |
|                   LinqAF |          4 |   100 | 8.139 μs | 0.0525 μs | 0.0465 μs |  2.33 |    0.03 | 5.9204 |     - |     - |  12,400 B |
|               StructLinq |          4 |   100 | 3.469 μs | 0.0119 μs | 0.0099 μs |  0.99 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |          4 |   100 | 3.519 μs | 0.0109 μs | 0.0102 μs |  1.01 |    0.01 |      - |     - |     - |         - |
|                Hyperlinq |          4 |   100 | 3.526 μs | 0.0077 μs | 0.0072 μs |  1.01 |    0.01 |      - |     - |     - |         - |
