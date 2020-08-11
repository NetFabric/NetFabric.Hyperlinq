## List.Int32.ListInt32Select

### Source
[ListInt32Select.cs](../LinqBenchmarks/List/Int32/ListInt32Select.cs)

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
|               Method | Count |       Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   112.1 ns | 0.20 ns | 0.19 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   233.5 ns | 0.25 ns | 0.23 ns |  2.08 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 1,004.4 ns | 1.60 ns | 1.34 ns |  8.96 |    0.02 | 0.0343 |     - |     - |      72 B |
|           LinqFaster |   100 |   454.8 ns | 0.98 ns | 0.82 ns |  4.06 |    0.01 | 0.2179 |     - |     - |     456 B |
|               LinqAF |   100 |   827.1 ns | 1.68 ns | 1.49 ns |  7.38 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 |   293.0 ns | 0.42 ns | 0.37 ns |  2.61 |    0.01 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 |   170.5 ns | 0.12 ns | 0.10 ns |  1.52 |    0.00 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |   100 |   324.2 ns | 0.13 ns | 0.11 ns |  2.89 |    0.01 |      - |     - |     - |         - |
|        Hyperlinq_For |   100 |   323.8 ns | 0.50 ns | 0.42 ns |  2.89 |    0.01 |      - |     - |     - |         - |
