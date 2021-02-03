## Range.Range

### Source
[Range.cs](../LinqBenchmarks/Range/Range.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta31](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta31)

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
|     ForLoop |     0 |   100 |  33.52 ns |  0.065 ns |  0.051 ns |  1.00 |    0.00 |      - |     - |     - |         - |
| ForeachLoop |     0 |   100 | 788.12 ns | 15.492 ns | 25.454 ns | 23.52 |    0.47 | 0.0267 |     - |     - |      56 B |
|        Linq |     0 |   100 | 903.65 ns | 25.241 ns | 74.425 ns | 27.49 |    2.35 | 0.0191 |     - |     - |      40 B |
|  LinqFaster |     0 |   100 | 133.38 ns |  0.530 ns |  0.470 ns |  3.98 |    0.01 | 0.2027 |     - |     - |     424 B |
|      LinqAF |     0 |   100 | 419.41 ns |  9.373 ns | 27.637 ns | 12.77 |    0.57 |      - |     - |     - |         - |
|  StructLinq |     0 |   100 |  32.53 ns |  0.103 ns |  0.097 ns |  0.97 |    0.00 |      - |     - |     - |         - |
|   Hyperlinq |     0 |   100 |  45.24 ns |  0.323 ns |  0.286 ns |  1.35 |    0.01 |      - |     - |     - |         - |
