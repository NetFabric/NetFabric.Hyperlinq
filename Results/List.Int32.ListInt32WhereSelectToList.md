## List.Int32.ListInt32WhereSelectToList

### Source
[ListInt32WhereSelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToList.cs)

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
|              ForLoop |   100 | 232.1 ns | 0.89 ns | 0.79 ns |  1.00 |    0.00 | 0.3095 |     - |     - |     648 B |              1 |                       0 |
|          ForeachLoop |   100 | 396.2 ns | 3.02 ns | 2.52 ns |  1.71 |    0.01 | 0.3095 |     - |     - |     648 B |              2 |                       2 |
|                 Linq |   100 | 538.9 ns | 3.95 ns | 3.69 ns |  2.32 |    0.02 | 0.3824 |     - |     - |     800 B |              2 |                       2 |
|           LinqFaster |   100 | 525.8 ns | 2.07 ns | 1.94 ns |  2.26 |    0.01 | 0.4320 |     - |     - |     904 B |              2 |                       2 |
|           StructLinq |   100 | 665.1 ns | 3.34 ns | 3.13 ns |  2.86 |    0.02 | 0.1450 |     - |     - |     304 B |              2 |                       2 |
| StructLinq_IFunction |   100 | 360.1 ns | 1.61 ns | 1.43 ns |  1.55 |    0.01 | 0.1450 |     - |     - |     304 B |              1 |                       1 |
|            Hyperlinq |   100 | 666.2 ns | 3.52 ns | 3.29 ns |  2.87 |    0.01 | 0.1564 |     - |     - |     328 B |              2 |                       2 |
