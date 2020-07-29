## Array.ValueType.ArrayValueTypeWhere

### Source
[ArrayValueTypeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhere.cs)

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
|               Method | Count |       Mean |   Error |  StdDev | Ratio | RatioSD | Code Size |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |-----------:|--------:|--------:|------:|--------:|----------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |   100 |   478.3 ns | 1.99 ns | 1.86 ns |  1.00 |    0.00 |     283 B |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop |   100 |   464.9 ns | 1.73 ns | 1.53 ns |  0.97 |    0.00 |     283 B |      - |     - |     - |         - |              0 |                       0 |
|                 Linq |   100 |   893.4 ns | 6.06 ns | 5.67 ns |  1.87 |    0.01 |    1107 B | 0.0381 |     - |     - |      80 B |              1 |                       1 |
|           LinqFaster |   100 | 1,053.2 ns | 8.23 ns | 7.30 ns |  2.20 |    0.02 |     977 B | 2.8896 |     - |     - |    6048 B |              7 |                       2 |
|           StructLinq |   100 |   748.9 ns | 5.11 ns | 4.53 ns |  1.57 |    0.01 |     972 B |      - |     - |     - |         - |              0 |                       1 |
| StructLinq_IFunction |   100 |   512.2 ns | 2.56 ns | 2.27 ns |  1.07 |    0.01 |     675 B |      - |     - |     - |         - |              0 |                       0 |
|            Hyperlinq |   100 |   678.6 ns | 2.27 ns | 2.01 ns |  1.42 |    0.01 |     758 B |      - |     - |     - |         - |              0 |                       1 |
