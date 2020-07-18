## ListWhereSelectToList

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
|              ForLoop |   100 | 230.9 ns | 1.33 ns | 1.11 ns |  1.00 |    0.00 | 0.3097 |     - |     - |     648 B |
|          ForeachLoop |   100 | 371.6 ns | 3.10 ns | 2.59 ns |  1.61 |    0.02 | 0.3095 |     - |     - |     648 B |
|                 Linq |   100 | 525.8 ns | 4.59 ns | 3.83 ns |  2.28 |    0.02 | 0.3824 |     - |     - |     800 B |
|           LinqFaster |   100 | 519.6 ns | 3.59 ns | 3.18 ns |  2.25 |    0.02 | 0.4320 |     - |     - |     904 B |
|           StructLinq |   100 | 671.3 ns | 4.04 ns | 3.58 ns |  2.91 |    0.02 | 0.3328 |     - |     - |     696 B |
| StructLinq_IFunction |   100 | 309.5 ns | 5.99 ns | 5.00 ns |  1.34 |    0.02 | 0.3328 |     - |     - |     696 B |
|            Hyperlinq |   100 | 671.3 ns | 6.07 ns | 5.68 ns |  2.90 |    0.03 | 0.1564 |     - |     - |     328 B |
