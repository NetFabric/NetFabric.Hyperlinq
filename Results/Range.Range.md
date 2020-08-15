## Range.Range

### Source
[Range.cs](../LinqBenchmarks/Range/Range.cs)

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
|      Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|     ForLoop |     0 |   100 |  36.57 ns | 0.031 ns | 0.026 ns |  1.00 |    0.00 |      - |     - |     - |         - |
| ForeachLoop |     0 |   100 | 570.57 ns | 0.785 ns | 0.655 ns | 15.60 |    0.02 | 0.0267 |     - |     - |      56 B |
|        Linq |     0 |   100 | 540.37 ns | 0.605 ns | 0.505 ns | 14.78 |    0.02 | 0.0191 |     - |     - |      40 B |
|  LinqFaster |     0 |   100 | 149.92 ns | 0.530 ns | 0.470 ns |  4.10 |    0.01 | 0.2027 |     - |     - |     424 B |
|      LinqAF |     0 |   100 | 226.27 ns | 0.239 ns | 0.200 ns |  6.19 |    0.01 |      - |     - |     - |         - |
|  StructLinq |     0 |   100 |  62.72 ns | 0.055 ns | 0.046 ns |  1.72 |    0.00 |      - |     - |     - |         - |
|   Hyperlinq |     0 |   100 |  52.16 ns | 0.090 ns | 0.075 ns |  1.43 |    0.00 |      - |     - |     - |         - |
