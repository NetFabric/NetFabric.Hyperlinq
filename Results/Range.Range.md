## Range.Range

### Source
[Range.cs](../LinqBenchmarks/Range/Range.cs)

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
|      Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|     ForLoop |     0 |   100 |  34.18 ns | 0.255 ns | 0.226 ns |  1.00 |    0.00 |      - |     - |     - |         - |
| ForeachLoop |     0 |   100 | 508.39 ns | 7.081 ns | 5.913 ns | 14.88 |    0.21 | 0.0267 |     - |     - |      56 B |
|        Linq |     0 |   100 | 429.27 ns | 3.043 ns | 2.847 ns | 12.55 |    0.07 | 0.0191 |     - |     - |      40 B |
|  LinqFaster |     0 |   100 | 126.11 ns | 1.249 ns | 1.043 ns |  3.69 |    0.04 | 0.2027 |     - |     - |     424 B |
|      LinqAF |     0 |   100 | 201.65 ns | 2.085 ns | 1.951 ns |  5.89 |    0.07 |      - |     - |     - |         - |
|  StructLinq |     0 |   100 |  41.51 ns | 0.160 ns | 0.142 ns |  1.21 |    0.01 |      - |     - |     - |         - |
|   Hyperlinq |     0 |   100 |  44.70 ns | 0.234 ns | 0.208 ns |  1.31 |    0.01 |      - |     - |     - |         - |
