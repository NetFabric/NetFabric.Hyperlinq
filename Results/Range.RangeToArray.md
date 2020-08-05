## Range.RangeToArray

### Source
[RangeToArray.cs](../LinqBenchmarks/Range/RangeToArray.cs)

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
|         Method |           Job |       Runtime | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | Code Size | CacheMisses/Op | BranchMispredictions/Op |
|--------------- |-------------- |-------------- |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|----------:|---------------:|------------------------:|
|        ForLoop |      .NET 4.8 |      .NET 4.8 |     0 |   100 |  78.36 ns | 0.694 ns | 0.649 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     425 B |      78 B |              0 |                       0 |
|           Linq |      .NET 4.8 |      .NET 4.8 |     0 |   100 | 779.84 ns | 3.671 ns | 3.434 ns |  9.95 |    0.11 | 0.7763 |     - |     - |    1629 B |     275 B |              3 |                       2 |
|     LinqFaster |      .NET 4.8 |      .NET 4.8 |     0 |   100 |  67.24 ns | 0.265 ns | 0.235 ns |  0.86 |    0.01 | 0.2027 |     - |     - |     425 B |     158 B |              0 |                       0 |
|     StructLinq |      .NET 4.8 |      .NET 4.8 |     0 |   100 | 531.57 ns | 2.523 ns | 2.360 ns |  6.78 |    0.05 | 0.2136 |     - |     - |     449 B |     856 B |              2 |                       1 |
|      Hyperlinq |      .NET 4.8 |      .NET 4.8 |     0 |   100 |  79.32 ns | 0.407 ns | 0.381 ns |  1.01 |    0.01 | 0.2027 |     - |     - |     425 B |     263 B |              0 |                       0 |
| Hyperlinq_Pool |      .NET 4.8 |      .NET 4.8 |     0 |   100 | 200.45 ns | 0.672 ns | 0.595 ns |  2.56 |    0.02 | 0.0267 |     - |     - |      56 B |    1246 B |              0 |                       0 |
|        ForLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |   100 |  79.97 ns | 0.649 ns | 0.575 ns |  1.02 |    0.01 | 0.2027 |     - |     - |     424 B |      79 B |              0 |                       0 |
|           Linq | .NET Core 3.1 | .NET Core 3.1 |     0 |   100 |  82.37 ns | 0.548 ns | 0.513 ns |  1.05 |    0.01 | 0.2218 |     - |     - |     464 B |     318 B |              0 |                       0 |
|     LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     0 |   100 |  78.17 ns | 0.717 ns | 0.671 ns |  1.00 |    0.02 | 0.2027 |     - |     - |     424 B |     161 B |              0 |                       0 |
|     StructLinq | .NET Core 3.1 | .NET Core 3.1 |     0 |   100 | 462.77 ns | 3.794 ns | 3.549 ns |  5.91 |    0.05 | 0.2136 |     - |     - |     448 B |     647 B |              2 |                       1 |
|      Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |     0 |   100 |  80.32 ns | 0.817 ns | 0.682 ns |  1.03 |    0.02 | 0.2027 |     - |     - |     424 B |     266 B |              0 |                       0 |
| Hyperlinq_Pool | .NET Core 3.1 | .NET Core 3.1 |     0 |   100 | 133.60 ns | 0.870 ns | 0.727 ns |  1.71 |    0.02 | 0.0267 |     - |     - |      56 B |     735 B |              0 |                       0 |
|        ForLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |   100 |  78.95 ns | 0.601 ns | 0.562 ns |  1.01 |    0.01 | 0.2027 |     - |     - |     424 B |      79 B |              0 |                       0 |
|           Linq | .NET Core 5.0 | .NET Core 5.0 |     0 |   100 |  86.51 ns | 0.488 ns | 0.407 ns |  1.10 |    0.01 | 0.2218 |     - |     - |     464 B |     300 B |              0 |                       0 |
|     LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     0 |   100 |  66.74 ns | 0.371 ns | 0.347 ns |  0.85 |    0.01 | 0.2027 |     - |     - |     424 B |     153 B |              0 |                       0 |
|     StructLinq | .NET Core 5.0 | .NET Core 5.0 |     0 |   100 | 366.33 ns | 1.635 ns | 1.365 ns |  4.68 |    0.05 | 0.2141 |     - |     - |     448 B |     758 B |              1 |                       0 |
|      Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |     0 |   100 |  84.05 ns | 0.608 ns | 0.539 ns |  1.07 |    0.01 | 0.2027 |     - |     - |     424 B |     266 B |              0 |                       0 |
| Hyperlinq_Pool | .NET Core 5.0 | .NET Core 5.0 |     0 |   100 | 123.09 ns | 0.691 ns | 0.646 ns |  1.57 |    0.02 | 0.0267 |     - |     - |      56 B |     731 B |              0 |                       0 |
