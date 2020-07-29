## Array.ValueType.ArrayValueTypeWhereSelectToArray

### Source
[ArrayValueTypeWhereSelectToArray.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToArray.cs)

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
|               Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD | Code Size |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |-----------:|---------:|---------:|------:|--------:|----------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |   100 | 1,139.4 ns |  8.40 ns |  7.44 ns |  1.00 |    0.00 |     935 B | 3.4103 |     - |     - |    7136 B |              7 |                       1 |
|          ForeachLoop |   100 | 1,127.5 ns | 15.43 ns | 12.05 ns |  0.99 |    0.01 |     934 B | 3.4103 |     - |     - |    7136 B |              7 |                       2 |
|                 Linq |   100 | 1,418.5 ns | 24.77 ns | 23.17 ns |  1.25 |    0.03 |    1713 B | 2.4319 |     - |     - |    5088 B |              9 |                       3 |
|           LinqFaster |   100 | 1,168.4 ns |  5.10 ns |  4.26 ns |  1.03 |    0.01 |    1042 B | 2.8896 |     - |     - |    6048 B |              7 |                       2 |
|           StructLinq |   100 | 1,388.5 ns | 13.62 ns | 12.07 ns |  1.22 |    0.01 |    2421 B | 0.9899 |     - |     - |    2072 B |              7 |                       3 |
| StructLinq_IFunction |   100 |   914.7 ns |  4.86 ns |  4.31 ns |  0.80 |    0.01 |    2033 B | 0.9899 |     - |     - |    2072 B |              5 |                       3 |
|            Hyperlinq |   100 | 1,273.7 ns |  8.55 ns |  8.00 ns |  1.12 |    0.01 |    2027 B | 0.9670 |     - |     - |    2024 B |              6 |                       3 |
|       Hyperlinq_Pool |   100 | 1,180.4 ns |  7.35 ns |  6.51 ns |  1.04 |    0.01 |    2719 B | 0.0267 |     - |     - |      56 B |              1 |                       3 |
