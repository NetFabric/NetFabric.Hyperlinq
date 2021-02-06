## Range.Range

### Source
[Range.cs](../LinqBenchmarks/Range/Range.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta32](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta32)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|      Method | Start | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |------ |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|     ForLoop |     0 |   100 |  31.69 ns |  0.125 ns |  0.105 ns |  1.00 |    0.00 |      - |     - |     - |         - |
| ForeachLoop |     0 |   100 | 786.29 ns | 15.394 ns | 25.293 ns | 24.67 |    0.81 | 0.0267 |     - |     - |      56 B |
|        Linq |     0 |   100 | 837.83 ns | 17.687 ns | 51.874 ns | 26.53 |    2.18 | 0.0191 |     - |     - |      40 B |
|  LinqFaster |     0 |   100 | 135.25 ns |  0.870 ns |  0.814 ns |  4.27 |    0.03 | 0.2027 |     - |     - |     424 B |
|      LinqAF |     0 |   100 | 427.31 ns | 11.191 ns | 32.820 ns | 13.53 |    1.21 |      - |     - |     - |         - |
|  StructLinq |     0 |   100 |  33.32 ns |  0.094 ns |  0.088 ns |  1.05 |    0.00 |      - |     - |     - |         - |
|   Hyperlinq |     0 |   100 |  46.65 ns |  0.307 ns |  0.287 ns |  1.47 |    0.01 |      - |     - |     - |         - |
