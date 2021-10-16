## List.ValueType.ListValueTypeSelectSum

### Source
[ListValueTypeSelectSum.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelectSum.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.27.0](https://www.nuget.org/packages/StructLinq/0.27.0)
- NetFabric.Hyperlinq: [3.0.0-beta48](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta48)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1419) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.2.21505.57
  [Host]     : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 PGO : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT

Job=.NET 6 PGO  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|---------------:|--------:|-------:|----------:|
|                  ForLoop |   100 |    155.35 ns |   2.292 ns |   1.914 ns |       baseline |         |      - |         - |
|              ForeachLoop |   100 |    399.90 ns |   0.677 ns |   0.600 ns |   2.57x slower |   0.03x |      - |         - |
|                     Linq |   100 |    697.01 ns |   1.059 ns |   0.990 ns |   4.49x slower |   0.05x | 0.0458 |      96 B |
|               LinqFaster |   100 |    383.60 ns |   1.025 ns |   0.909 ns |   2.47x slower |   0.03x |      - |         - |
|             LinqFasterer |   100 |    704.22 ns |   4.406 ns |   4.121 ns |   4.54x slower |   0.06x | 3.0670 |   6,424 B |
|                   LinqAF |   100 |    964.32 ns |   1.501 ns |   1.404 ns |   6.21x slower |   0.08x |      - |         - |
|            LinqOptimizer |   100 | 37,576.46 ns | 255.917 ns | 226.864 ns | 241.73x slower |   3.03x | 9.4604 |  19,829 B |
|                  Streams |   100 |    833.81 ns |   1.923 ns |   1.798 ns |   5.37x slower |   0.07x | 0.1717 |     360 B |
|               StructLinq |   100 |    222.94 ns |   0.564 ns |   0.500 ns |   1.44x slower |   0.02x | 0.0191 |      40 B |
| StructLinq_ValueDelegate |   100 |     95.09 ns |   0.200 ns |   0.177 ns |   1.63x faster |   0.02x |      - |         - |
|                Hyperlinq |   100 |    529.61 ns |   1.009 ns |   0.944 ns |   3.41x slower |   0.04x |      - |         - |
|  Hyperlinq_ValueDelegate |   100 |    284.99 ns |   0.291 ns |   0.258 ns |   1.84x slower |   0.02x |      - |         - |
