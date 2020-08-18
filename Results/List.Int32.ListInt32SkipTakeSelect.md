## List.Int32.ListInt32SkipTakeSelect

### Source
[ListInt32SkipTakeSelect.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeSelect.cs)

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
|               Method | Skip | Count |        Mean |     Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |------------:|----------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |    69.41 ns |  0.042 ns | 0.037 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 5,229.13 ns | 10.856 ns | 9.624 ns | 75.33 |    0.15 | 0.0153 |     - |     - |      40 B |
|                 Linq | 1000 |   100 | 1,181.32 ns |  3.647 ns | 3.412 ns | 17.02 |    0.05 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |   100 |   905.90 ns |  2.339 ns | 2.187 ns | 13.05 |    0.03 | 0.6542 |     - |     - |    1368 B |
|               LinqAF | 1000 |   100 | 6,117.32 ns |  7.188 ns | 6.002 ns | 88.13 |    0.11 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 | 1,138.21 ns |  2.373 ns | 1.852 ns | 16.40 |    0.02 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 | 1,008.20 ns |  1.602 ns | 1.338 ns | 14.52 |    0.02 | 0.0458 |     - |     - |      96 B |
|    Hyperlinq_Foreach | 1000 |   100 |   339.03 ns |  0.824 ns | 0.730 ns |  4.88 |    0.01 |      - |     - |     - |         - |
|        Hyperlinq_For | 1000 |   100 |   383.19 ns |  0.177 ns | 0.139 ns |  5.52 |    0.00 |      - |     - |     - |         - |
