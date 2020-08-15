## Range.RangeSelectToList

### Source
[RangeSelectToList.cs](../LinqBenchmarks/Range/RangeSelectToList.cs)

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
|               Method | Start | Count |     Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------ |---------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|              ForLoop |     0 |   100 | 340.4 ns | 0.52 ns | 0.40 ns |  1.00 | 0.5660 |     - |     - |    1184 B |
|          ForeachLoop |     0 |   100 | 851.0 ns | 1.45 ns | 1.28 ns |  2.50 | 0.5922 |     - |     - |    1240 B |
|                 Linq |     0 |   100 | 370.4 ns | 0.47 ns | 0.37 ns |  1.09 | 0.2599 |     - |     - |     544 B |
|           LinqFaster |     0 |   100 | 353.5 ns | 0.42 ns | 0.35 ns |  1.04 | 0.6232 |     - |     - |    1304 B |
|               LinqAF |     0 |   100 | 922.3 ns | 1.83 ns | 1.53 ns |  2.71 | 0.5655 |     - |     - |    1184 B |
|           StructLinq |     0 |   100 | 563.9 ns | 0.78 ns | 0.61 ns |  1.66 | 0.2327 |     - |     - |     488 B |
| StructLinq_IFunction |     0 |   100 | 443.8 ns | 0.62 ns | 0.48 ns |  1.30 | 0.2332 |     - |     - |     488 B |
|            Hyperlinq |     0 |   100 | 252.5 ns | 0.36 ns | 0.30 ns |  0.74 | 0.2408 |     - |     - |     504 B |
