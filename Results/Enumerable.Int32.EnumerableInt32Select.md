## Enumerable.Int32.EnumerableInt32Select

### Source
[EnumerableInt32Select.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Select.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta43](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta43)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                      Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                 **ForeachLoop** |    **10** |    **61.57 ns** |  **0.389 ns** |  **0.364 ns** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                        Linq |    10 |   165.16 ns |  0.580 ns |  0.514 ns |  2.68 |    0.02 | 0.0458 |     - |     - |      96 B |
|                      LinqAF |    10 |   131.22 ns |  0.564 ns |  0.527 ns |  2.13 |    0.02 | 0.0191 |     - |     - |      40 B |
|                  StructLinq |    10 |    96.71 ns |  0.341 ns |  0.285 ns |  1.57 |    0.01 | 0.0305 |     - |     - |      64 B |
|        StructLinq_IFunction |    10 |    68.25 ns |  0.310 ns |  0.275 ns |  1.11 |    0.01 | 0.0191 |     - |     - |      40 B |
|           Hyperlinq_Foreach |    10 |    86.13 ns |  0.292 ns |  0.244 ns |  1.40 |    0.01 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_Foreach_IFunction |    10 |    67.97 ns |  0.481 ns |  0.427 ns |  1.10 |    0.01 | 0.0191 |     - |     - |      40 B |
|                             |       |             |           |           |       |         |        |       |       |           |
|                 **ForeachLoop** |  **1000** | **4,026.19 ns** | **15.305 ns** | **11.949 ns** |  **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                        Linq |  1000 | 9,693.68 ns | 18.446 ns | 17.255 ns |  2.41 |    0.01 | 0.0458 |     - |     - |      96 B |
|                      LinqAF |  1000 | 8,446.91 ns | 25.748 ns | 22.825 ns |  2.10 |    0.01 | 0.0153 |     - |     - |      40 B |
|                  StructLinq |  1000 | 6,031.37 ns | 26.998 ns | 22.545 ns |  1.50 |    0.01 | 0.0305 |     - |     - |      64 B |
|        StructLinq_IFunction |  1000 | 4,828.92 ns | 15.784 ns | 13.992 ns |  1.20 |    0.00 | 0.0153 |     - |     - |      40 B |
|           Hyperlinq_Foreach |  1000 | 5,865.79 ns | 21.986 ns | 19.490 ns |  1.46 |    0.01 | 0.0153 |     - |     - |      40 B |
| Hyperlinq_Foreach_IFunction |  1000 | 4,837.70 ns | 25.704 ns | 24.044 ns |  1.20 |    0.01 | 0.0153 |     - |     - |      40 B |
