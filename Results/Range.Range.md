## Range.Range

### Source
[Range.cs](../LinqBenchmarks/Range/Range.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta35](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta35)

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
|         ForLoop |     0 |   100 |  33.55 ns | 0.141 ns | 0.125 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|     ForeachLoop |     0 |   100 | 473.35 ns | 1.508 ns | 1.259 ns | 14.11 |    0.06 | 0.0267 |     - |     - |      56 B |
|            Linq |     0 |   100 | 422.07 ns | 1.482 ns | 1.314 ns | 12.58 |    0.05 | 0.0191 |     - |     - |      40 B |
|      LinqFaster |     0 |   100 | 123.07 ns | 0.800 ns | 0.749 ns |  3.67 |    0.03 | 0.2027 |     - |     - |     424 B |
| LinqFaster_SIMD |     0 |   100 |  91.84 ns | 0.447 ns | 0.349 ns |  2.74 |    0.01 | 0.2027 |     - |     - |     424 B |
|          LinqAF |     0 |   100 | 177.67 ns | 0.312 ns | 0.277 ns |  5.30 |    0.02 |      - |     - |     - |         - |
|      StructLinq |     0 |   100 |  34.00 ns | 0.122 ns | 0.109 ns |  1.01 |    0.01 |      - |     - |     - |         - |
|       Hyperlinq |     0 |   100 |  44.67 ns | 0.107 ns | 0.090 ns |  1.33 |    0.01 |      - |     - |     - |         - |
