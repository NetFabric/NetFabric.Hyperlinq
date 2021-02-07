## Range.RangeToList

### Source
[RangeToList.cs](../LinqBenchmarks/Range/RangeToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta33](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta33)

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
|        ValueLinq_Standard |     0 |   100 | 264.80 ns | 0.854 ns | 0.757 ns |  0.98 |    0.01 | 0.2179 |     - |     - |     456 B |
|           ValueLinq_Stack |     0 |   100 | 512.44 ns | 1.707 ns | 1.426 ns |  1.90 |    0.01 | 0.3319 |     - |     - |     696 B |
| ValueLinq_SharedPool_Push |     0 |   100 | 380.01 ns | 1.069 ns | 0.893 ns |  1.41 |    0.01 | 0.2179 |     - |     - |     456 B |
| ValueLinq_SharedPool_Pull |     0 |   100 | 530.38 ns | 1.612 ns | 1.508 ns |  1.97 |    0.01 | 0.2174 |     - |     - |     456 B |
|                   ForLoop |     0 |   100 | 269.71 ns | 1.828 ns | 1.710 ns |  1.00 |    0.00 | 0.5660 |     - |     - |    1184 B |
|               ForeachLoop |     0 |   100 | 775.75 ns | 2.402 ns | 2.130 ns |  2.88 |    0.02 | 0.5922 |     - |     - |    1240 B |
|                      Linq |     0 |   100 | 206.44 ns | 0.765 ns | 0.678 ns |  0.77 |    0.01 | 0.2370 |     - |     - |     496 B |
|                LinqFaster |     0 |   100 | 121.35 ns | 0.790 ns | 0.700 ns |  0.45 |    0.00 | 0.4206 |     - |     - |     880 B |
|                    LinqAF |     0 |   100 | 326.65 ns | 1.237 ns | 1.096 ns |  1.21 |    0.01 | 0.2179 |     - |     - |     456 B |
|                StructLinq |     0 |   100 |  88.10 ns | 0.392 ns | 0.366 ns |  0.33 |    0.00 | 0.2180 |     - |     - |     456 B |
|                 Hyperlinq |     0 |   100 | 103.66 ns | 0.739 ns | 0.656 ns |  0.38 |    0.00 | 0.2333 |     - |     - |     488 B |
