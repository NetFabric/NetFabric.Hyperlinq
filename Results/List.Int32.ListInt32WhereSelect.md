## List.Int32.ListInt32WhereSelect

### Source
[ListInt32WhereSelect.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

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
|              ForLoop |   100 |   162.6 ns | 0.28 ns | 0.25 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   305.7 ns | 1.17 ns | 1.04 ns |  1.88 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 |   852.1 ns | 1.65 ns | 1.29 ns |  5.24 |    0.01 | 0.0725 |     - |     - |     152 B |
|           LinqFaster |   100 |   557.5 ns | 2.34 ns | 1.95 ns |  3.43 |    0.01 | 0.3090 |     - |     - |     648 B |
|               LinqAF |   100 | 1,028.4 ns | 2.25 ns | 1.88 ns |  6.32 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 |   478.4 ns | 0.97 ns | 0.86 ns |  2.94 |    0.01 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 |   194.0 ns | 0.10 ns | 0.08 ns |  1.19 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   526.8 ns | 1.24 ns | 1.10 ns |  3.24 |    0.01 |      - |     - |     - |         - |
