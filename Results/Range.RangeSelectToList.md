## Range.RangeSelectToList

### Source
[RangeSelectToList.cs](../LinqBenchmarks/Range/RangeSelectToList.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta23](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta23)

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
|              ForLoop |     0 |   100 | 302.6 ns | 2.70 ns | 2.53 ns |  1.00 |    0.00 | 0.5660 |     - |     - |    1184 B |
|          ForeachLoop |     0 |   100 | 701.7 ns | 4.22 ns | 3.95 ns |  2.32 |    0.03 | 0.5922 |     - |     - |    1240 B |
|                 Linq |     0 |   100 | 353.9 ns | 4.53 ns | 3.79 ns |  1.17 |    0.02 | 0.2599 |     - |     - |     544 B |
|           LinqFaster |     0 |   100 | 339.2 ns | 1.37 ns | 1.07 ns |  1.12 |    0.01 | 0.6232 |     - |     - |    1304 B |
|           StructLinq |     0 |   100 | 528.5 ns | 2.80 ns | 2.48 ns |  1.75 |    0.02 | 0.2327 |     - |     - |     488 B |
| StructLinq_IFunction |     0 |   100 | 385.4 ns | 2.25 ns | 2.00 ns |  1.27 |    0.01 | 0.2332 |     - |     - |     488 B |
|            Hyperlinq |     0 |   100 | 255.3 ns | 1.60 ns | 1.42 ns |  0.84 |    0.01 | 0.2446 |     - |     - |     512 B |
