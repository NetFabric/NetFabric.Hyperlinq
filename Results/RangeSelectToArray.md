## RangeSelectToArray

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
|              ForLoop |     0 |   100 |  88.07 ns | 1.230 ns | 1.150 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                 Linq |     0 |   100 | 248.70 ns | 3.438 ns | 3.215 ns |  2.82 |    0.04 | 0.2446 |     - |     - |     512 B |
|           LinqFaster |     0 |   100 | 307.56 ns | 2.478 ns | 2.318 ns |  3.49 |    0.06 | 0.4053 |     - |     - |     848 B |
|           StructLinq |     0 |   100 | 539.96 ns | 4.990 ns | 4.668 ns |  6.13 |    0.10 | 0.7839 |     - |     - |    1640 B |
| StructLinq_IFunction |     0 |   100 | 361.16 ns | 2.934 ns | 2.450 ns |  4.11 |    0.07 | 0.7839 |     - |     - |    1640 B |
|            Hyperlinq |     0 |   100 | 233.38 ns | 2.536 ns | 2.118 ns |  2.65 |    0.04 | 0.2027 |     - |     - |     424 B |
|       Hyperlinq_Pool |     0 |   100 | 273.50 ns | 2.810 ns | 2.628 ns |  3.11 |    0.06 | 0.0267 |     - |     - |      56 B |
