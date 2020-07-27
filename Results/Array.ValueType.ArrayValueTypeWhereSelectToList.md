## Array.ValueType.ArrayValueTypeWhereSelectToList

### Source
[ArrayValueTypeWhereSelectToList.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToList.cs)

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
|              ForLoop |   100 |   891.9 ns |  7.08 ns |  6.28 ns |  1.00 |    0.00 | 2.4433 |     - |     - |   4.99 KB |              3 |                       1 |
|          ForeachLoop |   100 |   863.1 ns |  8.81 ns |  7.81 ns |  0.97 |    0.01 | 2.4433 |     - |     - |   4.99 KB |              3 |                       1 |
|                 Linq |   100 | 1,261.4 ns |  9.01 ns |  7.99 ns |  1.41 |    0.02 | 2.5234 |     - |     - |   5.16 KB |              6 |                       3 |
|           LinqFaster |   100 | 1,163.9 ns | 10.30 ns |  9.13 ns |  1.30 |    0.01 | 3.8700 |     - |     - |   7.91 KB |              4 |                       1 |
|           StructLinq |   100 | 1,308.6 ns | 11.57 ns | 10.82 ns |  1.47 |    0.02 | 1.0052 |     - |     - |   2.05 KB |              5 |                       2 |
| StructLinq_IFunction |   100 |   871.7 ns |  8.07 ns |  7.55 ns |  0.98 |    0.01 | 1.0052 |     - |     - |   2.05 KB |              3 |                       2 |
|            Hyperlinq |   100 | 1,260.7 ns | 12.55 ns | 11.12 ns |  1.41 |    0.02 | 1.0166 |     - |     - |   2.08 KB |              4 |                       2 |
