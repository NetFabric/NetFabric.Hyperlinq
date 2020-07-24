## Array.ValueType.ArrayValueTypeWhereSelect

### Source
[ArrayValueTypeWhereSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelect.cs)

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
|              ForLoop |   100 |   861.6 ns |  4.63 ns |  4.11 ns |  1.00 |    0.00 |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop |   100 |   858.7 ns |  4.13 ns |  3.86 ns |  1.00 |    0.01 |      - |     - |     - |         - |              0 |                       0 |
|                 Linq |   100 | 1,358.5 ns |  5.17 ns |  4.84 ns |  1.58 |    0.01 | 0.0801 |     - |     - |     168 B |              2 |                       1 |
|           LinqFaster |   100 | 1,428.0 ns | 12.97 ns | 11.50 ns |  1.66 |    0.02 | 2.8896 |     - |     - |    6048 B |              6 |                       1 |
|           StructLinq |   100 | 1,277.8 ns |  8.90 ns |  7.43 ns |  1.48 |    0.01 |      - |     - |     - |         - |              0 |                       1 |
| StructLinq_IFunction |   100 |   885.4 ns |  1.79 ns |  1.59 ns |  1.03 |    0.01 |      - |     - |     - |         - |              0 |                       0 |
|            Hyperlinq |   100 | 1,247.8 ns | 10.03 ns |  9.39 ns |  1.45 |    0.02 |      - |     - |     - |         - |              0 |                       1 |
