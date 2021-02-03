## Array.ValueType.ArrayValueTypeWhereSelectToList

### Source
[ArrayValueTypeWhereSelectToList.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToList.cs)

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
|                                Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |   100 | 1,389.6 ns | 17.21 ns | 16.10 ns |  1.72 |    0.02 | 2.4433 |     - |     - |   4.99 KB |
|                       ValueLinq_Stack |   100 | 1,108.2 ns |  6.17 ns |  5.47 ns |  1.38 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|             ValueLinq_SharedPool_Push |   100 | 1,729.9 ns | 20.36 ns | 19.04 ns |  2.15 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|             ValueLinq_SharedPool_Pull |   100 | 1,405.9 ns |  4.92 ns |  4.36 ns |  1.75 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                ValueLinq_Ref_Standard |   100 | 1,308.8 ns |  5.73 ns |  4.79 ns |  1.63 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                   ValueLinq_Ref_Stack |   100 | 1,121.1 ns |  6.37 ns |  5.65 ns |  1.39 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|         ValueLinq_Ref_SharedPool_Push |   100 | 1,550.7 ns |  8.56 ns |  7.59 ns |  1.93 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|         ValueLinq_Ref_SharedPool_Pull |   100 | 1,379.8 ns |  3.95 ns |  3.30 ns |  1.71 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|        ValueLinq_ValueLambda_Standard |   100 | 1,106.3 ns |  4.13 ns |  3.66 ns |  1.37 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|           ValueLinq_ValueLambda_Stack |   100 | 1,083.8 ns |  3.14 ns |  2.93 ns |  1.35 |    0.00 | 0.9823 |     - |     - |   2.01 KB |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,354.0 ns |  9.34 ns |  7.80 ns |  1.68 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,329.4 ns |  4.48 ns |  4.19 ns |  1.65 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                               ForLoop |   100 |   805.0 ns |  3.13 ns |  2.78 ns |  1.00 |    0.00 | 2.4433 |     - |     - |   4.99 KB |
|                           ForeachLoop |   100 |   874.9 ns | 14.34 ns | 13.41 ns |  1.09 |    0.02 | 2.4433 |     - |     - |   4.99 KB |
|                                  Linq |   100 | 1,258.9 ns |  8.22 ns |  7.69 ns |  1.56 |    0.01 | 2.5234 |     - |     - |   5.16 KB |
|                            LinqFaster |   100 | 1,160.2 ns |  7.40 ns |  6.56 ns |  1.44 |    0.01 | 3.8700 |     - |     - |   7.91 KB |
|                                LinqAF |   100 | 2,014.5 ns | 25.48 ns | 22.59 ns |  2.50 |    0.03 | 2.4414 |     - |     - |   4.99 KB |
|                            StructLinq |   100 | 1,161.1 ns |  6.18 ns |  5.48 ns |  1.44 |    0.01 | 1.0281 |     - |     - |    2.1 KB |
|                  StructLinq_IFunction |   100 |   872.0 ns |  4.15 ns |  3.68 ns |  1.08 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                             Hyperlinq |   100 | 1,070.0 ns |  2.59 ns |  2.30 ns |  1.33 |    0.00 | 0.9823 |     - |     - |   2.01 KB |
|                   Hyperlinq_IFunction |   100 |   819.8 ns |  2.90 ns |  2.57 ns |  1.02 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
