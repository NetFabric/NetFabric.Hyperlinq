## List.ValueType.ListValueTypeWhereSelect

### Source
[ListValueTypeWhereSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelect.cs)

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
|               Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |   100 |   888.8 ns |  4.47 ns |  3.73 ns |  1.00 |    0.00 |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop |   100 | 1,043.2 ns |  2.87 ns |  2.24 ns |  1.17 |    0.01 |      - |     - |     - |         - |              0 |                       0 |
|                 Linq |   100 | 1,612.6 ns |  5.57 ns |  5.21 ns |  1.81 |    0.01 | 0.1335 |     - |     - |     280 B |              3 |                       1 |
|           LinqFaster |   100 | 1,672.1 ns | 20.81 ns | 18.45 ns |  1.88 |    0.02 | 2.4433 |     - |     - |    5112 B |              5 |                       2 |
|           StructLinq |   100 | 1,245.4 ns | 13.64 ns | 12.76 ns |  1.40 |    0.01 |      - |     - |     - |         - |              0 |                       1 |
| StructLinq_IFunction |   100 |   914.5 ns |  5.80 ns |  5.14 ns |  1.03 |    0.01 |      - |     - |     - |         - |              0 |                       0 |
|            Hyperlinq |   100 | 1,224.3 ns |  5.84 ns |  5.17 ns |  1.38 |    0.01 |      - |     - |     - |         - |              0 |                       1 |
