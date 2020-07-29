## Array.Int32.ArrayInt32WhereCount

### Source
[ArrayInt32WhereCount.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereCount.cs)

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
|              ForLoop |   100 |  79.96 ns | 0.257 ns | 0.215 ns |  1.00 |    0.00 |      41 B |      - |     - |     - |         - |              0 |                       1 |
|          ForeachLoop |   100 |  66.79 ns | 0.633 ns | 0.592 ns |  0.83 |    0.01 |      41 B |      - |     - |     - |         - |              0 |                       1 |
|                 Linq |   100 | 637.86 ns | 2.090 ns | 1.745 ns |  7.98 |    0.03 |     378 B | 0.0153 |     - |     - |      32 B |              1 |                       1 |
|           LinqFaster |   100 | 259.43 ns | 1.468 ns | 1.226 ns |  3.24 |    0.02 |     343 B |      - |     - |     - |         - |              0 |                       1 |
|           StructLinq |   100 | 337.18 ns | 2.017 ns | 1.684 ns |  4.22 |    0.02 |     447 B | 0.0191 |     - |     - |      40 B |              0 |                       1 |
| StructLinq_IFunction |   100 | 167.84 ns | 0.702 ns | 0.622 ns |  2.10 |    0.01 |     315 B | 0.0191 |     - |     - |      40 B |              0 |                       0 |
|            Hyperlinq |   100 | 200.65 ns | 3.046 ns | 2.543 ns |  2.51 |    0.03 |     496 B |      - |     - |     - |         - |              0 |                       0 |
