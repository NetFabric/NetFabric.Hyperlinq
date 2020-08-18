## List.Int32.ListInt32SkipTakeWhere

### Source
[ListInt32SkipTakeWhere.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeWhere.cs)

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
|               Method | Skip | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |   129.7 ns |  0.07 ns |  0.06 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 4,587.4 ns |  7.50 ns |  6.26 ns | 35.37 |    0.05 | 0.0153 |     - |     - |      40 B |
|                 Linq | 1000 |   100 | 1,458.2 ns | 17.05 ns | 15.95 ns | 11.25 |    0.12 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |   100 |   973.7 ns |  7.60 ns |  6.74 ns |  7.51 |    0.05 | 0.7458 |     - |     - |    1560 B |
|               LinqAF | 1000 |   100 | 6,237.5 ns |  9.55 ns |  8.46 ns | 48.09 |    0.06 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 | 1,229.4 ns |  2.00 ns |  1.78 ns |  9.48 |    0.02 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 | 1,106.4 ns |  1.27 ns |  1.06 ns |  8.53 |    0.01 | 0.0458 |     - |     - |      96 B |
|            Hyperlinq | 1000 |   100 |   372.6 ns |  0.65 ns |  0.61 ns |  2.87 |    0.01 |      - |     - |     - |         - |
