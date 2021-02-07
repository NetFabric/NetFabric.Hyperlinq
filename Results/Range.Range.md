## Range.Range

### Source
[Range.cs](../LinqBenchmarks/Range/Range.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta33](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta33)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|          Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|         ForLoop |     0 |   100 |  33.65 ns | 0.106 ns | 0.094 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|     ForeachLoop |     0 |   100 | 473.25 ns | 1.724 ns | 1.613 ns | 14.07 |    0.05 | 0.0267 |     - |     - |      56 B |
|            Linq |     0 |   100 | 440.73 ns | 1.055 ns | 0.935 ns | 13.10 |    0.04 | 0.0191 |     - |     - |      40 B |
|      LinqFaster |     0 |   100 | 133.70 ns | 0.887 ns | 0.829 ns |  3.97 |    0.03 | 0.2027 |     - |     - |     424 B |
| LinqFaster_SIMD |     0 |   100 |  95.47 ns | 0.201 ns | 0.157 ns |  2.84 |    0.01 | 0.2027 |     - |     - |     424 B |
|          LinqAF |     0 |   100 | 212.21 ns | 0.812 ns | 0.634 ns |  6.31 |    0.03 |      - |     - |     - |         - |
|      StructLinq |     0 |   100 |  33.91 ns | 0.080 ns | 0.071 ns |  1.01 |    0.00 |      - |     - |     - |         - |
|       Hyperlinq |     0 |   100 |  43.67 ns | 0.110 ns | 0.098 ns |  1.30 |    0.00 |      - |     - |     - |         - |
