## Range.RangeSelect

### Source
[RangeSelect.cs](../LinqBenchmarks/Range/RangeSelect.cs)

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
|              ForLoop |     0 |   100 |  36.84 ns | 0.177 ns | 0.148 ns |  1.00 |    0.00 |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop |     0 |   100 | 457.67 ns | 1.169 ns | 1.093 ns | 12.42 |    0.06 | 0.0267 |     - |     - |      56 B |              1 |                       1 |
|                 Linq |     0 |   100 | 636.93 ns | 2.641 ns | 2.341 ns | 17.29 |    0.10 | 0.0420 |     - |     - |      88 B |              1 |                       1 |
|           LinqFaster |     0 |   100 | 343.79 ns | 1.206 ns | 1.007 ns |  9.33 |    0.04 | 0.4053 |     - |     - |     848 B |              1 |                       1 |
|           StructLinq |     0 |   100 | 256.34 ns | 1.220 ns | 1.019 ns |  6.96 |    0.03 |      - |     - |     - |         - |              0 |                       0 |
| StructLinq_IFunction |     0 |   100 | 172.97 ns | 0.430 ns | 0.359 ns |  4.70 |    0.02 |      - |     - |     - |         - |              0 |                       0 |
|    Hyperlinq_Foreach |     0 |   100 | 379.09 ns | 2.525 ns | 2.238 ns | 10.29 |    0.08 |      - |     - |     - |         - |              0 |                       0 |
|        Hyperlinq_For |     0 |   100 | 373.67 ns | 2.496 ns | 2.212 ns | 10.15 |    0.09 |      - |     - |     - |         - |              0 |                       1 |
