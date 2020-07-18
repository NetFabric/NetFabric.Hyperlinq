## RangeSelect

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
|              ForLoop |     0 |   100 |  38.65 ns | 0.717 ns | 0.636 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |     0 |   100 | 448.16 ns | 3.948 ns | 3.693 ns | 11.60 |    0.17 | 0.0267 |     - |     - |      56 B |
|                 Linq |     0 |   100 | 563.95 ns | 5.301 ns | 4.958 ns | 14.59 |    0.27 | 0.0420 |     - |     - |      88 B |
|           LinqFaster |     0 |   100 | 361.84 ns | 4.076 ns | 3.614 ns |  9.36 |    0.14 | 0.4053 |     - |     - |     848 B |
|           StructLinq |     0 |   100 | 228.59 ns | 1.575 ns | 1.473 ns |  5.92 |    0.10 |      - |     - |     - |         - |
| StructLinq_IFunction |     0 |   100 | 172.08 ns | 1.576 ns | 1.475 ns |  4.45 |    0.09 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |     0 |   100 | 326.88 ns | 4.293 ns | 3.806 ns |  8.46 |    0.16 |      - |     - |     - |         - |
|        Hyperlinq_For |     0 |   100 | 375.35 ns | 3.390 ns | 3.171 ns |  9.72 |    0.18 |      - |     - |     - |         - |
