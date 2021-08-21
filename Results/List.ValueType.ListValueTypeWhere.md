## List.ValueType.ListValueTypeWhere

### Source
[ListValueTypeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhere.cs)

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

BenchmarkDotNet=v0.13.0, OS=macOS Catalina 10.15.7 (19H1323) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |        Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|--------------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |    549.0 ns |   0.28 ns |   0.23 ns |      baseline |         |       - |     - |     - |         - |
|              ForeachLoop |   100 |    793.0 ns |   0.41 ns |   0.36 ns |  1.44x slower |   0.00x |       - |     - |     - |         - |
|                     Linq |   100 |  1,172.8 ns |   3.66 ns |   3.25 ns |  2.14x slower |   0.01x |  0.0877 |     - |     - |     184 B |
|               LinqFaster |   100 |  1,749.4 ns |   2.22 ns |   1.86 ns |  3.19x slower |   0.00x |  3.8605 |     - |     - |   8,088 B |
|             LinqFasterer |   100 |  1,770.7 ns |  31.86 ns |  29.80 ns |  3.22x slower |   0.05x |  4.7379 |     - |     - |   9,936 B |
|                   LinqAF |   100 |  1,379.6 ns |   5.92 ns |   5.53 ns |  2.51x slower |   0.01x |       - |     - |     - |         - |
|            LinqOptimizer |   100 | 53,881.7 ns | 289.55 ns | 241.79 ns | 98.14x slower |   0.44x | 73.1201 |     - |     - | 154,832 B |
|                 SpanLinq |   100 |    783.5 ns |   0.37 ns |   0.30 ns |  1.43x slower |   0.00x |       - |     - |     - |         - |
|                  Streams |   100 |  2,088.3 ns |   1.65 ns |   1.47 ns |  3.80x slower |   0.00x |  0.4044 |     - |     - |     848 B |
|               StructLinq |   100 |    648.5 ns |   0.33 ns |   0.26 ns |  1.18x slower |   0.00x |  0.0191 |     - |     - |      40 B |
| StructLinq_ValueDelegate |   100 |    574.7 ns |   0.23 ns |   0.21 ns |  1.05x slower |   0.00x |       - |     - |     - |         - |
|                Hyperlinq |   100 |  1,043.6 ns |   7.31 ns |   6.84 ns |  1.90x slower |   0.01x |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    892.6 ns |   0.46 ns |   0.40 ns |  1.63x slower |   0.00x |       - |     - |     - |         - |
