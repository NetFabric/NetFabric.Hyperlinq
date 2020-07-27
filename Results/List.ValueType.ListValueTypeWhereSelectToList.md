## List.ValueType.ListValueTypeWhereSelectToList

### Source
[ListValueTypeWhereSelectToList.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToList.cs)

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
|              ForLoop |   100 |   885.4 ns |  7.13 ns |  6.67 ns |  1.00 |    0.00 | 2.4433 |     - |     - |   4.99 KB |              3 |                       1 |
|          ForeachLoop |   100 | 1,126.3 ns |  9.72 ns |  8.62 ns |  1.27 |    0.01 | 2.4433 |     - |     - |   4.99 KB |              5 |                       2 |
|                 Linq |   100 | 1,299.6 ns | 17.91 ns | 16.75 ns |  1.47 |    0.02 | 2.5768 |     - |     - |   5.27 KB |              4 |                       2 |
|           LinqFaster |   100 | 1,380.4 ns | 19.92 ns | 18.63 ns |  1.56 |    0.02 | 3.4237 |     - |     - |      7 KB |              5 |                       3 |
|           StructLinq |   100 | 1,305.8 ns | 21.52 ns | 20.13 ns |  1.47 |    0.02 | 1.0052 |     - |     - |   2.05 KB |              5 |                       2 |
| StructLinq_IFunction |   100 |   850.1 ns |  4.72 ns |  4.19 ns |  0.96 |    0.01 | 1.0052 |     - |     - |   2.05 KB |              3 |                       3 |
|            Hyperlinq |   100 | 1,186.7 ns |  7.58 ns |  7.09 ns |  1.34 |    0.02 | 1.0166 |     - |     - |   2.08 KB |              4 |                       2 |
