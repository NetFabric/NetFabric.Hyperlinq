## Range.RangeToArray

### Source
[RangeToArray.cs](../LinqBenchmarks/Range/RangeToArray.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta27](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta27)

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
|        ValueLinq_Standard |     0 |   100 | 229.12 ns | 0.732 ns | 0.649 ns |  1.79 |    0.01 | 0.2027 |     - |     - |     424 B |
|           ValueLinq_Stack |     0 |   100 | 315.25 ns | 1.167 ns | 1.035 ns |  2.47 |    0.01 | 0.3171 |     - |     - |     664 B |
| ValueLinq_SharedPool_Push |     0 |   100 | 369.65 ns | 0.822 ns | 0.728 ns |  2.89 |    0.01 | 0.2027 |     - |     - |     424 B |
| ValueLinq_SharedPool_Pull |     0 |   100 | 455.88 ns | 1.356 ns | 1.133 ns |  3.57 |    0.01 | 0.2027 |     - |     - |     424 B |
|                   ForLoop |     0 |   100 | 127.77 ns | 0.497 ns | 0.440 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                      Linq |     0 |   100 |  82.54 ns | 0.968 ns | 0.809 ns |  0.65 |    0.01 | 0.2218 |     - |     - |     464 B |
|                LinqFaster |     0 |   100 |  66.24 ns | 0.540 ns | 0.505 ns |  0.52 |    0.00 | 0.2027 |     - |     - |     424 B |
|                    LinqAF |     0 |   100 | 262.79 ns | 1.646 ns | 1.459 ns |  2.06 |    0.02 | 0.2027 |     - |     - |     424 B |
|                StructLinq |     0 |   100 | 204.93 ns | 0.631 ns | 0.527 ns |  1.60 |    0.01 | 0.2027 |     - |     - |     424 B |
|                 Hyperlinq |     0 |   100 |  79.59 ns | 0.535 ns | 0.501 ns |  0.62 |    0.00 | 0.2027 |     - |     - |     424 B |
|            Hyperlinq_Pool |     0 |   100 | 125.55 ns | 0.382 ns | 0.358 ns |  0.98 |    0.01 | 0.0267 |     - |     - |      56 B |
