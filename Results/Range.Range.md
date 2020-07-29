## Range.Range

### Source
[Range.cs](../LinqBenchmarks/Range/Range.cs)

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
|            Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD | Code Size |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|------------------ |------ |------ |----------:|---------:|---------:|------:|--------:|----------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|           ForLoop |     0 |   100 |  34.53 ns | 0.193 ns | 0.161 ns |  1.00 |    0.00 |      27 B |      - |     - |     - |         - |              0 |                       0 |
|       ForeachLoop |     0 |   100 | 461.09 ns | 2.764 ns | 2.308 ns | 13.36 |    0.09 |     348 B | 0.0267 |     - |     - |      56 B |              1 |                       1 |
|              Linq |     0 |   100 | 429.42 ns | 3.351 ns | 2.798 ns | 12.44 |    0.11 |     431 B | 0.0191 |     - |     - |      40 B |              0 |                       1 |
|        LinqFaster |     0 |   100 | 132.22 ns | 1.220 ns | 1.141 ns |  3.83 |    0.03 |     192 B | 0.2027 |     - |     - |     424 B |              1 |                       1 |
|        StructLinq |     0 |   100 |  41.28 ns | 0.343 ns | 0.267 ns |  1.20 |    0.01 |      78 B |      - |     - |     - |         - |              0 |                       0 |
| Hyperlinq_Foreach |     0 |   100 | 169.45 ns | 0.913 ns | 0.809 ns |  4.91 |    0.03 |     269 B |      - |     - |     - |         - |              0 |                       0 |
|     Hyperlinq_For |     0 |   100 |  64.50 ns | 0.486 ns | 0.379 ns |  1.87 |    0.02 |     242 B |      - |     - |     - |         - |              0 |                       0 |
