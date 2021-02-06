## List.Int32.ListInt32Select

### Source
[ListInt32Select.cs](../LinqBenchmarks/List/Int32/ListInt32Select.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta32](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta32)

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
|                     ForLoop |   100 | 136.6 ns | 0.27 ns | 0.21 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop |   100 | 196.4 ns | 0.57 ns | 0.47 ns |  1.44 |    0.00 |      - |     - |     - |         - |
|                        Linq |   100 | 827.0 ns | 2.65 ns | 2.21 ns |  6.06 |    0.02 | 0.0343 |     - |     - |      72 B |
|                  LinqFaster |   100 | 405.7 ns | 1.34 ns | 1.12 ns |  2.97 |    0.01 | 0.2179 |     - |     - |     456 B |
|                      LinqAF |   100 | 753.5 ns | 2.07 ns | 1.93 ns |  5.51 |    0.02 |      - |     - |     - |         - |
|                  StructLinq |   100 | 215.1 ns | 0.46 ns | 0.38 ns |  1.57 |    0.00 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |   100 | 165.4 ns | 0.33 ns | 0.29 ns |  1.21 |    0.00 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |   100 | 192.2 ns | 0.34 ns | 0.30 ns |  1.41 |    0.00 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |   100 | 159.3 ns | 0.40 ns | 0.35 ns |  1.17 |    0.00 |      - |     - |     - |         - |
|               Hyperlinq_For |   100 | 218.5 ns | 0.63 ns | 0.56 ns |  1.60 |    0.00 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction |   100 | 110.9 ns | 0.31 ns | 0.28 ns |  0.81 |    0.00 |      - |     - |     - |         - |
