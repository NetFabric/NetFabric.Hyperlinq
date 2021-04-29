## Array.ValueType.ArrayValueTypeDistinct

### Source
[ArrayValueTypeDistinct.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeDistinct.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [](https://www.nuget.org/packages/LinqOptimizer.CSharp/)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Duplicates | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |----------- |------ |----------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |          4 |   100 | 12.840 μs | 0.0734 μs | 0.0687 μs |  1.00 |    0.00 | 12.8174 |     - |     - |  26,976 B |
|              ForeachLoop |          4 |   100 | 13.121 μs | 0.0468 μs | 0.0438 μs |  1.02 |    0.01 | 12.8174 |     - |     - |  26,976 B |
|                     Linq |          4 |   100 | 15.904 μs | 0.1100 μs | 0.0975 μs |  1.24 |    0.01 | 12.8174 |     - |     - |  26,848 B |
|             LinqFasterer |          4 |   100 | 16.552 μs | 0.2244 μs | 0.1874 μs |  1.29 |    0.02 | 22.5983 |     - |     - |  47,544 B |
|                   LinqAF |          4 |   100 | 77.910 μs | 0.5193 μs | 0.4857 μs |  6.07 |    0.05 | 19.8975 |     - |     - |  41,872 B |
|               StructLinq |          4 |   100 | 14.445 μs | 0.0615 μs | 0.0545 μs |  1.12 |    0.01 |  0.0153 |     - |     - |      56 B |
| StructLinq_ValueDelegate |          4 |   100 |  5.388 μs | 0.0235 μs | 0.0208 μs |  0.42 |    0.00 |       - |     - |     - |         - |
|                Hyperlinq |          4 |   100 | 13.242 μs | 0.0721 μs | 0.0639 μs |  1.03 |    0.01 |       - |     - |     - |         - |
