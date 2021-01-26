## Range.RangeToArray

### Source
[RangeToArray.cs](../LinqBenchmarks/Range/RangeToArray.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.630 (2004/?/20H1)
Intel Core i7 CPU 930 2.80GHz (Nehalem), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.100
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                    Method | Start | Count |     Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |------ |------ |---------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|        ValueLinq_Standard |     0 |   100 | 373.7 ns |  7.32 ns |  8.72 ns |  2.16 |    0.08 | 0.1011 |     - |     - |     424 B |
|           ValueLinq_Stack |     0 |   100 | 635.5 ns | 12.05 ns | 12.89 ns |  3.68 |    0.14 | 0.1583 |     - |     - |     664 B |
| ValueLinq_SharedPool_Push |     0 |   100 | 751.4 ns | 11.08 ns | 10.36 ns |  4.35 |    0.11 | 0.1011 |     - |     - |     424 B |
| ValueLinq_SharedPool_Pull |     0 |   100 | 708.8 ns | 13.05 ns | 17.87 ns |  4.11 |    0.18 | 0.1011 |     - |     - |     424 B |
|                   ForLoop |     0 |   100 | 172.3 ns |  3.52 ns |  5.16 ns |  1.00 |    0.00 | 0.1013 |     - |     - |     424 B |
|                      Linq |     0 |   100 | 202.4 ns |  4.09 ns |  5.99 ns |  1.18 |    0.05 | 0.1109 |     - |     - |     464 B |
|                LinqFaster |     0 |   100 | 180.2 ns |  3.56 ns |  4.37 ns |  1.04 |    0.03 | 0.1013 |     - |     - |     424 B |
|                    LinqAF |     0 |   100 | 470.2 ns |  9.28 ns | 21.50 ns |  2.71 |    0.17 | 0.1011 |     - |     - |     424 B |
|                StructLinq |     0 |   100 | 443.3 ns |  8.86 ns | 20.53 ns |  2.61 |    0.13 | 0.1011 |     - |     - |     424 B |
|                 Hyperlinq |     0 |   100 | 197.5 ns |  3.94 ns |  5.52 ns |  1.15 |    0.04 | 0.1013 |     - |     - |     424 B |
|            Hyperlinq_Pool |     0 |   100 | 238.5 ns |  3.54 ns |  3.31 ns |  1.38 |    0.05 | 0.0134 |     - |     - |      56 B |
