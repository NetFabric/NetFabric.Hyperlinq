## List.Int32.ListInt32SkipTakeSelect

### Source
[ListInt32SkipTakeSelect.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeSelect.cs)

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
|               Method | Skip | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-------------:|-----------:|-----------:|-------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |     70.07 ns |   0.290 ns |   0.242 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 |  5,289.88 ns | 105.223 ns | 200.197 ns |  76.57 |    3.17 | 0.0153 |     - |     - |      40 B |
|                 Linq | 1000 |   100 |  1,183.21 ns |   2.175 ns |   2.034 ns |  16.89 |    0.07 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |   100 |    908.98 ns |   3.095 ns |   2.744 ns |  12.97 |    0.07 | 0.6542 |     - |     - |    1368 B |
|               LinqAF | 1000 |   100 | 13,258.07 ns | 249.719 ns | 366.035 ns | 189.80 |    3.31 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |  1,174.57 ns |   1.499 ns |   1.171 ns |  16.76 |    0.06 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 |  1,041.82 ns |   1.564 ns |   1.306 ns |  14.87 |    0.05 | 0.0458 |     - |     - |      96 B |
|    Hyperlinq_Foreach | 1000 |   100 |    331.66 ns |   0.968 ns |   0.809 ns |   4.73 |    0.02 |      - |     - |     - |         - |
|        Hyperlinq_For | 1000 |   100 |    268.24 ns |   0.143 ns |   0.119 ns |   3.83 |    0.01 |      - |     - |     - |         - |
