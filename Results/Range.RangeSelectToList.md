## Range.RangeSelectToList

### Source
[RangeSelectToList.cs](../LinqBenchmarks/Range/RangeSelectToList.cs)

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
|               Method | Start | Count |     Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------ |---------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|              ForLoop |     0 |   100 | 331.5 ns | 0.54 ns | 0.42 ns |  1.00 | 0.5660 |     - |     - |    1184 B |
|          ForeachLoop |     0 |   100 | 852.7 ns | 2.72 ns | 2.41 ns |  2.57 | 0.5922 |     - |     - |    1240 B |
|                 Linq |     0 |   100 | 317.4 ns | 0.75 ns | 0.66 ns |  0.96 | 0.2599 |     - |     - |     544 B |
|           LinqFaster |     0 |   100 | 358.5 ns | 1.91 ns | 1.59 ns |  1.08 | 0.6232 |     - |     - |    1304 B |
|               LinqAF |     0 |   100 | 917.9 ns | 2.80 ns | 2.62 ns |  2.77 | 0.5655 |     - |     - |    1184 B |
|           StructLinq |     0 |   100 | 546.8 ns | 1.38 ns | 1.22 ns |  1.65 | 0.2327 |     - |     - |     488 B |
| StructLinq_IFunction |     0 |   100 | 421.4 ns | 0.82 ns | 0.73 ns |  1.27 | 0.2332 |     - |     - |     488 B |
|            Hyperlinq |     0 |   100 | 246.6 ns | 0.27 ns | 0.23 ns |  0.74 | 0.2408 |     - |     - |     504 B |
