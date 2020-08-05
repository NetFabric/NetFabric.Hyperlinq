## Enumerable.Int32.EnumerableInt32Select

### Source
[EnumerableInt32Select.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Select.cs)

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
|               Method |           Job |       Runtime | Count |       Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated | Code Size | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |-------------- |-------------- |------ |-----------:|--------:|--------:|------:|-------:|------:|------:|----------:|----------:|---------------:|------------------------:|
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |   100 |   495.4 ns | 2.06 ns | 1.72 ns |  1.00 | 0.0191 |     - |     - |      40 B |     202 B |              0 |                       1 |
|                 Linq |      .NET 4.8 |      .NET 4.8 |   100 | 1,053.0 ns | 4.52 ns | 3.77 ns |  2.13 | 0.0496 |     - |     - |     104 B |     900 B |              1 |                       1 |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |   100 |   658.8 ns | 2.91 ns | 2.72 ns |  1.33 | 0.0191 |     - |     - |      40 B |     561 B |              1 |                       1 |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |   100 |   505.2 ns | 3.78 ns | 3.53 ns |  1.02 | 0.0191 |     - |     - |      40 B |     622 B |              0 |                       1 |
|    Hyperlinq_Foreach |      .NET 4.8 |      .NET 4.8 |   100 |   905.2 ns | 3.44 ns | 3.21 ns |  1.83 | 0.0191 |     - |     - |      40 B |     586 B |              1 |                       1 |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |   100 |   419.6 ns | 1.49 ns | 1.32 ns |  0.85 | 0.0191 |     - |     - |      40 B |     207 B |              0 |                       1 |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,017.1 ns | 5.12 ns | 4.54 ns |  2.05 | 0.0458 |     - |     - |      96 B |    1073 B |              1 |                       1 |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |   100 |   679.1 ns | 3.03 ns | 2.84 ns |  1.37 | 0.0191 |     - |     - |      40 B |     494 B |              1 |                       1 |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |   100 |   485.1 ns | 3.10 ns | 2.90 ns |  0.98 | 0.0191 |     - |     - |      40 B |     585 B |              1 |                       1 |
|    Hyperlinq_Foreach | .NET Core 3.1 | .NET Core 3.1 |   100 |   822.0 ns | 3.95 ns | 3.50 ns |  1.66 | 0.0191 |     - |     - |      40 B |     507 B |              1 |                       1 |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |   100 |   446.7 ns | 2.52 ns | 2.24 ns |  0.90 | 0.0191 |     - |     - |      40 B |     195 B |              0 |                       1 |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |   100 | 1,040.4 ns | 4.35 ns | 3.86 ns |  2.10 | 0.0458 |     - |     - |      96 B |    1057 B |              1 |                       1 |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |   100 |   631.3 ns | 1.38 ns | 1.29 ns |  1.27 | 0.0191 |     - |     - |      40 B |     469 B |              0 |                       0 |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |   100 |   451.8 ns | 1.18 ns | 0.98 ns |  0.91 | 0.0191 |     - |     - |      40 B |     543 B |              0 |                       1 |
|    Hyperlinq_Foreach | .NET Core 5.0 | .NET Core 5.0 |   100 |   769.2 ns | 3.85 ns | 3.60 ns |  1.55 | 0.0191 |     - |     - |      40 B |     480 B |              1 |                       1 |
