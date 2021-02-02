## Range.Range

### Source
[Range.cs](../LinqBenchmarks/Range/Range.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta30](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta30)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|      Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|     ForLoop |     0 |   100 |  33.55 ns | 0.107 ns | 0.089 ns |  1.00 |    0.00 |      - |     - |     - |         - |
| ForeachLoop |     0 |   100 | 445.73 ns | 0.929 ns | 0.824 ns | 13.28 |    0.04 | 0.0267 |     - |     - |      56 B |
|        Linq |     0 |   100 | 397.66 ns | 1.016 ns | 0.901 ns | 11.85 |    0.05 | 0.0191 |     - |     - |      40 B |
|  LinqFaster |     0 |   100 | 122.70 ns | 0.562 ns | 0.525 ns |  3.66 |    0.02 | 0.2027 |     - |     - |     424 B |
|      LinqAF |     0 |   100 | 219.96 ns | 0.428 ns | 0.379 ns |  6.56 |    0.02 |      - |     - |     - |         - |
|  StructLinq |     0 |   100 |  33.93 ns | 0.129 ns | 0.121 ns |  1.01 |    0.00 |      - |     - |     - |         - |
|   Hyperlinq |     0 |   100 |  43.71 ns | 0.112 ns | 0.099 ns |  1.30 |    0.00 |      - |     - |     - |         - |
