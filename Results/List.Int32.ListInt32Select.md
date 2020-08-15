## List.Int32.ListInt32Select

### Source
[ListInt32Select.cs](../LinqBenchmarks/List/Int32/ListInt32Select.cs)

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
|               Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 111.8 ns | 0.08 ns | 0.06 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 239.9 ns | 0.13 ns | 0.10 ns |  2.14 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 987.4 ns | 3.40 ns | 3.01 ns |  8.83 |    0.03 | 0.0343 |     - |     - |      72 B |
|           LinqFaster |   100 | 439.8 ns | 1.88 ns | 1.67 ns |  3.93 |    0.01 | 0.2179 |     - |     - |     456 B |
|               LinqAF |   100 | 723.8 ns | 1.15 ns | 0.96 ns |  6.47 |    0.01 |      - |     - |     - |         - |
|           StructLinq |   100 | 291.4 ns | 0.21 ns | 0.17 ns |  2.61 |    0.00 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 170.5 ns | 0.24 ns | 0.20 ns |  1.52 |    0.00 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |   100 | 277.9 ns | 0.49 ns | 0.43 ns |  2.49 |    0.00 |      - |     - |     - |         - |
|        Hyperlinq_For |   100 | 295.6 ns | 0.31 ns | 0.24 ns |  2.64 |    0.00 |      - |     - |     - |         - |
