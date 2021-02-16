## Range.Range

### Source
[Range.cs](../LinqBenchmarks/Range/Range.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta37](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta37)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|          Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|         ForLoop |     0 |   100 |  33.74 ns | 0.093 ns | 0.087 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|     ForeachLoop |     0 |   100 | 448.19 ns | 1.801 ns | 1.685 ns | 13.29 |    0.06 | 0.0267 |     - |     - |      56 B |
|            Linq |     0 |   100 | 420.17 ns | 1.151 ns | 1.020 ns | 12.45 |    0.05 | 0.0191 |     - |     - |      40 B |
|      LinqFaster |     0 |   100 | 122.85 ns | 0.799 ns | 0.747 ns |  3.64 |    0.02 | 0.2027 |     - |     - |     424 B |
| LinqFaster_SIMD |     0 |   100 |  94.79 ns | 0.682 ns | 0.638 ns |  2.81 |    0.02 | 0.2027 |     - |     - |     424 B |
|          LinqAF |     0 |   100 | 198.79 ns | 0.544 ns | 0.482 ns |  5.89 |    0.02 |      - |     - |     - |         - |
|      StructLinq |     0 |   100 |  34.63 ns | 0.202 ns | 0.179 ns |  1.03 |    0.00 |      - |     - |     - |         - |
|       Hyperlinq |     0 |   100 |  44.60 ns | 0.117 ns | 0.104 ns |  1.32 |    0.00 |      - |     - |     - |         - |
