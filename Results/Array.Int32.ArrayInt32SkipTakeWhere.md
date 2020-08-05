## Array.Int32.ArrayInt32SkipTakeWhere

### Source
[ArrayInt32SkipTakeWhere.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeWhere.cs)

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
|               Method |           Job |       Runtime | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | Code Size | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |-------------- |-------------- |----- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|----------:|---------------:|------------------------:|
|              ForLoop |      .NET 4.8 |      .NET 4.8 | 1000 |   100 |    76.36 ns |  0.262 ns |  0.232 ns |  1.00 |    0.00 |      - |     - |     - |         - |      69 B |              0 |                       0 |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 2,458.73 ns | 16.990 ns | 15.892 ns | 32.20 |    0.19 | 0.0153 |     - |     - |      32 B |     217 B |              1 |                       1 |
|                 Linq |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 4,659.28 ns | 16.232 ns | 13.554 ns | 61.02 |    0.24 | 0.0992 |     - |     - |     217 B |    1066 B |              3 |                       3 |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 | 1000 |   100 |   375.55 ns |  2.657 ns |  2.486 ns |  4.92 |    0.04 | 0.7153 |     - |     - |    1500 B |     879 B |              1 |                       1 |
|           StructLinq |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 4,544.81 ns | 16.447 ns | 14.580 ns | 59.52 |    0.30 | 0.0763 |     - |     - |     161 B |     807 B |              3 |                       3 |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 4,500.51 ns | 19.811 ns | 18.531 ns | 58.93 |    0.23 | 0.0763 |     - |     - |     161 B |     738 B |              3 |                       3 |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 | 1000 |   100 |   425.39 ns |  1.144 ns |  1.014 ns |  5.57 |    0.02 |      - |     - |     - |         - |    1330 B |              0 |                       1 |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 |    63.27 ns |  0.352 ns |  0.294 ns |  0.83 |    0.00 |      - |     - |     - |         - |      69 B |              0 |                       0 |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 | 2,644.17 ns | 10.470 ns |  9.794 ns | 34.64 |    0.10 | 0.0153 |     - |     - |      32 B |     228 B |              1 |                       1 |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 | 1,313.55 ns |  5.636 ns |  5.272 ns | 17.21 |    0.07 | 0.0725 |     - |     - |     152 B |    1139 B |              2 |                       1 |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 |   402.23 ns |  5.318 ns |  4.714 ns |  5.27 |    0.07 | 0.7153 |     - |     - |    1496 B |     836 B |              2 |                       1 |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 | 1,253.62 ns | 13.167 ns | 12.317 ns | 16.44 |    0.14 | 0.0458 |     - |     - |      96 B |     826 B |              1 |                       1 |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 |   962.34 ns |  5.786 ns |  5.413 ns | 12.61 |    0.09 | 0.0458 |     - |     - |      96 B |     778 B |              1 |                       1 |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 |   328.13 ns |  1.268 ns |  1.186 ns |  4.30 |    0.02 |      - |     - |     - |         - |     710 B |              0 |                       1 |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 |   124.10 ns |  0.410 ns |  0.364 ns |  1.63 |    0.01 |      - |     - |     - |         - |      69 B |              0 |                       1 |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 | 2,357.17 ns | 12.913 ns | 12.078 ns | 30.87 |    0.20 | 0.0153 |     - |     - |      32 B |     218 B |              1 |                       2 |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 | 1,406.72 ns |  4.939 ns |  4.620 ns | 18.42 |    0.09 | 0.0725 |     - |     - |     152 B |    1106 B |              2 |                       1 |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 |   346.21 ns |  3.769 ns |  3.341 ns |  4.53 |    0.05 | 0.7153 |     - |     - |    1496 B |     821 B |              1 |                       1 |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 | 1,198.08 ns |  5.080 ns |  4.752 ns | 15.69 |    0.06 | 0.0458 |     - |     - |      96 B |     762 B |              1 |                       1 |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 |   925.68 ns |  3.221 ns |  2.855 ns | 12.12 |    0.05 | 0.0458 |     - |     - |      96 B |     717 B |              1 |                       1 |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 |   335.08 ns |  1.287 ns |  1.204 ns |  4.39 |    0.02 |      - |     - |     - |         - |     697 B |              0 |                       0 |
