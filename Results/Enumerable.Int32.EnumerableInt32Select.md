## Enumerable.Int32.EnumerableInt32Select

### Source
[EnumerableInt32Select.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Select.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta38](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta38)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                      Method | Count |         Mean |      Error |       StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |-------------:|-----------:|-------------:|------:|--------:|-------:|------:|------:|----------:|
|                 **ForeachLoop** |     **0** |     **14.77 ns** |   **0.156 ns** |     **0.138 ns** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                        Linq |     0 |     69.87 ns |   0.445 ns |     0.372 ns |  4.73 |    0.04 | 0.0459 |     - |     - |      96 B |
|                      LinqAF |     0 |     50.98 ns |   0.420 ns |     0.393 ns |  3.46 |    0.04 | 0.0191 |     - |     - |      40 B |
|                  StructLinq |     0 |     23.33 ns |   0.152 ns |     0.127 ns |  1.58 |    0.02 | 0.0306 |     - |     - |      64 B |
|        StructLinq_IFunction |     0 |     24.45 ns |   0.108 ns |     0.096 ns |  1.66 |    0.02 | 0.0191 |     - |     - |      40 B |
|           Hyperlinq_Foreach |     0 |     20.09 ns |   0.118 ns |     0.099 ns |  1.36 |    0.01 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_Foreach_IFunction |     0 |     24.58 ns |   0.104 ns |     0.092 ns |  1.66 |    0.02 | 0.0191 |     - |     - |      40 B |
|                             |       |              |            |              |       |         |        |       |       |           |
|                 **ForeachLoop** |    **10** |     **70.08 ns** |   **1.396 ns** |     **1.306 ns** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                        Linq |    10 |    221.52 ns |   2.781 ns |     2.465 ns |  3.16 |    0.08 | 0.0458 |     - |     - |      96 B |
|                      LinqAF |    10 |    193.62 ns |   3.785 ns |     5.780 ns |  2.79 |    0.11 | 0.0191 |     - |     - |      40 B |
|                  StructLinq |    10 |    117.76 ns |   2.310 ns |     2.661 ns |  1.68 |    0.05 | 0.0305 |     - |     - |      64 B |
|        StructLinq_IFunction |    10 |     74.75 ns |   1.430 ns |     1.404 ns |  1.07 |    0.03 | 0.0191 |     - |     - |      40 B |
|           Hyperlinq_Foreach |    10 |    117.01 ns |   2.334 ns |     3.348 ns |  1.67 |    0.06 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_Foreach_IFunction |    10 |     74.92 ns |   1.484 ns |     1.388 ns |  1.07 |    0.03 | 0.0191 |     - |     - |      40 B |
|                             |       |              |            |              |       |         |        |       |       |           |
|                 **ForeachLoop** |  **1000** |  **6,894.71 ns** | **136.063 ns** |   **287.004 ns** |  **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                        Linq |  1000 | 19,021.76 ns | 464.827 ns | 1,370.552 ns |  2.78 |    0.21 | 0.0305 |     - |     - |      96 B |
|                      LinqAF |  1000 | 14,834.36 ns | 295.066 ns |   846.600 ns |  2.16 |    0.17 | 0.0153 |     - |     - |      40 B |
|                  StructLinq |  1000 | 10,936.46 ns | 218.443 ns |   519.153 ns |  1.58 |    0.09 | 0.0305 |     - |     - |      64 B |
|        StructLinq_IFunction |  1000 |  6,962.09 ns | 139.194 ns |   302.595 ns |  1.01 |    0.06 | 0.0153 |     - |     - |      40 B |
|           Hyperlinq_Foreach |  1000 | 11,206.73 ns | 223.475 ns |   655.415 ns |  1.61 |    0.13 | 0.0153 |     - |     - |      40 B |
| Hyperlinq_Foreach_IFunction |  1000 |  7,271.06 ns | 144.911 ns |   253.800 ns |  1.05 |    0.06 | 0.0153 |     - |     - |      40 B |
