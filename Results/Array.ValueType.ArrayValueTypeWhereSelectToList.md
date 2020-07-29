## Array.ValueType.ArrayValueTypeWhereSelectToList

### Source
[ArrayValueTypeWhereSelectToList.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToList.cs)

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
|               Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD | Code Size |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |-----------:|---------:|---------:|------:|--------:|----------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |   100 |   956.6 ns |  8.73 ns |  6.82 ns |  1.00 |    0.00 |    0.6 KB | 2.4433 |     - |     - |   4.99 KB |              7 |                       2 |
|          ForeachLoop |   100 |   961.6 ns |  6.51 ns |  5.43 ns |  1.01 |    0.01 |    0.6 KB | 2.4433 |     - |     - |   4.99 KB |              6 |                       2 |
|                 Linq |   100 | 1,348.7 ns | 13.34 ns | 12.48 ns |  1.41 |    0.02 |    1.7 KB | 2.5234 |     - |     - |   5.16 KB |              9 |                       3 |
|           LinqFaster |   100 | 1,322.8 ns | 18.01 ns | 16.84 ns |  1.38 |    0.02 |   1.67 KB | 3.8700 |     - |     - |   7.91 KB |             16 |                       4 |
|           StructLinq |   100 | 1,377.9 ns | 13.50 ns | 12.63 ns |  1.44 |    0.01 |   2.42 KB | 1.0052 |     - |     - |   2.05 KB |              6 |                       2 |
| StructLinq_IFunction |   100 |   918.6 ns |  5.13 ns |  4.55 ns |  0.96 |    0.01 |   2.05 KB | 1.0052 |     - |     - |   2.05 KB |              5 |                       3 |
|            Hyperlinq |   100 | 1,319.3 ns | 10.88 ns |  9.65 ns |  1.38 |    0.01 |   2.62 KB | 1.0166 |     - |     - |   2.08 KB |              7 |                       3 |
