## List.Int32.ListInt32WhereSelectToList

### Source
[ListInt32WhereSelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToList.cs)

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
|               Method | Count |       Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   317.7 ns | 1.27 ns | 1.13 ns |  1.00 |    0.00 | 0.3095 |     - |     - |     648 B |
|          ForeachLoop |   100 |   423.0 ns | 0.67 ns | 0.56 ns |  1.33 |    0.00 | 0.3095 |     - |     - |     648 B |
|                 Linq |   100 |   642.6 ns | 0.72 ns | 0.60 ns |  2.02 |    0.01 | 0.3824 |     - |     - |     800 B |
|           LinqFaster |   100 |   593.3 ns | 2.96 ns | 2.31 ns |  1.87 |    0.01 | 0.4320 |     - |     - |     904 B |
|               LinqAF |   100 | 1,279.7 ns | 4.66 ns | 4.13 ns |  4.03 |    0.02 | 0.3090 |     - |     - |     648 B |
|           StructLinq |   100 |   730.9 ns | 3.05 ns | 2.85 ns |  2.30 |    0.01 | 0.1450 |     - |     - |     304 B |
| StructLinq_IFunction |   100 |   425.0 ns | 2.52 ns | 2.10 ns |  1.34 |    0.01 | 0.1450 |     - |     - |     304 B |
|            Hyperlinq |   100 |   785.4 ns | 2.15 ns | 2.01 ns |  2.47 |    0.01 | 0.1564 |     - |     - |     328 B |
