## Range.RangeToList

### Source
[RangeToList.cs](../LinqBenchmarks/Range/RangeToList.cs)

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
|                    Method | Start | Count |      Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |------ |------ |----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|        ValueLinq_Standard |     0 |   100 | 256.88 ns | 0.703 ns | 0.623 ns |  0.90 | 0.2179 |     - |     - |     456 B |
|           ValueLinq_Stack |     0 |   100 | 523.02 ns | 1.352 ns | 1.198 ns |  1.84 | 0.3319 |     - |     - |     696 B |
| ValueLinq_SharedPool_Push |     0 |   100 | 386.02 ns | 1.137 ns | 1.008 ns |  1.36 | 0.2179 |     - |     - |     456 B |
| ValueLinq_SharedPool_Pull |     0 |   100 | 533.04 ns | 1.045 ns | 0.816 ns |  1.88 | 0.2174 |     - |     - |     456 B |
|                   ForLoop |     0 |   100 | 284.28 ns | 1.431 ns | 1.339 ns |  1.00 | 0.5660 |     - |     - |    1184 B |
|               ForeachLoop |     0 |   100 | 736.16 ns | 3.324 ns | 3.109 ns |  2.59 | 0.5922 |     - |     - |    1240 B |
|                      Linq |     0 |   100 | 207.01 ns | 0.670 ns | 0.594 ns |  0.73 | 0.2370 |     - |     - |     496 B |
|                LinqFaster |     0 |   100 | 116.25 ns | 0.857 ns | 0.802 ns |  0.41 | 0.4206 |     - |     - |     880 B |
|                    LinqAF |     0 |   100 | 319.35 ns | 1.098 ns | 0.917 ns |  1.12 | 0.2179 |     - |     - |     456 B |
|                StructLinq |     0 |   100 |  88.60 ns | 0.623 ns | 0.520 ns |  0.31 | 0.2180 |     - |     - |     456 B |
|                 Hyperlinq |     0 |   100 | 108.35 ns | 0.400 ns | 0.354 ns |  0.38 | 0.2333 |     - |     - |     488 B |
