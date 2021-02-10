## Range.RangeToArray

### Source
[RangeToArray.cs](../LinqBenchmarks/Range/RangeToArray.cs)

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
|                    Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|        ValueLinq_Standard |     0 |   100 | 221.56 ns | 1.128 ns | 0.942 ns |  1.73 |    0.01 | 0.2027 |     - |     - |     424 B |
|           ValueLinq_Stack |     0 |   100 | 339.71 ns | 1.976 ns | 1.848 ns |  2.65 |    0.01 | 0.3171 |     - |     - |     664 B |
| ValueLinq_SharedPool_Push |     0 |   100 | 371.26 ns | 1.126 ns | 0.940 ns |  2.89 |    0.01 | 0.2027 |     - |     - |     424 B |
| ValueLinq_SharedPool_Pull |     0 |   100 | 449.76 ns | 1.890 ns | 1.675 ns |  3.50 |    0.01 | 0.2027 |     - |     - |     424 B |
|                   ForLoop |     0 |   100 | 128.47 ns | 0.206 ns | 0.161 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                      Linq |     0 |   100 |  90.81 ns | 0.236 ns | 0.184 ns |  0.71 |    0.00 | 0.2218 |     - |     - |     464 B |
|                LinqFaster |     0 |   100 |  69.55 ns | 0.553 ns | 0.490 ns |  0.54 |    0.00 | 0.2027 |     - |     - |     424 B |
|           LinqFaster_SIMD |     0 |   100 |  34.61 ns | 0.816 ns | 0.764 ns |  0.27 |    0.01 | 0.2027 |     - |     - |     424 B |
|                    LinqAF |     0 |   100 | 351.89 ns | 6.343 ns | 5.933 ns |  2.75 |    0.05 | 0.2027 |     - |     - |     424 B |
|                StructLinq |     0 |   100 | 105.13 ns | 0.363 ns | 0.303 ns |  0.82 |    0.00 | 0.2027 |     - |     - |     424 B |
|                 Hyperlinq |     0 |   100 |  53.53 ns | 0.220 ns | 0.195 ns |  0.42 |    0.00 | 0.2027 |     - |     - |     424 B |
|            Hyperlinq_Pool |     0 |   100 |  97.89 ns | 1.136 ns | 1.007 ns |  0.76 |    0.01 | 0.0267 |     - |     - |      56 B |
