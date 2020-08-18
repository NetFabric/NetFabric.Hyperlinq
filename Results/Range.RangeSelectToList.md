## Range.RangeSelectToList

### Source
[RangeSelectToList.cs](../LinqBenchmarks/Range/RangeSelectToList.cs)

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
|               Method | Start | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |     0 |   100 | 338.2 ns | 0.53 ns | 0.42 ns |  1.00 |    0.00 | 0.5660 |     - |     - |    1184 B |
|          ForeachLoop |     0 |   100 | 855.6 ns | 2.82 ns | 2.64 ns |  2.53 |    0.01 | 0.5922 |     - |     - |    1240 B |
|                 Linq |     0 |   100 | 322.2 ns | 0.74 ns | 0.61 ns |  0.95 |    0.00 | 0.2599 |     - |     - |     544 B |
|           LinqFaster |     0 |   100 | 352.9 ns | 0.37 ns | 0.29 ns |  1.04 |    0.00 | 0.6232 |     - |     - |    1304 B |
|               LinqAF |     0 |   100 | 922.7 ns | 6.69 ns | 5.93 ns |  2.73 |    0.02 | 0.5655 |     - |     - |    1184 B |
|           StructLinq |     0 |   100 | 566.3 ns | 1.29 ns | 1.08 ns |  1.67 |    0.00 | 0.2327 |     - |     - |     488 B |
| StructLinq_IFunction |     0 |   100 | 425.2 ns | 0.81 ns | 0.72 ns |  1.26 |    0.00 | 0.2332 |     - |     - |     488 B |
|            Hyperlinq |     0 |   100 | 252.5 ns | 0.22 ns | 0.17 ns |  0.75 |    0.00 | 0.2408 |     - |     - |     504 B |
