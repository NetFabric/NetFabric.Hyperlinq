## Range.Range

### Source
[Range.cs](../LinqBenchmarks/Range/Range.cs)

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
|      Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|     ForLoop |     0 |   100 |  36.55 ns | 0.030 ns | 0.024 ns |  1.00 |    0.00 |      - |     - |     - |         - |
| ForeachLoop |     0 |   100 | 568.74 ns | 0.491 ns | 0.410 ns | 15.56 |    0.02 | 0.0267 |     - |     - |      56 B |
|        Linq |     0 |   100 | 542.31 ns | 0.645 ns | 0.572 ns | 14.84 |    0.02 | 0.0191 |     - |     - |      40 B |
|  LinqFaster |     0 |   100 | 151.15 ns | 0.239 ns | 0.223 ns |  4.13 |    0.01 | 0.2027 |     - |     - |     424 B |
|      LinqAF |     0 |   100 | 224.56 ns | 0.408 ns | 0.382 ns |  6.14 |    0.01 |      - |     - |     - |         - |
|  StructLinq |     0 |   100 |  63.59 ns | 0.602 ns | 0.563 ns |  1.74 |    0.02 |      - |     - |     - |         - |
|   Hyperlinq |     0 |   100 |  52.14 ns | 0.071 ns | 0.063 ns |  1.43 |    0.00 |      - |     - |     - |         - |
