## Range.RangeSelectToList

### Source
[RangeSelectToList.cs](../LinqBenchmarks/Range/RangeSelectToList.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Start | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |     0 |   100 | 290.5 ns | 3.03 ns | 2.68 ns |  1.00 |    0.00 | 0.5660 |     - |     - |    1184 B |
|          ForeachLoop |     0 |   100 | 748.5 ns | 5.24 ns | 4.64 ns |  2.58 |    0.03 | 0.5922 |     - |     - |    1240 B |
|                 Linq |     0 |   100 | 326.8 ns | 2.96 ns | 2.77 ns |  1.12 |    0.02 | 0.2599 |     - |     - |     544 B |
|           LinqFaster |     0 |   100 | 369.2 ns | 2.35 ns | 2.08 ns |  1.27 |    0.01 | 0.6232 |     - |     - |    1304 B |
|               LinqAF |     0 |   100 | 798.3 ns | 8.80 ns | 8.23 ns |  2.75 |    0.03 | 0.5655 |     - |     - |    1184 B |
|           StructLinq |     0 |   100 | 456.8 ns | 2.54 ns | 2.25 ns |  1.57 |    0.01 | 0.2294 |     - |     - |     480 B |
| StructLinq_IFunction |     0 |   100 | 312.0 ns | 1.93 ns | 1.80 ns |  1.07 |    0.01 | 0.2179 |     - |     - |     456 B |
|            Hyperlinq |     0 |   100 | 225.6 ns | 1.10 ns | 0.98 ns |  0.78 |    0.01 | 0.2408 |     - |     - |     504 B |
