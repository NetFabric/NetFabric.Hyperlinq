## ArraySelect

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
|               Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |  59.15 ns | 0.458 ns | 0.383 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  44.85 ns | 0.580 ns | 0.514 ns |  0.76 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 603.63 ns | 5.361 ns | 5.014 ns | 10.21 |    0.10 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |   100 | 246.61 ns | 2.702 ns | 2.527 ns |  4.16 |    0.04 | 0.2027 |     - |     - |     424 B |
|           StructLinq |   100 | 248.46 ns | 2.355 ns | 2.203 ns |  4.20 |    0.04 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 157.51 ns | 1.109 ns | 1.037 ns |  2.66 |    0.03 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |   100 | 279.71 ns | 2.665 ns | 2.362 ns |  4.73 |    0.06 |      - |     - |     - |         - |
|        Hyperlinq_For |   100 | 452.18 ns | 3.805 ns | 3.177 ns |  7.65 |    0.09 |      - |     - |     - |         - |
