## ListWhere

- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.1.9](https://www.nuget.org/packages/StructLinq.BCL/0.1.9)
- NetFabric.Hyperlinq: [3.0.0-beta19](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta19)

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 125.7 ns | 0.69 ns | 0.61 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 248.1 ns | 1.51 ns | 1.34 ns |  1.97 |    0.02 |      - |     - |     - |         - |
|                 Linq |   100 | 652.6 ns | 6.12 ns | 5.42 ns |  5.19 |    0.04 | 0.0343 |     - |     - |      72 B |
|           LinqFaster |   100 | 408.0 ns | 2.27 ns | 2.01 ns |  3.25 |    0.01 | 0.3095 |     - |     - |     648 B |
|           StructLinq |   100 | 342.7 ns | 1.22 ns | 1.08 ns |  2.73 |    0.01 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 166.6 ns | 1.51 ns | 1.42 ns |  1.33 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 386.3 ns | 2.52 ns | 2.11 ns |  3.07 |    0.02 |      - |     - |     - |         - |
