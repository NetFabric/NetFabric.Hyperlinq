## List.Int32.ListInt32Distinct

### Source
[ListInt32Distinct.cs](../LinqBenchmarks/List/Int32/ListInt32Distinct.cs)

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
|               Method | Duplicates | Count |       Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |----------- |------ |-----------:|---------:|---------:|------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |          4 |   100 |   827.3 ns |  3.39 ns |  3.01 ns |  1.00 | 0.6304 |     - |     - |    1320 B |              3 |                       1 |
|          ForeachLoop |          4 |   100 |   976.4 ns |  7.47 ns |  6.98 ns |  1.18 | 0.6294 |     - |     - |    1320 B |              3 |                       2 |
|                 Linq |          4 |   100 | 1,829.2 ns |  8.12 ns |  7.20 ns |  2.21 | 0.5569 |     - |     - |    1168 B |              6 |                       4 |
|           LinqFaster |          4 |   100 |   135.5 ns |  0.73 ns |  0.69 ns |  0.16 |      - |     - |     - |         - |              0 |                       0 |
|           StructLinq |          4 |   100 | 1,467.3 ns |  8.52 ns |  7.55 ns |  1.77 |      - |     - |     - |         - |              0 |                       2 |
| StructLinq_IFunction |          4 |   100 | 1,082.8 ns |  4.69 ns |  4.16 ns |  1.31 |      - |     - |     - |         - |              0 |                       2 |
|            Hyperlinq |          4 |   100 | 1,211.6 ns | 11.41 ns | 10.12 ns |  1.46 |      - |     - |     - |         - |              0 |                       2 |
