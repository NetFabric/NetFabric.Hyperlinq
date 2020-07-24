## Range.RangeSelectToArray

### Source
[RangeSelectToArray.cs](../LinqBenchmarks/Range/RangeSelectToArray.cs)

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
|               Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |     0 |   100 |  86.11 ns | 0.824 ns | 0.688 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |              0 |                       0 |
|                 Linq |     0 |   100 | 278.34 ns | 1.393 ns | 1.235 ns |  3.23 |    0.03 | 0.2446 |     - |     - |     512 B |              1 |                       1 |
|           LinqFaster |     0 |   100 | 284.94 ns | 1.971 ns | 1.747 ns |  3.31 |    0.04 | 0.4053 |     - |     - |     848 B |              1 |                       1 |
|           StructLinq |     0 |   100 | 543.74 ns | 3.649 ns | 3.234 ns |  6.32 |    0.06 | 0.2174 |     - |     - |     456 B |              2 |                       3 |
| StructLinq_IFunction |     0 |   100 | 380.56 ns | 2.244 ns | 1.989 ns |  4.42 |    0.04 | 0.2179 |     - |     - |     456 B |              2 |                       0 |
|            Hyperlinq |     0 |   100 | 262.86 ns | 1.253 ns | 1.111 ns |  3.05 |    0.03 | 0.2027 |     - |     - |     424 B |              1 |                       1 |
|       Hyperlinq_Pool |     0 |   100 | 278.54 ns | 1.847 ns | 1.727 ns |  3.23 |    0.03 | 0.0267 |     - |     - |      56 B |              1 |                       0 |
