## Range.Range

### Source
[Range.cs](../LinqBenchmarks/Range/Range.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta27](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta27)

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
|     ForLoop |     0 |   100 |  33.36 ns | 0.123 ns | 0.103 ns |  1.00 |    0.00 |      - |     - |     - |         - |
| ForeachLoop |     0 |   100 | 472.15 ns | 1.641 ns | 1.535 ns | 14.15 |    0.05 | 0.0267 |     - |     - |      56 B |
|        Linq |     0 |   100 | 498.29 ns | 2.057 ns | 1.824 ns | 14.93 |    0.08 | 0.0191 |     - |     - |      40 B |
|  LinqFaster |     0 |   100 | 122.36 ns | 1.019 ns | 0.954 ns |  3.67 |    0.03 | 0.2027 |     - |     - |     424 B |
|      LinqAF |     0 |   100 | 211.61 ns | 0.625 ns | 0.554 ns |  6.34 |    0.03 |      - |     - |     - |         - |
|  StructLinq |     0 |   100 |  34.05 ns | 0.098 ns | 0.082 ns |  1.02 |    0.00 |      - |     - |     - |         - |
|   Hyperlinq |     0 |   100 |  43.42 ns | 0.122 ns | 0.096 ns |  1.30 |    0.00 |      - |     - |     - |         - |
