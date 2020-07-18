## ArrayWhereSelectToList

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
|              ForLoop |   100 | 242.2 ns | 2.57 ns | 2.40 ns |  1.00 |    0.00 | 0.3095 |     - |     - |     648 B |
|          ForeachLoop |   100 | 219.0 ns | 2.07 ns | 1.94 ns |  0.90 |    0.01 | 0.3097 |     - |     - |     648 B |
|                 Linq |   100 | 492.5 ns | 8.34 ns | 7.39 ns |  2.03 |    0.04 | 0.3595 |     - |     - |     752 B |
|           LinqFaster |   100 | 364.2 ns | 3.63 ns | 3.39 ns |  1.50 |    0.02 | 0.4320 |     - |     - |     904 B |
|           StructLinq |   100 | 629.0 ns | 4.32 ns | 4.04 ns |  2.60 |    0.03 | 0.3328 |     - |     - |     696 B |
| StructLinq_IFunction |   100 | 309.2 ns | 3.50 ns | 3.10 ns |  1.28 |    0.02 | 0.3328 |     - |     - |     696 B |
|            Hyperlinq |   100 | 639.8 ns | 4.77 ns | 4.46 ns |  2.64 |    0.03 | 0.1564 |     - |     - |     328 B |
