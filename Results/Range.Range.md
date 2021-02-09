## Range.Range

### Source
[Range.cs](../LinqBenchmarks/Range/Range.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta34](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta34)

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
|         ForLoop |     0 |   100 |  33.62 ns | 0.194 ns | 0.162 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|     ForeachLoop |     0 |   100 | 472.39 ns | 1.185 ns | 1.051 ns | 14.05 |    0.08 | 0.0267 |     - |     - |      56 B |
|            Linq |     0 |   100 | 422.00 ns | 1.360 ns | 1.205 ns | 12.56 |    0.05 | 0.0191 |     - |     - |      40 B |
|      LinqFaster |     0 |   100 | 133.49 ns | 0.738 ns | 0.655 ns |  3.97 |    0.02 | 0.2027 |     - |     - |     424 B |
| LinqFaster_SIMD |     0 |   100 |  97.28 ns | 0.170 ns | 0.151 ns |  2.89 |    0.01 | 0.2027 |     - |     - |     424 B |
|          LinqAF |     0 |   100 | 178.54 ns | 0.511 ns | 0.478 ns |  5.31 |    0.02 |      - |     - |     - |         - |
|      StructLinq |     0 |   100 |  33.88 ns | 0.089 ns | 0.079 ns |  1.01 |    0.01 |      - |     - |     - |         - |
|       Hyperlinq |     0 |   100 |  44.61 ns | 0.159 ns | 0.133 ns |  1.33 |    0.01 |      - |     - |     - |         - |
