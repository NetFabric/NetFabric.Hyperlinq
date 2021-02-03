## Array.Int32.ArrayInt32WhereSelect

### Source
[ArrayInt32WhereSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta31](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta31)

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
|              ForLoop |   100 |    74.13 ns |  0.169 ns |  0.149 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |    74.25 ns |  0.144 ns |  0.135 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 1,031.86 ns | 20.671 ns | 58.641 ns | 14.17 |    0.91 | 0.0496 |     - |     - |     104 B |
|           LinqFaster |   100 |   431.92 ns |  1.101 ns |  0.976 ns |  5.83 |    0.02 | 0.3095 |     - |     - |     648 B |
|               LinqAF |   100 |   463.41 ns |  1.422 ns |  1.261 ns |  6.25 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 |   595.60 ns | 11.816 ns | 18.044 ns |  7.97 |    0.20 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |   185.01 ns |  0.320 ns |  0.299 ns |  2.50 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   685.62 ns | 13.726 ns | 36.400 ns |  9.08 |    0.41 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   192.23 ns |  0.304 ns |  0.269 ns |  2.59 |    0.01 |      - |     - |     - |         - |
