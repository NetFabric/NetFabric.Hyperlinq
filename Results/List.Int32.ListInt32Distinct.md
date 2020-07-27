## List.Int32.ListInt32Distinct

### Source
[ListInt32Distinct.cs](../LinqBenchmarks/List/Int32/ListInt32Distinct.cs)

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
|               Method | Duplicates | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |----------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |          4 |   100 |   816.4 ns |  3.27 ns |  2.90 ns |  1.00 |    0.00 | 0.6304 |     - |     - |    1320 B |              3 |                       1 |
|          ForeachLoop |          4 |   100 |   967.0 ns |  7.23 ns |  6.41 ns |  1.18 |    0.01 | 0.6294 |     - |     - |    1320 B |              3 |                       2 |
|                 Linq |          4 |   100 | 1,785.8 ns | 12.84 ns | 12.01 ns |  2.19 |    0.02 | 0.5569 |     - |     - |    1168 B |              6 |                       3 |
|           LinqFaster |          4 |   100 |   139.9 ns |  1.14 ns |  1.01 ns |  0.17 |    0.00 |      - |     - |     - |         - |              0 |                       0 |
|           StructLinq |          4 |   100 | 1,493.8 ns |  6.28 ns |  5.24 ns |  1.83 |    0.01 |      - |     - |     - |         - |              0 |                       2 |
| StructLinq_IFunction |          4 |   100 | 1,061.8 ns |  8.37 ns |  7.42 ns |  1.30 |    0.01 |      - |     - |     - |         - |              0 |                       2 |
|            Hyperlinq |          4 |   100 | 1,173.8 ns | 10.30 ns |  9.64 ns |  1.44 |    0.01 |      - |     - |     - |         - |              0 |                       2 |
