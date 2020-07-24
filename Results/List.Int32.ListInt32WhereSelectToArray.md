## List.Int32.ListInt32WhereSelectToArray

### Source
[ListInt32WhereSelectToArray.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToArray.cs)

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
|              ForLoop |   100 | 258.8 ns | 2.62 ns | 2.33 ns |  1.00 |    0.00 | 0.4168 |     - |     - |     872 B |              1 |                       0 |
|          ForeachLoop |   100 | 413.5 ns | 2.26 ns | 2.01 ns |  1.60 |    0.01 | 0.4168 |     - |     - |     872 B |              2 |                       2 |
|                 Linq |   100 | 606.9 ns | 3.08 ns | 2.73 ns |  2.35 |    0.02 | 0.3939 |     - |     - |     824 B |              2 |                       2 |
|           LinqFaster |   100 | 525.9 ns | 2.63 ns | 2.33 ns |  2.03 |    0.02 | 0.4168 |     - |     - |     872 B |              2 |                       2 |
|           StructLinq |   100 | 630.6 ns | 2.88 ns | 2.55 ns |  2.44 |    0.03 | 0.1297 |     - |     - |     272 B |              2 |                       2 |
| StructLinq_IFunction |   100 | 352.6 ns | 2.39 ns | 2.12 ns |  1.36 |    0.02 | 0.1297 |     - |     - |     272 B |              1 |                       1 |
|            Hyperlinq |   100 | 609.5 ns | 3.46 ns | 3.24 ns |  2.36 |    0.02 | 0.1068 |     - |     - |     224 B |              2 |                       2 |
|       Hyperlinq_Pool |   100 | 623.5 ns | 4.33 ns | 4.05 ns |  2.41 |    0.03 | 0.0267 |     - |     - |      56 B |              1 |                       2 |
