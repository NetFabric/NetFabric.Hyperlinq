## Array.ValueType.ArrayValueTypeWhereSelect

### Source
[ArrayValueTypeWhereSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelect.cs)

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
|               Method | Count |       Mean |    Error |   StdDev | Ratio | Code Size |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |-----------:|---------:|---------:|------:|----------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |   100 |   855.9 ns |  3.19 ns |  2.83 ns |  1.00 |     439 B |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop |   100 |   852.2 ns |  2.15 ns |  2.02 ns |  1.00 |     459 B |      - |     - |     - |         - |              0 |                       0 |
|                 Linq |   100 | 1,392.8 ns |  5.49 ns |  5.13 ns |  1.63 |    2050 B | 0.0801 |     - |     - |     168 B |              2 |                       1 |
|           LinqFaster |   100 | 1,512.5 ns | 13.50 ns | 12.63 ns |  1.77 |    1303 B | 2.8896 |     - |     - |    6048 B |             10 |                       2 |
|           StructLinq |   100 | 1,245.9 ns |  5.09 ns |  4.77 ns |  1.46 |    1613 B |      - |     - |     - |         - |              0 |                       1 |
| StructLinq_IFunction |   100 |   906.3 ns |  2.35 ns |  2.08 ns |  1.06 |    1255 B |      - |     - |     - |         - |              0 |                       0 |
|            Hyperlinq |   100 | 1,232.1 ns |  7.55 ns |  7.06 ns |  1.44 |    1364 B |      - |     - |     - |         - |              0 |                       1 |
