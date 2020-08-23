## List.Int32.ListInt32Where

### Source
[ListInt32Where.cs](../LinqBenchmarks/List/Int32/ListInt32Where.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 124.4 ns | 0.45 ns | 0.40 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 263.3 ns | 1.68 ns | 1.41 ns |  2.12 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 696.4 ns | 5.50 ns | 5.14 ns |  5.60 |    0.05 | 0.0343 |     - |     - |      72 B |
|           LinqFaster |   100 | 431.3 ns | 3.41 ns | 3.19 ns |  3.47 |    0.03 | 0.3095 |     - |     - |     648 B |
|               LinqAF |   100 | 751.7 ns | 6.18 ns | 5.48 ns |  6.04 |    0.06 |      - |     - |     - |         - |
|           StructLinq |   100 | 339.8 ns | 2.68 ns | 2.38 ns |  2.73 |    0.02 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |   100 | 173.7 ns | 1.60 ns | 1.41 ns |  1.40 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 343.5 ns | 2.06 ns | 1.82 ns |  2.76 |    0.02 |      - |     - |     - |         - |
