## List.Int32.ListInt32WhereSelectToList

### Source
[ListInt32WhereSelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToList.cs)

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
|              ForLoop |   100 | 240.6 ns | 1.58 ns | 1.48 ns |  1.00 |    0.00 | 0.3095 |     - |     - |     648 B |              1 |                       0 |
|          ForeachLoop |   100 | 378.1 ns | 1.90 ns | 1.68 ns |  1.57 |    0.01 | 0.3095 |     - |     - |     648 B |              2 |                       2 |
|                 Linq |   100 | 594.7 ns | 4.22 ns | 3.74 ns |  2.47 |    0.02 | 0.3824 |     - |     - |     800 B |              2 |                       2 |
|           LinqFaster |   100 | 514.5 ns | 3.49 ns | 3.26 ns |  2.14 |    0.02 | 0.4320 |     - |     - |     904 B |              2 |                       2 |
|           StructLinq |   100 | 666.3 ns | 3.64 ns | 3.40 ns |  2.77 |    0.02 | 0.1450 |     - |     - |     304 B |              2 |                       2 |
| StructLinq_IFunction |   100 | 362.1 ns | 1.16 ns | 0.91 ns |  1.51 |    0.01 | 0.1450 |     - |     - |     304 B |              1 |                       1 |
|            Hyperlinq |   100 | 665.4 ns | 4.96 ns | 4.40 ns |  2.77 |    0.03 | 0.1564 |     - |     - |     328 B |              2 |                       2 |
