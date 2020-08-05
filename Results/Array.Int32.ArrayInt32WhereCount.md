## Array.Int32.ArrayInt32WhereCount

### Source
[ArrayInt32WhereCount.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereCount.cs)

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
|               Method |           Job |       Runtime | Count |      Mean |    Error |   StdDev | Ratio | RatioSD | Code Size |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |-------------- |-------------- |------ |----------:|---------:|---------:|------:|--------:|----------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |      .NET 4.8 |      .NET 4.8 |   100 |  79.54 ns | 0.338 ns | 0.316 ns |  1.00 |    0.00 |      41 B |      - |     - |     - |         - |              0 |                       1 |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |   100 |  79.68 ns | 0.286 ns | 0.268 ns |  1.00 |    0.01 |      41 B |      - |     - |     - |         - |              0 |                       1 |
|                 Linq |      .NET 4.8 |      .NET 4.8 |   100 | 604.19 ns | 2.654 ns | 2.352 ns |  7.60 |    0.03 |     579 B | 0.0153 |     - |     - |      32 B |              0 |                       1 |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |   100 | 226.56 ns | 1.005 ns | 0.940 ns |  2.85 |    0.02 |     424 B |      - |     - |     - |         - |              0 |                       0 |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |   100 | 377.72 ns | 1.248 ns | 1.042 ns |  4.75 |    0.03 |     555 B | 0.0191 |     - |     - |      40 B |              0 |                       0 |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |   100 | 209.14 ns | 1.072 ns | 1.002 ns |  2.63 |    0.01 |     436 B | 0.0191 |     - |     - |      40 B |              0 |                       0 |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |   100 | 189.88 ns | 0.678 ns | 0.634 ns |  2.39 |    0.01 |     748 B |      - |     - |     - |         - |              0 |                       0 |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |   100 |  80.12 ns | 0.256 ns | 0.239 ns |  1.01 |    0.01 |      41 B |      - |     - |     - |         - |              0 |                       1 |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |   100 |  80.17 ns | 0.277 ns | 0.259 ns |  1.01 |    0.01 |      41 B |      - |     - |     - |         - |              0 |                       1 |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |   100 | 586.26 ns | 3.869 ns | 3.430 ns |  7.37 |    0.06 |     425 B | 0.0153 |     - |     - |      32 B |              0 |                       1 |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |   100 | 251.43 ns | 0.833 ns | 0.779 ns |  3.16 |    0.02 |     354 B |      - |     - |     - |         - |              0 |                       0 |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |   100 | 321.58 ns | 1.549 ns | 1.449 ns |  4.04 |    0.03 |     461 B | 0.0191 |     - |     - |      40 B |              0 |                       0 |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |   100 | 203.17 ns | 0.634 ns | 0.593 ns |  2.55 |    0.01 |     343 B | 0.0191 |     - |     - |      40 B |              0 |                       0 |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |   100 | 230.83 ns | 1.088 ns | 0.964 ns |  2.90 |    0.02 |     505 B |      - |     - |     - |         - |              0 |                       0 |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |   100 |  75.78 ns | 0.403 ns | 0.357 ns |  0.95 |    0.01 |      41 B |      - |     - |     - |         - |              0 |                       1 |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |   100 |  79.79 ns | 0.245 ns | 0.205 ns |  1.00 |    0.01 |      41 B |      - |     - |     - |         - |              0 |                       1 |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |   100 | 614.42 ns | 3.229 ns | 3.021 ns |  7.72 |    0.05 |     378 B | 0.0153 |     - |     - |      32 B |              0 |                       1 |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |   100 | 216.79 ns | 0.643 ns | 0.602 ns |  2.73 |    0.01 |     343 B |      - |     - |     - |         - |              0 |                       1 |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |   100 | 340.95 ns | 1.174 ns | 1.040 ns |  4.29 |    0.02 |     433 B | 0.0191 |     - |     - |      40 B |              0 |                       0 |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |   100 | 164.34 ns | 0.595 ns | 0.497 ns |  2.07 |    0.01 |     315 B | 0.0191 |     - |     - |      40 B |              0 |                       0 |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |   100 | 222.88 ns | 1.141 ns | 0.952 ns |  2.80 |    0.02 |     491 B |      - |     - |     - |         - |              0 |                       0 |
