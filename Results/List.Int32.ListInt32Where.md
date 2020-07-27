## List.Int32.ListInt32Where

### Source
[ListInt32Where.cs](../LinqBenchmarks/List/Int32/ListInt32Where.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta20](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta20)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |   100 | 106.8 ns | 1.07 ns | 1.00 ns |  1.00 |    0.00 |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop |   100 | 212.3 ns | 1.85 ns | 1.64 ns |  1.99 |    0.03 |      - |     - |     - |         - |              0 |                       0 |
|                 Linq |   100 | 633.8 ns | 4.35 ns | 4.07 ns |  5.94 |    0.07 | 0.0343 |     - |     - |      72 B |              1 |                       0 |
|           LinqFaster |   100 | 436.8 ns | 2.09 ns | 1.86 ns |  4.09 |    0.05 | 0.3095 |     - |     - |     648 B |              2 |                       2 |
|           StructLinq |   100 | 373.2 ns | 3.55 ns | 3.32 ns |  3.50 |    0.04 |      - |     - |     - |         - |              0 |                       0 |
| StructLinq_IFunction |   100 | 166.4 ns | 0.82 ns | 0.77 ns |  1.56 |    0.02 |      - |     - |     - |         - |              0 |                       0 |
|            Hyperlinq |   100 | 349.0 ns | 2.41 ns | 2.13 ns |  3.27 |    0.04 |      - |     - |     - |         - |              0 |                       0 |
