## Array.ValueType.ArrayValueTypeWhereSelectToArray

### Source
[ArrayValueTypeWhereSelectToArray.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToArray.cs)

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
|              ForLoop |   100 | 1,054.2 ns | 13.31 ns | 12.45 ns |  1.00 |    0.00 | 3.4103 |     - |     - |    7136 B |              4 |                       1 |
|          ForeachLoop |   100 | 1,023.8 ns |  6.01 ns |  5.63 ns |  0.97 |    0.01 | 3.4103 |     - |     - |    7136 B |              4 |                       1 |
|                 Linq |   100 | 1,304.8 ns | 15.54 ns | 14.54 ns |  1.24 |    0.02 | 2.4319 |     - |     - |    5088 B |              6 |                       3 |
|           LinqFaster |   100 | 1,024.3 ns |  5.35 ns |  4.74 ns |  0.97 |    0.01 | 2.8896 |     - |     - |    6048 B |              4 |                       1 |
|           StructLinq |   100 | 1,300.7 ns | 13.32 ns | 11.81 ns |  1.23 |    0.02 | 0.9899 |     - |     - |    2072 B |              4 |                       2 |
| StructLinq_IFunction |   100 |   877.6 ns |  5.20 ns |  4.61 ns |  0.83 |    0.01 | 0.9899 |     - |     - |    2072 B |              3 |                       2 |
|            Hyperlinq |   100 | 1,198.0 ns |  8.64 ns |  7.22 ns |  1.14 |    0.02 | 0.9670 |     - |     - |    2024 B |              4 |                       2 |
|       Hyperlinq_Pool |   100 | 1,154.4 ns |  3.67 ns |  3.44 ns |  1.10 |    0.01 | 0.0267 |     - |     - |      56 B |              1 |                       2 |
