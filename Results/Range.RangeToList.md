## Range.RangeToList

### Source
[RangeToList.cs](../LinqBenchmarks/Range/RangeToList.cs)

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
|      Method |           Job |       Runtime | Start | Count |      Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated | Code Size | CacheMisses/Op | BranchMispredictions/Op |
|------------ |-------------- |-------------- |------ |------ |----------:|---------:|---------:|------:|-------:|------:|------:|----------:|----------:|---------------:|------------------------:|
|     ForLoop |      .NET 4.8 |      .NET 4.8 |     0 |   100 | 423.47 ns | 2.038 ns | 1.702 ns |  1.00 | 0.5698 |     - |     - |    1196 B |     184 B |              1 |                       1 |
| ForeachLoop |      .NET 4.8 |      .NET 4.8 |     0 |   100 | 865.45 ns | 5.107 ns | 4.528 ns |  2.04 | 0.5960 |     - |     - |    1252 B |     425 B |              3 |                       3 |
|        Linq |      .NET 4.8 |      .NET 4.8 |     0 |   100 | 960.04 ns | 3.878 ns | 3.628 ns |  2.27 | 0.5913 |     - |     - |    1244 B |     235 B |              4 |                       3 |
|  LinqFaster |      .NET 4.8 |      .NET 4.8 |     0 |   100 | 148.09 ns | 0.596 ns | 0.528 ns |  0.35 | 0.4246 |     - |     - |     891 B |     607 B |              1 |                       1 |
|  StructLinq |      .NET 4.8 |      .NET 4.8 |     0 |   100 | 544.66 ns | 3.997 ns | 3.544 ns |  1.29 | 0.2327 |     - |     - |     490 B |     936 B |              2 |                       1 |
|   Hyperlinq |      .NET 4.8 |      .NET 4.8 |     0 |   100 | 103.48 ns | 0.508 ns | 0.450 ns |  0.24 | 0.2371 |     - |     - |     498 B |     686 B |              0 |                       0 |
|     ForLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |   100 | 337.54 ns | 3.106 ns | 2.905 ns |  0.80 | 0.5660 |     - |     - |    1184 B |     208 B |              1 |                       0 |
| ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |   100 | 732.62 ns | 2.995 ns | 2.655 ns |  1.73 | 0.5922 |     - |     - |    1240 B |     489 B |              3 |                       3 |
|        Linq | .NET Core 3.1 | .NET Core 3.1 |     0 |   100 | 192.14 ns | 1.512 ns | 1.340 ns |  0.45 | 0.2370 |     - |     - |     496 B |     338 B |              1 |                       0 |
|  LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     0 |   100 | 133.81 ns | 2.660 ns | 2.488 ns |  0.31 | 0.4206 |     - |     - |     880 B |     709 B |              1 |                       1 |
|  StructLinq | .NET Core 3.1 | .NET Core 3.1 |     0 |   100 | 475.15 ns | 2.445 ns | 2.168 ns |  1.12 | 0.2294 |     - |     - |     480 B |     709 B |              1 |                       1 |
|   Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |     0 |   100 | 100.96 ns | 0.933 ns | 0.873 ns |  0.24 | 0.2332 |     - |     - |     488 B |     785 B |              0 |                       0 |
|     ForLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |   100 | 282.09 ns | 3.417 ns | 2.853 ns |  0.67 | 0.5660 |     - |     - |    1184 B |     208 B |              1 |                       0 |
| ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |   100 | 714.39 ns | 3.884 ns | 3.443 ns |  1.69 | 0.5922 |     - |     - |    1240 B |     477 B |              3 |                       3 |
|        Linq | .NET Core 5.0 | .NET Core 5.0 |     0 |   100 | 190.89 ns | 0.903 ns | 0.845 ns |  0.45 | 0.2370 |     - |     - |     496 B |     328 B |              1 |                       1 |
|  LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     0 |   100 | 115.64 ns | 1.339 ns | 1.118 ns |  0.27 | 0.4206 |     - |     - |     880 B |     693 B |              1 |                       1 |
|  StructLinq | .NET Core 5.0 | .NET Core 5.0 |     0 |   100 | 376.89 ns | 2.285 ns | 2.026 ns |  0.89 | 0.2294 |     - |     - |     480 B |     823 B |              1 |                       0 |
|   Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |     0 |   100 |  95.32 ns | 0.858 ns | 0.716 ns |  0.23 | 0.2333 |     - |     - |     488 B |     761 B |              0 |                       0 |
