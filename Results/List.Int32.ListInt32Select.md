## List.Int32.ListInt32Select

### Source
[ListInt32Select.cs](../LinqBenchmarks/List/Int32/ListInt32Select.cs)

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
|               Method | Count |     Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |---------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |   100 | 106.1 ns |  0.74 ns |  0.69 ns |  1.00 |    0.00 |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop |   100 | 221.0 ns |  2.22 ns |  2.08 ns |  2.08 |    0.02 |      - |     - |     - |         - |              0 |                       0 |
|                 Linq |   100 | 767.7 ns | 11.54 ns | 10.23 ns |  7.24 |    0.11 | 0.0343 |     - |     - |      72 B |              1 |                       1 |
|           LinqFaster |   100 | 319.4 ns |  1.92 ns |  1.70 ns |  3.01 |    0.02 | 0.2179 |     - |     - |     456 B |              1 |                       1 |
|           StructLinq |   100 | 273.8 ns |  2.62 ns |  2.32 ns |  2.58 |    0.03 |      - |     - |     - |         - |              0 |                       0 |
| StructLinq_IFunction |   100 | 161.1 ns |  1.45 ns |  1.36 ns |  1.52 |    0.01 |      - |     - |     - |         - |              0 |                       0 |
|    Hyperlinq_Foreach |   100 | 257.7 ns |  2.18 ns |  1.93 ns |  2.43 |    0.03 |      - |     - |     - |         - |              0 |                       0 |
|        Hyperlinq_For |   100 | 433.1 ns |  1.17 ns |  1.09 ns |  4.08 |    0.03 |      - |     - |     - |         - |              0 |                       0 |
