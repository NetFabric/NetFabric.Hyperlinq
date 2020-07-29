## Array.ValueType.ArrayValueTypeSkipTakeSelect

### Source
[ArrayValueTypeSkipTakeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeSelect.cs)

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
|           ForLoop | 1000 |   100 | 1.556 μs | 0.0058 μs | 0.0055 μs |  1.00 |    0.00 |     411 B |      - |     - |     - |         - |              0 |                       0 |
|       ForeachLoop | 1000 |   100 | 4.147 μs | 0.0112 μs | 0.0094 μs |  2.67 |    0.01 |     658 B | 0.0153 |     - |     - |      32 B |              2 |                       3 |
|              Linq | 1000 |   100 | 2.629 μs | 0.0175 μs | 0.0146 μs |  1.69 |    0.01 |    2220 B | 0.1183 |     - |     - |     248 B |              3 |                       2 |
|        LinqFaster | 1000 |   100 | 2.768 μs | 0.0271 μs | 0.0227 μs |  1.78 |    0.01 |    1386 B | 5.7678 |     - |     - |   12072 B |             17 |                       3 |
|        StructLinq | 1000 |   100 | 2.602 μs | 0.0097 μs | 0.0086 μs |  1.67 |    0.01 |    1711 B | 0.0763 |     - |     - |     160 B |              2 |                       2 |
| Hyperlinq_Foreach | 1000 |   100 | 1.916 μs | 0.0353 μs | 0.0295 μs |  1.23 |    0.02 |    1072 B |      - |     - |     - |         - |              1 |                       1 |
|     Hyperlinq_For | 1000 |   100 | 1.950 μs | 0.0071 μs | 0.0063 μs |  1.25 |    0.01 |    1024 B |      - |     - |     - |         - |              1 |                       1 |
