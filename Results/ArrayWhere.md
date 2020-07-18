## ArrayWhere

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
|              ForLoop |   100 |  68.01 ns | 0.904 ns | 0.845 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  65.01 ns | 0.690 ns | 0.645 ns |  0.96 |    0.02 |      - |     - |     - |         - |
|                 Linq |   100 | 450.86 ns | 4.082 ns | 3.619 ns |  6.64 |    0.11 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |   100 | 290.52 ns | 1.810 ns | 1.693 ns |  4.27 |    0.06 | 0.3095 |     - |     - |     648 B |
|           StructLinq |   100 | 348.69 ns | 3.187 ns | 2.825 ns |  5.13 |    0.08 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 163.48 ns | 1.052 ns | 0.984 ns |  2.40 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 335.44 ns | 2.534 ns | 2.371 ns |  4.93 |    0.08 |      - |     - |     - |         - |
