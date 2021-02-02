## Range.RangeSelectToArray

### Source
[RangeSelectToArray.cs](../LinqBenchmarks/Range/RangeSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta30](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta30)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                                Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |     0 |   100 | 314.86 ns | 0.869 ns | 0.771 ns |  3.62 |    0.02 | 0.2027 |     - |     - |     424 B |
|                       ValueLinq_Stack |     0 |   100 | 523.43 ns | 2.582 ns | 2.289 ns |  6.01 |    0.04 | 0.3166 |     - |     - |     664 B |
|             ValueLinq_SharedPool_Push |     0 |   100 | 581.06 ns | 2.349 ns | 1.834 ns |  6.67 |    0.05 | 0.2022 |     - |     - |     424 B |
|             ValueLinq_SharedPool_Pull |     0 |   100 | 623.99 ns | 1.593 ns | 1.412 ns |  7.17 |    0.04 | 0.2022 |     - |     - |     424 B |
|        ValueLinq_ValueLambda_Standard |     0 |   100 | 234.13 ns | 0.588 ns | 0.521 ns |  2.69 |    0.01 | 0.2027 |     - |     - |     424 B |
|           ValueLinq_ValueLambda_Stack |     0 |   100 | 372.23 ns | 1.558 ns | 1.381 ns |  4.28 |    0.03 | 0.3171 |     - |     - |     664 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |   100 | 428.97 ns | 0.929 ns | 0.776 ns |  4.93 |    0.02 | 0.2027 |     - |     - |     424 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |   100 | 462.28 ns | 1.922 ns | 1.605 ns |  5.31 |    0.04 | 0.2022 |     - |     - |     424 B |
|                               ForLoop |     0 |   100 |  87.03 ns | 0.428 ns | 0.379 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                                  Linq |     0 |   100 | 245.22 ns | 2.494 ns | 2.211 ns |  2.82 |    0.03 | 0.2446 |     - |     - |     512 B |
|                            LinqFaster |     0 |   100 | 277.23 ns | 1.641 ns | 1.455 ns |  3.19 |    0.02 | 0.4053 |     - |     - |     848 B |
|                                LinqAF |     0 |   100 | 808.42 ns | 3.860 ns | 3.422 ns |  9.29 |    0.06 | 0.7534 |     - |     - |    1576 B |
|                            StructLinq |     0 |   100 | 228.16 ns | 0.392 ns | 0.367 ns |  2.62 |    0.01 | 0.2294 |     - |     - |     480 B |
|                  StructLinq_IFunction |     0 |   100 |  93.02 ns | 0.424 ns | 0.331 ns |  1.07 |    0.01 | 0.2027 |     - |     - |     424 B |
|                             Hyperlinq |     0 |   100 | 219.38 ns | 0.735 ns | 0.651 ns |  2.52 |    0.01 | 0.2027 |     - |     - |     424 B |
|                   Hyperlinq_IFunction |     0 |   100 |  98.83 ns | 0.591 ns | 0.553 ns |  1.14 |    0.01 | 0.2027 |     - |     - |     424 B |
|                        Hyperlinq_Pool |     0 |   100 | 260.61 ns | 0.572 ns | 0.507 ns |  2.99 |    0.01 | 0.0267 |     - |     - |      56 B |
|              Hyperlinq_Pool_IFunction |     0 |   100 | 147.19 ns | 0.384 ns | 0.359 ns |  1.69 |    0.01 | 0.0267 |     - |     - |      56 B |
