## List.ValueType.ListValueTypeDistinct

### Source
[ListValueTypeDistinct.cs](../LinqBenchmarks/List/ValueType/ListValueTypeDistinct.cs)

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
|               Method | Duplicates | Count |        Mean |     Error |    StdDev | Ratio |   Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |----------- |------ |------------:|----------:|----------:|------:|--------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |          4 |   100 | 36,502.2 ns | 237.25 ns | 221.92 ns |  1.00 | 72.6929 |     - |     - |  152008 B |            128 |                      57 |
|          ForeachLoop |          4 |   100 | 36,767.7 ns | 320.18 ns | 299.49 ns |  1.01 | 72.6929 |     - |     - |  152008 B |            134 |                      64 |
|                 Linq |          4 |   100 | 39,247.5 ns | 206.38 ns | 193.05 ns |  1.08 | 72.4487 |     - |     - |  151528 B |            149 |                      67 |
|           LinqFaster |          4 |   100 |    522.9 ns |  10.31 ns |  13.04 ns |  0.01 |  0.0114 |     - |     - |      24 B |              0 |                       0 |
|           StructLinq |          4 |   100 | 41,502.1 ns | 430.80 ns | 381.89 ns |  1.14 | 70.9229 |     - |     - |  148400 B |            176 |                      66 |
| StructLinq_IFunction |          4 |   100 |  5,835.2 ns |  28.47 ns |  25.24 ns |  0.16 |       - |     - |     - |         - |              1 |                       6 |
|            Hyperlinq |          4 |   100 | 36,990.1 ns | 322.58 ns | 301.74 ns |  1.01 | 70.9229 |     - |     - |  148400 B |            170 |                      59 |
