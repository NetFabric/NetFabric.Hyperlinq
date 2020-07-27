## Range.Range

### Source
[Range.cs](../LinqBenchmarks/Range/Range.cs)

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
|            Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|------------------ |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|           ForLoop |     0 |   100 |  33.62 ns | 0.172 ns | 0.144 ns |  1.00 |    0.00 |      - |     - |     - |         - |              0 |                       0 |
|       ForeachLoop |     0 |   100 | 503.88 ns | 2.382 ns | 2.228 ns | 14.98 |    0.08 | 0.0267 |     - |     - |      56 B |              1 |                       1 |
|              Linq |     0 |   100 | 424.73 ns | 2.825 ns | 2.642 ns | 12.65 |    0.10 | 0.0191 |     - |     - |      40 B |              0 |                       0 |
|        LinqFaster |     0 |   100 | 122.89 ns | 0.856 ns | 0.759 ns |  3.65 |    0.02 | 0.2027 |     - |     - |     424 B |              0 |                       1 |
|        StructLinq |     0 |   100 |  40.86 ns | 0.321 ns | 0.285 ns |  1.21 |    0.01 |      - |     - |     - |         - |              0 |                       0 |
| Hyperlinq_Foreach |     0 |   100 | 170.09 ns | 1.332 ns | 1.246 ns |  5.07 |    0.04 |      - |     - |     - |         - |              0 |                       0 |
|     Hyperlinq_For |     0 |   100 |  63.79 ns | 0.426 ns | 0.355 ns |  1.90 |    0.01 |      - |     - |     - |         - |              0 |                       0 |
