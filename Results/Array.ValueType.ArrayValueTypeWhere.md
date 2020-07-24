## Array.ValueType.ArrayValueTypeWhere

### Source
[ArrayValueTypeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhere.cs)

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
|               Method | Count |     Mean |    Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |---------:|---------:|--------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |   100 | 472.4 ns |  2.63 ns | 2.33 ns |  1.00 |    0.00 |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop |   100 | 458.8 ns |  3.84 ns | 3.40 ns |  0.97 |    0.01 |      - |     - |     - |         - |              0 |                       0 |
|                 Linq |   100 | 855.4 ns | 10.20 ns | 9.04 ns |  1.81 |    0.02 | 0.0381 |     - |     - |      80 B |              1 |                       1 |
|           LinqFaster |   100 | 960.3 ns |  9.56 ns | 8.95 ns |  2.03 |    0.03 | 2.8896 |     - |     - |    6048 B |              3 |                       1 |
|           StructLinq |   100 | 738.2 ns |  4.26 ns | 3.98 ns |  1.56 |    0.01 |      - |     - |     - |         - |              0 |                       1 |
| StructLinq_IFunction |   100 | 510.2 ns |  2.31 ns | 2.16 ns |  1.08 |    0.01 |      - |     - |     - |         - |              0 |                       0 |
|            Hyperlinq |   100 | 683.6 ns |  1.71 ns | 1.52 ns |  1.45 |    0.01 |      - |     - |     - |         - |              0 |                       1 |
