## List.Int32.ListInt32Select

### Source
[ListInt32Select.cs](../LinqBenchmarks/List/Int32/ListInt32Select.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta33](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta33)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                      Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                     ForLoop |   100 | 103.46 ns | 0.267 ns | 0.250 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop |   100 | 194.75 ns | 0.533 ns | 0.473 ns |  1.88 |    0.01 |      - |     - |     - |         - |
|                        Linq |   100 | 802.78 ns | 1.557 ns | 1.216 ns |  7.76 |    0.02 | 0.0343 |     - |     - |      72 B |
|                  LinqFaster |   100 | 406.13 ns | 1.289 ns | 1.206 ns |  3.93 |    0.01 | 0.2179 |     - |     - |     456 B |
|                      LinqAF |   100 | 712.90 ns | 1.149 ns | 1.019 ns |  6.89 |    0.02 |      - |     - |     - |         - |
|                  StructLinq |   100 | 214.29 ns | 0.496 ns | 0.440 ns |  2.07 |    0.01 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |   100 | 165.28 ns | 0.295 ns | 0.262 ns |  1.60 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |   100 | 191.06 ns | 0.294 ns | 0.246 ns |  1.85 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |   100 | 158.61 ns | 0.385 ns | 0.360 ns |  1.53 |    0.00 |      - |     - |     - |         - |
|               Hyperlinq_For |   100 | 192.29 ns | 0.427 ns | 0.378 ns |  1.86 |    0.01 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction |   100 |  88.61 ns | 0.218 ns | 0.194 ns |  0.86 |    0.00 |      - |     - |     - |         - |
