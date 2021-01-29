## List.Int32.ListInt32Select

### Source
[ListInt32Select.cs](../LinqBenchmarks/List/Int32/ListInt32Select.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta28](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta28)

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
|                     ForLoop |   100 | 149.12 ns | 0.445 ns | 0.395 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop |   100 | 328.66 ns | 1.680 ns | 1.571 ns |  2.20 |    0.01 |      - |     - |     - |         - |
|                        Linq |   100 | 889.76 ns | 4.625 ns | 4.100 ns |  5.97 |    0.03 | 0.0343 |     - |     - |      72 B |
|                  LinqFaster |   100 | 443.72 ns | 1.984 ns | 1.856 ns |  2.98 |    0.02 | 0.2179 |     - |     - |     456 B |
|                      LinqAF |   100 | 820.98 ns | 5.098 ns | 4.519 ns |  5.51 |    0.03 |      - |     - |     - |         - |
|                  StructLinq |   100 | 237.06 ns | 0.995 ns | 0.882 ns |  1.59 |    0.01 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |   100 | 181.30 ns | 0.705 ns | 0.660 ns |  1.22 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |   100 | 190.84 ns | 1.096 ns | 0.972 ns |  1.28 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |   100 | 173.48 ns | 1.171 ns | 1.096 ns |  1.16 |    0.01 |      - |     - |     - |         - |
|               Hyperlinq_For |   100 | 274.89 ns | 1.071 ns | 1.002 ns |  1.84 |    0.01 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction |   100 |  97.31 ns | 0.362 ns | 0.302 ns |  0.65 |    0.00 |      - |     - |     - |         - |
