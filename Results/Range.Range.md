## Range.Range

### Source
[Range.cs](../LinqBenchmarks/Range/Range.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta29](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta29)

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
|     ForLoop |     0 |   100 |  32.20 ns |  0.105 ns |  0.093 ns |  1.00 |    0.00 |      - |     - |     - |         - |
| ForeachLoop |     0 |   100 | 769.96 ns | 15.304 ns | 26.804 ns | 23.82 |    0.77 | 0.0267 |     - |     - |      56 B |
|        Linq |     0 |   100 | 882.69 ns | 21.387 ns | 62.725 ns | 27.21 |    1.49 | 0.0191 |     - |     - |      40 B |
|  LinqFaster |     0 |   100 | 134.30 ns |  0.501 ns |  0.444 ns |  4.17 |    0.02 | 0.2027 |     - |     - |     424 B |
|      LinqAF |     0 |   100 | 451.42 ns |  9.017 ns | 25.432 ns | 13.76 |    0.85 |      - |     - |     - |         - |
|  StructLinq |     0 |   100 |  32.72 ns |  0.105 ns |  0.088 ns |  1.02 |    0.00 |      - |     - |     - |         - |
|   Hyperlinq |     0 |   100 |  45.85 ns |  0.275 ns |  0.244 ns |  1.42 |    0.01 |      - |     - |     - |         - |
