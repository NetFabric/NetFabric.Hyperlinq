## Array.Int32.ArrayInt32WhereSelect

### Source
[ArrayInt32WhereSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelect.cs)

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
|               Method |           Job |       Runtime | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | Code Size | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |-------------- |-------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|----------:|---------------:|------------------------:|
|              ForLoop |      .NET 4.8 |      .NET 4.8 |   100 |  76.19 ns | 0.246 ns | 0.230 ns |  1.00 |    0.00 |      - |     - |     - |         - |      43 B |              0 |                       0 |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |   100 |  76.46 ns | 0.416 ns | 0.389 ns |  1.00 |    0.01 |      - |     - |     - |         - |      43 B |              0 |                       0 |
|                 Linq |      .NET 4.8 |      .NET 4.8 |   100 | 576.97 ns | 2.835 ns | 2.652 ns |  7.57 |    0.04 | 0.0496 |     - |     - |     104 B |    1498 B |              1 |                       1 |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |   100 | 378.71 ns | 2.598 ns | 2.430 ns |  4.97 |    0.04 | 0.3095 |     - |     - |     650 B |     741 B |              1 |                       1 |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |   100 | 460.56 ns | 1.454 ns | 1.289 ns |  6.05 |    0.02 |      - |     - |     - |         - |    1244 B |              0 |                       0 |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |   100 | 211.00 ns | 0.708 ns | 0.663 ns |  2.77 |    0.01 |      - |     - |     - |         - |    1081 B |              0 |                       0 |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |   100 | 500.49 ns | 1.798 ns | 1.682 ns |  6.57 |    0.03 |      - |     - |     - |         - |    1190 B |              0 |                       1 |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |   100 |  76.08 ns | 0.213 ns | 0.189 ns |  1.00 |    0.00 |      - |     - |     - |         - |      43 B |              0 |                       0 |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |   100 |  76.25 ns | 0.409 ns | 0.382 ns |  1.00 |    0.01 |      - |     - |     - |         - |      43 B |              0 |                       0 |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |   100 | 598.17 ns | 2.624 ns | 2.455 ns |  7.85 |    0.04 | 0.0496 |     - |     - |     104 B |    1699 B |              1 |                       1 |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |   100 | 388.00 ns | 1.732 ns | 1.446 ns |  5.10 |    0.02 | 0.3095 |     - |     - |     648 B |     687 B |              2 |                       1 |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |   100 | 482.65 ns | 1.648 ns | 1.542 ns |  6.34 |    0.03 |      - |     - |     - |         - |    1145 B |              0 |                       0 |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |   100 | 192.52 ns | 0.502 ns | 0.419 ns |  2.53 |    0.01 |      - |     - |     - |         - |     989 B |              0 |                       0 |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |   100 | 490.72 ns | 2.021 ns | 1.891 ns |  6.44 |    0.04 |      - |     - |     - |         - |     963 B |              0 |                       1 |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |   100 |  76.21 ns | 0.285 ns | 0.266 ns |  1.00 |    0.00 |      - |     - |     - |         - |      43 B |              0 |                       0 |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |   100 |  76.12 ns | 0.364 ns | 0.341 ns |  1.00 |    0.00 |      - |     - |     - |         - |      43 B |              0 |                       0 |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |   100 | 540.66 ns | 1.705 ns | 1.512 ns |  7.10 |    0.03 | 0.0496 |     - |     - |     104 B |    1674 B |              1 |                       1 |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |   100 | 357.46 ns | 2.487 ns | 2.205 ns |  4.69 |    0.03 | 0.3095 |     - |     - |     648 B |     674 B |              1 |                       1 |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |   100 | 423.29 ns | 1.620 ns | 1.436 ns |  5.56 |    0.03 |      - |     - |     - |         - |    1021 B |              0 |                       0 |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |   100 | 183.06 ns | 0.986 ns | 0.874 ns |  2.40 |    0.01 |      - |     - |     - |         - |     855 B |              0 |                       0 |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |   100 | 496.01 ns | 3.031 ns | 2.687 ns |  6.51 |    0.04 |      - |     - |     - |         - |     940 B |              0 |                       0 |
