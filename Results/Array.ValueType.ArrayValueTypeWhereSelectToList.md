## Array.ValueType.ArrayValueTypeWhereSelectToList

### Source
[ArrayValueTypeWhereSelectToList.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToList.cs)

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
|                   Method | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |   Gen 0 |  Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |----------:|----------:|----------:|----------:|------:|--------:|--------:|-------:|------:|----------:|
|                  ForLoop |   100 |  1.215 μs | 0.0242 μs | 0.0249 μs |  1.216 μs |  1.00 |    0.00 |  3.8605 |      - |     - |      8 KB |
|              ForeachLoop |   100 |  1.372 μs | 0.0256 μs | 0.0731 μs |  1.338 μs |  1.18 |    0.07 |  3.8605 |      - |     - |      8 KB |
|                     Linq |   100 |  1.665 μs | 0.0341 μs | 0.1005 μs |  1.614 μs |  1.42 |    0.09 |  3.9673 |      - |     - |      8 KB |
|               LinqFaster |   100 |  1.654 μs | 0.0231 μs | 0.0216 μs |  1.654 μs |  1.36 |    0.03 |  6.4087 |      - |     - |     13 KB |
|             LinqFasterer |   100 |  3.424 μs | 0.0607 μs | 0.0945 μs |  3.396 μs |  2.84 |    0.10 |  9.0332 |      - |     - |     18 KB |
|                   LinqAF |   100 |  2.549 μs | 0.0484 μs | 0.0538 μs |  2.545 μs |  2.10 |    0.06 |  3.8605 |      - |     - |      8 KB |
|            LinqOptimizer |   100 | 66.503 μs | 1.0794 μs | 0.9569 μs | 66.714 μs | 54.57 |    1.28 | 71.5942 | 6.9580 |     - |    157 KB |
|                  Streams |   100 |  7.108 μs | 0.0336 μs | 0.0298 μs |  7.106 μs |  5.83 |    0.11 |  4.1199 |      - |     - |      8 KB |
|               StructLinq |   100 |  1.428 μs | 0.0071 μs | 0.0063 μs |  1.429 μs |  1.17 |    0.02 |  1.7223 |      - |     - |      4 KB |
| StructLinq_ValueDelegate |   100 |  1.260 μs | 0.0253 μs | 0.0700 μs |  1.219 μs |  1.05 |    0.08 |  1.6766 |      - |     - |      3 KB |
|                Hyperlinq |   100 |  1.820 μs | 0.0363 μs | 0.1035 μs |  1.766 μs |  1.58 |    0.07 |  1.6766 |      - |     - |      3 KB |
|  Hyperlinq_ValueDelegate |   100 |  1.453 μs | 0.0290 μs | 0.0851 μs |  1.402 μs |  1.26 |    0.06 |  1.6766 |      - |     - |      3 KB |
