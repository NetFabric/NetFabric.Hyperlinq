## Array.Int32.ArrayInt32Where

### Source
[ArrayInt32Where.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Where.cs)

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
|               Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |   100 | 122.70 ns | 0.914 ns | 0.763 ns |  1.00 |    0.00 |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop |   100 |  75.85 ns | 0.516 ns | 0.483 ns |  0.62 |    0.01 |      - |     - |     - |         - |              0 |                       0 |
|                 Linq |   100 | 447.25 ns | 2.026 ns | 1.895 ns |  3.64 |    0.03 | 0.0229 |     - |     - |      48 B |              0 |                       0 |
|           LinqFaster |   100 | 290.83 ns | 1.816 ns | 1.609 ns |  2.37 |    0.01 | 0.3095 |     - |     - |     648 B |              1 |                       1 |
|           StructLinq |   100 | 365.01 ns | 3.087 ns | 2.887 ns |  2.98 |    0.02 |      - |     - |     - |         - |              0 |                       0 |
| StructLinq_IFunction |   100 | 165.22 ns | 1.356 ns | 1.268 ns |  1.35 |    0.01 |      - |     - |     - |         - |              0 |                       0 |
|            Hyperlinq |   100 | 329.26 ns | 1.443 ns | 1.279 ns |  2.68 |    0.02 |      - |     - |     - |         - |              0 |                       0 |
