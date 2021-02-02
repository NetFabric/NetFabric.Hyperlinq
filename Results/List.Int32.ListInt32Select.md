## List.Int32.ListInt32Select

### Source
[ListInt32Select.cs](../LinqBenchmarks/List/Int32/ListInt32Select.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta30](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta30)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                      Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|                     ForLoop |   100 | 104.2 ns | 0.19 ns | 0.17 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop |   100 | 294.5 ns | 0.74 ns | 0.66 ns |  2.83 |    0.01 |      - |     - |     - |         - |
|                        Linq |   100 | 815.5 ns | 3.62 ns | 3.02 ns |  7.83 |    0.03 | 0.0343 |     - |     - |      72 B |
|                  LinqFaster |   100 | 401.1 ns | 2.13 ns | 1.78 ns |  3.85 |    0.02 | 0.2179 |     - |     - |     456 B |
|                      LinqAF |   100 | 741.3 ns | 1.13 ns | 1.00 ns |  7.12 |    0.01 |      - |     - |     - |         - |
|                  StructLinq |   100 | 230.5 ns | 0.51 ns | 0.45 ns |  2.21 |    0.01 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |   100 | 166.0 ns | 0.28 ns | 0.24 ns |  1.59 |    0.00 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |   100 | 232.8 ns | 0.68 ns | 0.64 ns |  2.23 |    0.00 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |   100 | 171.8 ns | 0.24 ns | 0.22 ns |  1.65 |    0.00 |      - |     - |     - |         - |
|               Hyperlinq_For |   100 | 270.0 ns | 0.79 ns | 0.66 ns |  2.59 |    0.01 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction |   100 | 190.2 ns | 0.59 ns | 0.53 ns |  1.83 |    0.01 |      - |     - |     - |         - |
