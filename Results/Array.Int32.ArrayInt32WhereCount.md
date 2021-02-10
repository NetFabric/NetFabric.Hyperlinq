## Array.Int32.ArrayInt32WhereCount

### Source
[ArrayInt32WhereCount.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereCount.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta35](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta35)

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
|              ForLoop |   100 |  78.10 ns | 0.229 ns | 0.191 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  65.77 ns | 0.197 ns | 0.175 ns |  0.84 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 653.07 ns | 2.855 ns | 2.671 ns |  8.37 |    0.04 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 | 184.36 ns | 0.743 ns | 0.621 ns |  2.36 |    0.01 |      - |     - |     - |         - |
|               LinqAF |   100 | 258.80 ns | 1.454 ns | 1.289 ns |  3.31 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 | 240.61 ns | 2.661 ns | 2.489 ns |  3.08 |    0.03 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |  84.67 ns | 0.150 ns | 0.141 ns |  1.08 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 167.91 ns | 0.211 ns | 0.177 ns |  2.15 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |  78.42 ns | 0.251 ns | 0.223 ns |  1.00 |    0.00 |      - |     - |     - |         - |
