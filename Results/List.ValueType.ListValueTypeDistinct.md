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
|                   Method | Duplicates | Count |      Mean |     Error |    StdDev |    Median |        Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |----------- |------ |----------:|----------:|----------:|----------:|-------------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |          4 |   100 | 15.737 μs | 0.3142 μs | 0.9263 μs | 15.200 μs |     baseline |         | 12.8174 |     - |     - |  26,976 B |
|              ForeachLoop |          4 |   100 | 15.201 μs | 0.1339 μs | 0.1187 μs | 15.182 μs | 1.02x faster |   0.06x | 12.8174 |     - |     - |  26,976 B |
|                     Linq |          4 |   100 | 20.457 μs | 0.3444 μs | 0.3221 μs | 20.365 μs | 1.32x slower |   0.07x | 12.8174 |     - |     - |  26,912 B |
|               LinqFaster |          4 |   100 |  3.612 μs | 0.0479 μs | 0.0448 μs |  3.634 μs | 4.30x faster |   0.22x |  0.0114 |     - |     - |      24 B |
|             LinqFasterer |          4 |   100 | 18.086 μs | 0.3244 μs | 0.2709 μs | 18.001 μs | 1.18x slower |   0.06x | 34.8816 |     - |     - |  73,168 B |
|                   LinqAF |          4 |   100 | 68.328 μs | 0.3934 μs | 0.3680 μs | 68.431 μs | 4.41x slower |   0.26x | 20.2637 |     - |     - |  42,504 B |
|               StructLinq |          4 |   100 | 15.386 μs | 0.0759 μs | 0.0673 μs | 15.384 μs | 1.01x faster |   0.06x |  0.0305 |     - |     - |      64 B |
| StructLinq_ValueDelegate |          4 |   100 |  5.229 μs | 0.0499 μs | 0.0416 μs |  5.229 μs | 2.94x faster |   0.16x |       - |     - |     - |         - |
|                Hyperlinq |          4 |   100 | 14.186 μs | 0.0807 μs | 0.0716 μs | 14.194 μs | 1.09x faster |   0.06x |       - |     - |     - |         - |
