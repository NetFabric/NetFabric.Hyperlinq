## List.ValueType.ListValueTypeDistinct

### Source
[ListValueTypeDistinct.cs](../LinqBenchmarks/List/ValueType/ListValueTypeDistinct.cs)

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
|               Method | Duplicates | Count |        Mean |     Error |    StdDev | Ratio |   Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |----------- |------ |------------:|----------:|----------:|------:|--------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |          4 |   100 | 38,127.7 ns | 274.69 ns | 243.51 ns |  1.00 | 72.6929 |     - |     - |  152008 B |            140 |                      64 |
|          ForeachLoop |          4 |   100 | 39,084.9 ns | 192.27 ns | 179.85 ns |  1.02 | 72.6929 |     - |     - |  152008 B |            173 |                      73 |
|                 Linq |          4 |   100 | 39,902.1 ns | 130.48 ns | 108.96 ns |  1.05 | 72.4487 |     - |     - |  151528 B |            169 |                      65 |
|           LinqFaster |          4 |   100 |    515.3 ns |  10.32 ns |  12.68 ns |  0.01 |  0.0114 |     - |     - |      24 B |              0 |                       1 |
|           StructLinq |          4 |   100 | 41,806.7 ns | 369.63 ns | 345.76 ns |  1.10 | 70.9229 |     - |     - |  148400 B |            206 |                      80 |
| StructLinq_IFunction |          4 |   100 |  6,350.2 ns |  41.80 ns |  39.10 ns |  0.17 |       - |     - |     - |         - |              1 |                       8 |
|            Hyperlinq |          4 |   100 | 37,948.6 ns | 278.56 ns | 260.57 ns |  0.99 | 70.9229 |     - |     - |  148400 B |            182 |                      69 |
