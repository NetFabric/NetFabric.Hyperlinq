## List.ValueType.ListValueTypeDistinct

### Source
[ListValueTypeDistinct.cs](../LinqBenchmarks/List/ValueType/ListValueTypeDistinct.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta19](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta19)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Duplicates | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |----------- |------ |------------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |          4 |   100 |    994.7 ns |  16.84 ns |  14.92 ns |  1.00 |    0.00 |  0.6294 |     - |     - |    1320 B |              7 |                       2 |
|          ForeachLoop |          4 |   100 |  1,272.8 ns |  20.35 ns |  18.04 ns |  1.28 |    0.03 |  0.6294 |     - |     - |    1320 B |              7 |                       3 |
|                 Linq |          4 |   100 | 43,631.2 ns | 765.28 ns | 597.48 ns | 43.80 |    1.02 | 72.4487 |     - |     - |  151528 B |            343 |                     106 |
|           LinqFaster |          4 |   100 |    355.9 ns |   4.63 ns |   4.33 ns |  0.36 |    0.01 |  0.0114 |     - |     - |      24 B |              0 |                       1 |
|           StructLinq |          4 |   100 | 45,825.0 ns | 513.26 ns | 428.60 ns | 46.04 |    0.88 | 70.9229 |     - |     - |  148400 B |            355 |                     107 |
| StructLinq_IFunction |          4 |   100 |  5,941.3 ns | 113.08 ns | 120.99 ns |  5.98 |    0.13 |       - |     - |     - |         - |              2 |                      10 |
|            Hyperlinq |          4 |   100 | 41,603.0 ns | 434.19 ns | 406.14 ns | 41.87 |    0.85 | 70.9229 |     - |     - |  148400 B |            315 |                      83 |
