## Range.RangeToArray

### Source
[RangeToArray.cs](../LinqBenchmarks/Range/RangeToArray.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta28](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta28)

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
|        ValueLinq_Standard |     0 |   100 | 252.87 ns | 1.079 ns | 1.009 ns |  1.77 |    0.01 | 0.2027 |     - |     - |     424 B |
|           ValueLinq_Stack |     0 |   100 | 359.39 ns | 2.502 ns | 2.089 ns |  2.52 |    0.01 | 0.3171 |     - |     - |     664 B |
| ValueLinq_SharedPool_Push |     0 |   100 | 466.50 ns | 2.088 ns | 1.953 ns |  3.27 |    0.02 | 0.2027 |     - |     - |     424 B |
| ValueLinq_SharedPool_Pull |     0 |   100 | 464.62 ns | 1.989 ns | 1.861 ns |  3.25 |    0.02 | 0.2022 |     - |     - |     424 B |
|                   ForLoop |     0 |   100 | 142.79 ns | 0.480 ns | 0.401 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                      Linq |     0 |   100 |  95.91 ns | 1.093 ns | 0.969 ns |  0.67 |    0.01 | 0.2218 |     - |     - |     464 B |
|                LinqFaster |     0 |   100 |  77.04 ns | 0.881 ns | 0.824 ns |  0.54 |    0.01 | 0.2027 |     - |     - |     424 B |
|                    LinqAF |     0 |   100 | 295.45 ns | 1.204 ns | 0.940 ns |  2.07 |    0.01 | 0.2027 |     - |     - |     424 B |
|                StructLinq |     0 |   100 | 117.18 ns | 0.745 ns | 0.660 ns |  0.82 |    0.00 | 0.2027 |     - |     - |     424 B |
|                 Hyperlinq |     0 |   100 |  91.24 ns | 0.620 ns | 0.550 ns |  0.64 |    0.00 | 0.2027 |     - |     - |     424 B |
|            Hyperlinq_Pool |     0 |   100 | 141.72 ns | 0.764 ns | 0.714 ns |  0.99 |    0.01 | 0.0267 |     - |     - |      56 B |
