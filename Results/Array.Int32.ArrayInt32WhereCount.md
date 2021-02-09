## Array.Int32.ArrayInt32WhereCount

### Source
[ArrayInt32WhereCount.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereCount.cs)

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
|              ForLoop |   100 |  65.85 ns | 0.210 ns | 0.196 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  65.91 ns | 0.254 ns | 0.238 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 683.76 ns | 2.061 ns | 1.928 ns | 10.38 |    0.05 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 | 185.86 ns | 0.684 ns | 0.606 ns |  2.82 |    0.01 |      - |     - |     - |         - |
|               LinqAF |   100 | 223.41 ns | 1.145 ns | 1.071 ns |  3.39 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 | 247.66 ns | 0.983 ns | 0.872 ns |  3.76 |    0.02 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |  84.92 ns | 0.259 ns | 0.242 ns |  1.29 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 190.27 ns | 0.513 ns | 0.455 ns |  2.89 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |  75.04 ns | 0.193 ns | 0.181 ns |  1.14 |    0.00 |      - |     - |     - |         - |
