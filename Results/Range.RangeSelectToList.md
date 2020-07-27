## Range.RangeSelectToList

### Source
[RangeSelectToList.cs](../LinqBenchmarks/Range/RangeSelectToList.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta20](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta20)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Start | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |     0 |   100 | 300.8 ns | 1.82 ns | 1.62 ns |  1.00 |    0.00 | 0.5660 |     - |     - |    1184 B |              1 |                       0 |
|          ForeachLoop |     0 |   100 | 736.0 ns | 6.26 ns | 5.85 ns |  2.45 |    0.02 | 0.5922 |     - |     - |    1240 B |              3 |                       2 |
|                 Linq |     0 |   100 | 352.5 ns | 2.25 ns | 1.99 ns |  1.17 |    0.01 | 0.2599 |     - |     - |     544 B |              1 |                       1 |
|           LinqFaster |     0 |   100 | 333.1 ns | 1.34 ns | 1.18 ns |  1.11 |    0.01 | 0.6232 |     - |     - |    1304 B |              1 |                       1 |
|           StructLinq |     0 |   100 | 549.3 ns | 2.70 ns | 2.53 ns |  1.83 |    0.01 | 0.2327 |     - |     - |     488 B |              2 |                       3 |
| StructLinq_IFunction |     0 |   100 | 382.8 ns | 1.91 ns | 1.69 ns |  1.27 |    0.01 | 0.2332 |     - |     - |     488 B |              1 |                       0 |
|            Hyperlinq |     0 |   100 | 253.3 ns | 1.68 ns | 1.57 ns |  0.84 |    0.01 | 0.2446 |     - |     - |     512 B |              1 |                       1 |
