## Array.ValueType.ArrayValueTypeWhereSelectToArray

### Source
[ArrayValueTypeWhereSelectToArray.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToArray.cs)

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
|                   Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 | 1,104.1 ns |  9.07 ns |  8.04 ns |  1.00 |    0.00 | 3.4103 |     - |     - |    7136 B |
|              ForeachLoop |   100 | 1,179.5 ns | 14.10 ns | 13.19 ns |  1.07 |    0.01 | 3.4103 |     - |     - |    7136 B |
|                     Linq |   100 | 1,613.5 ns | 14.70 ns | 13.03 ns |  1.46 |    0.02 | 2.4319 |     - |     - |    5088 B |
|               LinqFaster |   100 | 1,319.5 ns | 17.32 ns | 16.20 ns |  1.19 |    0.02 | 2.8896 |     - |     - |    6048 B |
|                   LinqAF |   100 | 2,624.7 ns | 25.97 ns | 21.69 ns |  2.38 |    0.03 | 3.3951 |     - |     - |    7104 B |
|               StructLinq |   100 | 1,581.4 ns | 12.79 ns | 11.33 ns |  1.43 |    0.02 | 1.0128 |     - |     - |    2120 B |
|     StructLinq_IFunction |   100 |   999.9 ns |  8.32 ns |  7.37 ns |  0.91 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                Hyperlinq |   100 | 2,572.9 ns | 12.71 ns | 11.27 ns |  2.33 |    0.02 | 0.9670 |     - |     - |    2024 B |
|      Hyperlinq_IFunction |   100 | 1,136.1 ns |  7.84 ns |  7.33 ns |  1.03 |    0.01 | 0.9670 |     - |     - |    2024 B |
|           Hyperlinq_Pool |   100 | 1,405.6 ns |  7.84 ns |  6.95 ns |  1.27 |    0.01 | 0.0267 |     - |     - |      56 B |
| Hyperlinq_Pool_IFunction |   100 | 1,007.5 ns |  6.70 ns |  5.94 ns |  0.91 |    0.01 | 0.0267 |     - |     - |      56 B |
