## Range.RangeToArray

### Source
[RangeToArray.cs](../LinqBenchmarks/Range/RangeToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
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
|                    Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|        ValueLinq_Standard |     0 |   100 | 217.55 ns | 0.426 ns | 0.377 ns |  1.68 |    0.01 | 0.2027 |     - |     - |     424 B |
|           ValueLinq_Stack |     0 |   100 | 314.12 ns | 1.934 ns | 1.809 ns |  2.43 |    0.01 | 0.3171 |     - |     - |     664 B |
| ValueLinq_SharedPool_Push |     0 |   100 | 365.22 ns | 0.810 ns | 0.718 ns |  2.83 |    0.02 | 0.2027 |     - |     - |     424 B |
| ValueLinq_SharedPool_Pull |     0 |   100 | 419.44 ns | 1.782 ns | 1.488 ns |  3.24 |    0.03 | 0.2027 |     - |     - |     424 B |
|                   ForLoop |     0 |   100 | 129.17 ns | 1.059 ns | 0.990 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                      Linq |     0 |   100 |  82.58 ns | 0.690 ns | 0.612 ns |  0.64 |    0.01 | 0.2218 |     - |     - |     464 B |
|                LinqFaster |     0 |   100 |  68.08 ns | 0.333 ns | 0.295 ns |  0.53 |    0.00 | 0.2027 |     - |     - |     424 B |
|                    LinqAF |     0 |   100 | 262.76 ns | 1.298 ns | 1.084 ns |  2.03 |    0.01 | 0.2027 |     - |     - |     424 B |
|                StructLinq |     0 |   100 | 104.65 ns | 0.483 ns | 0.428 ns |  0.81 |    0.01 | 0.2027 |     - |     - |     424 B |
|                 Hyperlinq |     0 |   100 |  71.94 ns | 0.600 ns | 0.562 ns |  0.56 |    0.01 | 0.2027 |     - |     - |     424 B |
|            Hyperlinq_Pool |     0 |   100 | 126.41 ns | 0.375 ns | 0.351 ns |  0.98 |    0.01 | 0.0267 |     - |     - |      56 B |
