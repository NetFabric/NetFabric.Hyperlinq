## Range.RangeToArray

### Source
[RangeToArray.cs](../LinqBenchmarks/Range/RangeToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta29](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta29)

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
|        ValueLinq_Standard |     0 |   100 | 217.18 ns | 0.503 ns | 0.392 ns |  1.69 |    0.01 | 0.2027 |     - |     - |     424 B |
|           ValueLinq_Stack |     0 |   100 | 313.64 ns | 1.596 ns | 1.493 ns |  2.44 |    0.02 | 0.3171 |     - |     - |     664 B |
| ValueLinq_SharedPool_Push |     0 |   100 | 365.39 ns | 0.843 ns | 0.747 ns |  2.85 |    0.01 | 0.2027 |     - |     - |     424 B |
| ValueLinq_SharedPool_Pull |     0 |   100 | 416.81 ns | 1.898 ns | 1.683 ns |  3.25 |    0.01 | 0.2027 |     - |     - |     424 B |
|                   ForLoop |     0 |   100 | 128.37 ns | 0.446 ns | 0.396 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                      Linq |     0 |   100 |  83.32 ns | 0.497 ns | 0.441 ns |  0.65 |    0.00 | 0.2218 |     - |     - |     464 B |
|                LinqFaster |     0 |   100 |  67.02 ns | 0.659 ns | 0.584 ns |  0.52 |    0.00 | 0.2027 |     - |     - |     424 B |
|                    LinqAF |     0 |   100 | 262.19 ns | 1.302 ns | 1.155 ns |  2.04 |    0.01 | 0.2027 |     - |     - |     424 B |
|                StructLinq |     0 |   100 | 104.24 ns | 0.856 ns | 0.715 ns |  0.81 |    0.01 | 0.2027 |     - |     - |     424 B |
|                 Hyperlinq |     0 |   100 |  80.01 ns | 0.475 ns | 0.445 ns |  0.62 |    0.00 | 0.2027 |     - |     - |     424 B |
|            Hyperlinq_Pool |     0 |   100 | 119.09 ns | 0.560 ns | 0.524 ns |  0.93 |    0.01 | 0.0267 |     - |     - |      56 B |
