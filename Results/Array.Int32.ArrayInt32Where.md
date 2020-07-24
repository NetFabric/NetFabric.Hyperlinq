## Array.Int32.ArrayInt32Where

### Source
[ArrayInt32Where.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Where.cs)

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
|               Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |   100 |  80.83 ns | 0.598 ns | 0.559 ns |  1.00 |    0.00 |      - |     - |     - |         - |              0 |                       1 |
|          ForeachLoop |   100 |  66.00 ns | 0.612 ns | 0.572 ns |  0.82 |    0.01 |      - |     - |     - |         - |              0 |                       1 |
|                 Linq |   100 | 406.68 ns | 2.523 ns | 2.360 ns |  5.03 |    0.05 | 0.0229 |     - |     - |      48 B |              1 |                       1 |
|           LinqFaster |   100 | 301.13 ns | 2.232 ns | 2.087 ns |  3.73 |    0.02 | 0.3095 |     - |     - |     648 B |              1 |                       1 |
|           StructLinq |   100 | 311.20 ns | 1.618 ns | 1.351 ns |  3.85 |    0.03 |      - |     - |     - |         - |              0 |                       0 |
| StructLinq_IFunction |   100 | 164.70 ns | 0.622 ns | 0.582 ns |  2.04 |    0.01 |      - |     - |     - |         - |              0 |                       0 |
|            Hyperlinq |   100 | 363.79 ns | 1.139 ns | 1.010 ns |  4.50 |    0.02 |      - |     - |     - |         - |              0 |                       0 |
