## Range.Range

### Source
[Range.cs](../LinqBenchmarks/Range/Range.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
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
|          Method | Start | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------ |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|         ForLoop |     0 |   100 |  33.34 ns |  0.125 ns |  0.111 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|     ForeachLoop |     0 |   100 | 620.09 ns | 12.429 ns | 17.013 ns | 18.56 |    0.54 | 0.0267 |     - |     - |      56 B |
|            Linq |     0 |   100 | 777.51 ns | 18.744 ns | 54.082 ns | 23.67 |    1.51 | 0.0191 |     - |     - |      40 B |
|      LinqFaster |     0 |   100 | 123.82 ns |  0.794 ns |  0.663 ns |  3.71 |    0.03 | 0.2027 |     - |     - |     424 B |
| LinqFaster_SIMD |     0 |   100 |  91.02 ns |  0.372 ns |  0.290 ns |  2.73 |    0.01 | 0.2027 |     - |     - |     424 B |
|          LinqAF |     0 |   100 | 197.02 ns |  0.450 ns |  0.352 ns |  5.91 |    0.02 |      - |     - |     - |         - |
|      StructLinq |     0 |   100 |  32.90 ns |  0.136 ns |  0.127 ns |  0.99 |    0.01 |      - |     - |     - |         - |
|       Hyperlinq |     0 |   100 |  47.71 ns |  0.351 ns |  0.328 ns |  1.43 |    0.01 |      - |     - |     - |         - |
