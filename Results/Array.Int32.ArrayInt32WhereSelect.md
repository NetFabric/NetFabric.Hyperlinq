## Array.Int32.ArrayInt32WhereSelect

### Source
[ArrayInt32WhereSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelect.cs)

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
|              ForLoop |   100 |  68.28 ns | 0.216 ns | 0.192 ns |  1.00 |    0.00 |      - |     - |     - |         - |              0 |                       1 |
|          ForeachLoop |   100 |  77.99 ns | 1.573 ns | 2.101 ns |  1.15 |    0.03 |      - |     - |     - |         - |              0 |                       0 |
|                 Linq |   100 | 546.76 ns | 4.484 ns | 3.975 ns |  8.01 |    0.05 | 0.0496 |     - |     - |     104 B |              1 |                       1 |
|           LinqFaster |   100 | 447.22 ns | 2.729 ns | 2.553 ns |  6.55 |    0.04 | 0.3095 |     - |     - |     648 B |              2 |                       1 |
|           StructLinq |   100 | 423.83 ns | 2.823 ns | 2.640 ns |  6.21 |    0.04 |      - |     - |     - |         - |              0 |                       0 |
| StructLinq_IFunction |   100 | 183.31 ns | 0.855 ns | 0.714 ns |  2.69 |    0.01 |      - |     - |     - |         - |              0 |                       0 |
|            Hyperlinq |   100 | 476.94 ns | 3.443 ns | 3.221 ns |  6.98 |    0.05 |      - |     - |     - |         - |              0 |                       1 |
