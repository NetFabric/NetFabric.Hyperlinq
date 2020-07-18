## ArraySkipTakeWhere

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
|      Method | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |----- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|     ForLoop | 1000 |   100 |    62.17 ns |  0.785 ns |  0.734 ns |  1.00 |    0.00 |      - |     - |     - |         - |
| ForeachLoop | 1000 |   100 | 2,689.34 ns | 34.787 ns | 30.838 ns | 43.24 |    0.66 | 0.0153 |     - |     - |      32 B |
|        Linq | 1000 |   100 | 1,324.30 ns | 16.581 ns | 15.510 ns | 21.30 |    0.33 | 0.0725 |     - |     - |     152 B |
|  LinqFaster | 1000 |   100 |   293.80 ns |  3.093 ns |  2.742 ns |  4.72 |    0.08 | 0.3095 |     - |     - |     648 B |
|   Hyperlinq | 1000 |   100 |   331.82 ns |  3.307 ns |  2.932 ns |  5.34 |    0.08 |      - |     - |     - |         - |
