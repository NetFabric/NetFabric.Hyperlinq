## Range.RangeSelectToList

### Source
[RangeSelectToList.cs](../LinqBenchmarks/Range/RangeSelectToList.cs)

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
|               Method | Start | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |     0 |   100 | 282.9 ns | 2.04 ns | 1.90 ns |  1.00 |    0.00 | 0.5660 |     - |     - |    1184 B |              1 |                       0 |
|          ForeachLoop |     0 |   100 | 683.7 ns | 4.70 ns | 3.93 ns |  2.41 |    0.02 | 0.5922 |     - |     - |    1240 B |              3 |                       3 |
|                 Linq |     0 |   100 | 296.8 ns | 1.36 ns | 1.14 ns |  1.05 |    0.01 | 0.2599 |     - |     - |     544 B |              1 |                       1 |
|           LinqFaster |     0 |   100 | 321.8 ns | 1.85 ns | 1.64 ns |  1.14 |    0.01 | 0.6232 |     - |     - |    1304 B |              2 |                       1 |
|           StructLinq |     0 |   100 | 514.2 ns | 3.13 ns | 2.93 ns |  1.82 |    0.02 | 0.2327 |     - |     - |     488 B |              2 |                       3 |
| StructLinq_IFunction |     0 |   100 | 384.7 ns | 1.72 ns | 1.44 ns |  1.36 |    0.01 | 0.2332 |     - |     - |     488 B |              2 |                       0 |
|            Hyperlinq |     0 |   100 | 261.9 ns | 1.74 ns | 1.54 ns |  0.93 |    0.01 | 0.2446 |     - |     - |     512 B |              1 |                       1 |
