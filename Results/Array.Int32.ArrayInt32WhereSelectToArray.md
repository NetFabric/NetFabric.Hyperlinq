## Array.Int32.ArrayInt32WhereSelectToArray

### Source
[ArrayInt32WhereSelectToArray.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToArray.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta27](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta27)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                   Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 | 294.2 ns | 2.02 ns | 1.79 ns |  1.00 |    0.00 | 0.4168 |     - |     - |     872 B |
|              ForeachLoop |   100 | 295.2 ns | 2.13 ns | 1.89 ns |  1.00 |    0.01 | 0.4168 |     - |     - |     872 B |
|                     Linq |   100 | 624.6 ns | 3.66 ns | 3.06 ns |  2.12 |    0.02 | 0.3710 |     - |     - |     776 B |
|               LinqFaster |   100 | 399.3 ns | 2.13 ns | 1.89 ns |  1.36 |    0.01 | 0.3095 |     - |     - |     648 B |
|                   LinqAF |   100 | 718.4 ns | 4.64 ns | 4.11 ns |  2.44 |    0.02 | 0.4015 |     - |     - |     840 B |
|               StructLinq |   100 | 573.5 ns | 3.67 ns | 3.43 ns |  1.95 |    0.02 | 0.1526 |     - |     - |     320 B |
|     StructLinq_IFunction |   100 | 389.3 ns | 2.39 ns | 2.12 ns |  1.32 |    0.01 | 0.1068 |     - |     - |     224 B |
|                Hyperlinq |   100 | 711.2 ns | 4.03 ns | 3.57 ns |  2.42 |    0.02 | 0.1068 |     - |     - |     224 B |
|      Hyperlinq_IFunction |   100 | 371.9 ns | 3.05 ns | 2.70 ns |  1.26 |    0.01 | 0.1068 |     - |     - |     224 B |
|           Hyperlinq_Pool |   100 | 672.6 ns | 2.93 ns | 2.74 ns |  2.29 |    0.02 | 0.0267 |     - |     - |      56 B |
| Hyperlinq_Pool_IFunction |   100 | 688.8 ns | 3.39 ns | 2.83 ns |  2.34 |    0.02 | 0.0267 |     - |     - |      56 B |
