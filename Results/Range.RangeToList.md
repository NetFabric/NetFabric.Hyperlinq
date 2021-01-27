## Range.RangeToList

### Source
[RangeToList.cs](../LinqBenchmarks/Range/RangeToList.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta27](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta27)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                    Method | Start | Count |     Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |------ |------ |---------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|        ValueLinq_Standard |     0 |   100 | 259.4 ns | 0.53 ns | 0.47 ns |  0.98 | 0.2179 |     - |     - |     456 B |
|           ValueLinq_Stack |     0 |   100 | 507.6 ns | 2.89 ns | 2.56 ns |  1.91 | 0.3319 |     - |     - |     696 B |
| ValueLinq_SharedPool_Push |     0 |   100 | 377.8 ns | 1.95 ns | 1.52 ns |  1.42 | 0.2179 |     - |     - |     456 B |
| ValueLinq_SharedPool_Pull |     0 |   100 | 533.4 ns | 2.16 ns | 1.81 ns |  2.01 | 0.2174 |     - |     - |     456 B |
|                   ForLoop |     0 |   100 | 265.5 ns | 1.75 ns | 1.56 ns |  1.00 | 0.5660 |     - |     - |    1184 B |
|               ForeachLoop |     0 |   100 | 718.0 ns | 4.17 ns | 3.48 ns |  2.70 | 0.5922 |     - |     - |    1240 B |
|                      Linq |     0 |   100 | 203.3 ns | 0.73 ns | 0.69 ns |  0.77 | 0.2370 |     - |     - |     496 B |
|                LinqFaster |     0 |   100 | 113.4 ns | 0.62 ns | 0.55 ns |  0.43 | 0.4207 |     - |     - |     880 B |
|                    LinqAF |     0 |   100 | 320.1 ns | 1.28 ns | 1.20 ns |  1.21 | 0.2179 |     - |     - |     456 B |
|                StructLinq |     0 |   100 | 210.5 ns | 1.32 ns | 1.17 ns |  0.79 | 0.2179 |     - |     - |     456 B |
|                 Hyperlinq |     0 |   100 | 124.9 ns | 0.48 ns | 0.40 ns |  0.47 | 0.2332 |     - |     - |     488 B |
