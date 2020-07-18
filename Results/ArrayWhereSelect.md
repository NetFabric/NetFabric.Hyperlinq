## ArrayWhereSelect

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
|              ForLoop |   100 |  80.52 ns | 0.317 ns | 0.297 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  65.27 ns | 0.285 ns | 0.253 ns |  0.81 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 544.13 ns | 4.080 ns | 3.617 ns |  6.76 |    0.04 | 0.0496 |     - |     - |     104 B |
|           LinqFaster |   100 | 385.78 ns | 1.229 ns | 1.089 ns |  4.79 |    0.02 | 0.3095 |     - |     - |     648 B |
|           StructLinq |   100 | 424.77 ns | 4.626 ns | 4.101 ns |  5.28 |    0.05 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 184.38 ns | 1.230 ns | 1.090 ns |  2.29 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 437.96 ns | 1.610 ns | 1.428 ns |  5.44 |    0.03 |      - |     - |     - |         - |
