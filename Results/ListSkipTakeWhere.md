## ListSkipTakeWhere

### Source
[ListSkipTakeWhere.cs](../LinqBenchmarks/ListSkipTakeWhere.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.1.9](https://www.nuget.org/packages/StructLinq.BCL/0.1.9)
- NetFabric.Hyperlinq: [3.0.0-beta19](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta19)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|      Method | Skip | Count |        Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |----- |------ |------------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|     ForLoop | 1000 |   100 |    82.69 ns | 0.391 ns | 0.346 ns |  1.00 |    0.00 |      - |     - |     - |         - |
| ForeachLoop | 1000 |   100 | 3,686.52 ns | 9.343 ns | 7.802 ns | 44.58 |    0.20 | 0.0191 |     - |     - |      40 B |
|        Linq | 1000 |   100 | 1,193.11 ns | 2.573 ns | 2.407 ns | 14.43 |    0.06 | 0.0725 |     - |     - |     152 B |
|   Hyperlinq | 1000 |   100 |   363.21 ns | 1.131 ns | 1.003 ns |  4.39 |    0.02 |      - |     - |     - |         - |
