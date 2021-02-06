## Array.Int32.ArrayInt32WhereSelect

### Source
[ArrayInt32WhereSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta32](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta32)

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
|              ForLoop |   100 |    74.34 ns |  0.173 ns |  0.145 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |    74.47 ns |  0.206 ns |  0.182 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 1,027.85 ns | 21.880 ns | 64.515 ns | 13.44 |    0.50 | 0.0496 |     - |     - |     104 B |
|           LinqFaster |   100 |   433.11 ns |  1.459 ns |  1.293 ns |  5.82 |    0.02 | 0.3095 |     - |     - |     648 B |
|               LinqAF |   100 |   469.31 ns |  1.771 ns |  1.570 ns |  6.31 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 |   605.41 ns | 11.984 ns | 17.566 ns |  8.11 |    0.21 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |   186.12 ns |  0.540 ns |  0.505 ns |  2.50 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   673.50 ns | 13.402 ns | 35.541 ns |  8.91 |    0.60 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   192.23 ns |  0.374 ns |  0.312 ns |  2.59 |    0.01 |      - |     - |     - |         - |
