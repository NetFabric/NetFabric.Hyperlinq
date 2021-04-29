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
|                   Method | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 |  Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |----------:|----------:|----------:|------:|--------:|--------:|-------:|------:|----------:|
|                  ForLoop |   100 |  1.229 μs | 0.0085 μs | 0.0071 μs |  1.00 |    0.00 |  3.8605 |      - |     - |      8 KB |
|              ForeachLoop |   100 |  1.344 μs | 0.0241 μs | 0.0201 μs |  1.09 |    0.01 |  3.8605 |      - |     - |      8 KB |
|                     Linq |   100 |  1.634 μs | 0.0181 μs | 0.0169 μs |  1.33 |    0.02 |  3.9673 |      - |     - |      8 KB |
|               LinqFaster |   100 |  1.621 μs | 0.0301 μs | 0.0282 μs |  1.32 |    0.02 |  6.4087 |      - |     - |     13 KB |
|             LinqFasterer |   100 |  2.932 μs | 0.0202 μs | 0.0179 μs |  2.39 |    0.02 |  9.0332 |      - |     - |     18 KB |
|                   LinqAF |   100 |  2.674 μs | 0.0534 μs | 0.0572 μs |  2.18 |    0.05 |  3.8605 |      - |     - |      8 KB |
|            LinqOptimizer |   100 | 54.592 μs | 0.3966 μs | 0.3311 μs | 44.44 |    0.34 | 71.8994 | 6.7749 |     - |    157 KB |
|                  Streams |   100 |  6.982 μs | 0.0277 μs | 0.0246 μs |  5.69 |    0.03 |  4.1199 |      - |     - |      8 KB |
|               StructLinq |   100 |  1.424 μs | 0.0143 μs | 0.0127 μs |  1.16 |    0.01 |  1.7223 |      - |     - |      4 KB |
| StructLinq_ValueDelegate |   100 |  1.212 μs | 0.0076 μs | 0.0059 μs |  0.99 |    0.01 |  1.6766 |      - |     - |      3 KB |
|                Hyperlinq |   100 |  2.297 μs | 0.0149 μs | 0.0139 μs |  1.87 |    0.02 |  1.6766 |      - |     - |      3 KB |
|  Hyperlinq_ValueDelegate |   100 |  1.568 μs | 0.0318 μs | 0.0880 μs |  1.32 |    0.11 |  1.6766 |      - |     - |      3 KB |
