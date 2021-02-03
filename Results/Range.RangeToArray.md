## Range.RangeToArray

### Source
[RangeToArray.cs](../LinqBenchmarks/Range/RangeToArray.cs)

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
|        ValueLinq_Standard |     0 |   100 | 215.46 ns | 0.598 ns | 0.530 ns |  1.68 | 0.2027 |     - |     - |     424 B |
|           ValueLinq_Stack |     0 |   100 | 312.50 ns | 1.136 ns | 1.063 ns |  2.44 | 0.3171 |     - |     - |     664 B |
| ValueLinq_SharedPool_Push |     0 |   100 | 364.14 ns | 1.409 ns | 1.318 ns |  2.84 | 0.2027 |     - |     - |     424 B |
| ValueLinq_SharedPool_Pull |     0 |   100 | 416.08 ns | 0.757 ns | 0.632 ns |  3.25 | 0.2027 |     - |     - |     424 B |
|                   ForLoop |     0 |   100 | 128.22 ns | 0.349 ns | 0.291 ns |  1.00 | 0.2027 |     - |     - |     424 B |
|                      Linq |     0 |   100 |  82.94 ns | 0.835 ns | 0.697 ns |  0.65 | 0.2218 |     - |     - |     464 B |
|                LinqFaster |     0 |   100 |  67.52 ns | 1.243 ns | 1.102 ns |  0.53 | 0.2027 |     - |     - |     424 B |
|                    LinqAF |     0 |   100 | 261.64 ns | 1.680 ns | 1.489 ns |  2.04 | 0.2027 |     - |     - |     424 B |
|                StructLinq |     0 |   100 | 103.88 ns | 0.298 ns | 0.233 ns |  0.81 | 0.2027 |     - |     - |     424 B |
|                 Hyperlinq |     0 |   100 |  71.73 ns | 0.593 ns | 0.555 ns |  0.56 | 0.2027 |     - |     - |     424 B |
|            Hyperlinq_Pool |     0 |   100 | 119.54 ns | 0.399 ns | 0.354 ns |  0.93 | 0.0267 |     - |     - |      56 B |
