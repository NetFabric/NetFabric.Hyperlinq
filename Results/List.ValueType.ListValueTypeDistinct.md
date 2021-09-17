## List.ValueType.ListValueTypeDistinct

### Source
[ListValueTypeDistinct.cs](../LinqBenchmarks/List/ValueType/ListValueTypeDistinct.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.27.0](https://www.nuget.org/packages/StructLinq/0.27.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
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
|                   Method | Duplicates | Count |      Mean |     Error |    StdDev |        Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |----------- |------ |----------:|----------:|----------:|-------------:|--------:|--------:|----------:|
|                  ForLoop |          4 |   100 | 12.613 μs | 0.0446 μs | 0.0395 μs |     baseline |         | 12.8784 |  26,976 B |
|              ForeachLoop |          4 |   100 | 13.156 μs | 0.0764 μs | 0.0714 μs | 1.04x slower |   0.01x | 12.8784 |  26,976 B |
|                     Linq |          4 |   100 | 14.679 μs | 0.0620 μs | 0.0580 μs | 1.16x slower |   0.01x | 12.8174 |  26,912 B |
|               LinqFaster |          4 |   100 |  2.737 μs | 0.0092 μs | 0.0086 μs | 4.61x faster |   0.02x |  0.0114 |      24 B |
|             LinqFasterer |          4 |   100 | 17.667 μs | 0.1957 μs | 0.1831 μs | 1.40x slower |   0.02x | 34.8816 |  73,168 B |
|                   LinqAF |          4 |   100 | 57.320 μs | 0.2905 μs | 0.2575 μs | 4.54x slower |   0.02x | 20.3247 |  42,504 B |
|               StructLinq |          4 |   100 | 12.373 μs | 0.0714 μs | 0.0633 μs | 1.02x faster |   0.00x |  0.0305 |      64 B |
| StructLinq_ValueDelegate |          4 |   100 |  5.184 μs | 0.0250 μs | 0.0234 μs | 2.43x faster |   0.02x |       - |         - |
|                Hyperlinq |          4 |   100 | 11.269 μs | 0.0532 μs | 0.0471 μs | 1.12x faster |   0.01x |       - |         - |
