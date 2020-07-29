## List.ValueType.ListValueTypeSkipTakeSelect

### Source
[ListValueTypeSkipTakeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta21](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta21)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|            Method | Skip | Count |     Mean |     Error |    StdDev | Ratio | RatioSD | Code Size |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|------------------ |----- |------ |---------:|----------:|----------:|------:|--------:|----------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|           ForLoop | 1000 |   100 | 1.676 μs | 0.0067 μs | 0.0062 μs |  1.00 |    0.00 |     494 B |      - |     - |     - |         - |              0 |                       0 |
|       ForeachLoop | 1000 |   100 | 5.648 μs | 0.0453 μs | 0.0402 μs |  3.37 |    0.02 |     658 B | 0.0305 |     - |     - |      72 B |              3 |                       3 |
|              Linq | 1000 |   100 | 2.528 μs | 0.0153 μs | 0.0136 μs |  1.51 |    0.01 |    2220 B | 0.1183 |     - |     - |     248 B |              3 |                       1 |
|        LinqFaster | 1000 |   100 | 3.921 μs | 0.0444 μs | 0.0415 μs |  2.34 |    0.03 |    2146 B | 5.8136 |     - |     - |   12168 B |             16 |                       5 |
|        StructLinq | 1000 |   100 | 2.508 μs | 0.0217 μs | 0.0203 μs |  1.50 |    0.01 |    1711 B | 0.0763 |     - |     - |     160 B |              2 |                       1 |
| Hyperlinq_Foreach | 1000 |   100 | 1.935 μs | 0.0161 μs | 0.0151 μs |  1.15 |    0.01 |    1309 B |      - |     - |     - |         - |              0 |                       1 |
|     Hyperlinq_For | 1000 |   100 | 2.062 μs | 0.0096 μs | 0.0090 μs |  1.23 |    0.01 |    1206 B |      - |     - |     - |         - |              0 |                       1 |
