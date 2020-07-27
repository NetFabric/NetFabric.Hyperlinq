## Range.RangeSelectToArray

### Source
[RangeSelectToArray.cs](../LinqBenchmarks/Range/RangeSelectToArray.cs)

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
|              ForLoop |     0 |   100 |  88.49 ns | 0.492 ns | 0.411 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |              0 |                       0 |
|                 Linq |     0 |   100 | 225.07 ns | 1.704 ns | 1.423 ns |  2.54 |    0.02 | 0.2446 |     - |     - |     512 B |              1 |                       0 |
|           LinqFaster |     0 |   100 | 281.76 ns | 1.962 ns | 1.739 ns |  3.18 |    0.03 | 0.4053 |     - |     - |     848 B |              1 |                       1 |
|           StructLinq |     0 |   100 | 551.45 ns | 3.050 ns | 2.704 ns |  6.24 |    0.04 | 0.2174 |     - |     - |     456 B |              2 |                       3 |
| StructLinq_IFunction |     0 |   100 | 379.72 ns | 2.329 ns | 1.819 ns |  4.29 |    0.03 | 0.2179 |     - |     - |     456 B |              1 |                       0 |
|            Hyperlinq |     0 |   100 | 235.17 ns | 1.941 ns | 1.721 ns |  2.66 |    0.02 | 0.2027 |     - |     - |     424 B |              1 |                       0 |
|       Hyperlinq_Pool |     0 |   100 | 305.79 ns | 1.527 ns | 1.429 ns |  3.45 |    0.02 | 0.0267 |     - |     - |      56 B |              0 |                       0 |
