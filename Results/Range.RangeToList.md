## Range.RangeToList

### Source
[RangeToList.cs](../LinqBenchmarks/Range/RangeToList.cs)

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
|                    Method | Start | Count |      Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |------ |------ |----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|        ValueLinq_Standard |     0 |   100 | 259.10 ns | 1.097 ns | 1.026 ns |  0.85 | 0.2179 |     - |     - |     456 B |
|           ValueLinq_Stack |     0 |   100 | 506.55 ns | 2.003 ns | 1.672 ns |  1.67 | 0.3319 |     - |     - |     696 B |
| ValueLinq_SharedPool_Push |     0 |   100 | 390.25 ns | 1.576 ns | 1.474 ns |  1.28 | 0.2179 |     - |     - |     456 B |
| ValueLinq_SharedPool_Pull |     0 |   100 | 535.77 ns | 1.753 ns | 1.640 ns |  1.76 | 0.2174 |     - |     - |     456 B |
|                   ForLoop |     0 |   100 | 303.98 ns | 1.461 ns | 1.367 ns |  1.00 | 0.5660 |     - |     - |    1184 B |
|               ForeachLoop |     0 |   100 | 763.11 ns | 3.873 ns | 3.433 ns |  2.51 | 0.5922 |     - |     - |    1240 B |
|                      Linq |     0 |   100 | 205.99 ns | 1.870 ns | 1.658 ns |  0.68 | 0.2370 |     - |     - |     496 B |
|                LinqFaster |     0 |   100 | 128.10 ns | 0.873 ns | 0.729 ns |  0.42 | 0.4206 |     - |     - |     880 B |
|                    LinqAF |     0 |   100 | 290.79 ns | 0.942 ns | 0.881 ns |  0.96 | 0.2179 |     - |     - |     456 B |
|                StructLinq |     0 |   100 |  87.96 ns | 0.386 ns | 0.323 ns |  0.29 | 0.2180 |     - |     - |     456 B |
|                 Hyperlinq |     0 |   100 | 105.61 ns | 0.646 ns | 0.604 ns |  0.35 | 0.2333 |     - |     - |     488 B |
