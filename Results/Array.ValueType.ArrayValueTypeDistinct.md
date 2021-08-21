## Array.ValueType.ArrayValueTypeDistinct

### Source
[ArrayValueTypeDistinct.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeDistinct.cs)

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
|                   Method | Duplicates | Count |      Mean |     Error |    StdDev |        Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |----------- |------ |----------:|----------:|----------:|-------------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |          4 |   100 | 11.442 μs | 0.0359 μs | 0.0318 μs |     baseline |         | 12.8784 |     - |     - |  26,976 B |
|              ForeachLoop |          4 |   100 | 12.031 μs | 0.0121 μs | 0.0107 μs | 1.05x slower |   0.00x | 12.8784 |     - |     - |  26,976 B |
|                     Linq |          4 |   100 | 14.684 μs | 0.0244 μs | 0.0216 μs | 1.28x slower |   0.00x | 12.8174 |     - |     - |  26,848 B |
|             LinqFasterer |          4 |   100 | 15.024 μs | 0.0373 μs | 0.0349 μs | 1.31x slower |   0.00x | 22.6135 |     - |     - |  47,544 B |
|                   LinqAF |          4 |   100 | 36.082 μs | 0.0643 μs | 0.0537 μs | 3.15x slower |   0.01x | 21.8506 |     - |     - |  45,752 B |
|               StructLinq |          4 |   100 | 13.228 μs | 0.0182 μs | 0.0152 μs | 1.16x slower |   0.00x |  0.0153 |     - |     - |      56 B |
| StructLinq_ValueDelegate |          4 |   100 |  5.195 μs | 0.0075 μs | 0.0070 μs | 2.20x faster |   0.01x |       - |     - |     - |         - |
|                Hyperlinq |          4 |   100 | 12.589 μs | 0.0101 μs | 0.0090 μs | 1.10x slower |   0.00x |       - |     - |     - |         - |
