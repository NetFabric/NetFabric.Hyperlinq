## Array.Int32.ArrayInt32Where

### Source
[ArrayInt32Where.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Where.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta21](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta21)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD | Code Size |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |----------:|---------:|---------:|------:|--------:|----------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |   100 |  66.85 ns | 0.346 ns | 0.306 ns |  1.00 |    0.00 |      42 B |      - |     - |     - |         - |              0 |                       1 |
|          ForeachLoop |   100 |  66.41 ns | 0.264 ns | 0.221 ns |  0.99 |    0.01 |      42 B |      - |     - |     - |         - |              0 |                       1 |
|                 Linq |   100 | 406.79 ns | 2.787 ns | 2.470 ns |  6.09 |    0.04 |     887 B | 0.0229 |     - |     - |      48 B |              1 |                       1 |
|           LinqFaster |   100 | 319.59 ns | 3.771 ns | 3.343 ns |  4.78 |    0.05 |     651 B | 0.3095 |     - |     - |     648 B |              2 |                       1 |
|           StructLinq |   100 | 313.96 ns | 1.867 ns | 1.655 ns |  4.70 |    0.04 |     527 B |      - |     - |     - |         - |              0 |                       1 |
| StructLinq_IFunction |   100 | 166.79 ns | 0.605 ns | 0.537 ns |  2.50 |    0.01 |     423 B |      - |     - |     - |         - |              0 |                       0 |
|            Hyperlinq |   100 | 360.84 ns | 2.143 ns | 2.004 ns |  5.39 |    0.04 |     532 B |      - |     - |     - |         - |              0 |                       1 |
