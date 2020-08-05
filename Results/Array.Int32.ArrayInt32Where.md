## Array.Int32.ArrayInt32Where

### Source
[ArrayInt32Where.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Where.cs)

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
|              ForLoop |      .NET 4.8 |      .NET 4.8 |   100 |  76.33 ns | 0.355 ns | 0.332 ns |  1.00 |    0.00 |      - |     - |     - |         - |      42 B |              0 |                       0 |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |   100 |  76.57 ns | 0.211 ns | 0.197 ns |  1.00 |    0.00 |      - |     - |     - |         - |      42 B |              0 |                       0 |
|                 Linq |      .NET 4.8 |      .NET 4.8 |   100 | 434.90 ns | 2.169 ns | 1.923 ns |  5.70 |    0.04 | 0.0229 |     - |     - |      48 B |     867 B |              0 |                       0 |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |   100 | 313.23 ns | 0.789 ns | 0.699 ns |  4.10 |    0.02 | 0.3095 |     - |     - |     650 B |     526 B |              1 |                       1 |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |   100 | 345.95 ns | 1.353 ns | 1.130 ns |  4.53 |    0.03 |      - |     - |     - |         - |     645 B |              0 |                       0 |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |   100 | 187.78 ns | 0.904 ns | 0.846 ns |  2.46 |    0.01 |      - |     - |     - |         - |     520 B |              0 |                       0 |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |   100 | 375.28 ns | 1.411 ns | 1.251 ns |  4.92 |    0.03 |      - |     - |     - |         - |     861 B |              0 |                       0 |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |   100 |  76.04 ns | 0.460 ns | 0.407 ns |  1.00 |    0.01 |      - |     - |     - |         - |      42 B |              0 |                       0 |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |   100 |  76.51 ns | 0.319 ns | 0.283 ns |  1.00 |    0.01 |      - |     - |     - |         - |      42 B |              0 |                       0 |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |   100 | 450.27 ns | 1.413 ns | 1.253 ns |  5.90 |    0.03 | 0.0229 |     - |     - |      48 B |     860 B |              1 |                       1 |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |   100 | 292.52 ns | 2.023 ns | 1.794 ns |  3.83 |    0.04 | 0.3095 |     - |     - |     648 B |     481 B |              1 |                       1 |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |   100 | 301.44 ns | 1.591 ns | 1.488 ns |  3.95 |    0.03 |      - |     - |     - |         - |     558 B |              0 |                       0 |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |   100 | 173.01 ns | 0.632 ns | 0.592 ns |  2.27 |    0.01 |      - |     - |     - |         - |     452 B |              0 |                       0 |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |   100 | 351.74 ns | 1.497 ns | 1.400 ns |  4.61 |    0.02 |      - |     - |     - |         - |     541 B |              0 |                       1 |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |   100 |  76.36 ns | 0.336 ns | 0.314 ns |  1.00 |    0.01 |      - |     - |     - |         - |      42 B |              0 |                       0 |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |   100 |  76.40 ns | 0.229 ns | 0.215 ns |  1.00 |    0.01 |      - |     - |     - |         - |      42 B |              0 |                       0 |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |   100 | 460.96 ns | 1.956 ns | 1.830 ns |  6.04 |    0.04 | 0.0229 |     - |     - |      48 B |     845 B |              1 |                       1 |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |   100 | 315.82 ns | 1.404 ns | 1.244 ns |  4.14 |    0.03 | 0.3095 |     - |     - |     648 B |     478 B |              1 |                       1 |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |   100 | 317.95 ns | 1.206 ns | 1.007 ns |  4.17 |    0.03 |      - |     - |     - |         - |     527 B |              0 |                       0 |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |   100 | 166.61 ns | 0.538 ns | 0.476 ns |  2.18 |    0.01 |      - |     - |     - |         - |     423 B |              0 |                       0 |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |   100 | 344.83 ns | 1.492 ns | 1.395 ns |  4.52 |    0.02 |      - |     - |     - |         - |     532 B |              0 |                       1 |
