## Array.ValueType.ArrayValueTypeSelect

### Source
[ArrayValueTypeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelect.cs)

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
|                   Method | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |----------:|----------:|----------:|----------:|------:|--------:|--------:|--------:|------:|----------:|
|                  ForLoop |   100 |  1.631 μs | 0.0028 μs | 0.0023 μs |  1.632 μs |  1.00 |    0.00 |       - |       - |     - |         - |
|              ForeachLoop |   100 |  2.446 μs | 0.0111 μs | 0.0104 μs |  2.446 μs |  1.50 |    0.01 |       - |       - |     - |         - |
|                     Linq |   100 |  2.170 μs | 0.0038 μs | 0.0032 μs |  2.170 μs |  1.33 |    0.00 |  0.0496 |       - |     - |     104 B |
|               LinqFaster |   100 |  2.340 μs | 0.0280 μs | 0.0262 μs |  2.332 μs |  1.44 |    0.02 |  3.0670 |       - |     - |   6,424 B |
|             LinqFasterer |   100 |  2.728 μs | 0.0542 μs | 0.1389 μs |  2.653 μs |  1.64 |    0.05 |  3.0861 |       - |     - |   6,456 B |
|                   LinqAF |   100 |  3.060 μs | 0.0607 μs | 0.0568 μs |  3.049 μs |  1.87 |    0.04 |       - |       - |     - |         - |
|            LinqOptimizer |   100 | 46.547 μs | 0.9263 μs | 0.9512 μs | 46.410 μs | 28.56 |    0.65 | 57.6782 | 19.2261 |     - | 156,603 B |
|                  Streams |   100 | 10.940 μs | 0.1297 μs | 0.1150 μs | 10.954 μs |  6.70 |    0.07 |  0.3815 |       - |     - |     824 B |
|               StructLinq |   100 |  1.881 μs | 0.0058 μs | 0.0051 μs |  1.881 μs |  1.15 |    0.00 |  0.0153 |       - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |  2.352 μs | 0.0062 μs | 0.0058 μs |  2.353 μs |  1.44 |    0.00 |       - |       - |     - |         - |
|                Hyperlinq |   100 |  2.534 μs | 0.0050 μs | 0.0047 μs |  2.534 μs |  1.55 |    0.00 |       - |       - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |  1.741 μs | 0.0051 μs | 0.0048 μs |  1.740 μs |  1.07 |    0.00 |       - |       - |     - |         - |
