## Enumerable.Int32.EnumerableInt32WhereSelect

### Source
[EnumerableInt32WhereSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1517-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|          **ForeachLoop** |    **10** |    **60.12 ns** |  **0.395 ns** |  **0.308 ns** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq |    10 |   175.88 ns |  0.807 ns |  0.715 ns |  2.93 |    0.02 | 0.0763 |     - |     - |     160 B |
|               LinqAF |    10 |   141.24 ns |  0.325 ns |  0.304 ns |  2.35 |    0.01 | 0.0191 |     - |     - |      40 B |
|           StructLinq |    10 |   122.22 ns |  0.523 ns |  0.490 ns |  2.03 |    0.01 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |    10 |    83.06 ns |  0.174 ns |  0.136 ns |  1.38 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |    10 |   112.73 ns |  0.369 ns |  0.308 ns |  1.88 |    0.01 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |    10 |    76.84 ns |  0.184 ns |  0.163 ns |  1.28 |    0.01 | 0.0191 |     - |     - |      40 B |
|                      |       |             |           |           |       |         |        |       |       |           |
|          **ForeachLoop** |  **1000** | **4,490.89 ns** | **13.640 ns** | **12.092 ns** |  **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq |  1000 | 9,475.63 ns | 23.260 ns | 20.619 ns |  2.11 |    0.01 | 0.0763 |     - |     - |     160 B |
|               LinqAF |  1000 | 8,922.67 ns | 18.615 ns | 14.534 ns |  1.99 |    0.01 | 0.0153 |     - |     - |      40 B |
|           StructLinq |  1000 | 7,208.02 ns | 15.125 ns | 12.630 ns |  1.60 |    0.00 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |  1000 | 5,509.21 ns |  9.459 ns |  8.385 ns |  1.23 |    0.00 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq |  1000 | 8,177.74 ns | 29.647 ns | 27.732 ns |  1.82 |    0.01 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction |  1000 | 4,886.89 ns | 12.936 ns | 12.100 ns |  1.09 |    0.00 | 0.0153 |     - |     - |      40 B |
