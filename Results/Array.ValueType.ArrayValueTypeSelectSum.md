## Array.ValueType.ArrayValueTypeSelectSum

### Source
[ArrayValueTypeSelectSum.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelectSum.cs)

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
|               Method | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |  63.07 ns |  0.228 ns |  0.202 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 134.87 ns |  0.497 ns |  0.415 ns |  2.14 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 596.91 ns |  2.296 ns |  2.036 ns |  9.46 |    0.05 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 | 258.05 ns |  0.555 ns |  0.492 ns |  4.09 |    0.02 |      - |     - |     - |         - |
|               LinqAF |   100 | 563.66 ns | 11.224 ns | 25.105 ns |  8.56 |    0.24 |      - |     - |     - |         - |
|           StructLinq |   100 | 203.13 ns |  0.712 ns |  0.631 ns |  3.22 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 |  73.84 ns |  0.171 ns |  0.143 ns |  1.17 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 192.53 ns |  0.471 ns |  0.394 ns |  3.05 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |  68.56 ns |  0.143 ns |  0.126 ns |  1.09 |    0.00 |      - |     - |     - |         - |
