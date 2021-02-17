## Array.ValueType.ArrayValueTypeSelect

### Source
[ArrayValueTypeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelect.cs)

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
|                      Method | Count |          Mean |       Error |      StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |--------------:|------------:|------------:|------:|--------:|--------:|------:|------:|----------:|
|                     **ForLoop** |     **0** |      **1.519 ns** |   **0.0096 ns** |   **0.0080 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |     0 |      1.917 ns |   0.0079 ns |   0.0070 ns |  1.26 |    0.01 |       - |     - |     - |         - |
|                        Linq |     0 |     21.069 ns |   0.0738 ns |   0.0616 ns | 13.87 |    0.08 |       - |     - |     - |         - |
|                  LinqFaster |     0 |      8.128 ns |   0.0340 ns |   0.0284 ns |  5.35 |    0.03 |  0.0115 |     - |     - |      24 B |
|                      LinqAF |     0 |     46.905 ns |   0.1469 ns |   0.1374 ns | 30.88 |    0.22 |       - |     - |     - |         - |
|                  StructLinq |     0 |     21.211 ns |   0.0607 ns |   0.0538 ns | 13.96 |    0.08 |  0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |     0 |     22.759 ns |   0.0638 ns |   0.0597 ns | 14.98 |    0.07 |       - |     - |     - |         - |
|           Hyperlinq_Foreach |     0 |     19.862 ns |   0.0500 ns |   0.0443 ns | 13.08 |    0.08 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |     0 |     18.599 ns |   0.0478 ns |   0.0447 ns | 12.24 |    0.07 |       - |     - |     - |         - |
|               Hyperlinq_For |     0 |     10.082 ns |   0.0219 ns |   0.0194 ns |  6.64 |    0.04 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction |     0 |      8.247 ns |   0.0244 ns |   0.0216 ns |  5.43 |    0.03 |       - |     - |     - |         - |
|                             |       |               |             |             |       |         |         |       |       |           |
|                     **ForLoop** |    **10** |    **151.838 ns** |   **0.1989 ns** |   **0.1661 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |    10 |    157.468 ns |   0.2319 ns |   0.2056 ns |  1.04 |    0.00 |       - |     - |     - |         - |
|                        Linq |    10 |    245.539 ns |   0.5266 ns |   0.4668 ns |  1.62 |    0.00 |  0.0381 |     - |     - |      80 B |
|                  LinqFaster |    10 |    202.809 ns |   0.6633 ns |   0.5880 ns |  1.34 |    0.00 |  0.2027 |     - |     - |     424 B |
|                      LinqAF |    10 |    298.935 ns |   0.9773 ns |   0.8663 ns |  1.97 |    0.01 |       - |     - |     - |         - |
|                  StructLinq |    10 |    200.009 ns |   0.6805 ns |   0.6032 ns |  1.32 |    0.00 |  0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |    10 |    177.292 ns |   0.3465 ns |   0.2893 ns |  1.17 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach |    10 |    188.457 ns |   0.3617 ns |   0.3020 ns |  1.24 |    0.00 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |    10 |    174.108 ns |   0.5598 ns |   0.4963 ns |  1.15 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For |    10 |    179.946 ns |   0.5107 ns |   0.4265 ns |  1.19 |    0.00 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction |    10 |    166.350 ns |   0.6204 ns |   0.5500 ns |  1.10 |    0.00 |       - |     - |     - |         - |
|                             |       |               |             |             |       |         |         |       |       |           |
|                     **ForLoop** |  **1000** | **15,158.400 ns** |  **22.9758 ns** |  **19.1859 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |  1000 | 15,736.366 ns |  45.3281 ns |  40.1822 ns |  1.04 |    0.00 |       - |     - |     - |         - |
|                        Linq |  1000 | 20,941.352 ns |  52.0555 ns |  46.1459 ns |  1.38 |    0.00 |  0.0305 |     - |     - |      80 B |
|                  LinqFaster |  1000 | 19,978.352 ns |  58.5927 ns |  51.9409 ns |  1.32 |    0.00 | 18.8599 |     - |     - |   40024 B |
|                      LinqAF |  1000 | 26,416.201 ns | 189.9905 ns | 148.3321 ns |  1.74 |    0.01 |       - |     - |     - |         - |
|                  StructLinq |  1000 | 17,824.317 ns |  40.5149 ns |  35.9154 ns |  1.18 |    0.00 |       - |     - |     - |      32 B |
|        StructLinq_IFunction |  1000 | 15,403.230 ns |  28.0238 ns |  23.4012 ns |  1.02 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach |  1000 | 17,200.496 ns |  52.4559 ns |  49.0673 ns |  1.13 |    0.00 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |  1000 | 15,487.643 ns |  46.4247 ns |  43.4257 ns |  1.02 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For |  1000 | 16,953.441 ns |  35.7716 ns |  31.7106 ns |  1.12 |    0.00 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction |  1000 | 15,222.810 ns |  31.4498 ns |  29.4181 ns |  1.00 |    0.00 |       - |     - |     - |         - |
