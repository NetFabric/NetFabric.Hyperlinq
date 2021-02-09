## List.Int32.ListInt32Where

### Source
[ListInt32Where.cs](../LinqBenchmarks/List/Int32/ListInt32Where.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta34](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta34)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |  97.41 ns | 0.168 ns | 0.157 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 251.63 ns | 0.876 ns | 0.777 ns |  2.58 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 776.27 ns | 2.503 ns | 2.341 ns |  7.97 |    0.03 | 0.0343 |     - |     - |      72 B |
|           LinqFaster |   100 | 402.66 ns | 1.639 ns | 1.280 ns |  4.13 |    0.01 | 0.3095 |     - |     - |     648 B |
|               LinqAF |   100 | 938.78 ns | 3.446 ns | 3.055 ns |  9.64 |    0.03 |      - |     - |     - |         - |
|           StructLinq |   100 | 335.23 ns | 2.395 ns | 2.123 ns |  3.44 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 | 168.18 ns | 0.844 ns | 0.748 ns |  1.73 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 251.64 ns | 0.708 ns | 0.663 ns |  2.58 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 | 182.57 ns | 0.336 ns | 0.297 ns |  1.87 |    0.00 |      - |     - |     - |         - |
