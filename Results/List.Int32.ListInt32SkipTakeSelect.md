## List.Int32.ListInt32SkipTakeSelect

### Source
[ListInt32SkipTakeSelect.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeSelect.cs)

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
|               Method |           Job |       Runtime | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD | Code Size |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |-------------- |-------------- |----- |------ |------------:|----------:|----------:|------:|--------:|----------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |      .NET 4.8 |      .NET 4.8 | 1000 |   100 |    85.15 ns |  0.331 ns |  0.276 ns |  1.00 |    0.00 |     178 B |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 3,486.43 ns | 16.404 ns | 14.542 ns | 40.94 |    0.20 |     214 B | 0.0191 |     - |     - |      40 B |              1 |                       1 |
|                 Linq |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 6,028.01 ns | 26.111 ns | 21.804 ns | 70.79 |    0.32 |    1099 B | 0.1068 |     - |     - |     233 B |              4 |                       3 |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 1,025.76 ns |  6.954 ns |  6.164 ns | 12.03 |    0.08 |    1085 B | 0.6638 |     - |     - |    1396 B |              4 |                       2 |
|           StructLinq |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 5,382.62 ns | 20.644 ns | 18.300 ns | 63.22 |    0.21 |     757 B | 0.0763 |     - |     - |     169 B |              3 |                       3 |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 | 1000 |   100 | 5,341.61 ns | 27.280 ns | 25.518 ns | 62.75 |    0.23 |     818 B | 0.0763 |     - |     - |     169 B |              3 |                       2 |
|    Hyperlinq_Foreach |      .NET 4.8 |      .NET 4.8 | 1000 |   100 |   310.48 ns |  2.479 ns |  2.070 ns |  3.65 |    0.03 |    1306 B |      - |     - |     - |         - |              0 |                       0 |
|        Hyperlinq_For |      .NET 4.8 |      .NET 4.8 | 1000 |   100 |   355.49 ns |  1.684 ns |  1.493 ns |  4.18 |    0.03 |    1143 B |      - |     - |     - |         - |              0 |                       0 |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 |    84.18 ns |  0.403 ns |  0.337 ns |  0.99 |    0.00 |      80 B |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 | 3,768.23 ns | 15.507 ns | 13.747 ns | 44.27 |    0.22 |     225 B | 0.0191 |     - |     - |      40 B |              2 |                       2 |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 |   986.71 ns | 10.100 ns |  9.448 ns | 11.58 |    0.11 |    1352 B | 0.0725 |     - |     - |     152 B |              2 |                       1 |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 |   711.40 ns |  6.377 ns |  5.653 ns |  8.36 |    0.08 |    1068 B | 0.6533 |     - |     - |    1368 B |              2 |                       2 |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 |   986.92 ns |  4.653 ns |  4.352 ns | 11.59 |    0.08 |     773 B | 0.0458 |     - |     - |      96 B |              1 |                       1 |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 |   821.48 ns |  2.957 ns |  2.622 ns |  9.65 |    0.06 |     852 B | 0.0458 |     - |     - |      96 B |              1 |                       1 |
|    Hyperlinq_Foreach | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 |   313.05 ns |  1.641 ns |  1.535 ns |  3.68 |    0.02 |     680 B |      - |     - |     - |         - |              0 |                       0 |
|        Hyperlinq_For | .NET Core 3.1 | .NET Core 3.1 | 1000 |   100 |   261.98 ns |  1.089 ns |  0.965 ns |  3.08 |    0.01 |     664 B |      - |     - |     - |         - |              0 |                       0 |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 |    71.76 ns |  0.265 ns |  0.235 ns |  0.84 |    0.00 |      80 B |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 | 3,515.61 ns | 10.438 ns |  8.716 ns | 41.29 |    0.12 |     215 B | 0.0191 |     - |     - |      40 B |              1 |                       2 |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 |   933.91 ns |  5.839 ns |  5.177 ns | 10.97 |    0.05 |    1318 B | 0.0725 |     - |     - |     152 B |              2 |                       1 |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 |   708.18 ns |  3.469 ns |  3.245 ns |  8.32 |    0.05 |    1068 B | 0.6533 |     - |     - |    1368 B |              3 |                       2 |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 | 1,010.87 ns |  2.398 ns |  2.002 ns | 11.87 |    0.03 |     730 B | 0.0458 |     - |     - |      96 B |              1 |                       1 |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 |   784.84 ns |  3.379 ns |  3.161 ns |  9.22 |    0.05 |     793 B | 0.0458 |     - |     - |      96 B |              1 |                       1 |
|    Hyperlinq_Foreach | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 |   279.82 ns |  1.127 ns |  1.055 ns |  3.29 |    0.01 |     662 B |      - |     - |     - |         - |              0 |                       0 |
|        Hyperlinq_For | .NET Core 5.0 | .NET Core 5.0 | 1000 |   100 |   253.15 ns |  1.111 ns |  0.928 ns |  2.97 |    0.01 |     634 B |      - |     - |     - |         - |              0 |                       0 |
