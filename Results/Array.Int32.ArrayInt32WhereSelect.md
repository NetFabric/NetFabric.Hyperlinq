## Array.Int32.ArrayInt32WhereSelect

### Source
[ArrayInt32WhereSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelect.cs)

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
|                   Method | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|-------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |     67.40 ns |   0.391 ns |   0.365 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|              ForeachLoop |   100 |     67.87 ns |   0.341 ns |   0.266 ns |   1.01 |    0.01 |       - |     - |     - |         - |
|                     Linq |   100 |    528.37 ns |   9.980 ns |   8.847 ns |   7.84 |    0.15 |  0.0496 |     - |     - |     104 B |
|               LinqFaster |   100 |    400.05 ns |   1.722 ns |   1.610 ns |   5.94 |    0.04 |  0.3171 |     - |     - |     664 B |
|             LinqFasterer |   100 |    754.18 ns |   5.651 ns |   5.286 ns |  11.19 |    0.09 |  0.4129 |     - |     - |     864 B |
|                   LinqAF |   100 |    442.97 ns |   3.992 ns |   3.539 ns |   6.57 |    0.07 |       - |     - |     - |         - |
|            LinqOptimizer |   100 | 52,252.49 ns | 452.198 ns | 422.987 ns | 775.24 |    7.67 | 14.2212 |     - |     - |  29,775 B |
|                 SpanLinq |   100 |    327.01 ns |   3.561 ns |   3.331 ns |   4.85 |    0.05 |       - |     - |     - |         - |
|                  Streams |   100 |  1,499.12 ns |   7.541 ns |   6.685 ns |  22.24 |    0.17 |  0.3510 |     - |     - |     736 B |
|               StructLinq |   100 |    316.75 ns |   1.055 ns |   0.986 ns |   4.70 |    0.03 |  0.0305 |     - |     - |      64 B |
| StructLinq_ValueDelegate |   100 |    182.37 ns |   1.018 ns |   0.903 ns |   2.71 |    0.01 |       - |     - |     - |         - |
|                Hyperlinq |   100 |    322.53 ns |   1.550 ns |   1.294 ns |   4.78 |    0.03 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    230.44 ns |   1.028 ns |   0.962 ns |   3.42 |    0.02 |       - |     - |     - |         - |
