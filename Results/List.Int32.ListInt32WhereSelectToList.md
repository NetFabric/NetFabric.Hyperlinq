## List.Int32.ListInt32WhereSelectToList

### Source
[ListInt32WhereSelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToList.cs)

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
|               Method | Count |       Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   316.2 ns | 0.32 ns | 0.25 ns |  1.00 | 0.3095 |     - |     - |     648 B |
|          ForeachLoop |   100 |   421.5 ns | 0.89 ns | 0.74 ns |  1.33 | 0.3095 |     - |     - |     648 B |
|                 Linq |   100 |   647.6 ns | 0.68 ns | 0.53 ns |  2.05 | 0.3824 |     - |     - |     800 B |
|           LinqFaster |   100 |   590.6 ns | 1.48 ns | 1.31 ns |  1.87 | 0.4320 |     - |     - |     904 B |
|               LinqAF |   100 | 1,252.2 ns | 2.10 ns | 1.96 ns |  3.96 | 0.3090 |     - |     - |     648 B |
|           StructLinq |   100 |   697.8 ns | 1.63 ns | 1.44 ns |  2.21 | 0.1450 |     - |     - |     304 B |
| StructLinq_IFunction |   100 |   423.6 ns | 0.90 ns | 0.79 ns |  1.34 | 0.1450 |     - |     - |     304 B |
|            Hyperlinq |   100 |   765.3 ns | 1.98 ns | 1.85 ns |  2.42 | 0.1564 |     - |     - |     328 B |
