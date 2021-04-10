## Enumerable.Int32.EnumerableInt32Sum

### Source
[EnumerableInt32Sum.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Sum.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Count |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|----------:|----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|          **ForeachLoop** |    **10** |    **56.94 ns** |  **0.208 ns** |  **0.162 ns** |    **56.95 ns** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq |    10 |    64.76 ns |  0.282 ns |  0.250 ns |    64.75 ns |  1.14 |    0.00 | 0.0191 |     - |     - |      40 B |
|               LinqAF |    10 |    80.01 ns |  0.460 ns |  0.408 ns |    79.91 ns |  1.40 |    0.01 | 0.0191 |     - |     - |      40 B |
|           StructLinq |    10 |    76.32 ns |  0.421 ns |  0.373 ns |    76.47 ns |  1.34 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |    64.26 ns |  1.309 ns |  1.918 ns |    65.46 ns |  1.09 |    0.02 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |    10 |    61.97 ns |  1.180 ns |  1.358 ns |    61.47 ns |  1.09 |    0.03 | 0.0191 |     - |     - |      40 B |
|                      |       |             |           |           |             |       |         |        |       |       |           |
|          **ForeachLoop** |  **1000** | **4,047.84 ns** | **17.901 ns** | **15.869 ns** | **4,045.50 ns** |  **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq |  1000 | 4,384.41 ns | 33.608 ns | 29.793 ns | 4,394.17 ns |  1.08 |    0.01 | 0.0153 |     - |     - |      40 B |
|               LinqAF |  1000 | 4,900.81 ns | 17.837 ns | 16.685 ns | 4,904.05 ns |  1.21 |    0.01 | 0.0153 |     - |     - |      40 B |
|           StructLinq |  1000 | 4,912.53 ns | 17.670 ns | 16.529 ns | 4,913.63 ns |  1.21 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 | 4,829.85 ns | 29.861 ns | 24.935 ns | 4,822.68 ns |  1.19 |    0.00 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq |  1000 | 4,574.61 ns | 17.480 ns | 16.351 ns | 4,570.98 ns |  1.13 |    0.00 | 0.0153 |     - |     - |      40 B |
