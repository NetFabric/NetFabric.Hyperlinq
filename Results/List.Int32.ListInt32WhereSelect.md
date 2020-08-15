## List.Int32.ListInt32WhereSelect

### Source
[ListInt32WhereSelect.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelect.cs)

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
|               Method | Count |     Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 162.6 ns | 0.26 ns | 0.21 ns |  1.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 305.4 ns | 0.36 ns | 0.28 ns |  1.88 |      - |     - |     - |         - |
|                 Linq |   100 | 890.8 ns | 1.66 ns | 1.47 ns |  5.48 | 0.0725 |     - |     - |     152 B |
|           LinqFaster |   100 | 556.7 ns | 2.32 ns | 1.94 ns |  3.42 | 0.3090 |     - |     - |     648 B |
|               LinqAF |   100 | 982.5 ns | 1.33 ns | 1.11 ns |  6.04 |      - |     - |     - |         - |
|           StructLinq |   100 | 516.4 ns | 0.30 ns | 0.26 ns |  3.18 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 194.5 ns | 0.29 ns | 0.27 ns |  1.20 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 527.4 ns | 1.39 ns | 1.16 ns |  3.24 |      - |     - |     - |         - |
