## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

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
|               Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD | Code Size |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |----------:|---------:|---------:|------:|--------:|----------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |   100 |  45.81 ns | 0.496 ns | 0.464 ns |  1.00 |    0.00 |      37 B |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop |   100 |  45.55 ns | 0.461 ns | 0.385 ns |  1.00 |    0.01 |      37 B |      - |     - |     - |         - |              0 |                       0 |
|                 Linq |   100 | 662.50 ns | 4.953 ns | 4.633 ns | 14.46 |    0.22 |    1099 B | 0.0229 |     - |     - |      48 B |              1 |                       1 |
|           LinqFaster |   100 | 255.83 ns | 1.362 ns | 1.208 ns |  5.59 |    0.06 |     464 B | 0.2027 |     - |     - |     424 B |              1 |                       1 |
|           StructLinq |   100 | 255.10 ns | 1.861 ns | 1.554 ns |  5.58 |    0.06 |     492 B |      - |     - |     - |         - |              0 |                       0 |
| StructLinq_IFunction |   100 | 161.38 ns | 0.506 ns | 0.448 ns |  3.52 |    0.04 |     495 B |      - |     - |     - |         - |              0 |                       0 |
|    Hyperlinq_Foreach |   100 | 310.02 ns | 2.711 ns | 2.404 ns |  6.77 |    0.08 |     452 B |      - |     - |     - |         - |              0 |                       0 |
|        Hyperlinq_For |   100 | 250.75 ns | 2.668 ns | 2.496 ns |  5.47 |    0.08 |     428 B |      - |     - |     - |         - |              0 |                       1 |
