## Array.ValueType.ArrayValueTypeWhereSelectToArray

### Source
[ArrayValueTypeWhereSelectToArray.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToArray.cs)

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

BenchmarkDotNet=v0.13.0, OS=macOS Catalina 10.15.7 (19H1323) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |      Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |----------:|----------:|----------:|--------------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |  1.486 μs | 0.0046 μs | 0.0041 μs |      baseline |         |  5.5237 |     - |     - |     11 KB |
|              ForeachLoop |   100 |  1.621 μs | 0.0049 μs | 0.0046 μs |  1.09x slower |   0.01x |  5.5237 |     - |     - |     11 KB |
|                     Linq |   100 |  1.837 μs | 0.0059 μs | 0.0053 μs |  1.24x slower |   0.01x |  3.9291 |     - |     - |      8 KB |
|               LinqFaster |   100 |  1.534 μs | 0.0029 μs | 0.0026 μs |  1.03x slower |   0.00x |  4.7264 |     - |     - |     10 KB |
|             LinqFasterer |   100 |  2.597 μs | 0.0504 μs | 0.0706 μs |  1.77x slower |   0.06x |  6.0043 |     - |     - |     12 KB |
|                   LinqAF |   100 |  2.880 μs | 0.0154 μs | 0.0136 μs |  1.94x slower |   0.01x |  5.5122 |     - |     - |     11 KB |
|            LinqOptimizer |   100 | 57.580 μs | 0.2093 μs | 0.1855 μs | 38.76x slower |   0.16x | 74.0356 |     - |     - |    153 KB |
|                 SpanLinq |   100 |  2.358 μs | 0.0075 μs | 0.0063 μs |  1.59x slower |   0.01x |  5.5237 |     - |     - |     11 KB |
|                  Streams |   100 |  2.604 μs | 0.0168 μs | 0.0157 μs |  1.75x slower |   0.01x |  5.7716 |     - |     - |     12 KB |
|               StructLinq |   100 |  1.566 μs | 0.0028 μs | 0.0026 μs |  1.05x slower |   0.00x |  1.7052 |     - |     - |      3 KB |
| StructLinq_ValueDelegate |   100 |  1.084 μs | 0.0020 μs | 0.0018 μs |  1.37x faster |   0.00x |  1.6575 |     - |     - |      3 KB |
|                Hyperlinq |   100 |  1.844 μs | 0.0026 μs | 0.0023 μs |  1.24x slower |   0.00x |  1.6632 |     - |     - |      3 KB |
|  Hyperlinq_ValueDelegate |   100 |  1.426 μs | 0.0031 μs | 0.0029 μs |  1.04x faster |   0.00x |  1.6632 |     - |     - |      3 KB |
