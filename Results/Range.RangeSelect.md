## Range.RangeSelect

### Source
[RangeSelect.cs](../LinqBenchmarks/Range/RangeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta21](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta21)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | Code Size | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|----------:|---------------:|------------------------:|
|              ForLoop |     0 |   100 |  40.26 ns | 0.156 ns | 0.130 ns |  1.00 |    0.00 |      - |     - |     - |         - |      28 B |              0 |                       0 |
|          ForeachLoop |     0 |   100 | 508.62 ns | 3.131 ns | 2.776 ns | 12.63 |    0.05 | 0.0267 |     - |     - |      56 B |     349 B |              1 |                       1 |
|                 Linq |     0 |   100 | 639.52 ns | 5.391 ns | 5.042 ns | 15.87 |    0.14 | 0.0420 |     - |     - |      88 B |    1294 B |              1 |                       1 |
|           LinqFaster |     0 |   100 | 336.58 ns | 3.827 ns | 3.196 ns |  8.36 |    0.07 | 0.4053 |     - |     - |     848 B |     616 B |              1 |                       1 |
|           StructLinq |     0 |   100 | 258.36 ns | 1.120 ns | 0.935 ns |  6.42 |    0.02 |      - |     - |     - |         - |     489 B |              0 |                       0 |
| StructLinq_IFunction |     0 |   100 | 172.99 ns | 0.705 ns | 0.660 ns |  4.30 |    0.02 |      - |     - |     - |         - |     460 B |              0 |                       0 |
|    Hyperlinq_Foreach |     0 |   100 | 333.30 ns | 1.626 ns | 1.441 ns |  8.28 |    0.05 |      - |     - |     - |         - |     860 B |              0 |                       1 |
|        Hyperlinq_For |     0 |   100 | 435.62 ns | 2.065 ns | 1.830 ns | 10.82 |    0.05 |      - |     - |     - |         - |     721 B |              0 |                       1 |
