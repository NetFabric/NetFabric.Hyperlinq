## Array.Int32.ArrayInt32WhereSelect

### Source
[ArrayInt32WhereSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelect.cs)

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
|              ForLoop |   100 |  66.23 ns | 0.180 ns | 0.150 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  65.80 ns | 0.080 ns | 0.062 ns |  0.99 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 652.04 ns | 1.775 ns | 1.386 ns |  9.85 |    0.04 | 0.0496 |     - |     - |     104 B |
|           LinqFaster |   100 | 379.87 ns | 0.806 ns | 0.673 ns |  5.74 |    0.02 | 0.3171 |     - |     - |     664 B |
|               LinqAF |   100 | 475.69 ns | 2.604 ns | 2.436 ns |  7.18 |    0.03 |      - |     - |     - |         - |
|           StructLinq |   100 | 393.16 ns | 1.580 ns | 1.401 ns |  5.94 |    0.03 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 | 182.86 ns | 0.591 ns | 0.553 ns |  2.76 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 380.39 ns | 1.274 ns | 1.192 ns |  5.74 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 | 206.36 ns | 0.463 ns | 0.410 ns |  3.12 |    0.01 |      - |     - |     - |         - |
