## ArrayWhereSelectToArray

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
|              ForLoop |   100 | 264.8 ns | 1.87 ns | 1.75 ns |  1.00 |    0.00 | 0.4168 |     - |     - |     872 B |
|          ForeachLoop |   100 | 231.6 ns | 1.51 ns | 1.41 ns |  0.87 |    0.01 | 0.4170 |     - |     - |     872 B |
|                 Linq |   100 | 567.6 ns | 4.05 ns | 3.59 ns |  2.14 |    0.02 | 0.3710 |     - |     - |     776 B |
|           LinqFaster |   100 | 358.1 ns | 1.61 ns | 1.43 ns |  1.35 |    0.01 | 0.3095 |     - |     - |     648 B |
|           StructLinq |   100 | 644.6 ns | 5.53 ns | 5.17 ns |  2.43 |    0.03 | 0.4396 |     - |     - |     920 B |
| StructLinq_IFunction |   100 | 332.0 ns | 6.66 ns | 6.23 ns |  1.25 |    0.03 | 0.4396 |     - |     - |     920 B |
|            Hyperlinq |   100 | 615.4 ns | 6.03 ns | 5.64 ns |  2.32 |    0.03 | 0.1068 |     - |     - |     224 B |
|       Hyperlinq_Pool |   100 | 670.0 ns | 6.82 ns | 6.38 ns |  2.53 |    0.03 | 0.0267 |     - |     - |      56 B |
