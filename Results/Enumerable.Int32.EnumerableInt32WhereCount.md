## Enumerable.Int32.EnumerableInt32WhereCount

### Source
[EnumerableInt32WhereCount.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereCount.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta22](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta22)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET 4.8      : .NET Framework 4.8 (4.8.4180.0), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT


```
|               Method |           Job |       Runtime | Count |     Mean |    Error |  StdDev | Ratio | RatioSD | Code Size |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |-------------- |-------------- |------ |---------:|---------:|--------:|------:|--------:|----------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |   100 | 517.2 ns |  6.34 ns | 5.93 ns |  1.00 |    0.00 |     205 B | 0.0191 |     - |     - |      40 B |              0 |                       0 |
|                 Linq |      .NET 4.8 |      .NET 4.8 |   100 | 596.3 ns |  3.15 ns | 2.95 ns |  1.15 |    0.01 |     579 B | 0.0191 |     - |     - |      40 B |              0 |                       1 |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |   100 | 745.0 ns | 10.82 ns | 9.03 ns |  1.44 |    0.03 |     540 B | 0.0343 |     - |     - |      72 B |              0 |                       1 |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |   100 | 504.4 ns |  4.40 ns | 4.11 ns |  0.98 |    0.01 |     447 B | 0.0343 |     - |     - |      72 B |              0 |                       0 |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |   100 | 636.9 ns |  6.18 ns | 5.78 ns |  1.23 |    0.02 |     561 B | 0.0191 |     - |     - |      40 B |              0 |                       0 |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |   100 | 452.0 ns |  3.95 ns | 3.69 ns |  0.87 |    0.01 |     210 B | 0.0191 |     - |     - |      40 B |              0 |                       1 |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |   100 | 675.8 ns |  5.80 ns | 5.14 ns |  1.31 |    0.02 |     425 B | 0.0191 |     - |     - |      40 B |              0 |                       1 |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |   100 | 775.7 ns |  8.40 ns | 7.44 ns |  1.50 |    0.02 |     450 B | 0.0343 |     - |     - |      72 B |              1 |                       1 |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |   100 | 547.1 ns |  2.88 ns | 2.56 ns |  1.06 |    0.01 |     361 B | 0.0343 |     - |     - |      72 B |              1 |                       1 |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |   100 | 637.1 ns |  4.01 ns | 3.55 ns |  1.23 |    0.02 |     499 B | 0.0191 |     - |     - |      40 B |              1 |                       1 |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |   100 | 477.3 ns |  1.79 ns | 1.67 ns |  0.92 |    0.01 |     198 B | 0.0191 |     - |     - |      40 B |              0 |                       1 |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |   100 | 639.5 ns |  3.50 ns | 3.10 ns |  1.24 |    0.01 |     378 B | 0.0191 |     - |     - |      40 B |              0 |                       1 |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |   100 | 735.9 ns |  1.67 ns | 1.40 ns |  1.42 |    0.02 |     427 B | 0.0343 |     - |     - |      72 B |              1 |                       1 |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |   100 | 497.3 ns |  3.38 ns | 3.16 ns |  0.96 |    0.01 |     342 B | 0.0343 |     - |     - |      72 B |              1 |                       1 |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |   100 | 586.1 ns |  1.76 ns | 1.47 ns |  1.13 |    0.01 |     462 B | 0.0191 |     - |     - |      40 B |              0 |                       1 |
