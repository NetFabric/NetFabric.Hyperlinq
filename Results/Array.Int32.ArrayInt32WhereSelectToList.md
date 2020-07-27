## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

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
|               Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |   100 | 231.6 ns | 1.46 ns | 1.36 ns |  1.00 |    0.00 | 0.3095 |     - |     - |     648 B |              1 |                       0 |
|          ForeachLoop |   100 | 221.5 ns | 1.31 ns | 1.22 ns |  0.96 |    0.01 | 0.3097 |     - |     - |     648 B |              1 |                       0 |
|                 Linq |   100 | 464.9 ns | 2.74 ns | 2.28 ns |  2.01 |    0.02 | 0.3595 |     - |     - |     752 B |              1 |                       2 |
|           LinqFaster |   100 | 425.2 ns | 2.00 ns | 1.77 ns |  1.84 |    0.01 | 0.4320 |     - |     - |     904 B |              1 |                       1 |
|           StructLinq |   100 | 615.9 ns | 3.71 ns | 3.47 ns |  2.66 |    0.02 | 0.1450 |     - |     - |     304 B |              2 |                       2 |
| StructLinq_IFunction |   100 | 359.8 ns | 1.72 ns | 1.61 ns |  1.55 |    0.01 | 0.1450 |     - |     - |     304 B |              1 |                       1 |
|            Hyperlinq |   100 | 643.4 ns | 3.32 ns | 2.94 ns |  2.78 |    0.02 | 0.1564 |     - |     - |     328 B |              2 |                       2 |
