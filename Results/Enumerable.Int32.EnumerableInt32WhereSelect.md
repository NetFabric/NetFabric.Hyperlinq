## Enumerable.Int32.EnumerableInt32WhereSelect

### Source
[EnumerableInt32WhereSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelect.cs)

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
|               Method | Count |       Mean |   Error |  StdDev | Ratio | Code Size |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |-----------:|--------:|--------:|------:|----------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|          ForeachLoop |   100 |   519.8 ns | 1.74 ns | 1.54 ns |  1.00 |     199 B | 0.0191 |     - |     - |      40 B |              0 |                       1 |
|                 Linq |   100 | 1,014.3 ns | 4.93 ns | 4.37 ns |  1.95 |    1716 B | 0.0763 |     - |     - |     160 B |              2 |                       2 |
|           StructLinq |   100 |   905.2 ns | 3.36 ns | 2.80 ns |  1.74 |     872 B | 0.0191 |     - |     - |      40 B |              1 |                       1 |
| StructLinq_IFunction |   100 |   604.7 ns | 4.26 ns | 3.77 ns |  1.16 |     824 B | 0.0191 |     - |     - |      40 B |              1 |                       1 |
|            Hyperlinq |   100 |   953.8 ns | 4.88 ns | 4.33 ns |  1.84 |     701 B | 0.0191 |     - |     - |      40 B |              1 |                       1 |
