## List.ValueType.ListValueTypeWhereSelectToList

### Source
[ListValueTypeWhereSelectToList.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToList.cs)

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
|              ForLoop |   100 |   908.1 ns | 10.65 ns |  9.96 ns |  1.00 |    0.00 | 2.4433 |     - |     - |   4.99 KB |              4 |                       1 |
|          ForeachLoop |   100 | 1,110.7 ns | 10.35 ns |  9.68 ns |  1.22 |    0.01 | 2.4433 |     - |     - |   4.99 KB |              5 |                       2 |
|                 Linq |   100 | 1,320.6 ns | 15.79 ns | 14.77 ns |  1.45 |    0.01 | 2.5768 |     - |     - |   5.27 KB |              5 |                       3 |
|           LinqFaster |   100 | 1,459.4 ns | 13.59 ns | 12.04 ns |  1.61 |    0.02 | 3.4237 |     - |     - |      7 KB |              6 |                       3 |
|           StructLinq |   100 | 1,299.4 ns | 15.06 ns | 13.35 ns |  1.43 |    0.02 | 1.0052 |     - |     - |   2.05 KB |              6 |                       2 |
| StructLinq_IFunction |   100 |   869.3 ns |  4.89 ns |  4.34 ns |  0.96 |    0.01 | 1.0052 |     - |     - |   2.05 KB |              4 |                       2 |
|            Hyperlinq |   100 | 1,265.3 ns |  9.78 ns |  9.15 ns |  1.39 |    0.02 | 1.0166 |     - |     - |   2.08 KB |              5 |                       2 |
