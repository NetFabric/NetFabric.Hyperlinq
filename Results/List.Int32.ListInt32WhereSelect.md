## List.Int32.ListInt32WhereSelect

### Source
[ListInt32WhereSelect.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelect.cs)

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
|              ForLoop |   100 |   104.5 ns |  0.35 ns |  0.31 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   473.4 ns | 12.00 ns | 35.19 ns |  4.51 |    0.29 |      - |     - |     - |         - |
|                 Linq |   100 | 1,235.6 ns | 24.24 ns | 34.76 ns | 11.83 |    0.33 | 0.0725 |     - |     - |     152 B |
|           LinqFaster |   100 |   643.6 ns | 11.17 ns | 10.45 ns |  6.16 |    0.11 | 0.3090 |     - |     - |     648 B |
|               LinqAF |   100 | 1,158.9 ns | 22.73 ns | 34.71 ns | 11.10 |    0.31 |      - |     - |     - |         - |
|           StructLinq |   100 |   746.5 ns | 14.94 ns | 42.86 ns |  6.97 |    0.55 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |   184.5 ns |  0.70 ns |  0.62 ns |  1.76 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   734.2 ns | 14.63 ns | 41.02 ns |  6.89 |    0.47 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   192.8 ns |  0.45 ns |  0.40 ns |  1.84 |    0.01 |      - |     - |     - |         - |
