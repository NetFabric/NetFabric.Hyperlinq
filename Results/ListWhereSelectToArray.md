## ListWhereSelectToArray

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
|              ForLoop |   100 | 254.4 ns | 2.82 ns | 2.64 ns |  1.00 |    0.00 | 0.4168 |     - |     - |     872 B |
|          ForeachLoop |   100 | 395.5 ns | 4.87 ns | 4.55 ns |  1.56 |    0.02 | 0.4168 |     - |     - |     872 B |
|                 Linq |   100 | 567.0 ns | 7.12 ns | 6.66 ns |  2.23 |    0.03 | 0.3939 |     - |     - |     824 B |
|           LinqFaster |   100 | 467.4 ns | 4.29 ns | 4.02 ns |  1.84 |    0.02 | 0.4168 |     - |     - |     872 B |
|           StructLinq |   100 | 656.2 ns | 6.34 ns | 5.30 ns |  2.58 |    0.03 | 0.4396 |     - |     - |     920 B |
| StructLinq_IFunction |   100 | 340.3 ns | 3.63 ns | 3.39 ns |  1.34 |    0.02 | 0.4396 |     - |     - |     920 B |
|            Hyperlinq |   100 | 607.6 ns | 5.13 ns | 4.80 ns |  2.39 |    0.02 | 0.1068 |     - |     - |     224 B |
|       Hyperlinq_Pool |   100 | 653.8 ns | 6.26 ns | 5.85 ns |  2.57 |    0.04 | 0.0267 |     - |     - |      56 B |
