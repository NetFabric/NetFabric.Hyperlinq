## Array.Int32.ArrayInt32WhereSelect

### Source
[ArrayInt32WhereSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelect.cs)

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
|              ForLoop |   100 |  81.30 ns | 0.313 ns | 0.261 ns |  1.00 |    0.00 |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop |   100 |  75.98 ns | 0.411 ns | 0.385 ns |  0.93 |    0.01 |      - |     - |     - |         - |              0 |                       0 |
|                 Linq |   100 | 528.96 ns | 2.152 ns | 1.907 ns |  6.51 |    0.02 | 0.0496 |     - |     - |     104 B |              1 |                       1 |
|           LinqFaster |   100 | 372.16 ns | 2.038 ns | 1.906 ns |  4.58 |    0.03 | 0.3095 |     - |     - |     648 B |              1 |                       1 |
|           StructLinq |   100 | 444.72 ns | 1.636 ns | 1.531 ns |  5.47 |    0.03 |      - |     - |     - |         - |              0 |                       0 |
| StructLinq_IFunction |   100 | 182.49 ns | 0.711 ns | 0.630 ns |  2.24 |    0.01 |      - |     - |     - |         - |              0 |                       0 |
|            Hyperlinq |   100 | 494.19 ns | 2.021 ns | 1.792 ns |  6.08 |    0.03 |      - |     - |     - |         - |              0 |                       1 |
