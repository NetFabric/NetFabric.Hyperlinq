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
|                  ForLoop |          4 |   100 | 12.818 μs | 0.0473 μs | 0.0419 μs |  1.00 |    0.00 | 12.8174 |     - |     - |  26,976 B |
|              ForeachLoop |          4 |   100 | 13.282 μs | 0.0619 μs | 0.0517 μs |  1.04 |    0.01 | 12.8174 |     - |     - |  26,976 B |
|                     Linq |          4 |   100 | 16.122 μs | 0.0872 μs | 0.0681 μs |  1.26 |    0.00 | 12.8174 |     - |     - |  26,848 B |
|             LinqFasterer |          4 |   100 | 15.382 μs | 0.0673 μs | 0.0597 μs |  1.20 |    0.01 | 22.5830 |     - |     - |  47,544 B |
|                   LinqAF |          4 |   100 | 85.283 μs | 0.2910 μs | 0.2722 μs |  6.66 |    0.03 | 19.8975 |     - |     - |  41,937 B |
|               StructLinq |          4 |   100 | 14.797 μs | 0.0593 μs | 0.0555 μs |  1.15 |    0.01 |  0.0153 |     - |     - |      56 B |
| StructLinq_ValueDelegate |          4 |   100 |  5.011 μs | 0.0334 μs | 0.0313 μs |  0.39 |    0.00 |       - |     - |     - |         - |
|                Hyperlinq |          4 |   100 | 13.429 μs | 0.0735 μs | 0.0652 μs |  1.05 |    0.01 |       - |     - |     - |         - |
