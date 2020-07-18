## RangeSelectToList

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
|               Method | Start | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |     0 |   100 | 286.8 ns | 4.42 ns | 3.92 ns |  1.00 |    0.00 | 0.5660 |     - |     - |    1184 B |
|          ForeachLoop |     0 |   100 | 718.3 ns | 7.81 ns | 7.30 ns |  2.50 |    0.04 | 0.5922 |     - |     - |    1240 B |
|                 Linq |     0 |   100 | 359.6 ns | 3.81 ns | 3.57 ns |  1.25 |    0.02 | 0.2599 |     - |     - |     544 B |
|           LinqFaster |     0 |   100 | 336.0 ns | 2.67 ns | 2.50 ns |  1.17 |    0.01 | 0.6232 |     - |     - |    1304 B |
|           StructLinq |     0 |   100 | 480.1 ns | 3.18 ns | 2.65 ns |  1.67 |    0.02 | 0.5813 |     - |     - |    1216 B |
| StructLinq_IFunction |     0 |   100 | 327.2 ns | 5.66 ns | 5.01 ns |  1.14 |    0.02 | 0.5813 |     - |     - |    1216 B |
|            Hyperlinq |     0 |   100 | 287.8 ns | 2.48 ns | 2.32 ns |  1.00 |    0.02 | 0.2446 |     - |     - |     512 B |
