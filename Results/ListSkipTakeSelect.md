## ListSkipTakeSelect

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
|            Method | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------ |----- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|           ForLoop | 1000 |   100 |    84.21 ns |  0.498 ns |  0.416 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|       ForeachLoop | 1000 |   100 | 3,459.24 ns | 16.946 ns | 14.151 ns | 41.08 |    0.28 | 0.0191 |     - |     - |      40 B |
|              Linq | 1000 |   100 |   901.67 ns |  9.918 ns |  9.277 ns | 10.70 |    0.13 | 0.0725 |     - |     - |     152 B |
| Hyperlinq_Foreach | 1000 |   100 |   241.81 ns |  2.640 ns |  2.340 ns |  2.87 |    0.03 |      - |     - |     - |         - |
|     Hyperlinq_For | 1000 |   100 |   465.00 ns |  3.662 ns |  3.425 ns |  5.52 |    0.04 |      - |     - |     - |         - |
