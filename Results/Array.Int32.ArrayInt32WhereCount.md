## Array.Int32.ArrayInt32WhereCount

### Source
[ArrayInt32WhereCount.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereCount.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta29](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta29)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |    77.99 ns |  0.260 ns |  0.231 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |    77.68 ns |  0.114 ns |  0.095 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 1,022.93 ns |  2.435 ns |  2.158 ns | 13.12 |    0.04 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 |   495.92 ns | 10.957 ns | 32.134 ns |  6.39 |    0.44 |      - |     - |     - |         - |
|               LinqAF |   100 |   467.12 ns |  9.233 ns | 23.502 ns |  5.95 |    0.27 |      - |     - |     - |         - |
|           StructLinq |   100 |   456.82 ns |  9.018 ns | 14.816 ns |  5.82 |    0.18 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |    81.27 ns |  0.214 ns |  0.200 ns |  1.04 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   402.22 ns |  9.628 ns | 28.237 ns |  5.27 |    0.36 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |    74.77 ns |  0.430 ns |  0.402 ns |  0.96 |    0.01 |      - |     - |     - |         - |
