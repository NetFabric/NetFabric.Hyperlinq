## List.Int32.ListInt32Select

### Source
[ListInt32Select.cs](../LinqBenchmarks/List/Int32/ListInt32Select.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta34](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta34)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                      Method | Count |        Mean |     Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |------------:|----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                     ForLoop |   100 |   141.33 ns |  0.335 ns |   0.280 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop |   100 |   594.55 ns | 13.711 ns |  40.212 ns |  4.16 |    0.31 |      - |     - |     - |         - |
|                        Linq |   100 | 1,692.77 ns | 35.078 ns | 103.427 ns | 12.11 |    0.83 | 0.0343 |     - |     - |      72 B |
|                  LinqFaster |   100 |   525.36 ns |  6.573 ns |   5.826 ns |  3.72 |    0.04 | 0.2174 |     - |     - |     456 B |
|                      LinqAF |   100 | 1,477.04 ns | 29.333 ns |  73.590 ns | 10.37 |    0.69 |      - |     - |     - |         - |
|                  StructLinq |   100 |   458.98 ns | 11.598 ns |  34.196 ns |  3.27 |    0.25 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |   100 |   165.07 ns |  0.367 ns |   0.343 ns |  1.17 |    0.00 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |   100 |   461.89 ns | 19.823 ns |  58.138 ns |  3.36 |    0.46 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach |   100 |   163.45 ns |  0.532 ns |   0.444 ns |  1.16 |    0.00 |      - |     - |     - |         - |
|               Hyperlinq_For |   100 |   514.66 ns | 19.624 ns |  57.554 ns |  3.76 |    0.26 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For |   100 |    89.15 ns |  0.289 ns |   0.256 ns |  0.63 |    0.00 |      - |     - |     - |         - |
|              Hyperlinq_SIMD |   100 |   870.07 ns | 17.403 ns |  37.088 ns |  6.13 |    0.31 |      - |     - |     - |         - |
|    Hyperlinq_SIMD_IFunction |   100 |   869.32 ns | 17.317 ns |  46.223 ns |  6.12 |    0.27 |      - |     - |     - |         - |
