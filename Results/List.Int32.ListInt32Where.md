## List.Int32.ListInt32Where

### Source
[ListInt32Where.cs](../LinqBenchmarks/List/Int32/ListInt32Where.cs)

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
|               Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 148.8 ns | 0.29 ns | 0.26 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 209.1 ns | 0.46 ns | 0.43 ns |  1.40 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 653.9 ns | 1.27 ns | 1.12 ns |  4.39 |    0.01 | 0.0343 |     - |     - |      72 B |
|           LinqFaster |   100 | 419.3 ns | 0.90 ns | 0.71 ns |  2.82 |    0.00 | 0.3095 |     - |     - |     648 B |
|               LinqAF |   100 | 721.2 ns | 1.69 ns | 1.50 ns |  4.85 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 | 290.0 ns | 0.45 ns | 0.40 ns |  1.95 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 | 170.3 ns | 0.42 ns | 0.39 ns |  1.14 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 300.8 ns | 1.00 ns | 0.94 ns |  2.02 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 | 199.8 ns | 0.46 ns | 0.41 ns |  1.34 |    0.00 |      - |     - |     - |         - |
