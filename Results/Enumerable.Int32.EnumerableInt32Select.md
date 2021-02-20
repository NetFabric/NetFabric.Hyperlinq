## Enumerable.Int32.EnumerableInt32Select

### Source
[EnumerableInt32Select.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Select.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta39](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta39)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=6.0.100-preview.1.21103.13
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                      Method | Count |         Mean |      Error |       StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |-------------:|-----------:|-------------:|------:|--------:|-------:|------:|------:|----------:|
|                 **ForeachLoop** |    **10** |     **60.52 ns** |   **0.220 ns** |     **0.183 ns** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                        Linq |    10 |    223.63 ns |   4.371 ns |     4.089 ns |  3.69 |    0.07 | 0.0458 |     - |     - |      96 B |
|                      LinqAF |    10 |    206.33 ns |   4.022 ns |     7.456 ns |  3.38 |    0.07 | 0.0191 |     - |     - |      40 B |
|                  StructLinq |    10 |    100.77 ns |   0.312 ns |     0.244 ns |  1.66 |    0.01 | 0.0305 |     - |     - |      64 B |
|        StructLinq_IFunction |    10 |     65.45 ns |   0.414 ns |     0.323 ns |  1.08 |    0.01 | 0.0191 |     - |     - |      40 B |
|           Hyperlinq_Foreach |    10 |     93.37 ns |   0.176 ns |     0.156 ns |  1.54 |    0.01 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_Foreach_IFunction |    10 |     66.92 ns |   0.219 ns |     0.194 ns |  1.11 |    0.01 | 0.0191 |     - |     - |      40 B |
|                             |       |              |            |              |       |         |        |       |       |           |
|                 **ForeachLoop** |  **1000** |  **4,179.85 ns** |  **10.780 ns** |     **9.556 ns** |  **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                        Linq |  1000 | 19,686.14 ns | 400.342 ns | 1,180.416 ns |  4.69 |    0.34 | 0.0305 |     - |     - |      96 B |
|                      LinqAF |  1000 | 16,592.17 ns | 331.793 ns |   862.374 ns |  3.98 |    0.19 | 0.0153 |     - |     - |      40 B |
|                  StructLinq |  1000 |  6,629.03 ns |  21.199 ns |    18.792 ns |  1.59 |    0.01 | 0.0305 |     - |     - |      64 B |
|        StructLinq_IFunction |  1000 |  4,375.70 ns |  14.715 ns |    13.044 ns |  1.05 |    0.00 | 0.0153 |     - |     - |      40 B |
|           Hyperlinq_Foreach |  1000 |  6,569.65 ns |  17.540 ns |    16.407 ns |  1.57 |    0.01 | 0.0153 |     - |     - |      40 B |
| Hyperlinq_Foreach_IFunction |  1000 |  4,429.16 ns |  11.159 ns |     9.892 ns |  1.06 |    0.00 | 0.0153 |     - |     - |      40 B |
