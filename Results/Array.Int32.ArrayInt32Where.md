## Array.Int32.ArrayInt32Where

### Source
[ArrayInt32Where.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Where.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta37](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta37)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |  78.49 ns | 0.219 ns | 0.194 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  66.10 ns | 0.251 ns | 0.222 ns |  0.84 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 506.88 ns | 1.788 ns | 1.493 ns |  6.46 |    0.03 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |   100 | 277.62 ns | 1.158 ns | 1.027 ns |  3.54 |    0.02 | 0.3171 |     - |     - |     664 B |
|               LinqAF |   100 | 368.33 ns | 2.115 ns | 1.875 ns |  4.69 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 | 269.68 ns | 1.152 ns | 1.022 ns |  3.44 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 | 164.43 ns | 0.709 ns | 0.629 ns |  2.09 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 256.00 ns | 1.441 ns | 1.277 ns |  3.26 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 | 194.99 ns | 0.617 ns | 0.547 ns |  2.48 |    0.01 |      - |     - |     - |         - |
