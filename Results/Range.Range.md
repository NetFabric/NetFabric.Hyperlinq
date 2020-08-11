## Range.Range

### Source
[Range.cs](../LinqBenchmarks/Range/Range.cs)

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
|      Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|     ForLoop |     0 |   100 |  36.50 ns | 0.032 ns | 0.025 ns |  1.00 |    0.00 |      - |     - |     - |         - |
| ForeachLoop |     0 |   100 | 568.37 ns | 1.452 ns | 1.287 ns | 15.57 |    0.04 | 0.0267 |     - |     - |      56 B |
|        Linq |     0 |   100 | 538.90 ns | 0.877 ns | 0.733 ns | 14.76 |    0.02 | 0.0191 |     - |     - |      40 B |
|  LinqFaster |     0 |   100 | 136.31 ns | 0.387 ns | 0.323 ns |  3.73 |    0.01 | 0.2027 |     - |     - |     424 B |
|      LinqAF |     0 |   100 | 188.09 ns | 0.382 ns | 0.319 ns |  5.15 |    0.01 |      - |     - |     - |         - |
|  StructLinq |     0 |   100 |  44.17 ns | 0.042 ns | 0.035 ns |  1.21 |    0.00 |      - |     - |     - |         - |
|   Hyperlinq |     0 |   100 |  46.97 ns | 0.054 ns | 0.045 ns |  1.29 |    0.00 |      - |     - |     - |         - |
