## Range.RangeToList

### Source
[RangeToList.cs](../LinqBenchmarks/Range/RangeToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta29](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta29)

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
|        ValueLinq_Standard |     0 |   100 | 257.67 ns | 1.210 ns | 1.132 ns |  0.93 |    0.01 | 0.2179 |     - |     - |     456 B |
|           ValueLinq_Stack |     0 |   100 | 508.52 ns | 1.449 ns | 1.210 ns |  1.85 |    0.01 | 0.3319 |     - |     - |     696 B |
| ValueLinq_SharedPool_Push |     0 |   100 | 390.71 ns | 1.673 ns | 1.565 ns |  1.42 |    0.01 | 0.2179 |     - |     - |     456 B |
| ValueLinq_SharedPool_Pull |     0 |   100 | 534.90 ns | 2.055 ns | 1.922 ns |  1.94 |    0.01 | 0.2174 |     - |     - |     456 B |
|                   ForLoop |     0 |   100 | 275.60 ns | 1.773 ns | 1.659 ns |  1.00 |    0.00 | 0.5660 |     - |     - |    1184 B |
|               ForeachLoop |     0 |   100 | 762.14 ns | 2.970 ns | 2.633 ns |  2.77 |    0.02 | 0.5922 |     - |     - |    1240 B |
|                      Linq |     0 |   100 | 206.41 ns | 0.682 ns | 0.604 ns |  0.75 |    0.01 | 0.2370 |     - |     - |     496 B |
|                LinqFaster |     0 |   100 | 117.03 ns | 0.707 ns | 0.627 ns |  0.42 |    0.00 | 0.4206 |     - |     - |     880 B |
|                    LinqAF |     0 |   100 | 297.69 ns | 2.152 ns | 1.908 ns |  1.08 |    0.01 | 0.2179 |     - |     - |     456 B |
|                StructLinq |     0 |   100 |  89.11 ns | 0.413 ns | 0.366 ns |  0.32 |    0.00 | 0.2180 |     - |     - |     456 B |
|                 Hyperlinq |     0 |   100 | 128.47 ns | 1.408 ns | 1.248 ns |  0.47 |    0.01 | 0.2332 |     - |     - |     488 B |
