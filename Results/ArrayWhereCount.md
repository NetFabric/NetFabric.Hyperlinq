## ArrayWhereCount

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
|              ForLoop |   100 |  79.48 ns | 0.851 ns | 0.796 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  65.40 ns | 0.522 ns | 0.436 ns |  0.82 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 608.05 ns | 3.071 ns | 2.723 ns |  7.65 |    0.09 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 | 232.58 ns | 1.334 ns | 1.247 ns |  2.93 |    0.03 |      - |     - |     - |         - |
|           StructLinq |   100 | 311.94 ns | 1.099 ns | 0.974 ns |  3.93 |    0.04 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |   100 | 164.39 ns | 1.090 ns | 1.020 ns |  2.07 |    0.03 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 | 171.98 ns | 1.138 ns | 1.009 ns |  2.16 |    0.02 |      - |     - |     - |         - |
