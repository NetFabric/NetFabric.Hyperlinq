## List.Int32.ListInt32WhereSelectToArray

### Source
[ListInt32WhereSelectToArray.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToArray.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta21](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta21)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | Code Size | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|----------:|---------------:|------------------------:|
|              ForLoop |   100 | 274.0 ns | 2.72 ns | 2.41 ns |  1.00 |    0.00 | 0.4168 |     - |     - |     872 B |     617 B |              2 |                       1 |
|          ForeachLoop |   100 | 420.0 ns | 3.17 ns | 2.64 ns |  1.53 |    0.02 | 0.4168 |     - |     - |     872 B |     749 B |              2 |                       2 |
|                 Linq |   100 | 633.0 ns | 5.37 ns | 5.02 ns |  2.31 |    0.03 | 0.3939 |     - |     - |     824 B |    1599 B |              3 |                       2 |
|           LinqFaster |   100 | 540.1 ns | 4.10 ns | 3.83 ns |  1.97 |    0.03 | 0.4168 |     - |     - |     872 B |    1093 B |              3 |                       2 |
|           StructLinq |   100 | 642.0 ns | 6.87 ns | 5.36 ns |  2.34 |    0.03 | 0.1297 |     - |     - |     272 B |    1945 B |              2 |                       2 |
| StructLinq_IFunction |   100 | 364.2 ns | 1.26 ns | 1.12 ns |  1.33 |    0.01 | 0.1297 |     - |     - |     272 B |    1775 B |              2 |                       1 |
|            Hyperlinq |   100 | 607.1 ns | 1.56 ns | 1.21 ns |  2.21 |    0.02 | 0.1068 |     - |     - |     224 B |    1399 B |              2 |                       2 |
|       Hyperlinq_Pool |   100 | 681.7 ns | 4.10 ns | 3.42 ns |  2.49 |    0.03 | 0.0267 |     - |     - |      56 B |    1958 B |              1 |                       2 |
