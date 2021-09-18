## Array.Int32.ArrayInt32WhereSelect

### Source
[ArrayInt32WhereSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.27.0](https://www.nuget.org/packages/StructLinq/0.27.0)
- NetFabric.Hyperlinq: [3.0.0-beta46](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta46)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1417) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.1.21458.32
  [Host]     : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 PGO : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT

Job=.NET 6 PGO  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |         Mean |      Error |    StdDev |       Median |          Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |------ |-------------:|-----------:|----------:|-------------:|---------------:|--------:|--------:|----------:|
|                  ForLoop |   100 |     72.71 ns |   0.080 ns |  0.067 ns |     72.68 ns |       baseline |         |       - |         - |
|              ForeachLoop |   100 |     73.19 ns |   0.062 ns |  0.058 ns |     73.18 ns |   1.01x slower |   0.00x |       - |         - |
|                     Linq |   100 |    466.84 ns |   1.637 ns |  1.531 ns |    467.00 ns |   6.42x slower |   0.02x |  0.0496 |     104 B |
|               LinqFaster |   100 |    411.19 ns |   0.636 ns |  0.595 ns |    411.17 ns |   5.66x slower |   0.01x |  0.3171 |     664 B |
|             LinqFasterer |   100 |    704.51 ns |   0.762 ns |  0.676 ns |    704.28 ns |   9.69x slower |   0.01x |  0.4129 |     864 B |
|                   LinqAF |   100 |    308.61 ns |   0.776 ns |  0.726 ns |    308.78 ns |   4.25x slower |   0.00x |       - |         - |
|            LinqOptimizer |   100 | 45,598.08 ns | 114.323 ns | 95.465 ns | 45,596.69 ns | 627.16x slower |   1.39x | 14.2212 |  29,777 B |
|                 SpanLinq |   100 |    415.50 ns |   5.452 ns | 10.241 ns |    414.12 ns |   5.68x slower |   0.24x |       - |         - |
|                  Streams |   100 |  1,636.57 ns |  32.228 ns | 58.930 ns |  1,594.97 ns |  23.31x slower |   0.54x |  0.3510 |     736 B |
|               StructLinq |   100 |    409.35 ns |   2.898 ns |  2.569 ns |    409.88 ns |   5.64x slower |   0.03x |  0.0305 |      64 B |
| StructLinq_ValueDelegate |   100 |    197.07 ns |   1.294 ns |  1.081 ns |    196.56 ns |   2.71x slower |   0.02x |       - |         - |
|                Hyperlinq |   100 |    333.13 ns |   0.429 ns |  0.401 ns |    333.13 ns |   4.58x slower |   0.01x |       - |         - |
|  Hyperlinq_ValueDelegate |   100 |    229.24 ns |   0.183 ns |  0.153 ns |    229.21 ns |   3.15x slower |   0.00x |       - |         - |
