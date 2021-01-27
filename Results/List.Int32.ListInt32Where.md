## List.Int32.ListInt32Where

### Source
[ListInt32Where.cs](../LinqBenchmarks/List/Int32/ListInt32Where.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta27](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta27)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 122.6 ns | 0.31 ns | 0.28 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 247.3 ns | 1.24 ns | 1.16 ns |  2.02 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 656.7 ns | 2.33 ns | 2.18 ns |  5.36 |    0.02 | 0.0343 |     - |     - |      72 B |
|           LinqFaster |   100 | 429.3 ns | 1.34 ns | 1.19 ns |  3.50 |    0.01 | 0.3095 |     - |     - |     648 B |
|               LinqAF |   100 | 735.5 ns | 1.60 ns | 1.42 ns |  6.00 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 | 295.3 ns | 0.62 ns | 0.58 ns |  2.41 |    0.01 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |   100 | 169.2 ns | 0.50 ns | 0.44 ns |  1.38 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 296.2 ns | 1.18 ns | 0.99 ns |  2.42 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 | 184.1 ns | 0.27 ns | 0.21 ns |  1.50 |    0.00 |      - |     - |     - |         - |
