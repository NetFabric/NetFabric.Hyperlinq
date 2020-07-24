## Array.ValueType.ArrayValueTypeWhereSelectToList

### Source
[ArrayValueTypeWhereSelectToList.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToList.cs)

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
|              ForLoop |   100 |   893.9 ns |  3.67 ns |  2.87 ns |  1.00 |    0.00 | 2.4433 |     - |     - |   4.99 KB |              4 |                       1 |
|          ForeachLoop |   100 |   887.2 ns |  7.60 ns |  6.74 ns |  0.99 |    0.01 | 2.4433 |     - |     - |   4.99 KB |              4 |                       1 |
|                 Linq |   100 | 1,286.0 ns | 20.77 ns | 19.43 ns |  1.45 |    0.02 | 2.5234 |     - |     - |   5.16 KB |              6 |                       3 |
|           LinqFaster |   100 | 1,215.1 ns |  5.89 ns |  5.22 ns |  1.36 |    0.01 | 3.8700 |     - |     - |   7.91 KB |              5 |                       1 |
|           StructLinq |   100 | 1,326.4 ns | 13.44 ns | 12.57 ns |  1.48 |    0.02 | 1.0052 |     - |     - |   2.05 KB |              5 |                       2 |
| StructLinq_IFunction |   100 |   879.9 ns |  2.68 ns |  2.09 ns |  0.98 |    0.00 | 1.0052 |     - |     - |   2.05 KB |              3 |                       2 |
|            Hyperlinq |   100 | 1,254.9 ns | 12.06 ns | 10.69 ns |  1.40 |    0.01 | 1.0166 |     - |     - |   2.08 KB |              5 |                       3 |
