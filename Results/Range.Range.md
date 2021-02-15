## Range.Range

### Source
[Range.cs](../LinqBenchmarks/Range/Range.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta36](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta36)

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
|         ForLoop |     0 |   100 |  34.48 ns | 0.109 ns | 0.091 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|     ForeachLoop |     0 |   100 | 507.56 ns | 1.433 ns | 1.341 ns | 14.73 |    0.05 | 0.0267 |     - |     - |      56 B |
|            Linq |     0 |   100 | 428.64 ns | 1.378 ns | 1.221 ns | 12.44 |    0.03 | 0.0191 |     - |     - |      40 B |
|      LinqFaster |     0 |   100 | 126.50 ns | 0.963 ns | 0.804 ns |  3.67 |    0.02 | 0.2027 |     - |     - |     424 B |
| LinqFaster_SIMD |     0 |   100 |  95.35 ns | 0.481 ns | 0.427 ns |  2.77 |    0.01 | 0.2027 |     - |     - |     424 B |
|          LinqAF |     0 |   100 | 182.43 ns | 0.724 ns | 0.642 ns |  5.29 |    0.02 |      - |     - |     - |         - |
|      StructLinq |     0 |   100 |  35.07 ns | 0.091 ns | 0.086 ns |  1.02 |    0.00 |      - |     - |     - |         - |
|       Hyperlinq |     0 |   100 |  45.86 ns | 0.153 ns | 0.128 ns |  1.33 |    0.00 |      - |     - |     - |         - |
