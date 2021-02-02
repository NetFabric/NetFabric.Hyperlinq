## Range.RangeToArray

### Source
[RangeToArray.cs](../LinqBenchmarks/Range/RangeToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta30](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta30)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                    Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|        ValueLinq_Standard |     0 |   100 | 213.59 ns | 0.753 ns | 0.704 ns |  2.69 |    0.02 | 0.2027 |     - |     - |     424 B |
|           ValueLinq_Stack |     0 |   100 | 314.87 ns | 1.424 ns | 1.262 ns |  3.97 |    0.03 | 0.3171 |     - |     - |     664 B |
| ValueLinq_SharedPool_Push |     0 |   100 | 373.59 ns | 1.854 ns | 1.548 ns |  4.71 |    0.04 | 0.2027 |     - |     - |     424 B |
| ValueLinq_SharedPool_Pull |     0 |   100 | 417.16 ns | 2.166 ns | 2.026 ns |  5.26 |    0.03 | 0.2027 |     - |     - |     424 B |
|                   ForLoop |     0 |   100 |  79.37 ns | 0.414 ns | 0.345 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                      Linq |     0 |   100 |  83.41 ns | 0.500 ns | 0.443 ns |  1.05 |    0.01 | 0.2218 |     - |     - |     464 B |
|                LinqFaster |     0 |   100 |  67.03 ns | 0.281 ns | 0.263 ns |  0.84 |    0.00 | 0.2027 |     - |     - |     424 B |
|                    LinqAF |     0 |   100 | 261.25 ns | 1.070 ns | 0.949 ns |  3.29 |    0.02 | 0.2027 |     - |     - |     424 B |
|                StructLinq |     0 |   100 | 104.28 ns | 0.336 ns | 0.298 ns |  1.31 |    0.01 | 0.2027 |     - |     - |     424 B |
|                 Hyperlinq |     0 |   100 |  80.36 ns | 0.563 ns | 0.527 ns |  1.01 |    0.01 | 0.2027 |     - |     - |     424 B |
|            Hyperlinq_Pool |     0 |   100 | 124.33 ns | 0.397 ns | 0.371 ns |  1.57 |    0.01 | 0.0267 |     - |     - |      56 B |
