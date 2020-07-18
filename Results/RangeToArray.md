## RangeToArray

### Source
[RangeToArray.cs](../LinqBenchmarks/RangeToArray.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.1.9](https://www.nuget.org/packages/StructLinq.BCL/0.1.9)
- NetFabric.Hyperlinq: [3.0.0-beta19](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta19)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|         Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------- |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|        ForLoop |     0 |   100 |  77.42 ns | 0.272 ns | 0.227 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|           Linq |     0 |   100 |  81.92 ns | 0.349 ns | 0.327 ns |  1.06 |    0.00 | 0.2218 |     - |     - |     464 B |
|     LinqFaster |     0 |   100 |  66.16 ns | 0.402 ns | 0.356 ns |  0.85 |    0.00 | 0.2027 |     - |     - |     424 B |
|     StructLinq |     0 |   100 | 308.87 ns | 2.282 ns | 2.023 ns |  3.99 |    0.03 | 0.7801 |     - |     - |    1632 B |
|      Hyperlinq |     0 |   100 |  78.98 ns | 0.593 ns | 0.555 ns |  1.02 |    0.01 | 0.2027 |     - |     - |     424 B |
| Hyperlinq_Pool |     0 |   100 | 117.97 ns | 0.612 ns | 0.543 ns |  1.52 |    0.01 | 0.0267 |     - |     - |      56 B |
