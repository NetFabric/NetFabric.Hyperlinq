## Range.RangeSelectToArray

### Source
[RangeSelectToArray.cs](../LinqBenchmarks/Range/RangeSelectToArray.cs)

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
|               Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD | Code Size |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |------ |----------:|---------:|---------:|------:|--------:|----------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |     0 |   100 |  91.13 ns | 0.896 ns | 0.794 ns |  1.00 |    0.00 |      82 B | 0.2027 |     - |     - |     424 B |              1 |                       0 |
|                 Linq |     0 |   100 | 237.01 ns | 1.706 ns | 1.595 ns |  2.60 |    0.03 |    1177 B | 0.2446 |     - |     - |     512 B |              2 |                       1 |
|           LinqFaster |     0 |   100 | 298.39 ns | 1.534 ns | 1.360 ns |  3.27 |    0.04 |     565 B | 0.4053 |     - |     - |     848 B |              2 |                       1 |
|           StructLinq |     0 |   100 | 563.00 ns | 2.250 ns | 1.879 ns |  6.18 |    0.05 |    1496 B | 0.2174 |     - |     - |     456 B |              2 |                       3 |
| StructLinq_IFunction |     0 |   100 | 392.31 ns | 2.177 ns | 2.037 ns |  4.31 |    0.05 |    1488 B | 0.2179 |     - |     - |     456 B |              2 |                       0 |
|            Hyperlinq |     0 |   100 | 244.16 ns | 1.654 ns | 1.466 ns |  2.68 |    0.03 |    1060 B | 0.2027 |     - |     - |     424 B |              1 |                       1 |
|       Hyperlinq_Pool |     0 |   100 | 290.77 ns | 2.368 ns | 2.099 ns |  3.19 |    0.04 |    1613 B | 0.0267 |     - |     - |      56 B |              1 |                       0 |
