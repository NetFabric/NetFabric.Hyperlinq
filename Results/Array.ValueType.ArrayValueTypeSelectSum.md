## Array.ValueType.ArrayValueTypeSelectSum

### Source
[ArrayValueTypeSelectSum.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelectSum.cs)

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
|                   Method | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|---------------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 |     69.64 ns |   0.041 ns |   0.032 ns |       baseline |         |      - |     - |     - |         - |
|              ForeachLoop |   100 |    140.96 ns |   0.106 ns |   0.094 ns |   2.02x slower |   0.00x |      - |     - |     - |         - |
|                     Linq |   100 |    603.27 ns |   1.835 ns |   1.533 ns |   8.66x slower |   0.01x | 0.0153 |     - |     - |      32 B |
|               LinqFaster |   100 |    356.39 ns |   0.483 ns |   0.452 ns |   5.12x slower |   0.01x |      - |     - |     - |         - |
|             LinqFasterer |   100 |    261.75 ns |   0.171 ns |   0.152 ns |   3.76x slower |   0.00x |      - |     - |     - |         - |
|                   LinqAF |   100 |    719.94 ns |   0.408 ns |   0.362 ns |  10.34x slower |   0.01x |      - |     - |     - |         - |
|            LinqOptimizer |   100 | 29,914.35 ns | 120.966 ns | 113.152 ns | 429.40x slower |   1.80x | 9.0332 |     - |     - |  18,930 B |
|                  Streams |   100 |    648.77 ns |   0.510 ns |   0.399 ns |   9.32x slower |   0.01x | 0.1717 |     - |     - |     360 B |
|               StructLinq |   100 |    247.22 ns |   0.160 ns |   0.133 ns |   3.55x slower |   0.00x | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |     84.11 ns |   0.055 ns |   0.049 ns |   1.21x slower |   0.00x |      - |     - |     - |         - |
|                Hyperlinq |   100 |    617.71 ns |   0.247 ns |   0.206 ns |   8.87x slower |   0.00x |      - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    316.59 ns |   0.513 ns |   0.454 ns |   4.55x slower |   0.01x |      - |     - |     - |         - |
