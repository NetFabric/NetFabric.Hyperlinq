## Array.Int32.ArrayInt32WhereSelectToArray

### Source
[ArrayInt32WhereSelectToArray.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToArray.cs)

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
|              ForLoop |   100 | 230.9 ns | 1.38 ns | 1.08 ns |  1.00 |    0.00 | 0.4170 |     - |     - |     872 B |              1 |                       0 |
|          ForeachLoop |   100 | 237.4 ns | 1.76 ns | 1.65 ns |  1.03 |    0.01 | 0.4168 |     - |     - |     872 B |              1 |                       0 |
|                 Linq |   100 | 573.4 ns | 3.66 ns | 3.25 ns |  2.48 |    0.02 | 0.3710 |     - |     - |     776 B |              2 |                       2 |
|           LinqFaster |   100 | 369.0 ns | 2.03 ns | 1.90 ns |  1.60 |    0.01 | 0.3095 |     - |     - |     648 B |              1 |                       1 |
|           StructLinq |   100 | 662.5 ns | 4.43 ns | 3.93 ns |  2.87 |    0.02 | 0.1297 |     - |     - |     272 B |              2 |                       2 |
| StructLinq_IFunction |   100 | 353.0 ns | 2.84 ns | 2.37 ns |  1.53 |    0.02 | 0.1297 |     - |     - |     272 B |              1 |                       1 |
|            Hyperlinq |   100 | 603.1 ns | 3.93 ns | 3.68 ns |  2.61 |    0.02 | 0.1068 |     - |     - |     224 B |              2 |                       2 |
|       Hyperlinq_Pool |   100 | 635.1 ns | 5.60 ns | 4.67 ns |  2.75 |    0.02 | 0.0267 |     - |     - |      56 B |              1 |                       2 |
