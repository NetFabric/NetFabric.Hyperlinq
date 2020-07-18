## ListWhereSelect

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
|               Method | Count |     Mean |   Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|--------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 106.6 ns | 0.53 ns |  0.49 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 248.5 ns | 1.49 ns |  1.40 ns |  2.33 |    0.02 |      - |     - |     - |         - |
|                 Linq |   100 | 777.2 ns | 4.41 ns |  3.91 ns |  7.29 |    0.05 | 0.0725 |     - |     - |     152 B |
|           LinqFaster |   100 | 519.2 ns | 3.97 ns |  3.10 ns |  4.87 |    0.03 | 0.3090 |     - |     - |     648 B |
|           StructLinq |   100 | 432.5 ns | 3.37 ns |  3.15 ns |  4.06 |    0.03 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 183.3 ns | 2.18 ns |  1.93 ns |  1.72 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 497.0 ns | 9.93 ns | 17.38 ns |  4.72 |    0.19 |      - |     - |     - |         - |
