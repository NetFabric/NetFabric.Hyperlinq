## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

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
|               Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |   100 | 259.9 ns | 2.12 ns | 1.88 ns |  1.00 |    0.00 | 0.3095 |     - |     - |     648 B |              1 |                       0 |
|          ForeachLoop |   100 | 214.9 ns | 0.86 ns | 0.76 ns |  0.83 |    0.01 | 0.3097 |     - |     - |     648 B |              1 |                       0 |
|                 Linq |   100 | 473.3 ns | 2.12 ns | 1.98 ns |  1.82 |    0.01 | 0.3595 |     - |     - |     752 B |              2 |                       2 |
|           LinqFaster |   100 | 415.1 ns | 2.41 ns | 2.01 ns |  1.60 |    0.02 | 0.4320 |     - |     - |     904 B |              2 |                       1 |
|           StructLinq |   100 | 672.1 ns | 2.71 ns | 2.40 ns |  2.59 |    0.02 | 0.1450 |     - |     - |     304 B |              2 |                       2 |
| StructLinq_IFunction |   100 | 358.7 ns | 1.67 ns | 1.39 ns |  1.38 |    0.01 | 0.1450 |     - |     - |     304 B |              1 |                       1 |
|            Hyperlinq |   100 | 668.1 ns | 2.31 ns | 2.05 ns |  2.57 |    0.02 | 0.1564 |     - |     - |     328 B |              2 |                       2 |
