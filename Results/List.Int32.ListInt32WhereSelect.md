## List.Int32.ListInt32WhereSelect

### Source
[ListInt32WhereSelect.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelect.cs)

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
|               Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 132.9 ns | 0.10 ns | 0.09 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 304.9 ns | 0.44 ns | 0.37 ns |  2.29 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 853.6 ns | 1.24 ns | 1.03 ns |  6.42 |    0.01 | 0.0725 |     - |     - |     152 B |
|           LinqFaster |   100 | 590.6 ns | 0.88 ns | 0.69 ns |  4.44 |    0.00 | 0.3090 |     - |     - |     648 B |
|               LinqAF |   100 | 961.8 ns | 2.27 ns | 2.01 ns |  7.24 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 | 516.3 ns | 1.38 ns | 1.22 ns |  3.89 |    0.01 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 195.7 ns | 0.17 ns | 0.16 ns |  1.47 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 469.0 ns | 0.97 ns | 0.81 ns |  3.53 |    0.01 |      - |     - |     - |         - |
