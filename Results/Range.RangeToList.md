## Range.RangeToList

### Source
[RangeToList.cs](../LinqBenchmarks/Range/RangeToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta31](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta31)

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
|        ValueLinq_Standard |     0 |   100 | 256.32 ns | 0.716 ns | 0.635 ns |  0.94 | 0.2179 |     - |     - |     456 B |
|           ValueLinq_Stack |     0 |   100 | 504.19 ns | 1.409 ns | 1.176 ns |  1.86 | 0.3319 |     - |     - |     696 B |
| ValueLinq_SharedPool_Push |     0 |   100 | 387.15 ns | 0.941 ns | 0.834 ns |  1.43 | 0.2179 |     - |     - |     456 B |
| ValueLinq_SharedPool_Pull |     0 |   100 | 529.43 ns | 1.456 ns | 1.362 ns |  1.95 | 0.2174 |     - |     - |     456 B |
|                   ForLoop |     0 |   100 | 271.44 ns | 1.047 ns | 0.928 ns |  1.00 | 0.5660 |     - |     - |    1184 B |
|               ForeachLoop |     0 |   100 | 758.89 ns | 3.151 ns | 2.947 ns |  2.79 | 0.5922 |     - |     - |    1240 B |
|                      Linq |     0 |   100 | 207.40 ns | 0.733 ns | 0.685 ns |  0.76 | 0.2370 |     - |     - |     496 B |
|                LinqFaster |     0 |   100 | 127.10 ns | 0.537 ns | 0.448 ns |  0.47 | 0.4206 |     - |     - |     880 B |
|                    LinqAF |     0 |   100 | 275.59 ns | 1.108 ns | 0.982 ns |  1.02 | 0.2179 |     - |     - |     456 B |
|                StructLinq |     0 |   100 |  90.15 ns | 0.255 ns | 0.213 ns |  0.33 | 0.2180 |     - |     - |     456 B |
|                 Hyperlinq |     0 |   100 |  99.01 ns | 0.512 ns | 0.454 ns |  0.36 | 0.2333 |     - |     - |     488 B |
