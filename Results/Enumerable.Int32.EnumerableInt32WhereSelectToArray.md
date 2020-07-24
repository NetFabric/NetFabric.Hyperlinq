## Enumerable.Int32.EnumerableInt32WhereSelectToArray

### Source
[EnumerableInt32WhereSelectToArray.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToArray.cs)

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
|               Method | Count |       Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |-----------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|          ForeachLoop |   100 |   656.2 ns | 2.32 ns | 1.94 ns |  1.00 |    0.00 | 0.4358 |     - |     - |     912 B |              3 |                       3 |
|                 Linq |   100 | 1,058.9 ns | 6.91 ns | 6.12 ns |  1.61 |    0.01 | 0.3967 |     - |     - |     832 B |              4 |                       4 |
|           StructLinq |   100 | 1,140.7 ns | 9.12 ns | 8.53 ns |  1.74 |    0.02 | 0.1450 |     - |     - |     304 B |              3 |                       3 |
| StructLinq_IFunction |   100 |   758.6 ns | 3.39 ns | 3.17 ns |  1.16 |    0.00 | 0.1450 |     - |     - |     304 B |              2 |                       2 |
|            Hyperlinq |   100 | 1,059.5 ns | 8.06 ns | 7.14 ns |  1.61 |    0.01 | 0.1259 |     - |     - |     264 B |              2 |                       2 |
|       Hyperlinq_Pool |   100 | 1,098.3 ns | 8.17 ns | 7.25 ns |  1.67 |    0.01 | 0.0458 |     - |     - |      96 B |              1 |                       2 |
