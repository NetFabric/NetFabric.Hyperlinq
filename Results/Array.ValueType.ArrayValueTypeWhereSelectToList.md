## Array.ValueType.ArrayValueTypeWhereSelectToList

### Source
[ArrayValueTypeWhereSelectToList.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta36](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta36)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                                Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |   100 | 1,512.4 ns | 12.52 ns | 11.71 ns |  1.74 |    0.02 | 2.4433 |     - |     - |   4.99 KB |
|                       ValueLinq_Stack |   100 | 1,223.0 ns |  4.80 ns |  4.01 ns |  1.41 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|             ValueLinq_SharedPool_Push |   100 | 1,841.7 ns |  8.89 ns |  7.42 ns |  2.12 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|             ValueLinq_SharedPool_Pull |   100 | 1,521.8 ns |  6.50 ns |  6.08 ns |  1.76 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                ValueLinq_Ref_Standard |   100 | 1,375.1 ns |  8.00 ns |  6.68 ns |  1.59 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                   ValueLinq_Ref_Stack |   100 | 1,216.6 ns |  5.87 ns |  5.21 ns |  1.40 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|         ValueLinq_Ref_SharedPool_Push |   100 | 1,633.4 ns |  5.99 ns |  5.31 ns |  1.88 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|         ValueLinq_Ref_SharedPool_Pull |   100 | 1,531.9 ns |  4.35 ns |  4.07 ns |  1.77 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|        ValueLinq_ValueLambda_Standard |   100 | 1,201.5 ns |  6.44 ns |  6.02 ns |  1.39 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|           ValueLinq_ValueLambda_Stack |   100 | 1,205.7 ns | 11.08 ns | 10.37 ns |  1.39 |    0.02 | 1.0586 |     - |     - |   2.16 KB |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,435.6 ns |  5.16 ns |  4.58 ns |  1.66 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,411.9 ns |  5.59 ns |  5.23 ns |  1.63 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                               ForLoop |   100 |   867.3 ns |  4.62 ns |  4.09 ns |  1.00 |    0.00 | 2.4433 |     - |     - |   4.99 KB |
|                           ForeachLoop |   100 |   924.1 ns |  7.32 ns |  6.85 ns |  1.07 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                                  Linq |   100 | 1,289.9 ns |  9.73 ns |  8.62 ns |  1.49 |    0.01 | 2.5234 |     - |     - |   5.16 KB |
|                            LinqFaster |   100 | 1,294.7 ns |  6.53 ns |  5.79 ns |  1.49 |    0.01 | 4.0264 |     - |     - |   8.23 KB |
|                                LinqAF |   100 | 2,179.9 ns | 18.39 ns | 16.30 ns |  2.51 |    0.02 | 2.4414 |     - |     - |   4.99 KB |
|                            StructLinq |   100 | 1,265.7 ns |  4.28 ns |  3.34 ns |  1.46 |    0.01 | 1.1044 |     - |     - |   2.26 KB |
|                  StructLinq_IFunction |   100 |   902.6 ns |  4.50 ns |  3.99 ns |  1.04 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                             Hyperlinq |   100 | 1,168.1 ns |  4.99 ns |  4.67 ns |  1.35 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                   Hyperlinq_IFunction |   100 |   903.3 ns |  3.56 ns |  3.16 ns |  1.04 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
