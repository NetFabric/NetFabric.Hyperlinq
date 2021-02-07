## Enumerable.Int32.EnumerableInt32WhereSelectToArray

### Source
[EnumerableInt32WhereSelectToArray.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta33](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta33)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                                Method | Count |       Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-----------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |   100 | 1,000.4 ns | 4.03 ns | 3.57 ns |  1.57 | 0.1259 |     - |     - |     264 B |
|                       ValueLinq_Stack |   100 |   970.9 ns | 1.33 ns | 1.18 ns |  1.52 | 0.1259 |     - |     - |     264 B |
|             ValueLinq_SharedPool_Push |   100 | 1,255.0 ns | 3.47 ns | 2.71 ns |  1.97 | 0.1259 |     - |     - |     264 B |
|             ValueLinq_SharedPool_Pull |   100 | 1,091.4 ns | 3.93 ns | 3.07 ns |  1.71 | 0.1259 |     - |     - |     264 B |
|        ValueLinq_ValueLambda_Standard |   100 |   743.2 ns | 2.76 ns | 2.45 ns |  1.16 | 0.1259 |     - |     - |     264 B |
|           ValueLinq_ValueLambda_Stack |   100 |   782.9 ns | 2.09 ns | 1.95 ns |  1.23 | 0.1259 |     - |     - |     264 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 |   914.5 ns | 2.36 ns | 1.97 ns |  1.43 | 0.1259 |     - |     - |     264 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 |   911.7 ns | 1.84 ns | 1.63 ns |  1.43 | 0.1259 |     - |     - |     264 B |
|                           ForeachLoop |   100 |   638.6 ns | 1.29 ns | 1.15 ns |  1.00 | 0.4358 |     - |     - |     912 B |
|                                  Linq |   100 |   980.4 ns | 3.68 ns | 3.27 ns |  1.54 | 0.3967 |     - |     - |     832 B |
|                                LinqAF |   100 | 1,118.9 ns | 3.67 ns | 3.26 ns |  1.75 | 0.4196 |     - |     - |     880 B |
|                            StructLinq |   100 |   993.0 ns | 3.66 ns | 3.42 ns |  1.56 | 0.1678 |     - |     - |     352 B |
|                  StructLinq_IFunction |   100 |   708.4 ns | 1.61 ns | 1.35 ns |  1.11 | 0.1259 |     - |     - |     264 B |
|                             Hyperlinq |   100 |   966.0 ns | 2.38 ns | 2.23 ns |  1.51 | 0.1259 |     - |     - |     264 B |
|                   Hyperlinq_IFunction |   100 | 1,016.1 ns | 3.83 ns | 3.59 ns |  1.59 | 0.1259 |     - |     - |     264 B |
|                        Hyperlinq_Pool |   100 | 1,022.3 ns | 3.32 ns | 3.11 ns |  1.60 | 0.0458 |     - |     - |      96 B |
|              Hyperlinq_Pool_IFunction |   100 |   859.4 ns | 1.44 ns | 1.21 ns |  1.35 | 0.0458 |     - |     - |      96 B |
