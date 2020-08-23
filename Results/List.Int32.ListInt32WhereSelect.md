## List.Int32.ListInt32WhereSelect

### Source
[ListInt32WhereSelect.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelect.cs)

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
|              ForLoop |   100 | 139.3 ns | 0.63 ns | 0.56 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 264.6 ns | 2.65 ns | 2.48 ns |  1.90 |    0.02 |      - |     - |     - |         - |
|                 Linq |   100 | 794.4 ns | 4.67 ns | 4.14 ns |  5.70 |    0.03 | 0.0725 |     - |     - |     152 B |
|           LinqFaster |   100 | 531.7 ns | 4.38 ns | 3.66 ns |  3.82 |    0.03 | 0.3090 |     - |     - |     648 B |
|               LinqAF |   100 | 964.6 ns | 9.48 ns | 8.41 ns |  6.92 |    0.08 |      - |     - |     - |         - |
|           StructLinq |   100 | 479.5 ns | 3.51 ns | 3.28 ns |  3.44 |    0.03 | 0.0343 |     - |     - |      72 B |
| StructLinq_IFunction |   100 | 189.5 ns | 1.67 ns | 1.57 ns |  1.36 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 445.7 ns | 1.93 ns | 1.50 ns |  3.20 |    0.01 |      - |     - |     - |         - |
