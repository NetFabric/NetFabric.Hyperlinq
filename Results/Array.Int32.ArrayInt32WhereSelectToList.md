## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta27](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta27)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.630 (2004/?/20H1)
Intel Core i7 CPU 930 2.80GHz (Nehalem), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.100
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                                Method | Count |        Mean |       Error |      StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------------:|------------:|------------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |   100 |    969.6 ns |     5.67 ns |     5.31 ns |    967.4 ns |  1.73 |    0.17 | 0.1545 |     - |     - |     648 B |
|                       ValueLinq_Stack |   100 |  1,203.0 ns |    14.73 ns |    13.78 ns |  1,204.6 ns |  2.14 |    0.22 | 0.0610 |     - |     - |     256 B |
|             ValueLinq_SharedPool_Push |   100 |  1,441.3 ns |    23.31 ns |    21.80 ns |  1,438.5 ns |  2.57 |    0.27 | 0.0610 |     - |     - |     256 B |
|             ValueLinq_SharedPool_Pull |   100 |  1,483.2 ns |    27.83 ns |    29.78 ns |  1,479.5 ns |  2.64 |    0.21 | 0.0610 |     - |     - |     256 B |
|        ValueLinq_ValueLambda_Standard |   100 |    717.8 ns |    13.92 ns |    15.47 ns |    712.1 ns |  1.28 |    0.12 | 0.1545 |     - |     - |     648 B |
|           ValueLinq_ValueLambda_Stack |   100 |    745.9 ns |    15.01 ns |    20.55 ns |    753.7 ns |  1.32 |    0.12 | 0.0610 |     - |     - |     256 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 |  1,100.5 ns |    22.01 ns |    36.78 ns |  1,108.0 ns |  1.94 |    0.16 | 0.0610 |     - |     - |     256 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 |  1,068.3 ns |    21.35 ns |    48.63 ns |  1,086.8 ns |  1.87 |    0.15 | 0.0610 |     - |     - |     256 B |
|                               ForLoop |   100 |    581.3 ns |    11.37 ns |    32.99 ns |    581.0 ns |  1.00 |    0.00 | 0.1545 |     - |     - |     648 B |
|                           ForeachLoop |   100 |    607.2 ns |    12.23 ns |    24.14 ns |    611.0 ns |  1.07 |    0.08 | 0.1545 |     - |     - |     648 B |
|                                  Linq |   100 |  1,552.9 ns |    30.94 ns |    49.97 ns |  1,555.4 ns |  2.74 |    0.23 | 0.1793 |     - |     - |     752 B |
|                            LinqFaster |   100 |  1,340.7 ns |    26.32 ns |    43.98 ns |  1,355.3 ns |  2.37 |    0.20 | 0.2155 |     - |     - |     904 B |
|                                LinqAF |   100 | 11,333.0 ns | 1,411.85 ns | 4,096.03 ns | 10,000.0 ns | 19.62 |    7.46 |      - |     - |     - |     648 B |
|                            StructLinq |   100 |  1,706.4 ns |    33.84 ns |    58.37 ns |  1,706.6 ns |  3.02 |    0.26 | 0.0839 |     - |     - |     352 B |
|                  StructLinq_IFunction |   100 |  1,010.3 ns |    20.35 ns |    34.00 ns |  1,019.7 ns |  1.78 |    0.14 | 0.0610 |     - |     - |     256 B |
|                             Hyperlinq |   100 |  1,524.6 ns |    30.00 ns |    67.10 ns |  1,533.1 ns |  2.66 |    0.20 | 0.0782 |     - |     - |     328 B |
