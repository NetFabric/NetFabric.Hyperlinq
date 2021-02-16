## Range.RangeToArray

### Source
[RangeToArray.cs](../LinqBenchmarks/Range/RangeToArray.cs)

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
|                    Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|        ValueLinq_Standard |     0 |   100 | 221.27 ns | 0.650 ns | 0.542 ns |  1.72 |    0.01 | 0.2027 |     - |     - |     424 B |
|           ValueLinq_Stack |     0 |   100 | 318.20 ns | 0.946 ns | 0.885 ns |  2.48 |    0.01 | 0.3171 |     - |     - |     664 B |
| ValueLinq_SharedPool_Push |     0 |   100 | 371.28 ns | 1.840 ns | 1.536 ns |  2.89 |    0.02 | 0.2027 |     - |     - |     424 B |
| ValueLinq_SharedPool_Pull |     0 |   100 | 411.52 ns | 1.122 ns | 0.937 ns |  3.21 |    0.01 | 0.2027 |     - |     - |     424 B |
|                   ForLoop |     0 |   100 | 128.41 ns | 0.586 ns | 0.548 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                      Linq |     0 |   100 |  83.11 ns | 0.515 ns | 0.482 ns |  0.65 |    0.01 | 0.2218 |     - |     - |     464 B |
|                LinqFaster |     0 |   100 |  67.20 ns | 0.343 ns | 0.268 ns |  0.52 |    0.00 | 0.2027 |     - |     - |     424 B |
|           LinqFaster_SIMD |     0 |   100 |  35.84 ns | 0.227 ns | 0.201 ns |  0.28 |    0.00 | 0.2027 |     - |     - |     424 B |
|                    LinqAF |     0 |   100 | 260.77 ns | 0.967 ns | 0.904 ns |  2.03 |    0.01 | 0.2027 |     - |     - |     424 B |
|                StructLinq |     0 |   100 | 104.14 ns | 0.546 ns | 0.484 ns |  0.81 |    0.01 | 0.2027 |     - |     - |     424 B |
|                 Hyperlinq |     0 |   100 |  44.89 ns | 0.535 ns | 0.447 ns |  0.35 |    0.00 | 0.2027 |     - |     - |     424 B |
|            Hyperlinq_Pool |     0 |   100 |  77.08 ns | 0.372 ns | 0.330 ns |  0.60 |    0.00 | 0.0267 |     - |     - |      56 B |
