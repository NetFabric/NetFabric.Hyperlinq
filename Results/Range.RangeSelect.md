## Range.RangeSelect

### Source
[RangeSelect.cs](../LinqBenchmarks/Range/RangeSelect.cs)

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
|               Method |           Job |       Runtime | Start | Count |        Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | Code Size | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |-------------- |-------------- |------ |------ |------------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|----------:|---------------:|------------------------:|
|              ForLoop |      .NET 4.8 |      .NET 4.8 |     0 |   100 |    40.53 ns | 0.179 ns | 0.167 ns |  1.00 |    0.00 |      - |     - |     - |         - |      28 B |              0 |                       0 |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |     0 |   100 |   475.54 ns | 1.966 ns | 1.743 ns | 11.73 |    0.07 | 0.0267 |     - |     - |      56 B |     273 B |              1 |                       0 |
|                 Linq |      .NET 4.8 |      .NET 4.8 |     0 |   100 | 1,200.56 ns | 7.371 ns | 6.155 ns | 29.61 |    0.21 | 0.0534 |     - |     - |     112 B |    1010 B |              1 |                       1 |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |     0 |   100 |   349.10 ns | 2.101 ns | 1.965 ns |  8.61 |    0.05 | 0.4053 |     - |     - |     851 B |     667 B |              1 |                       1 |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |     0 |   100 |   285.03 ns | 1.308 ns | 1.224 ns |  7.03 |    0.03 |      - |     - |     - |         - |     579 B |              0 |                       0 |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |     0 |   100 |   177.56 ns | 0.734 ns | 0.651 ns |  4.38 |    0.02 |      - |     - |     - |         - |     537 B |              0 |                       0 |
|    Hyperlinq_Foreach |      .NET 4.8 |      .NET 4.8 |     0 |   100 |   390.50 ns | 2.353 ns | 1.965 ns |  9.63 |    0.06 |      - |     - |     - |         - |     797 B |              0 |                       0 |
|        Hyperlinq_For |      .NET 4.8 |      .NET 4.8 |     0 |   100 |   408.47 ns | 1.803 ns | 1.687 ns | 10.08 |    0.05 |      - |     - |     - |         - |     658 B |              0 |                       0 |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |   100 |    39.22 ns | 0.159 ns | 0.141 ns |  0.97 |    0.01 |      - |     - |     - |         - |      28 B |              0 |                       0 |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |   100 |   452.56 ns | 1.649 ns | 1.462 ns | 11.17 |    0.07 | 0.0267 |     - |     - |      56 B |     319 B |              1 |                       1 |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |     0 |   100 |   609.30 ns | 3.499 ns | 3.101 ns | 15.03 |    0.11 | 0.0420 |     - |     - |      88 B |    1268 B |              1 |                       1 |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     0 |   100 |   343.54 ns | 2.682 ns | 2.509 ns |  8.48 |    0.08 | 0.4053 |     - |     - |     848 B |     622 B |              1 |                       2 |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |     0 |   100 |   261.79 ns | 1.404 ns | 1.244 ns |  6.46 |    0.04 |      - |     - |     - |         - |     518 B |              0 |                       0 |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |     0 |   100 |   177.64 ns | 0.437 ns | 0.409 ns |  4.38 |    0.02 |      - |     - |     - |         - |     493 B |              0 |                       0 |
|    Hyperlinq_Foreach | .NET Core 3.1 | .NET Core 3.1 |     0 |   100 |   310.75 ns | 0.961 ns | 0.750 ns |  7.67 |    0.05 |      - |     - |     - |         - |     730 B |              0 |                       0 |
|        Hyperlinq_For | .NET Core 3.1 | .NET Core 3.1 |     0 |   100 |   397.60 ns | 7.367 ns | 6.152 ns |  9.81 |    0.14 |      - |     - |     - |         - |     598 B |              0 |                       0 |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |   100 |    42.62 ns | 0.750 ns | 0.665 ns |  1.05 |    0.02 |      - |     - |     - |         - |      28 B |              0 |                       0 |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |   100 |   478.33 ns | 1.916 ns | 1.698 ns | 11.80 |    0.07 | 0.0267 |     - |     - |      56 B |     307 B |              1 |                       1 |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |     0 |   100 |   652.66 ns | 2.607 ns | 2.439 ns | 16.10 |    0.07 | 0.0420 |     - |     - |      88 B |    1252 B |              1 |                       1 |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     0 |   100 |   313.22 ns | 2.369 ns | 2.100 ns |  7.73 |    0.06 | 0.4053 |     - |     - |     848 B |     616 B |              2 |                       2 |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |     0 |   100 |   262.15 ns | 1.032 ns | 0.915 ns |  6.47 |    0.03 |      - |     - |     - |         - |     489 B |              0 |                       0 |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |     0 |   100 |   172.34 ns | 0.534 ns | 0.500 ns |  4.25 |    0.02 |      - |     - |     - |         - |     460 B |              0 |                       0 |
|    Hyperlinq_Foreach | .NET Core 5.0 | .NET Core 5.0 |     0 |   100 |   352.61 ns | 1.472 ns | 1.377 ns |  8.70 |    0.05 |      - |     - |     - |         - |     723 B |              0 |                       0 |
|        Hyperlinq_For | .NET Core 5.0 | .NET Core 5.0 |     0 |   100 |   367.42 ns | 1.641 ns | 1.535 ns |  9.07 |    0.05 |      - |     - |     - |         - |     584 B |              0 |                       0 |
