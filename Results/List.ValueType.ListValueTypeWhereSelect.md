## List.ValueType.ListValueTypeWhereSelect

### Source
[ListValueTypeWhereSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelect.cs)

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
|               Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |   100 |   861.3 ns |  1.93 ns |  1.81 ns |  1.00 |    0.00 |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop |   100 | 1,090.8 ns |  6.70 ns |  5.94 ns |  1.27 |    0.01 |      - |     - |     - |         - |              0 |                       0 |
|                 Linq |   100 | 1,628.6 ns |  7.77 ns |  6.89 ns |  1.89 |    0.01 | 0.1335 |     - |     - |     280 B |              3 |                       1 |
|           LinqFaster |   100 | 1,735.1 ns | 15.31 ns | 13.58 ns |  2.01 |    0.02 | 2.4433 |     - |     - |    5112 B |              6 |                       3 |
|           StructLinq |   100 | 1,264.1 ns |  5.51 ns |  5.16 ns |  1.47 |    0.01 |      - |     - |     - |         - |              0 |                       1 |
| StructLinq_IFunction |   100 |   888.6 ns |  3.17 ns |  2.97 ns |  1.03 |    0.00 |      - |     - |     - |         - |              0 |                       0 |
|            Hyperlinq |   100 | 2,091.1 ns |  8.89 ns |  7.88 ns |  2.43 |    0.01 |      - |     - |     - |         - |              0 |                       1 |
