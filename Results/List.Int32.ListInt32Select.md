## List.Int32.ListInt32Select

### Source
[ListInt32Select.cs](../LinqBenchmarks/List/Int32/ListInt32Select.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta29](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta29)

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
|                     ForLoop |   100 | 136.79 ns | 0.445 ns | 0.394 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop |   100 | 244.77 ns | 0.950 ns | 0.793 ns |  1.79 |    0.01 |      - |     - |     - |         - |
|                        Linq |   100 | 831.75 ns | 2.538 ns | 2.119 ns |  6.08 |    0.02 | 0.0343 |     - |     - |      72 B |
|                  LinqFaster |   100 | 403.93 ns | 1.332 ns | 1.246 ns |  2.95 |    0.01 | 0.2179 |     - |     - |     456 B |
|                      LinqAF |   100 | 755.17 ns | 2.694 ns | 2.388 ns |  5.52 |    0.02 |      - |     - |     - |         - |
|                  StructLinq |   100 | 230.46 ns | 0.460 ns | 0.408 ns |  1.68 |    0.01 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |   100 | 166.36 ns | 0.273 ns | 0.255 ns |  1.22 |    0.00 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |   100 | 190.62 ns | 0.562 ns | 0.498 ns |  1.39 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |   100 | 160.50 ns | 0.256 ns | 0.227 ns |  1.17 |    0.00 |      - |     - |     - |         - |
|               Hyperlinq_For |   100 | 248.88 ns | 1.032 ns | 0.915 ns |  1.82 |    0.01 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction |   100 |  88.50 ns | 0.203 ns | 0.190 ns |  0.65 |    0.00 |      - |     - |     - |         - |
