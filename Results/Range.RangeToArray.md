## Range.RangeToArray

### Source
[RangeToArray.cs](../LinqBenchmarks/Range/RangeToArray.cs)

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
|         Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD | Code Size |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------- |------ |------ |----------:|---------:|---------:|------:|--------:|----------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|        ForLoop |     0 |   100 |  88.06 ns | 1.431 ns | 1.268 ns |  1.00 |    0.00 |      79 B | 0.2027 |     - |     - |     424 B |              1 |                       0 |
|           Linq |     0 |   100 |  91.24 ns | 0.778 ns | 0.728 ns |  1.04 |    0.02 |     342 B | 0.2218 |     - |     - |     464 B |              1 |                       0 |
|     LinqFaster |     0 |   100 |  74.10 ns | 0.577 ns | 0.540 ns |  0.84 |    0.01 |     153 B | 0.2027 |     - |     - |     424 B |              1 |                       1 |
|     StructLinq |     0 |   100 | 403.64 ns | 2.849 ns | 2.379 ns |  4.58 |    0.08 |    1206 B | 0.2141 |     - |     - |     448 B |              2 |                       0 |
|      Hyperlinq |     0 |   100 |  86.74 ns | 1.073 ns | 1.004 ns |  0.99 |    0.02 |     361 B | 0.2027 |     - |     - |     424 B |              1 |                       1 |
| Hyperlinq_Pool |     0 |   100 | 118.53 ns | 0.671 ns | 0.595 ns |  1.35 |    0.02 |     828 B | 0.0267 |     - |     - |      56 B |              0 |                       0 |
