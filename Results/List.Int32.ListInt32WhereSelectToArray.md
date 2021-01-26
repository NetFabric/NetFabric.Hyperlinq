## List.Int32.ListInt32WhereSelectToArray

### Source
[ListInt32WhereSelectToArray.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToArray.cs)

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
|                                        Method | Count |       Mean |     Error |    StdDev |     Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |------ |-----------:|----------:|----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                            ValueLinq_Standard |   100 | 1,579.3 ns |  31.41 ns |  81.08 ns | 1,592.8 ns |  2.17 |    0.17 | 0.1774 |     - |     - |     744 B |
|                               ValueLinq_Stack |   100 | 1,536.5 ns |  30.37 ns |  64.05 ns | 1,551.6 ns |  2.12 |    0.15 | 0.0534 |     - |     - |     224 B |
|                     ValueLinq_SharedPool_Push |   100 | 1,646.8 ns |  32.82 ns |  84.14 ns | 1,654.8 ns |  2.27 |    0.16 | 0.0534 |     - |     - |     224 B |
|                     ValueLinq_SharedPool_Pull |   100 | 1,915.3 ns |  38.26 ns | 106.01 ns | 1,935.3 ns |  2.64 |    0.22 | 0.0534 |     - |     - |     224 B |
|                ValueLinq_ValueLambda_Standard |   100 | 1,372.6 ns |  27.30 ns |  77.01 ns | 1,390.9 ns |  1.89 |    0.16 | 0.1774 |     - |     - |     744 B |
|                   ValueLinq_ValueLambda_Stack |   100 | 1,272.1 ns |  25.43 ns |  67.00 ns | 1,293.2 ns |  1.75 |    0.15 | 0.0534 |     - |     - |     224 B |
|         ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,416.2 ns |  28.38 ns |  82.78 ns | 1,432.0 ns |  1.95 |    0.17 | 0.0534 |     - |     - |     224 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,614.6 ns |  32.55 ns |  95.96 ns | 1,628.1 ns |  2.22 |    0.19 | 0.0534 |     - |     - |     224 B |
|                    ValueLinq_Standard_ByIndex |   100 | 1,303.9 ns |  26.69 ns |  78.68 ns | 1,348.9 ns |  1.80 |    0.14 | 0.1774 |     - |     - |     744 B |
|                       ValueLinq_Stack_ByIndex |   100 |   982.2 ns |  21.84 ns |  64.39 ns | 1,020.5 ns |  1.35 |    0.12 | 0.0534 |     - |     - |     224 B |
|             ValueLinq_SharedPool_Push_ByIndex |   100 | 1,276.1 ns |  25.55 ns |  74.94 ns | 1,240.8 ns |  1.76 |    0.14 | 0.0534 |     - |     - |     224 B |
|             ValueLinq_SharedPool_Pull_ByIndex |   100 | 1,247.5 ns |  25.02 ns |  71.78 ns | 1,215.3 ns |  1.72 |    0.15 | 0.0534 |     - |     - |     224 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |   100 | 1,050.8 ns |  21.69 ns |  63.95 ns | 1,078.6 ns |  1.45 |    0.11 | 0.1774 |     - |     - |     744 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |   100 |   604.9 ns |  13.63 ns |  40.19 ns |   629.9 ns |  0.83 |    0.07 | 0.0534 |     - |     - |     224 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 | 1,071.4 ns |  23.60 ns |  69.58 ns | 1,044.3 ns |  1.48 |    0.15 | 0.0534 |     - |     - |     224 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 |   951.4 ns |  19.10 ns |  53.88 ns |   939.7 ns |  1.31 |    0.11 | 0.0534 |     - |     - |     224 B |
|                                       ForLoop |   100 |   728.4 ns |  14.95 ns |  44.08 ns |   740.9 ns |  1.00 |    0.00 | 0.2079 |     - |     - |     872 B |
|                                   ForeachLoop |   100 |   969.3 ns |  22.11 ns |  65.20 ns |   989.2 ns |  1.34 |    0.13 | 0.2079 |     - |     - |     872 B |
|                                          Linq |   100 | 1,146.1 ns |  25.34 ns |  74.71 ns | 1,168.0 ns |  1.58 |    0.14 | 0.1965 |     - |     - |     824 B |
|                                    LinqFaster |   100 |   960.8 ns |  22.05 ns |  65.02 ns |   974.2 ns |  1.32 |    0.13 | 0.2079 |     - |     - |     872 B |
|                                        LinqAF |   100 | 8,074.7 ns | 161.47 ns | 408.06 ns | 7,900.0 ns | 11.13 |    0.93 |      - |     - |     - |     840 B |
|                                    StructLinq |   100 | 1,080.2 ns |  22.68 ns |  66.87 ns | 1,049.6 ns |  1.49 |    0.13 | 0.0782 |     - |     - |     328 B |
|                          StructLinq_IFunction |   100 |   821.1 ns |  17.24 ns |  50.85 ns |   814.6 ns |  1.13 |    0.10 | 0.0534 |     - |     - |     224 B |
|                                     Hyperlinq |   100 | 1,038.7 ns |  20.64 ns |  59.89 ns | 1,011.3 ns |  1.43 |    0.12 | 0.0534 |     - |     - |     224 B |
|                                Hyperlinq_Pool |   100 | 1,163.0 ns |  23.27 ns |  68.23 ns | 1,130.5 ns |  1.60 |    0.13 | 0.0134 |     - |     - |      56 B |
