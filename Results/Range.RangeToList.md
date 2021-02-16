## Range.RangeToList

### Source
[RangeToList.cs](../LinqBenchmarks/Range/RangeToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta37](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta37)

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
|        ValueLinq_Standard |     0 |   100 | 258.14 ns | 1.375 ns | 1.219 ns |  0.95 |    0.01 | 0.2179 |     - |     - |     456 B |
|           ValueLinq_Stack |     0 |   100 | 513.70 ns | 1.343 ns | 1.190 ns |  1.89 |    0.01 | 0.3319 |     - |     - |     696 B |
| ValueLinq_SharedPool_Push |     0 |   100 | 386.62 ns | 1.207 ns | 1.008 ns |  1.43 |    0.01 | 0.2179 |     - |     - |     456 B |
| ValueLinq_SharedPool_Pull |     0 |   100 | 530.09 ns | 2.655 ns | 2.354 ns |  1.95 |    0.02 | 0.2174 |     - |     - |     456 B |
|                   ForLoop |     0 |   100 | 271.28 ns | 2.146 ns | 1.902 ns |  1.00 |    0.00 | 0.5660 |     - |     - |    1184 B |
|               ForeachLoop |     0 |   100 | 758.73 ns | 3.730 ns | 3.306 ns |  2.80 |    0.03 | 0.5922 |     - |     - |    1240 B |
|                      Linq |     0 |   100 | 207.02 ns | 0.781 ns | 0.730 ns |  0.76 |    0.01 | 0.2370 |     - |     - |     496 B |
|                LinqFaster |     0 |   100 | 125.60 ns | 0.536 ns | 0.501 ns |  0.46 |    0.00 | 0.4206 |     - |     - |     880 B |
|                    LinqAF |     0 |   100 | 309.98 ns | 1.435 ns | 1.272 ns |  1.14 |    0.01 | 0.2179 |     - |     - |     456 B |
|                StructLinq |     0 |   100 |  88.22 ns | 0.420 ns | 0.351 ns |  0.33 |    0.00 | 0.2180 |     - |     - |     456 B |
|                 Hyperlinq |     0 |   100 |  52.85 ns | 0.336 ns | 0.280 ns |  0.19 |    0.00 | 0.2180 |     - |     - |     456 B |
