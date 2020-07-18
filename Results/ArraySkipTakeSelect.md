## ArraySkipTakeSelect

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
|           ForLoop | 1000 |   100 |    53.98 ns |  0.874 ns |  0.817 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|       ForeachLoop | 1000 |   100 | 2,631.06 ns | 30.376 ns | 28.414 ns | 48.76 |    0.99 | 0.0153 |     - |     - |      32 B |
|              Linq | 1000 |   100 | 1,052.65 ns | 10.154 ns |  9.498 ns | 19.51 |    0.32 | 0.0725 |     - |     - |     152 B |
|        LinqFaster | 1000 |   100 |   274.75 ns |  2.412 ns |  2.256 ns |  5.09 |    0.09 | 0.2027 |     - |     - |     424 B |
| Hyperlinq_Foreach | 1000 |   100 |   261.94 ns |  3.756 ns |  2.932 ns |  4.84 |    0.10 |      - |     - |     - |         - |
|     Hyperlinq_For | 1000 |   100 |   464.56 ns |  3.476 ns |  3.252 ns |  8.61 |    0.16 |      - |     - |     - |         - |
