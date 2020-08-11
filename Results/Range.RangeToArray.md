## Range.RangeToArray

### Source
[RangeToArray.cs](../LinqBenchmarks/Range/RangeToArray.cs)

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
|         Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------- |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|        ForLoop |     0 |   100 |  88.46 ns | 0.233 ns | 0.218 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|           Linq |     0 |   100 |  99.45 ns | 0.286 ns | 0.268 ns |  1.12 |    0.00 | 0.2218 |     - |     - |     464 B |
|     LinqFaster |     0 |   100 |  89.04 ns | 0.458 ns | 0.428 ns |  1.01 |    0.00 | 0.2027 |     - |     - |     424 B |
|         LinqAF |     0 |   100 | 283.24 ns | 0.430 ns | 0.382 ns |  3.20 |    0.01 | 0.2027 |     - |     - |     424 B |
|     StructLinq |     0 |   100 | 351.60 ns | 1.101 ns | 1.030 ns |  3.97 |    0.02 | 0.2141 |     - |     - |     448 B |
|      Hyperlinq |     0 |   100 |  95.00 ns | 0.237 ns | 0.210 ns |  1.07 |    0.00 | 0.2027 |     - |     - |     424 B |
| Hyperlinq_Pool |     0 |   100 | 140.88 ns | 0.363 ns | 0.303 ns |  1.59 |    0.01 | 0.0267 |     - |     - |      56 B |
