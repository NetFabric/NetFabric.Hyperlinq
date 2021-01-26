## Range.RangeToList

### Source
[RangeToList.cs](../LinqBenchmarks/Range/RangeToList.cs)

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
|                    Method | Start | Count |       Mean |    Error |   StdDev |     Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |------ |------ |-----------:|---------:|---------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|        ValueLinq_Standard |     0 |   100 |   551.0 ns |  5.03 ns |  4.20 ns |   550.3 ns |  0.87 |    0.02 | 0.1087 |     - |     - |     456 B |
|           ValueLinq_Stack |     0 |   100 |   900.6 ns |  7.73 ns |  7.23 ns |   902.4 ns |  1.43 |    0.03 | 0.1659 |     - |     - |     696 B |
| ValueLinq_SharedPool_Push |     0 |   100 |   798.6 ns |  6.26 ns |  5.85 ns |   798.0 ns |  1.26 |    0.02 | 0.1087 |     - |     - |     456 B |
| ValueLinq_SharedPool_Pull |     0 |   100 |   823.0 ns | 12.05 ns | 11.27 ns |   828.8 ns |  1.30 |    0.02 | 0.1087 |     - |     - |     456 B |
|                   ForLoop |     0 |   100 |   631.6 ns | 12.61 ns | 11.79 ns |   631.8 ns |  1.00 |    0.00 | 0.2823 |     - |     - |    1184 B |
|               ForeachLoop |     0 |   100 | 1,388.6 ns | 27.77 ns | 43.23 ns | 1,403.4 ns |  2.18 |    0.09 | 0.2956 |     - |     - |    1240 B |
|                      Linq |     0 |   100 |   305.4 ns |  6.12 ns |  7.74 ns |   309.8 ns |  0.48 |    0.01 | 0.1183 |     - |     - |     496 B |
|                LinqFaster |     0 |   100 |   283.3 ns |  5.41 ns |  5.79 ns |   282.5 ns |  0.45 |    0.01 | 0.2103 |     - |     - |     880 B |
|                    LinqAF |     0 |   100 |   591.6 ns | 11.77 ns | 21.81 ns |   601.2 ns |  0.94 |    0.03 | 0.1087 |     - |     - |     456 B |
|                StructLinq |     0 |   100 |   521.9 ns |  9.68 ns |  9.51 ns |   525.8 ns |  0.83 |    0.02 | 0.1087 |     - |     - |     456 B |
|                 Hyperlinq |     0 |   100 |   226.7 ns |  4.49 ns |  6.58 ns |   225.6 ns |  0.36 |    0.01 | 0.1166 |     - |     - |     488 B |
