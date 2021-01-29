## Range.Range

### Source
[Range.cs](../LinqBenchmarks/Range/Range.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta28](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta28)

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
|     ForLoop |     0 |   100 |  37.29 ns | 0.197 ns | 0.175 ns |  1.00 |    0.00 |      - |     - |     - |         - |
| ForeachLoop |     0 |   100 | 497.30 ns | 4.687 ns | 4.384 ns | 13.33 |    0.13 | 0.0267 |     - |     - |      56 B |
|        Linq |     0 |   100 | 466.31 ns | 2.058 ns | 1.824 ns | 12.51 |    0.09 | 0.0191 |     - |     - |      40 B |
|  LinqFaster |     0 |   100 | 150.37 ns | 1.408 ns | 1.317 ns |  4.03 |    0.05 | 0.2027 |     - |     - |     424 B |
|      LinqAF |     0 |   100 | 220.04 ns | 0.750 ns | 0.665 ns |  5.90 |    0.02 |      - |     - |     - |         - |
|  StructLinq |     0 |   100 |  37.96 ns | 0.200 ns | 0.187 ns |  1.02 |    0.00 |      - |     - |     - |         - |
|   Hyperlinq |     0 |   100 |  48.25 ns | 0.087 ns | 0.077 ns |  1.29 |    0.01 |      - |     - |     - |         - |
