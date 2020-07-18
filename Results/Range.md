## Range

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
|               Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |     0 |   100 |  33.96 ns | 0.423 ns | 0.396 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |     0 |   100 | 452.69 ns | 4.725 ns | 4.188 ns | 13.33 |    0.20 | 0.0267 |     - |     - |      56 B |
|                 Linq |     0 |   100 | 398.06 ns | 2.015 ns | 1.885 ns | 11.72 |    0.11 | 0.0191 |     - |     - |      40 B |
|           LinqFaster |     0 |   100 | 135.95 ns | 1.341 ns | 1.254 ns |  4.00 |    0.05 | 0.2027 |     - |     - |     424 B |
|           StructLinq |     0 |   100 |  40.13 ns | 0.372 ns | 0.330 ns |  1.18 |    0.02 |      - |     - |     - |         - |
| StructLinq_IFunction |     0 |   100 |  40.51 ns | 0.554 ns | 0.518 ns |  1.19 |    0.02 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |     0 |   100 | 171.16 ns | 1.843 ns | 1.724 ns |  5.04 |    0.06 |      - |     - |     - |         - |
|        Hyperlinq_For |     0 |   100 |  62.90 ns | 0.539 ns | 0.504 ns |  1.85 |    0.02 |      - |     - |     - |         - |
