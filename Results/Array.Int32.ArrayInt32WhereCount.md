## Array.Int32.ArrayInt32WhereCount

### Source
[ArrayInt32WhereCount.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereCount.cs)

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
|              ForLoop |   100 |  78.14 ns | 0.235 ns | 0.208 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  65.91 ns | 0.284 ns | 0.266 ns |  0.84 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 655.91 ns | 1.905 ns | 1.689 ns |  8.39 |    0.03 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 | 230.37 ns | 0.893 ns | 0.835 ns |  2.95 |    0.01 |      - |     - |     - |         - |
|               LinqAF |   100 | 257.40 ns | 1.273 ns | 1.190 ns |  3.30 |    0.01 |      - |     - |     - |         - |
|           StructLinq |   100 | 259.54 ns | 0.921 ns | 0.861 ns |  3.32 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |  83.70 ns | 0.165 ns | 0.146 ns |  1.07 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 167.52 ns | 0.424 ns | 0.397 ns |  2.14 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |  78.35 ns | 0.257 ns | 0.228 ns |  1.00 |    0.00 |      - |     - |     - |         - |
