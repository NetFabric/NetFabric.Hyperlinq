## List.Int32.ListInt32SkipTakeWhere

### Source
[ListInt32SkipTakeWhere.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeWhere.cs)

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
|               Method | Skip | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |   145.7 ns |  0.15 ns |  0.12 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 4,207.2 ns | 16.72 ns | 15.64 ns | 28.88 |    0.12 | 0.0153 |     - |     - |      40 B |
|                 Linq | 1000 |   100 | 1,438.4 ns |  3.89 ns |  3.45 ns |  9.87 |    0.03 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |   100 |   981.6 ns |  3.56 ns |  3.15 ns |  6.74 |    0.02 | 0.7458 |     - |     - |    1560 B |
|               LinqAF | 1000 |   100 | 6,917.1 ns | 15.77 ns | 13.98 ns | 47.49 |    0.09 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 | 1,240.8 ns |  0.62 ns |  0.52 ns |  8.52 |    0.01 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 | 1,093.3 ns |  5.34 ns |  4.46 ns |  7.51 |    0.03 | 0.0458 |     - |     - |      96 B |
|            Hyperlinq | 1000 |   100 |   372.5 ns |  0.40 ns |  0.33 ns |  2.56 |    0.00 |      - |     - |     - |         - |
