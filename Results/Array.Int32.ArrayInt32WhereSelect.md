## Array.Int32.ArrayInt32WhereSelect

### Source
[ArrayInt32WhereSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelect.cs)

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
|              ForLoop |   100 |  76.92 ns | 0.350 ns | 0.327 ns |  1.00 |    0.00 |      43 B |      - |     - |     - |         - |              0 |                       1 |
|          ForeachLoop |   100 |  76.85 ns | 0.578 ns | 0.451 ns |  1.00 |    0.01 |      43 B |      - |     - |     - |         - |              0 |                       0 |
|                 Linq |   100 | 559.88 ns | 4.975 ns | 4.654 ns |  7.28 |    0.08 |    1716 B | 0.0496 |     - |     - |     104 B |              1 |                       1 |
|           LinqFaster |   100 | 411.99 ns | 2.519 ns | 2.103 ns |  5.36 |    0.03 |     847 B | 0.3095 |     - |     - |     648 B |              2 |                       1 |
|           StructLinq |   100 | 442.31 ns | 3.286 ns | 2.913 ns |  5.75 |    0.04 |    1021 B |      - |     - |     - |         - |              0 |                       1 |
| StructLinq_IFunction |   100 | 186.63 ns | 0.816 ns | 0.681 ns |  2.43 |    0.01 |     855 B |      - |     - |     - |         - |              0 |                       0 |
|            Hyperlinq |   100 | 446.45 ns | 2.256 ns | 2.111 ns |  5.80 |    0.04 |     940 B |      - |     - |     - |         - |              0 |                       1 |
