## Array.Int32.ArrayInt32WhereSelect

### Source
[ArrayInt32WhereSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelect.cs)

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
|               Method | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |  80.53 ns |  0.339 ns |  0.317 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  80.36 ns |  0.228 ns |  0.213 ns |  1.00 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 803.74 ns | 15.079 ns | 14.105 ns |  9.98 |    0.18 | 0.0496 |     - |     - |     104 B |
|           LinqFaster |   100 | 479.67 ns |  4.503 ns |  4.212 ns |  5.96 |    0.06 | 0.3090 |     - |     - |     648 B |
|               LinqAF |   100 | 661.58 ns |  8.633 ns |  7.653 ns |  8.22 |    0.10 |      - |     - |     - |         - |
|           StructLinq |   100 | 503.12 ns |  9.267 ns | 14.427 ns |  6.13 |    0.20 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 | 195.94 ns |  0.788 ns |  0.699 ns |  2.43 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 538.03 ns |  8.363 ns |  7.414 ns |  6.68 |    0.10 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 | 208.04 ns |  0.636 ns |  0.564 ns |  2.58 |    0.02 |      - |     - |     - |         - |
