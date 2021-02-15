## Range.RangeToArray

### Source
[RangeToArray.cs](../LinqBenchmarks/Range/RangeToArray.cs)

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
|                    Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|        ValueLinq_Standard |     0 |   100 | 227.46 ns | 0.958 ns | 0.849 ns |  1.72 |    0.01 | 0.2027 |     - |     - |     424 B |
|           ValueLinq_Stack |     0 |   100 | 352.34 ns | 2.684 ns | 2.379 ns |  2.67 |    0.02 | 0.3171 |     - |     - |     664 B |
| ValueLinq_SharedPool_Push |     0 |   100 | 373.51 ns | 1.669 ns | 1.561 ns |  2.83 |    0.02 | 0.2027 |     - |     - |     424 B |
| ValueLinq_SharedPool_Pull |     0 |   100 | 450.29 ns | 2.026 ns | 1.796 ns |  3.40 |    0.02 | 0.2027 |     - |     - |     424 B |
|                   ForLoop |     0 |   100 | 132.18 ns | 0.554 ns | 0.433 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                      Linq |     0 |   100 |  94.46 ns | 1.066 ns | 0.998 ns |  0.72 |    0.01 | 0.2218 |     - |     - |     464 B |
|                LinqFaster |     0 |   100 |  80.95 ns | 0.531 ns | 0.496 ns |  0.61 |    0.00 | 0.2027 |     - |     - |     424 B |
|           LinqFaster_SIMD |     0 |   100 |  37.93 ns | 0.272 ns | 0.254 ns |  0.29 |    0.00 | 0.2027 |     - |     - |     424 B |
|                    LinqAF |     0 |   100 | 344.40 ns | 4.861 ns | 4.309 ns |  2.60 |    0.03 | 0.2027 |     - |     - |     424 B |
|                StructLinq |     0 |   100 | 109.47 ns | 0.657 ns | 0.614 ns |  0.83 |    0.01 | 0.2027 |     - |     - |     424 B |
|                 Hyperlinq |     0 |   100 |  46.73 ns | 0.368 ns | 0.326 ns |  0.35 |    0.00 | 0.2027 |     - |     - |     424 B |
|            Hyperlinq_Pool |     0 |   100 |  87.04 ns | 0.366 ns | 0.342 ns |  0.66 |    0.00 | 0.0267 |     - |     - |      56 B |
