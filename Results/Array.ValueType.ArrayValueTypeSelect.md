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
|                   Method | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |----------:|----------:|----------:|------:|--------:|--------:|--------:|------:|----------:|
|                  ForLoop |   100 |  1.629 μs | 0.0086 μs | 0.0076 μs |  1.00 |    0.00 |       - |       - |     - |         - |
|              ForeachLoop |   100 |  1.792 μs | 0.0051 μs | 0.0045 μs |  1.10 |    0.01 |       - |       - |     - |         - |
|                     Linq |   100 |  2.215 μs | 0.0099 μs | 0.0092 μs |  1.36 |    0.01 |  0.0496 |       - |     - |     104 B |
|               LinqFaster |   100 |  2.415 μs | 0.0183 μs | 0.0171 μs |  1.48 |    0.01 |  3.0670 |       - |     - |   6,424 B |
|             LinqFasterer |   100 |  3.252 μs | 0.0147 μs | 0.0115 μs |  2.00 |    0.01 |  3.0861 |       - |     - |   6,456 B |
|                   LinqAF |   100 |  3.070 μs | 0.0147 μs | 0.0115 μs |  1.88 |    0.01 |       - |       - |     - |         - |
|            LinqOptimizer |   100 | 46.057 μs | 0.2546 μs | 0.2257 μs | 28.28 |    0.18 | 57.6782 | 19.2261 |     - | 156,603 B |
|                  Streams |   100 | 10.729 μs | 0.0470 μs | 0.0393 μs |  6.59 |    0.04 |  0.3815 |       - |     - |     824 B |
|               StructLinq |   100 |  1.925 μs | 0.0069 μs | 0.0058 μs |  1.18 |    0.01 |  0.0153 |       - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |  1.827 μs | 0.0030 μs | 0.0025 μs |  1.12 |    0.01 |       - |       - |     - |         - |
|                Hyperlinq |   100 |  1.993 μs | 0.0041 μs | 0.0034 μs |  1.22 |    0.01 |       - |       - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |  1.762 μs | 0.0051 μs | 0.0048 μs |  1.08 |    0.00 |       - |       - |     - |         - |
