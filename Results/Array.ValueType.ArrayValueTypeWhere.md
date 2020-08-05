## Array.ValueType.ArrayValueTypeWhere

### Source
[ArrayValueTypeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhere.cs)

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
|               Method |           Job |       Runtime | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | Code Size | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |-------------- |-------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|----------:|---------------:|------------------------:|
|              ForLoop |      .NET 4.8 |      .NET 4.8 |   100 |   466.5 ns |  1.01 ns |  0.94 ns |  1.00 |    0.00 |      - |     - |     - |         - |     302 B |              0 |                       0 |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |   100 |   480.0 ns |  1.45 ns |  1.35 ns |  1.03 |    0.00 |      - |     - |     - |         - |     303 B |              0 |                       0 |
|                 Linq |      .NET 4.8 |      .NET 4.8 |   100 | 1,200.9 ns |  8.21 ns |  7.68 ns |  2.57 |    0.02 | 0.0420 |     - |     - |      88 B |    1092 B |              1 |                       1 |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |   100 |   924.4 ns |  2.99 ns |  2.50 ns |  1.98 |    0.01 | 2.8896 |     - |     - |    6067 B |     890 B |              3 |                       1 |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |   100 |   797.0 ns |  3.24 ns |  3.03 ns |  1.71 |    0.01 |      - |     - |     - |         - |    1087 B |              0 |                       1 |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |   100 |   501.0 ns |  2.16 ns |  2.02 ns |  1.07 |    0.00 |      - |     - |     - |         - |     778 B |              0 |                       0 |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |   100 |   728.8 ns |  2.34 ns |  2.19 ns |  1.56 |    0.01 |      - |     - |     - |         - |    1002 B |              0 |                       1 |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |   100 |   479.4 ns |  1.28 ns |  1.13 ns |  1.03 |    0.00 |      - |     - |     - |         - |     290 B |              0 |                       0 |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |   100 |   480.2 ns |  2.04 ns |  1.91 ns |  1.03 |    0.00 |      - |     - |     - |         - |     291 B |              0 |                       0 |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,216.1 ns | 12.24 ns | 11.45 ns |  2.61 |    0.03 | 0.0381 |     - |     - |      80 B |    1087 B |              1 |                       1 |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |   100 |   964.0 ns |  6.37 ns |  5.65 ns |  2.07 |    0.01 | 2.8896 |     - |     - |    6048 B |     809 B |              5 |                       1 |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |   100 |   780.7 ns |  4.33 ns |  3.84 ns |  1.67 |    0.01 |      - |     - |     - |         - |     993 B |              0 |                       1 |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |   100 |   494.5 ns |  5.15 ns |  4.82 ns |  1.06 |    0.01 |      - |     - |     - |         - |     699 B |              0 |                       0 |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |   100 |   680.8 ns | 10.18 ns | 14.61 ns |  1.47 |    0.04 |      - |     - |     - |         - |     774 B |              0 |                       1 |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |   100 |   468.3 ns |  5.14 ns |  4.81 ns |  1.00 |    0.01 |      - |     - |     - |         - |     283 B |              0 |                       0 |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |   100 |   464.8 ns |  0.57 ns |  0.45 ns |  1.00 |    0.00 |      - |     - |     - |         - |     283 B |              0 |                       0 |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |   100 |   864.1 ns |  7.53 ns |  7.04 ns |  1.85 |    0.01 | 0.0381 |     - |     - |      80 B |    1065 B |              1 |                       1 |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |   100 |   934.8 ns |  9.74 ns |  9.11 ns |  2.00 |    0.02 | 2.8896 |     - |     - |    6048 B |     804 B |              1 |                       1 |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |   100 |   730.9 ns |  4.07 ns |  3.80 ns |  1.57 |    0.01 |      - |     - |     - |         - |     972 B |              0 |                       0 |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |   100 |   498.1 ns |  1.83 ns |  1.43 ns |  1.07 |    0.00 |      - |     - |     - |         - |     675 B |              0 |                       0 |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |   100 |   667.1 ns |  5.45 ns |  5.10 ns |  1.43 |    0.01 |      - |     - |     - |         - |     758 B |              0 |                       0 |
