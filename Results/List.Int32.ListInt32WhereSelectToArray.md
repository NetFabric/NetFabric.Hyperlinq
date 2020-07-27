## List.Int32.ListInt32WhereSelectToArray

### Source
[ListInt32WhereSelectToArray.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToArray.cs)

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
|              ForLoop |   100 | 252.5 ns | 2.41 ns | 2.13 ns |  1.00 |    0.00 | 0.4168 |     - |     - |     872 B |              1 |                       0 |
|          ForeachLoop |   100 | 474.5 ns | 3.42 ns | 3.04 ns |  1.88 |    0.02 | 0.4168 |     - |     - |     872 B |              2 |                       2 |
|                 Linq |   100 | 602.1 ns | 3.83 ns | 3.58 ns |  2.39 |    0.02 | 0.3939 |     - |     - |     824 B |              2 |                       2 |
|           LinqFaster |   100 | 493.3 ns | 2.90 ns | 2.43 ns |  1.95 |    0.02 | 0.4168 |     - |     - |     872 B |              2 |                       2 |
|           StructLinq |   100 | 684.7 ns | 3.39 ns | 3.17 ns |  2.71 |    0.02 | 0.1297 |     - |     - |     272 B |              2 |                       2 |
| StructLinq_IFunction |   100 | 355.9 ns | 2.23 ns | 2.09 ns |  1.41 |    0.02 | 0.1297 |     - |     - |     272 B |              1 |                       1 |
|            Hyperlinq |   100 | 623.4 ns | 5.61 ns | 4.97 ns |  2.47 |    0.02 | 0.1068 |     - |     - |     224 B |              2 |                       2 |
|       Hyperlinq_Pool |   100 | 705.6 ns | 3.62 ns | 3.21 ns |  2.80 |    0.03 | 0.0267 |     - |     - |      56 B |              1 |                       2 |
