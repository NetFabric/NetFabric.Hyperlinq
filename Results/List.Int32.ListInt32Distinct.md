## List.Int32.ListInt32Distinct

### Source
[ListInt32Distinct.cs](../LinqBenchmarks/List/Int32/ListInt32Distinct.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [1.0.0](https://www.nuget.org/packages/LinqAF/1.0.0)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta25](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta25)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=macOS Catalina 10.15.6 (19G73) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Duplicates | Count |        Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |------------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|              ForLoop |          4 |   100 |  4,221.6 ns | 12.03 ns | 10.67 ns |  1.00 | 2.8687 |     - |     - |    6008 B |
|          ForeachLoop |          4 |   100 |  4,874.6 ns | 17.33 ns | 15.36 ns |  1.15 | 2.8687 |     - |     - |    6008 B |
|                 Linq |          4 |   100 |  8,775.1 ns | 22.72 ns | 18.97 ns |  2.08 | 2.0599 |     - |     - |    4320 B |
|           LinqFaster |          4 |   100 |    920.4 ns |  1.01 ns |  0.85 ns |  0.22 |      - |     - |     - |         - |
|               LinqAF |          4 |   100 | 11,312.5 ns | 18.26 ns | 15.24 ns |  2.68 | 5.9204 |     - |     - |   12400 B |
|           StructLinq |          4 |   100 |  5,828.3 ns | 12.50 ns | 11.70 ns |  1.38 |      - |     - |     - |         - |
| StructLinq_IFunction |          4 |   100 |  4,283.4 ns |  5.46 ns |  4.56 ns |  1.01 |      - |     - |     - |         - |
|            Hyperlinq |          4 |   100 |  4,429.8 ns |  3.34 ns |  2.61 ns |  1.05 |      - |     - |     - |         - |
