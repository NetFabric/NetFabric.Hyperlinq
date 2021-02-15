## List.Int32.ListInt32Select

### Source
[ListInt32Select.cs](../LinqBenchmarks/List/Int32/ListInt32Select.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta36](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta36)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                      Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                     ForLoop |   100 |   141.68 ns |  0.437 ns |  0.387 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop |   100 |   361.40 ns |  3.095 ns |  2.584 ns |  2.55 |    0.01 |      - |     - |     - |         - |
|                        Linq |   100 | 1,014.88 ns | 13.483 ns | 11.953 ns |  7.16 |    0.09 | 0.0343 |     - |     - |      72 B |
|                  LinqFaster |   100 |   514.32 ns |  5.822 ns |  5.161 ns |  3.63 |    0.03 | 0.2174 |     - |     - |     456 B |
|                      LinqAF |   100 |   940.86 ns |  3.875 ns |  3.236 ns |  6.64 |    0.03 |      - |     - |     - |         - |
|                  StructLinq |   100 |   251.53 ns |  4.314 ns |  4.035 ns |  1.78 |    0.03 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |   100 |   168.75 ns |  0.597 ns |  0.559 ns |  1.19 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |   100 |   195.89 ns |  2.050 ns |  1.711 ns |  1.38 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach |   100 |   162.89 ns |  0.557 ns |  0.494 ns |  1.15 |    0.01 |      - |     - |     - |         - |
|               Hyperlinq_For |   100 |   250.08 ns |  3.431 ns |  3.210 ns |  1.77 |    0.02 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For |   100 |    91.32 ns |  0.501 ns |  0.444 ns |  0.64 |    0.00 |      - |     - |     - |         - |
|              Hyperlinq_SIMD |   100 |   235.13 ns |  2.962 ns |  2.771 ns |  1.66 |    0.02 |      - |     - |     - |         - |
|    Hyperlinq_SIMD_IFunction |   100 |   170.83 ns |  0.574 ns |  0.509 ns |  1.21 |    0.01 |      - |     - |     - |         - |
