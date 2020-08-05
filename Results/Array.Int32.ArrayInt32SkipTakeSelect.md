## Array.Int32.ArrayInt32SkipTakeSelect

### Source
[ArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeSelect.cs)

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
|              ForLoop |      .NET 4.8 |      .NET 4.8 | 1000 |   100 |    58.12 ns |  0.541 ns |  0.506 ns |  1.00 |    0.00 |      - |     - |     - |         - |      64 B |              0 |                       0 |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 2,390.96 ns |  5.540 ns |  4.325 ns | 41.21 |    0.34 | 0.0153 |     - |     - |      32 B |     214 B |              0 |                       1 |
|                 Linq |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 4,752.32 ns | 50.135 ns | 46.897 ns | 81.78 |    1.21 | 0.1068 |     - |     - |     225 B |    1099 B |              2 |                       2 |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 | 1000 |   100 |   378.52 ns |  2.710 ns |  2.535 ns |  6.51 |    0.08 | 0.6080 |     - |     - |    1276 B |     871 B |              1 |                       1 |
|           StructLinq |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 4,365.24 ns | 37.913 ns | 35.464 ns | 75.12 |    0.82 | 0.0763 |     - |     - |     161 B |     757 B |              2 |                       2 |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 4,190.50 ns | 34.808 ns | 32.559 ns | 72.11 |    0.81 | 0.0763 |     - |     - |     161 B |     818 B |              2 |                       2 |
|    Hyperlinq_Foreach |      .NET 4.8 |      .NET 4.8 | 1000 |   100 |   303.96 ns |  3.189 ns |  2.983 ns |  5.23 |    0.08 |      - |     - |     - |         - |    1249 B |              0 |                       0 |
|        Hyperlinq_For |      .NET 4.8 |      .NET 4.8 | 1000 |   100 |   366.53 ns |  4.468 ns |  3.960 ns |  6.30 |    0.09 |      - |     - |     - |         - |    1089 B |              0 |                       0 |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 |    53.80 ns |  0.167 ns |  0.139 ns |  0.93 |    0.01 |      - |     - |     - |         - |      64 B |              0 |                       0 |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 | 2,558.18 ns | 21.717 ns | 20.314 ns | 44.02 |    0.40 | 0.0153 |     - |     - |      32 B |     225 B |              1 |                       1 |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 | 1,040.48 ns |  9.333 ns |  8.730 ns | 17.91 |    0.24 | 0.0725 |     - |     - |     152 B |    1352 B |              1 |                       1 |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 |   355.98 ns |  3.496 ns |  3.270 ns |  6.13 |    0.08 | 0.6080 |     - |     - |    1272 B |     825 B |              1 |                       1 |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 | 1,041.25 ns |  6.478 ns |  6.060 ns | 17.92 |    0.14 | 0.0458 |     - |     - |      96 B |     773 B |              1 |                       1 |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 |   872.60 ns |  8.796 ns |  8.227 ns | 15.02 |    0.21 | 0.0458 |     - |     - |      96 B |     852 B |              1 |                       1 |
|    Hyperlinq_Foreach | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 |   234.47 ns |  1.259 ns |  0.983 ns |  4.04 |    0.03 |      - |     - |     - |         - |     635 B |              0 |                       0 |
|        Hyperlinq_For | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 |   307.29 ns |  3.337 ns |  3.121 ns |  5.29 |    0.08 |      - |     - |     - |         - |     614 B |              0 |                       0 |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 |    54.04 ns |  0.560 ns |  0.496 ns |  0.93 |    0.01 |      - |     - |     - |         - |      64 B |              0 |                       0 |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 | 2,320.23 ns | 12.963 ns | 10.825 ns | 39.95 |    0.38 | 0.0153 |     - |     - |      32 B |     215 B |              1 |                       1 |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 | 1,017.73 ns |  5.645 ns |  5.004 ns | 17.50 |    0.15 | 0.0725 |     - |     - |     152 B |    1318 B |              2 |                       1 |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 |   308.62 ns |  4.073 ns |  3.611 ns |  5.31 |    0.08 | 0.6080 |     - |     - |    1272 B |     807 B |              1 |                       1 |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 | 1,143.16 ns |  4.517 ns |  4.005 ns | 19.66 |    0.15 | 0.0458 |     - |     - |      96 B |     730 B |              1 |                       1 |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 |   900.38 ns |  3.275 ns |  3.064 ns | 15.49 |    0.15 | 0.0458 |     - |     - |      96 B |     793 B |              1 |                       1 |
|    Hyperlinq_Foreach | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 |   305.08 ns |  2.179 ns |  1.932 ns |  5.25 |    0.03 |      - |     - |     - |         - |     621 B |              0 |                       0 |
|        Hyperlinq_For | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 |   305.11 ns |  1.488 ns |  1.319 ns |  5.25 |    0.05 |      - |     - |     - |         - |     593 B |              0 |                       0 |
