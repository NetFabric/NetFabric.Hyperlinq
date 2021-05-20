## Array.ValueType.ArrayValueTypeSelect

### Source
[ArrayValueTypeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19043.985 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |      Mean |     Error |    StdDev |    Median |         Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |----------:|----------:|----------:|----------:|--------------:|--------:|--------:|--------:|------:|----------:|
|                  ForLoop |   100 |  1.653 μs | 0.0087 μs | 0.0081 μs |  1.651 μs |      baseline |         |       - |       - |     - |         - |
|              ForeachLoop |   100 |  2.403 μs | 0.0214 μs | 0.0200 μs |  2.398 μs |  1.45x slower |   0.01x |       - |       - |     - |         - |
|                     Linq |   100 |  2.233 μs | 0.0121 μs | 0.0113 μs |  2.232 μs |  1.35x slower |   0.01x |  0.0496 |       - |     - |     104 B |
|               LinqFaster |   100 |  2.797 μs | 0.0310 μs | 0.0275 μs |  2.796 μs |  1.69x slower |   0.02x |  3.0670 |       - |     - |   6,424 B |
|             LinqFasterer |   100 |  3.113 μs | 0.0300 μs | 0.0281 μs |  3.109 μs |  1.88x slower |   0.02x |  3.0861 |       - |     - |   6,456 B |
|                   LinqAF |   100 |  4.092 μs | 0.0193 μs | 0.0171 μs |  4.091 μs |  2.47x slower |   0.01x |       - |       - |     - |         - |
|            LinqOptimizer |   100 | 54.982 μs | 2.0212 μs | 5.9597 μs | 50.705 μs | 34.13x slower |   3.43x | 57.6782 | 19.2261 |     - | 156,603 B |
|                 SpanLinq |   100 |  2.317 μs | 0.0128 μs | 0.0100 μs |  2.317 μs |  1.40x slower |   0.01x |       - |       - |     - |         - |
|                  Streams |   100 | 11.377 μs | 0.2074 μs | 0.1839 μs | 11.384 μs |  6.88x slower |   0.12x |  0.3815 |       - |     - |     824 B |
|               StructLinq |   100 |  1.928 μs | 0.0100 μs | 0.0083 μs |  1.932 μs |  1.17x slower |   0.01x |  0.0153 |       - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |  1.868 μs | 0.0075 μs | 0.0070 μs |  1.866 μs |  1.13x slower |   0.01x |       - |       - |     - |         - |
|                Hyperlinq |   100 |  2.037 μs | 0.0130 μs | 0.0121 μs |  2.036 μs |  1.23x slower |   0.01x |       - |       - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |  1.798 μs | 0.0078 μs | 0.0073 μs |  1.799 μs |  1.09x slower |   0.01x |       - |       - |     - |         - |
