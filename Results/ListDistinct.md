## ListDistinct

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
|      Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|     ForLoop |   100 | 1,466.9 ns | 15.64 ns | 13.86 ns |  1.00 |    0.00 | 2.8706 |     - |     - |    6008 B |
| ForeachLoop |   100 | 1,605.6 ns | 23.23 ns | 18.13 ns |  1.10 |    0.01 | 2.8706 |     - |     - |    6008 B |
|        Linq |   100 | 2,788.9 ns | 23.11 ns | 21.62 ns |  1.90 |    0.02 | 2.0638 |     - |     - |    4320 B |
|  LinqFaster |   100 |   666.8 ns |  7.26 ns |  6.79 ns |  0.45 |    0.01 |      - |     - |     - |         - |
|  StructLinq |   100 | 1,972.6 ns | 22.73 ns | 21.26 ns |  1.34 |    0.02 |      - |     - |     - |         - |
|   Hyperlinq |   100 | 1,919.6 ns | 25.12 ns | 23.50 ns |  1.31 |    0.02 |      - |     - |     - |         - |
