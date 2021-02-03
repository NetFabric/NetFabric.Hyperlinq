## List.Int32.ListInt32Where

### Source
[ListInt32Where.cs](../LinqBenchmarks/List/Int32/ListInt32Where.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta31](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta31)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   149.1 ns |  0.56 ns |  0.49 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   503.0 ns | 10.03 ns | 25.88 ns |  3.41 |    0.12 |      - |     - |     - |         - |
|                 Linq |   100 | 1,268.5 ns | 25.16 ns | 69.71 ns |  8.57 |    0.43 | 0.0343 |     - |     - |      72 B |
|           LinqFaster |   100 |   551.5 ns |  6.91 ns |  6.46 ns |  3.70 |    0.05 | 0.3090 |     - |     - |     648 B |
|               LinqAF |   100 | 1,437.2 ns | 27.61 ns | 63.44 ns |  9.70 |    0.38 |      - |     - |     - |         - |
|           StructLinq |   100 |   557.5 ns | 11.80 ns | 34.79 ns |  3.77 |    0.28 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 |   170.9 ns |  0.31 ns |  0.26 ns |  1.15 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   547.6 ns | 12.73 ns | 37.13 ns |  3.68 |    0.28 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   186.8 ns |  0.84 ns |  0.74 ns |  1.25 |    0.01 |      - |     - |     - |         - |
