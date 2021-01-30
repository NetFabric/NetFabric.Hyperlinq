## List.ValueType.ListValueTypeWhereSelect

### Source
[ListValueTypeWhereSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelect.cs)

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
|              ForLoop |   100 |   869.4 ns |  1.79 ns |  1.58 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 1,045.2 ns |  2.72 ns |  2.27 ns |  1.20 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 1,919.7 ns |  3.86 ns |  3.02 ns |  2.21 |    0.01 | 0.1335 |     - |     - |     280 B |
|           LinqFaster |   100 | 1,668.4 ns | 15.24 ns | 12.73 ns |  1.92 |    0.02 | 2.4433 |     - |     - |    5112 B |
|               LinqAF |   100 | 2,078.8 ns | 32.00 ns | 29.93 ns |  2.39 |    0.04 |      - |     - |     - |         - |
|           StructLinq |   100 | 1,122.6 ns |  3.15 ns |  2.79 ns |  1.29 |    0.00 | 0.0343 |     - |     - |      72 B |
| StructLinq_IFunction |   100 |   880.8 ns |  1.57 ns |  1.39 ns |  1.01 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 1,192.0 ns |  4.21 ns |  3.51 ns |  1.37 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   930.5 ns |  2.15 ns |  2.01 ns |  1.07 |    0.00 |      - |     - |     - |         - |
