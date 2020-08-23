## Range.RangeToArray

### Source
[RangeToArray.cs](../LinqBenchmarks/Range/RangeToArray.cs)

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
|         Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------- |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|        ForLoop |     0 |   100 | 132.36 ns | 1.084 ns | 1.014 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|           Linq |     0 |   100 |  87.02 ns | 0.650 ns | 0.608 ns |  0.66 |    0.01 | 0.2218 |     - |     - |     464 B |
|     LinqFaster |     0 |   100 |  79.30 ns | 0.751 ns | 0.666 ns |  0.60 |    0.01 | 0.2027 |     - |     - |     424 B |
|         LinqAF |     0 |   100 | 269.90 ns | 2.125 ns | 1.884 ns |  2.04 |    0.02 | 0.2027 |     - |     - |     424 B |
|     StructLinq |     0 |   100 | 216.50 ns | 1.442 ns | 1.278 ns |  1.64 |    0.02 | 0.2027 |     - |     - |     424 B |
|      Hyperlinq |     0 |   100 |  82.95 ns | 0.681 ns | 0.604 ns |  0.63 |    0.01 | 0.2027 |     - |     - |     424 B |
| Hyperlinq_Pool |     0 |   100 | 120.42 ns | 0.493 ns | 0.437 ns |  0.91 |    0.01 | 0.0267 |     - |     - |      56 B |
