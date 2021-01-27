## List.Int32.ListInt32WhereSelect

### Source
[ListInt32WhereSelect.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelect.cs)

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
|              ForLoop |   100 | 122.0 ns | 0.49 ns | 0.43 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 209.2 ns | 0.50 ns | 0.41 ns |  1.72 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 779.9 ns | 2.29 ns | 1.91 ns |  6.40 |    0.03 | 0.0725 |     - |     - |     152 B |
|           LinqFaster |   100 | 505.9 ns | 1.76 ns | 1.47 ns |  4.15 |    0.02 | 0.3090 |     - |     - |     648 B |
|               LinqAF |   100 | 779.4 ns | 1.31 ns | 1.02 ns |  6.39 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 | 372.4 ns | 1.03 ns | 0.86 ns |  3.05 |    0.01 | 0.0343 |     - |     - |      72 B |
| StructLinq_IFunction |   100 | 185.5 ns | 0.50 ns | 0.46 ns |  1.52 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 335.4 ns | 0.90 ns | 0.79 ns |  2.75 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 | 191.9 ns | 0.53 ns | 0.50 ns |  1.57 |    0.01 |      - |     - |     - |         - |
