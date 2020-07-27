## Array.ValueType.ArrayValueTypeWhereSelectToArray

### Source
[ArrayValueTypeWhereSelectToArray.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToArray.cs)

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
|              ForLoop |   100 | 1,028.7 ns |  9.30 ns |  8.70 ns |  1.00 |    0.00 | 3.4103 |     - |     - |    7136 B |              4 |                       1 |
|          ForeachLoop |   100 |   987.3 ns |  7.41 ns |  6.93 ns |  0.96 |    0.01 | 3.4103 |     - |     - |    7136 B |              4 |                       1 |
|                 Linq |   100 | 1,287.9 ns | 16.48 ns | 15.41 ns |  1.25 |    0.01 | 2.4319 |     - |     - |    5088 B |              4 |                       3 |
|           LinqFaster |   100 | 1,015.8 ns |  4.13 ns |  3.66 ns |  0.99 |    0.01 | 2.8896 |     - |     - |    6048 B |              4 |                       1 |
|           StructLinq |   100 | 1,299.7 ns | 11.47 ns | 10.73 ns |  1.26 |    0.02 | 0.9899 |     - |     - |    2072 B |              4 |                       2 |
| StructLinq_IFunction |   100 |   853.9 ns |  6.01 ns |  5.33 ns |  0.83 |    0.01 | 0.9899 |     - |     - |    2072 B |              3 |                       3 |
|            Hyperlinq |   100 | 1,224.4 ns | 14.76 ns | 13.09 ns |  1.19 |    0.02 | 0.9670 |     - |     - |    2024 B |              4 |                       2 |
|       Hyperlinq_Pool |   100 | 1,144.1 ns | 13.65 ns | 12.77 ns |  1.11 |    0.02 | 0.0267 |     - |     - |      56 B |              1 |                       2 |
