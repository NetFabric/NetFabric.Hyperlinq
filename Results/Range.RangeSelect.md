## Range.RangeSelect

### Source
[RangeSelect.cs](../LinqBenchmarks/Range/RangeSelect.cs)

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
|               Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |     0 |   100 |  36.69 ns | 0.213 ns | 0.178 ns |  1.00 |    0.00 |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop |     0 |   100 | 449.24 ns | 2.211 ns | 2.069 ns | 12.24 |    0.08 | 0.0267 |     - |     - |      56 B |              1 |                       1 |
|                 Linq |     0 |   100 | 633.33 ns | 5.007 ns | 4.439 ns | 17.27 |    0.14 | 0.0420 |     - |     - |      88 B |              1 |                       1 |
|           LinqFaster |     0 |   100 | 338.60 ns | 2.388 ns | 2.116 ns |  9.23 |    0.10 | 0.4053 |     - |     - |     848 B |              1 |                       1 |
|           StructLinq |     0 |   100 | 252.08 ns | 1.200 ns | 1.064 ns |  6.87 |    0.05 |      - |     - |     - |         - |              0 |                       0 |
| StructLinq_IFunction |     0 |   100 | 171.45 ns | 1.375 ns | 1.286 ns |  4.67 |    0.03 |      - |     - |     - |         - |              0 |                       0 |
|    Hyperlinq_Foreach |     0 |   100 | 376.66 ns | 3.606 ns | 3.373 ns | 10.27 |    0.12 |      - |     - |     - |         - |              0 |                       0 |
|        Hyperlinq_For |     0 |   100 | 382.42 ns | 1.648 ns | 1.541 ns | 10.42 |    0.07 |      - |     - |     - |         - |              0 |                       0 |
