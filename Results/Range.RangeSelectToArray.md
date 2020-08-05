## Range.RangeSelectToArray

### Source
[RangeSelectToArray.cs](../LinqBenchmarks/Range/RangeSelectToArray.cs)

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
|               Method |           Job |       Runtime | Start | Count |        Mean |     Error |   StdDev | Ratio | RatioSD | Code Size |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |-------------- |-------------- |------ |------ |------------:|----------:|---------:|------:|--------:|----------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |      .NET 4.8 |      .NET 4.8 |     0 |   100 |    78.78 ns |  0.522 ns | 0.489 ns |  1.00 |    0.00 |      81 B | 0.2027 |     - |     - |     425 B |              0 |                       0 |
|                 Linq |      .NET 4.8 |      .NET 4.8 |     0 |   100 | 1,423.69 ns | 10.745 ns | 9.525 ns | 18.05 |    0.14 |     970 B | 0.8068 |     - |     - |    1693 B |              5 |                       3 |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |     0 |   100 |   307.52 ns |  1.335 ns | 1.184 ns |  3.90 |    0.03 |     644 B | 0.4053 |     - |     - |     851 B |              1 |                       1 |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |     0 |   100 |   683.80 ns |  2.924 ns | 2.442 ns |  8.67 |    0.04 |    1206 B | 0.2174 |     - |     - |     457 B |              2 |                       3 |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |     0 |   100 |   538.37 ns |  3.454 ns | 3.231 ns |  6.83 |    0.06 |    1202 B | 0.2174 |     - |     - |     457 B |              2 |                       1 |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |     0 |   100 |   245.83 ns |  1.499 ns | 1.329 ns |  3.12 |    0.03 |    1061 B | 0.2027 |     - |     - |     425 B |              1 |                       0 |
|       Hyperlinq_Pool |      .NET 4.8 |      .NET 4.8 |     0 |   100 |   386.66 ns |  1.398 ns | 1.240 ns |  4.90 |    0.04 |    2034 B | 0.0267 |     - |     - |      56 B |              1 |                       0 |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |   100 |    79.03 ns |  0.395 ns | 0.369 ns |  1.00 |    0.01 |      82 B | 0.2027 |     - |     - |     424 B |              0 |                       0 |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |     0 |   100 |   225.32 ns |  1.007 ns | 0.841 ns |  2.86 |    0.02 |    1157 B | 0.2446 |     - |     - |     512 B |              1 |                       1 |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     0 |   100 |   309.13 ns |  2.242 ns | 1.872 ns |  3.92 |    0.03 |     579 B | 0.4053 |     - |     - |     848 B |              1 |                       1 |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |     0 |   100 |   594.37 ns |  2.939 ns | 2.749 ns |  7.54 |    0.06 |     937 B | 0.2174 |     - |     - |     456 B |              2 |                       3 |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |     0 |   100 |   475.10 ns |  3.134 ns | 2.932 ns |  6.03 |    0.05 |     922 B | 0.2174 |     - |     - |     456 B |              2 |                       1 |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |     0 |   100 |   244.50 ns |  1.836 ns | 1.628 ns |  3.10 |    0.03 |     963 B | 0.2027 |     - |     - |     424 B |              1 |                       1 |
|       Hyperlinq_Pool | .NET Core 3.1 | .NET Core 3.1 |     0 |   100 |   281.31 ns |  2.146 ns | 1.902 ns |  3.57 |    0.03 |    1443 B | 0.0267 |     - |     - |      56 B |              1 |                       0 |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |   100 |    86.86 ns |  0.640 ns | 0.599 ns |  1.10 |    0.01 |      82 B | 0.2027 |     - |     - |     424 B |              0 |                       0 |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |     0 |   100 |   225.83 ns |  1.127 ns | 1.054 ns |  2.87 |    0.02 |    1135 B | 0.2446 |     - |     - |     512 B |              1 |                       0 |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     0 |   100 |   306.36 ns |  1.815 ns | 1.697 ns |  3.89 |    0.04 |     565 B | 0.4053 |     - |     - |     848 B |              1 |                       1 |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |     0 |   100 |   509.41 ns |  3.972 ns | 3.521 ns |  6.46 |    0.07 |    1048 B | 0.2174 |     - |     - |     456 B |              2 |                       3 |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |     0 |   100 |   385.42 ns |  1.756 ns | 1.557 ns |  4.89 |    0.03 |    1040 B | 0.2179 |     - |     - |     456 B |              1 |                       0 |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |     0 |   100 |   234.95 ns |  1.155 ns | 1.024 ns |  2.98 |    0.02 |    1013 B | 0.2027 |     - |     - |     424 B |              1 |                       0 |
|       Hyperlinq_Pool | .NET Core 5.0 | .NET Core 5.0 |     0 |   100 |   276.10 ns |  2.245 ns | 2.100 ns |  3.50 |    0.03 |    1430 B | 0.0267 |     - |     - |      56 B |              1 |                       0 |
