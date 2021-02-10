## Range.RangeToList

### Source
[RangeToList.cs](../LinqBenchmarks/Range/RangeToList.cs)

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
|        ValueLinq_Standard |     0 |   100 | 256.34 ns | 1.055 ns | 0.987 ns |  0.91 |    0.00 | 0.2179 |     - |     - |     456 B |
|           ValueLinq_Stack |     0 |   100 | 511.61 ns | 1.043 ns | 0.924 ns |  1.81 |    0.01 | 0.3319 |     - |     - |     696 B |
| ValueLinq_SharedPool_Push |     0 |   100 | 384.66 ns | 1.276 ns | 1.131 ns |  1.36 |    0.01 | 0.2179 |     - |     - |     456 B |
| ValueLinq_SharedPool_Pull |     0 |   100 | 531.77 ns | 1.998 ns | 1.869 ns |  1.88 |    0.01 | 0.2174 |     - |     - |     456 B |
|                   ForLoop |     0 |   100 | 282.67 ns | 1.783 ns | 1.581 ns |  1.00 |    0.00 | 0.5660 |     - |     - |    1184 B |
|               ForeachLoop |     0 |   100 | 762.48 ns | 2.375 ns | 1.983 ns |  2.70 |    0.02 | 0.5922 |     - |     - |    1240 B |
|                      Linq |     0 |   100 | 206.56 ns | 0.801 ns | 0.749 ns |  0.73 |    0.01 | 0.2370 |     - |     - |     496 B |
|                LinqFaster |     0 |   100 | 125.17 ns | 0.435 ns | 0.363 ns |  0.44 |    0.00 | 0.4206 |     - |     - |     880 B |
|                    LinqAF |     0 |   100 | 295.69 ns | 1.635 ns | 1.366 ns |  1.05 |    0.01 | 0.2179 |     - |     - |     456 B |
|                StructLinq |     0 |   100 |  90.34 ns | 0.750 ns | 0.665 ns |  0.32 |    0.00 | 0.2180 |     - |     - |     456 B |
|                 Hyperlinq |     0 |   100 |  59.14 ns | 0.512 ns | 0.479 ns |  0.21 |    0.00 | 0.2180 |     - |     - |     456 B |
