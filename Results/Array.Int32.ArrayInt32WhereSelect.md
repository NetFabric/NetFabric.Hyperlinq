## Array.Int32.ArrayInt32WhereSelect

### Source
[ArrayInt32WhereSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |  66.34 ns | 0.479 ns | 0.448 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  75.93 ns | 0.636 ns | 0.595 ns |  1.14 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 545.03 ns | 3.413 ns | 3.192 ns |  8.22 |    0.09 | 0.0496 |     - |     - |     104 B |
|           LinqFaster |   100 | 450.79 ns | 2.478 ns | 2.318 ns |  6.80 |    0.05 | 0.3095 |     - |     - |     648 B |
|               LinqAF |   100 | 598.61 ns | 5.256 ns | 4.916 ns |  9.02 |    0.08 |      - |     - |     - |         - |
|           StructLinq |   100 | 485.48 ns | 3.097 ns | 2.745 ns |  7.31 |    0.07 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 | 186.83 ns | 1.187 ns | 1.053 ns |  2.81 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 502.02 ns | 3.543 ns | 3.314 ns |  7.57 |    0.08 |      - |     - |     - |         - |
