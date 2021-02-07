## Array.ValueType.ArrayValueTypeSkipTakeWhere

### Source
[ArrayValueTypeSkipTakeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeWhere.cs)

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
|               Method | Skip | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |   409.1 ns |  0.59 ns |  0.52 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 2,637.3 ns |  8.09 ns |  6.75 ns |  6.45 |    0.02 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |   100 | 2,650.5 ns |  4.39 ns |  3.67 ns |  6.48 |    0.01 | 0.1183 |     - |     - |     248 B |
|           LinqFaster | 1000 |   100 | 1,397.9 ns |  9.92 ns |  8.28 ns |  3.42 |    0.02 | 6.7329 |     - |     - |   14096 B |
|               LinqAF | 1000 |   100 | 5,009.8 ns | 96.96 ns | 95.23 ns | 12.27 |    0.21 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |   611.6 ns |  1.73 ns |  1.53 ns |  1.49 |    0.00 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 |   487.4 ns |  0.97 ns |  0.86 ns |  1.19 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |   527.9 ns |  1.29 ns |  1.21 ns |  1.29 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |   100 |   467.8 ns |  0.99 ns |  0.93 ns |  1.14 |    0.00 |      - |     - |     - |         - |
