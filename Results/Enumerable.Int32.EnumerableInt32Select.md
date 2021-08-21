## Enumerable.Int32.EnumerableInt32Select

### Source
[EnumerableInt32Select.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Select.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev |          Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|---------------:|--------:|--------:|------:|------:|----------:|
|              ForeachLoop |   100 |    299.2 ns |   0.13 ns |   0.11 ns |       baseline |         |  0.0191 |     - |     - |      40 B |
|                     Linq |   100 |    448.2 ns |   0.60 ns |   0.53 ns |   1.50x slower |   0.00x |  0.0458 |     - |     - |      96 B |
|                   LinqAF |   100 |    425.1 ns |   0.71 ns |   0.55 ns |   1.42x slower |   0.00x |  0.0191 |     - |     - |      40 B |
|            LinqOptimizer |   100 | 38,673.7 ns | 372.77 ns | 429.28 ns | 129.39x slower |   1.65x | 13.5498 |     - |     - |  28,431 B |
|                  Streams |   100 |  1,565.9 ns |   7.20 ns |   5.62 ns |   5.23x slower |   0.02x |  0.2823 |     - |     - |     592 B |
|               StructLinq |   100 |    335.2 ns |   0.24 ns |   0.21 ns |   1.12x slower |   0.00x |  0.0305 |     - |     - |      64 B |
| StructLinq_ValueDelegate |   100 |    311.0 ns |   0.20 ns |   0.19 ns |   1.04x slower |   0.00x |  0.0191 |     - |     - |      40 B |
|                Hyperlinq |   100 |    361.1 ns |   0.37 ns |   0.29 ns |   1.21x slower |   0.00x |  0.0191 |     - |     - |      40 B |
|  Hyperlinq_ValueDelegate |   100 |    286.3 ns |   1.39 ns |   1.16 ns |   1.05x faster |   0.00x |  0.0191 |     - |     - |      40 B |
