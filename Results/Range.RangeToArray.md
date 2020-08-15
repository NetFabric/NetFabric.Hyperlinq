## Range.RangeToArray

### Source
[RangeToArray.cs](../LinqBenchmarks/Range/RangeToArray.cs)

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
|         Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------- |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|        ForLoop |     0 |   100 |  91.98 ns | 0.337 ns | 0.315 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|           Linq |     0 |   100 | 100.00 ns | 0.284 ns | 0.251 ns |  1.09 |    0.00 | 0.2218 |     - |     - |     464 B |
|     LinqFaster |     0 |   100 |  89.92 ns | 0.679 ns | 0.567 ns |  0.98 |    0.01 | 0.2027 |     - |     - |     424 B |
|         LinqAF |     0 |   100 | 286.55 ns | 0.830 ns | 0.736 ns |  3.11 |    0.01 | 0.2027 |     - |     - |     424 B |
|     StructLinq |     0 |   100 | 359.51 ns | 1.930 ns | 1.805 ns |  3.91 |    0.02 | 0.2141 |     - |     - |     448 B |
|      Hyperlinq |     0 |   100 |  91.96 ns | 0.295 ns | 0.247 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
| Hyperlinq_Pool |     0 |   100 | 147.53 ns | 0.432 ns | 0.404 ns |  1.60 |    0.01 | 0.0267 |     - |     - |      56 B |
