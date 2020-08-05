## Range.Range

### Source
[Range.cs](../LinqBenchmarks/Range/Range.cs)

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
|            Method |           Job |       Runtime | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD | Code Size |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|------------------ |-------------- |-------------- |------ |------ |----------:|---------:|---------:|------:|--------:|----------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|           ForLoop |      .NET 4.8 |      .NET 4.8 |     0 |   100 |  34.61 ns | 0.237 ns | 0.198 ns |  1.00 |    0.00 |      27 B |      - |     - |     - |         - |              0 |                       0 |
|       ForeachLoop |      .NET 4.8 |      .NET 4.8 |     0 |   100 | 474.19 ns | 1.490 ns | 1.394 ns | 13.70 |    0.11 |     270 B | 0.0267 |     - |     - |      56 B |              1 |                       1 |
|              Linq |      .NET 4.8 |      .NET 4.8 |     0 |   100 | 527.76 ns | 2.286 ns | 2.138 ns | 15.26 |    0.10 |     307 B | 0.0229 |     - |     - |      48 B |              0 |                       1 |
|        LinqFaster |      .NET 4.8 |      .NET 4.8 |     0 |   100 | 124.70 ns | 0.994 ns | 0.930 ns |  3.60 |    0.03 |     189 B | 0.2027 |     - |     - |     425 B |              0 |                       1 |
|        StructLinq |      .NET 4.8 |      .NET 4.8 |     0 |   100 |  41.74 ns | 0.106 ns | 0.088 ns |  1.21 |    0.01 |      83 B |      - |     - |     - |         - |              0 |                       0 |
| Hyperlinq_Foreach |      .NET 4.8 |      .NET 4.8 |     0 |   100 | 181.91 ns | 0.462 ns | 0.432 ns |  5.26 |    0.04 |     277 B |      - |     - |     - |         - |              0 |                       0 |
|     Hyperlinq_For |      .NET 4.8 |      .NET 4.8 |     0 |   100 |  63.79 ns | 0.264 ns | 0.234 ns |  1.84 |    0.01 |     242 B |      - |     - |     - |         - |              0 |                       0 |
|           ForLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |   100 |  34.44 ns | 0.135 ns | 0.113 ns |  1.00 |    0.01 |      27 B |      - |     - |     - |         - |              0 |                       0 |
|       ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |   100 | 455.29 ns | 1.074 ns | 0.953 ns | 13.16 |    0.08 |     318 B | 0.0267 |     - |     - |      56 B |              1 |                       1 |
|              Linq | .NET Core 3.1 | .NET Core 3.1 |     0 |   100 | 429.28 ns | 1.784 ns | 1.581 ns | 12.41 |    0.07 |     401 B | 0.0191 |     - |     - |      40 B |              0 |                       1 |
|        LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     0 |   100 | 127.95 ns | 0.747 ns | 0.698 ns |  3.70 |    0.03 |     192 B | 0.2027 |     - |     - |     424 B |              0 |                       1 |
|        StructLinq | .NET Core 3.1 | .NET Core 3.1 |     0 |   100 |  41.17 ns | 0.146 ns | 0.130 ns |  1.19 |    0.01 |      83 B |      - |     - |     - |         - |              0 |                       0 |
| Hyperlinq_Foreach | .NET Core 3.1 | .NET Core 3.1 |     0 |   100 | 172.48 ns | 0.682 ns | 0.638 ns |  4.98 |    0.04 |     272 B |      - |     - |     - |         - |              0 |                       0 |
|     Hyperlinq_For | .NET Core 3.1 | .NET Core 3.1 |     0 |   100 |  64.57 ns | 0.336 ns | 0.314 ns |  1.86 |    0.02 |     242 B |      - |     - |     - |         - |              0 |                       0 |
|           ForLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |   100 |  34.14 ns | 0.148 ns | 0.138 ns |  0.99 |    0.01 |      27 B |      - |     - |     - |         - |              0 |                       0 |
|       ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |   100 | 504.34 ns | 2.446 ns | 2.168 ns | 14.57 |    0.13 |     306 B | 0.0267 |     - |     - |      56 B |              1 |                       1 |
|              Linq | .NET Core 5.0 | .NET Core 5.0 |     0 |   100 | 424.51 ns | 1.846 ns | 1.542 ns | 12.27 |    0.10 |     389 B | 0.0191 |     - |     - |      40 B |              0 |                       0 |
|        LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     0 |   100 | 136.16 ns | 0.847 ns | 0.751 ns |  3.94 |    0.03 |     192 B | 0.2027 |     - |     - |     424 B |              1 |                       1 |
|        StructLinq | .NET Core 5.0 | .NET Core 5.0 |     0 |   100 |  40.89 ns | 0.193 ns | 0.181 ns |  1.18 |    0.01 |      78 B |      - |     - |     - |         - |              0 |                       0 |
| Hyperlinq_Foreach | .NET Core 5.0 | .NET Core 5.0 |     0 |   100 | 171.29 ns | 0.536 ns | 0.502 ns |  4.95 |    0.04 |     269 B |      - |     - |     - |         - |              0 |                       0 |
|     Hyperlinq_For | .NET Core 5.0 | .NET Core 5.0 |     0 |   100 |  68.82 ns | 1.386 ns | 1.596 ns |  1.99 |    0.05 |     242 B |      - |     - |     - |         - |              0 |                       0 |
