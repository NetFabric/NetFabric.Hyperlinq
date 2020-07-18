## RangeToArray

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
|         Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------- |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|        ForLoop |     0 |   100 |  77.84 ns | 0.730 ns | 0.683 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|           Linq |     0 |   100 |  83.24 ns | 1.146 ns | 1.072 ns |  1.07 |    0.01 | 0.2218 |     - |     - |     464 B |
|     LinqFaster |     0 |   100 |  67.95 ns | 0.634 ns | 0.593 ns |  0.87 |    0.01 | 0.2027 |     - |     - |     424 B |
|     StructLinq |     0 |   100 | 315.61 ns | 4.507 ns | 3.995 ns |  4.05 |    0.07 | 0.7801 |     - |     - |    1632 B |
|      Hyperlinq |     0 |   100 |  85.29 ns | 0.772 ns | 0.722 ns |  1.10 |    0.01 | 0.2027 |     - |     - |     424 B |
| Hyperlinq_Pool |     0 |   100 | 116.23 ns | 1.436 ns | 1.344 ns |  1.49 |    0.02 | 0.0267 |     - |     - |      56 B |
