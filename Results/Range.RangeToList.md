## Range.RangeToList

### Source
[RangeToList.cs](../LinqBenchmarks/Range/RangeToList.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta28](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta28)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                    Method | Start | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |------ |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|        ValueLinq_Standard |     0 |   100 | 291.3 ns | 1.04 ns | 0.97 ns |  0.89 |    0.01 | 0.2179 |     - |     - |     456 B |
|           ValueLinq_Stack |     0 |   100 | 572.7 ns | 3.54 ns | 3.31 ns |  1.75 |    0.02 | 0.3319 |     - |     - |     696 B |
| ValueLinq_SharedPool_Push |     0 |   100 | 440.3 ns | 2.82 ns | 2.20 ns |  1.35 |    0.01 | 0.2179 |     - |     - |     456 B |
| ValueLinq_SharedPool_Pull |     0 |   100 | 617.4 ns | 2.96 ns | 2.62 ns |  1.88 |    0.02 | 0.2174 |     - |     - |     456 B |
|                   ForLoop |     0 |   100 | 327.7 ns | 2.18 ns | 2.04 ns |  1.00 |    0.00 | 0.5660 |     - |     - |    1184 B |
|               ForeachLoop |     0 |   100 | 834.0 ns | 2.94 ns | 2.75 ns |  2.55 |    0.02 | 0.5922 |     - |     - |    1240 B |
|                      Linq |     0 |   100 | 232.3 ns | 1.55 ns | 1.45 ns |  0.71 |    0.01 | 0.2370 |     - |     - |     496 B |
|                LinqFaster |     0 |   100 | 143.7 ns | 1.24 ns | 1.16 ns |  0.44 |    0.00 | 0.4206 |     - |     - |     880 B |
|                    LinqAF |     0 |   100 | 367.6 ns | 1.14 ns | 1.07 ns |  1.12 |    0.01 | 0.2179 |     - |     - |     456 B |
|                StructLinq |     0 |   100 | 101.2 ns | 0.91 ns | 0.81 ns |  0.31 |    0.00 | 0.2180 |     - |     - |     456 B |
|                 Hyperlinq |     0 |   100 | 142.5 ns | 1.33 ns | 1.24 ns |  0.44 |    0.00 | 0.2332 |     - |     - |     488 B |
