## List.Int32.ListInt32Where

### Source
[ListInt32Where.cs](../LinqBenchmarks/List/Int32/ListInt32Where.cs)

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
|               Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   104.4 ns |  0.26 ns |  0.22 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   469.9 ns |  9.38 ns | 23.53 ns |  4.41 |    0.21 |      - |     - |     - |         - |
|                 Linq |   100 | 1,246.6 ns | 24.96 ns | 72.80 ns | 11.93 |    0.81 | 0.0343 |     - |     - |      72 B |
|           LinqFaster |   100 |   549.7 ns |  7.65 ns |  7.16 ns |  5.28 |    0.06 | 0.3090 |     - |     - |     648 B |
|               LinqAF |   100 | 1,364.5 ns | 27.14 ns | 68.59 ns | 12.99 |    0.78 |      - |     - |     - |         - |
|           StructLinq |   100 |   545.0 ns | 11.09 ns | 32.70 ns |  5.24 |    0.35 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 |   171.1 ns |  0.51 ns |  0.45 ns |  1.64 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   544.3 ns | 13.19 ns | 38.67 ns |  5.20 |    0.33 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   187.0 ns |  0.60 ns |  0.54 ns |  1.79 |    0.01 |      - |     - |     - |         - |
