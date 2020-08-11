## List.Int32.ListInt32Distinct

### Source
[ListInt32Distinct.cs](../LinqBenchmarks/List/Int32/ListInt32Distinct.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta24](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta24)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=macOS Catalina 10.15.6 (19G73) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Duplicates | Count |        Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |------------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |          4 |   100 |  3,746.4 ns |  6.90 ns |  6.12 ns |  1.00 |    0.00 | 2.8687 |     - |     - |    6008 B |
|          ForeachLoop |          4 |   100 |  4,618.3 ns | 71.99 ns | 70.70 ns |  1.23 |    0.02 | 2.8687 |     - |     - |    6008 B |
|                 Linq |          4 |   100 |  8,765.6 ns | 23.20 ns | 20.57 ns |  2.34 |    0.01 | 2.0599 |     - |     - |    4320 B |
|           LinqFaster |          4 |   100 |    937.0 ns |  2.07 ns |  1.94 ns |  0.25 |    0.00 |      - |     - |     - |         - |
|               LinqAF |          4 |   100 | 11,234.9 ns | 33.81 ns | 31.63 ns |  3.00 |    0.01 | 5.9204 |     - |     - |   12400 B |
|           StructLinq |          4 |   100 |  6,208.5 ns | 12.64 ns | 11.82 ns |  1.66 |    0.00 |      - |     - |     - |         - |
| StructLinq_IFunction |          4 |   100 |  4,309.5 ns |  4.53 ns |  3.78 ns |  1.15 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |          4 |   100 |  4,477.4 ns | 30.11 ns | 26.69 ns |  1.20 |    0.01 |      - |     - |     - |         - |
