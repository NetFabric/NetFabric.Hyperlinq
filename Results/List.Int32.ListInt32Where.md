## List.Int32.ListInt32Where

### Source
[ListInt32Where.cs](../LinqBenchmarks/List/Int32/ListInt32Where.cs)

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
|               Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   104.3 ns |  0.16 ns |  0.13 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   508.4 ns | 10.19 ns | 29.56 ns |  4.85 |    0.33 |      - |     - |     - |         - |
|                 Linq |   100 | 1,237.2 ns | 24.69 ns | 64.18 ns | 11.81 |    0.52 | 0.0343 |     - |     - |      72 B |
|           LinqFaster |   100 |   550.1 ns |  6.19 ns |  5.79 ns |  5.27 |    0.06 | 0.3090 |     - |     - |     648 B |
|               LinqAF |   100 | 1,385.4 ns | 27.54 ns | 73.97 ns | 13.41 |    0.71 |      - |     - |     - |         - |
|           StructLinq |   100 |   555.5 ns | 12.83 ns | 37.83 ns |  5.23 |    0.41 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 |   170.5 ns |  0.53 ns |  0.47 ns |  1.63 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   482.1 ns | 10.89 ns | 31.94 ns |  4.52 |    0.37 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   185.5 ns |  0.44 ns |  0.37 ns |  1.78 |    0.00 |      - |     - |     - |         - |
