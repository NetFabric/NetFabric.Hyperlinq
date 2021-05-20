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

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19043.985 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Duplicates | Count |      Mean |     Error |    StdDev |    Median |        Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |----------- |------ |----------:|----------:|----------:|----------:|-------------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |          4 |   100 | 13.532 μs | 0.0649 μs | 0.0507 μs | 13.540 μs |     baseline |         | 12.8174 |     - |     - |  26,976 B |
|              ForeachLoop |          4 |   100 | 14.807 μs | 0.2905 μs | 0.7288 μs | 14.406 μs | 1.13x slower |   0.06x | 12.8174 |     - |     - |  26,976 B |
|                     Linq |          4 |   100 | 20.349 μs | 0.5389 μs | 1.4007 μs | 20.947 μs | 1.28x slower |   0.04x | 12.8174 |     - |     - |  26,848 B |
|             LinqFasterer |          4 |   100 | 18.495 μs | 0.2478 μs | 0.2318 μs | 18.481 μs | 1.37x slower |   0.02x | 22.5830 |     - |     - |  47,544 B |
|                   LinqAF |          4 |   100 | 84.666 μs | 0.6147 μs | 0.5449 μs | 84.656 μs | 6.25x slower |   0.05x | 19.8975 |     - |     - |  41,874 B |
|               StructLinq |          4 |   100 | 15.544 μs | 0.1173 μs | 0.1097 μs | 15.520 μs | 1.15x slower |   0.01x |       - |     - |     - |      56 B |
| StructLinq_ValueDelegate |          4 |   100 |  5.171 μs | 0.0416 μs | 0.0369 μs |  5.180 μs | 2.62x faster |   0.02x |       - |     - |     - |         - |
|                Hyperlinq |          4 |   100 | 22.494 μs | 0.0789 μs | 0.0738 μs | 22.472 μs | 1.66x slower |   0.01x |       - |     - |     - |         - |
