## Range.RangeToList

### Source
[RangeToList.cs](../LinqBenchmarks/Range/RangeToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta36](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta36)

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
|        ValueLinq_Standard |     0 |   100 | 264.28 ns | 0.946 ns | 0.790 ns |  0.90 |    0.01 | 0.2179 |     - |     - |     456 B |
|           ValueLinq_Stack |     0 |   100 | 527.72 ns | 3.215 ns | 2.850 ns |  1.81 |    0.01 | 0.3319 |     - |     - |     696 B |
| ValueLinq_SharedPool_Push |     0 |   100 | 397.28 ns | 2.720 ns | 2.411 ns |  1.36 |    0.01 | 0.2174 |     - |     - |     456 B |
| ValueLinq_SharedPool_Pull |     0 |   100 | 547.58 ns | 4.882 ns | 4.328 ns |  1.87 |    0.02 | 0.2174 |     - |     - |     456 B |
|                   ForLoop |     0 |   100 | 292.07 ns | 1.923 ns | 1.705 ns |  1.00 |    0.00 | 0.5660 |     - |     - |    1184 B |
|               ForeachLoop |     0 |   100 | 788.09 ns | 4.849 ns | 4.298 ns |  2.70 |    0.02 | 0.5922 |     - |     - |    1240 B |
|                      Linq |     0 |   100 | 213.43 ns | 1.214 ns | 1.135 ns |  0.73 |    0.01 | 0.2370 |     - |     - |     496 B |
|                LinqFaster |     0 |   100 | 129.53 ns | 0.858 ns | 0.717 ns |  0.44 |    0.00 | 0.4206 |     - |     - |     880 B |
|                    LinqAF |     0 |   100 | 299.06 ns | 2.393 ns | 2.121 ns |  1.02 |    0.01 | 0.2179 |     - |     - |     456 B |
|                StructLinq |     0 |   100 |  91.03 ns | 0.565 ns | 0.528 ns |  0.31 |    0.00 | 0.2180 |     - |     - |     456 B |
|                 Hyperlinq |     0 |   100 |  53.99 ns | 0.186 ns | 0.165 ns |  0.18 |    0.00 | 0.2180 |     - |     - |     456 B |
