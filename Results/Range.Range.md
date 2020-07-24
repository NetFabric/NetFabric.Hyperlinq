## Range.Range

### Source
[Range.cs](../LinqBenchmarks/Range/Range.cs)

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
|            Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|------------------ |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|           ForLoop |     0 |   100 |  34.64 ns | 0.196 ns | 0.183 ns |  1.00 |    0.00 |      - |     - |     - |         - |              0 |                       0 |
|       ForeachLoop |     0 |   100 | 479.49 ns | 2.561 ns | 2.270 ns | 13.84 |    0.09 | 0.0267 |     - |     - |      56 B |              1 |                       1 |
|              Linq |     0 |   100 | 426.36 ns | 2.496 ns | 2.084 ns | 12.30 |    0.11 | 0.0191 |     - |     - |      40 B |              0 |                       1 |
|        LinqFaster |     0 |   100 | 126.36 ns | 1.426 ns | 1.333 ns |  3.65 |    0.04 | 0.2027 |     - |     - |     424 B |              1 |                       1 |
|        StructLinq |     0 |   100 |  41.13 ns | 0.285 ns | 0.267 ns |  1.19 |    0.01 |      - |     - |     - |         - |              0 |                       0 |
| Hyperlinq_Foreach |     0 |   100 | 168.51 ns | 0.851 ns | 0.796 ns |  4.87 |    0.04 |      - |     - |     - |         - |              0 |                       0 |
|     Hyperlinq_For |     0 |   100 |  63.59 ns | 0.282 ns | 0.250 ns |  1.84 |    0.01 |      - |     - |     - |         - |              0 |                       0 |
