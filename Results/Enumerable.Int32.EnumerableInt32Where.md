## Enumerable.Int32.EnumerableInt32Where

### Source
[EnumerableInt32Where.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Where.cs)

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
|               Method |           Job |       Runtime | Count |     Mean |    Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated | Code Size | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |-------------- |-------------- |------ |---------:|---------:|--------:|------:|-------:|------:|------:|----------:|----------:|---------------:|------------------------:|
|                 Linq |      .NET 4.8 |      .NET 4.8 |   100 | 850.9 ns |  5.67 ns | 5.30 ns |  1.00 | 0.0458 |     - |     - |      96 B |     867 B |              1 |                       1 |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |   100 | 878.8 ns | 11.23 ns | 9.38 ns |  1.03 | 0.0191 |     - |     - |      40 B |     611 B |              0 |                       0 |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |   100 | 592.0 ns |  4.72 ns | 4.42 ns |  0.70 | 0.0191 |     - |     - |      40 B |     545 B |              0 |                       1 |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |   100 | 859.3 ns |  8.72 ns | 7.73 ns |  1.01 | 0.0191 |     - |     - |      40 B |     604 B |              0 |                       0 |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |   100 | 850.0 ns |  7.11 ns | 6.66 ns |  1.00 | 0.0458 |     - |     - |      96 B |     860 B |              1 |                       1 |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |   100 | 806.0 ns |  7.90 ns | 7.39 ns |  0.95 | 0.0191 |     - |     - |      40 B |     547 B |              0 |                       1 |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |   100 | 586.0 ns |  3.51 ns | 3.29 ns |  0.69 | 0.0191 |     - |     - |      40 B |     509 B |              0 |                       1 |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |   100 | 778.3 ns |  6.62 ns | 5.87 ns |  0.91 | 0.0191 |     - |     - |      40 B |     569 B |              0 |                       1 |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |   100 | 879.1 ns |  7.95 ns | 6.64 ns |  1.03 | 0.0458 |     - |     - |      96 B |     845 B |              1 |                       1 |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |   100 | 759.6 ns |  7.07 ns | 6.61 ns |  0.89 | 0.0191 |     - |     - |      40 B |     501 B |              0 |                       0 |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |   100 | 531.4 ns |  2.88 ns | 2.69 ns |  0.62 | 0.0191 |     - |     - |      40 B |     467 B |              0 |                       1 |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |   100 | 897.5 ns |  5.04 ns | 4.47 ns |  1.05 | 0.0191 |     - |     - |      40 B |     553 B |              0 |                       0 |
