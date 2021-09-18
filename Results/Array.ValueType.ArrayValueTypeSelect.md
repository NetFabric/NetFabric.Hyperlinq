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
|                   Method | Count |      Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |------ |----------:|----------:|----------:|--------------:|--------:|--------:|--------:|----------:|
|                  ForLoop |   100 |  1.514 μs | 0.0007 μs | 0.0006 μs |      baseline |         |       - |       - |         - |
|              ForeachLoop |   100 |  1.663 μs | 0.0316 μs | 0.0310 μs |  1.10x slower |   0.02x |       - |       - |         - |
|                     Linq |   100 |  2.289 μs | 0.0140 μs | 0.0131 μs |  1.51x slower |   0.01x |  0.0496 |       - |     104 B |
|               LinqFaster |   100 |  2.499 μs | 0.0497 μs | 0.0465 μs |  1.65x slower |   0.03x |  3.0670 |       - |   6,424 B |
|             LinqFasterer |   100 |  2.701 μs | 0.0046 μs | 0.0040 μs |  1.78x slower |   0.00x |  3.0861 |       - |   6,456 B |
|                   LinqAF |   100 |  2.678 μs | 0.0028 μs | 0.0025 μs |  1.77x slower |   0.00x |       - |       - |         - |
|            LinqOptimizer |   100 | 48.561 μs | 0.1237 μs | 0.1033 μs | 32.08x slower |   0.07x | 57.9224 | 19.1650 | 156,724 B |
|                 SpanLinq |   100 |  2.234 μs | 0.0018 μs | 0.0017 μs |  1.48x slower |   0.00x |       - |       - |         - |
|                  Streams |   100 |  3.388 μs | 0.0111 μs | 0.0098 μs |  2.24x slower |   0.01x |  0.3929 |       - |     824 B |
|               StructLinq |   100 |  1.881 μs | 0.0012 μs | 0.0011 μs |  1.24x slower |   0.00x |  0.0153 |       - |      32 B |
| StructLinq_ValueDelegate |   100 |  1.653 μs | 0.0004 μs | 0.0003 μs |  1.09x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |   100 |  1.908 μs | 0.0010 μs | 0.0008 μs |  1.26x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |   100 |  1.851 μs | 0.0005 μs | 0.0004 μs |  1.22x slower |   0.00x |       - |       - |         - |
