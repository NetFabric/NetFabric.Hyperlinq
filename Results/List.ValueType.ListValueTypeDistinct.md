## List.ValueType.ListValueTypeDistinct

### Source
[ListValueTypeDistinct.cs](../LinqBenchmarks/List/ValueType/ListValueTypeDistinct.cs)

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
|               Method | Duplicates | Count |         Mean |     Error |    StdDev | Ratio |     Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |-------------:|----------:|----------:|------:|----------:|------:|------:|----------:|
|              ForLoop |          4 |   100 |   703.036 μs | 1.2975 μs | 1.0834 μs | 1.000 | 1095.7031 |     - |     - | 2292184 B |
|          ForeachLoop |          4 |   100 |   702.684 μs | 1.1982 μs | 1.0005 μs | 1.000 | 1095.7031 |     - |     - | 2292184 B |
|                 Linq |          4 |   100 |   770.884 μs | 2.4502 μs | 2.2919 μs | 1.097 | 1092.7734 |     - |     - | 2286712 B |
|           LinqFaster |          4 |   100 |     2.604 μs | 0.0056 μs | 0.0050 μs | 0.004 |    0.0114 |     - |     - |      24 B |
|               LinqAF |          4 |   100 | 3,021.937 μs | 7.4613 μs | 6.2306 μs | 4.298 | 2187.5000 |     - |     - | 4575074 B |
|           StructLinq |          4 |   100 |   813.954 μs | 0.8246 μs | 0.6438 μs | 1.158 | 1086.9141 |     - |     - | 2273600 B |
| StructLinq_IFunction |          4 |   100 |    24.149 μs | 0.0362 μs | 0.0338 μs | 0.034 |         - |     - |     - |         - |
|            Hyperlinq |          4 |   100 |   669.258 μs | 4.0236 μs | 3.3599 μs | 0.952 | 1045.8984 |     - |     - | 2187584 B |
