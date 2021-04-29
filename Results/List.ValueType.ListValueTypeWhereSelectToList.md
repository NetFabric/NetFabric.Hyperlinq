## List.ValueType.ListValueTypeWhereSelectToList

### Source
[ListValueTypeWhereSelectToList.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToList.cs)

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
|                   Method | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |----------:|----------:|----------:|------:|--------:|--------:|--------:|------:|----------:|
|                  ForLoop |   100 |  1.355 μs | 0.0169 μs | 0.0158 μs |  1.00 |    0.00 |  3.8605 |       - |     - |      8 KB |
|              ForeachLoop |   100 |  1.532 μs | 0.0114 μs | 0.0095 μs |  1.13 |    0.02 |  3.8605 |       - |     - |      8 KB |
|                     Linq |   100 |  1.749 μs | 0.0342 μs | 0.0351 μs |  1.30 |    0.03 |  4.0436 |       - |     - |      8 KB |
|               LinqFaster |   100 |  1.914 μs | 0.0100 μs | 0.0093 μs |  1.41 |    0.02 |  5.5389 |       - |     - |     11 KB |
|             LinqFasterer |   100 |  2.246 μs | 0.0235 μs | 0.0208 μs |  1.66 |    0.03 |  8.0643 |       - |     - |     16 KB |
|                   LinqAF |   100 |  3.262 μs | 0.0556 μs | 0.0520 μs |  2.41 |    0.05 |  3.8605 |       - |     - |      8 KB |
|            LinqOptimizer |   100 | 58.542 μs | 0.3208 μs | 0.3001 μs | 43.21 |    0.49 | 58.0444 | 14.4653 |     - |    158 KB |
|                  Streams |   100 |  7.159 μs | 0.0432 μs | 0.0361 μs |  5.28 |    0.07 |  4.1199 |       - |     - |      8 KB |
|               StructLinq |   100 |  1.961 μs | 0.0061 μs | 0.0057 μs |  1.45 |    0.02 |  1.7262 |       - |     - |      4 KB |
| StructLinq_ValueDelegate |   100 |  1.207 μs | 0.0061 μs | 0.0057 μs |  0.89 |    0.01 |  1.6766 |       - |     - |      3 KB |
|                Hyperlinq |   100 |  1.796 μs | 0.0358 μs | 0.0317 μs |  1.33 |    0.02 |  1.6766 |       - |     - |      3 KB |
|  Hyperlinq_ValueDelegate |   100 |  1.405 μs | 0.0110 μs | 0.0092 μs |  1.04 |    0.02 |  1.6766 |       - |     - |      3 KB |
