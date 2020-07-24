## Enumerable.Int32.EnumerableInt32WhereSelect

### Source
[EnumerableInt32WhereSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelect.cs)

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
|          ForeachLoop |   100 |   511.9 ns | 3.28 ns | 2.91 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |              0 |                       1 |
|                 Linq |   100 | 1,002.5 ns | 5.49 ns | 4.87 ns |  1.96 |    0.02 | 0.0763 |     - |     - |     160 B |              2 |                       1 |
|           StructLinq |   100 |   964.2 ns | 4.42 ns | 4.13 ns |  1.88 |    0.01 | 0.0191 |     - |     - |      40 B |              1 |                       1 |
| StructLinq_IFunction |   100 |   589.3 ns | 2.91 ns | 2.58 ns |  1.15 |    0.01 | 0.0191 |     - |     - |      40 B |              0 |                       1 |
|            Hyperlinq |   100 | 1,039.3 ns | 7.20 ns | 6.74 ns |  2.03 |    0.01 | 0.0191 |     - |     - |      40 B |              1 |                       1 |
