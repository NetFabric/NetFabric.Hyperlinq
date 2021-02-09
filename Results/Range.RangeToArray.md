## Range.RangeToArray

### Source
[RangeToArray.cs](../LinqBenchmarks/Range/RangeToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta34](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta34)

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
|        ValueLinq_Standard |     0 |   100 | 219.27 ns | 0.776 ns | 0.688 ns |  1.70 |    0.01 | 0.2027 |     - |     - |     424 B |
|           ValueLinq_Stack |     0 |   100 | 337.64 ns | 2.024 ns | 1.794 ns |  2.62 |    0.01 | 0.3171 |     - |     - |     664 B |
| ValueLinq_SharedPool_Push |     0 |   100 | 369.95 ns | 1.001 ns | 0.937 ns |  2.88 |    0.01 | 0.2027 |     - |     - |     424 B |
| ValueLinq_SharedPool_Pull |     0 |   100 | 450.14 ns | 2.864 ns | 2.679 ns |  3.50 |    0.02 | 0.2027 |     - |     - |     424 B |
|                   ForLoop |     0 |   100 | 128.61 ns | 0.615 ns | 0.575 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                      Linq |     0 |   100 |  89.71 ns | 0.451 ns | 0.400 ns |  0.70 |    0.00 | 0.2218 |     - |     - |     464 B |
|                LinqFaster |     0 |   100 |  68.88 ns | 0.309 ns | 0.258 ns |  0.54 |    0.00 | 0.2027 |     - |     - |     424 B |
|                    LinqAF |     0 |   100 | 333.20 ns | 3.225 ns | 2.859 ns |  2.59 |    0.02 | 0.2027 |     - |     - |     424 B |
|                StructLinq |     0 |   100 | 106.13 ns | 0.300 ns | 0.266 ns |  0.82 |    0.00 | 0.2027 |     - |     - |     424 B |
|                 Hyperlinq |     0 |   100 |  84.20 ns | 0.364 ns | 0.340 ns |  0.65 |    0.00 | 0.2027 |     - |     - |     424 B |
|            Hyperlinq_Pool |     0 |   100 | 132.57 ns | 2.144 ns | 2.005 ns |  1.03 |    0.01 | 0.0267 |     - |     - |      56 B |
