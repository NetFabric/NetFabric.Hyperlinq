## Enumerable.Int32.EnumerableInt32WhereSelect

### Source
[EnumerableInt32WhereSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelect.cs)

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
|               Method |           Job |       Runtime | Count |       Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | Code Size | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |-------------- |-------------- |------ |-----------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|----------:|---------------:|------------------------:|
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |   100 |   494.4 ns | 2.34 ns | 2.07 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |     206 B |              0 |                       1 |
|                 Linq |      .NET 4.8 |      .NET 4.8 |   100 | 1,054.2 ns | 7.28 ns | 6.45 ns |  2.13 |    0.02 | 0.0763 |     - |     - |     160 B |    1498 B |              2 |                       1 |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |   100 |   967.6 ns | 4.45 ns | 3.94 ns |  1.96 |    0.01 | 0.0191 |     - |     - |      40 B |    1052 B |              1 |                       1 |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |   100 |   625.2 ns | 4.33 ns | 3.61 ns |  1.26 |    0.01 | 0.0191 |     - |     - |      40 B |     999 B |              0 |                       1 |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |   100 |   999.6 ns | 3.86 ns | 3.23 ns |  2.02 |    0.01 | 0.0191 |     - |     - |      40 B |     774 B |              1 |                       1 |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |   100 |   478.3 ns | 2.90 ns | 2.72 ns |  0.97 |    0.01 | 0.0191 |     - |     - |      40 B |     211 B |              1 |                       1 |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |   100 | 1,015.4 ns | 4.60 ns | 4.08 ns |  2.05 |    0.01 | 0.0763 |     - |     - |     160 B |    1699 B |              2 |                       1 |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |   100 |   972.1 ns | 4.00 ns | 3.34 ns |  1.97 |    0.01 | 0.0191 |     - |     - |      40 B |     967 B |              1 |                       1 |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |   100 |   657.9 ns | 3.19 ns | 2.83 ns |  1.33 |    0.01 | 0.0191 |     - |     - |      40 B |     941 B |              1 |                       1 |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |   100 |   976.7 ns | 4.09 ns | 3.83 ns |  1.98 |    0.01 | 0.0191 |     - |     - |      40 B |     723 B |              1 |                       1 |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |   100 |   474.9 ns | 2.39 ns | 2.24 ns |  0.96 |    0.01 | 0.0191 |     - |     - |      40 B |     199 B |              0 |                       1 |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |   100 | 1,031.9 ns | 4.69 ns | 4.38 ns |  2.09 |    0.01 | 0.0763 |     - |     - |     160 B |    1674 B |              2 |                       1 |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |   100 |   882.6 ns | 3.24 ns | 2.87 ns |  1.79 |    0.01 | 0.0191 |     - |     - |      40 B |     872 B |              1 |                       1 |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |   100 |   591.3 ns | 3.01 ns | 2.82 ns |  1.20 |    0.01 | 0.0191 |     - |     - |      40 B |     824 B |              1 |                       1 |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |   100 |   926.5 ns | 2.82 ns | 2.50 ns |  1.87 |    0.01 | 0.0191 |     - |     - |      40 B |     701 B |              1 |                       1 |
