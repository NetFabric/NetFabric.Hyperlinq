## Enumerable.Int32.EnumerableInt32WhereSelect

### Source
[EnumerableInt32WhereSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta34](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta34)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|          ForeachLoop |   100 |   761.8 ns | 15.25 ns | 34.12 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                 Linq |   100 | 1,849.6 ns | 36.62 ns | 78.82 ns |  2.43 |    0.16 | 0.0763 |     - |     - |     160 B |
|               LinqAF |   100 |   950.1 ns |  2.22 ns |  1.85 ns |  1.25 |    0.06 | 0.0191 |     - |     - |      40 B |
|           StructLinq |   100 | 1,541.8 ns | 30.64 ns | 87.41 ns |  2.01 |    0.14 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |   100 |   981.4 ns | 19.47 ns | 41.92 ns |  1.29 |    0.09 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 | 1,594.4 ns | 31.71 ns | 91.99 ns |  2.10 |    0.17 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |   100 |   976.8 ns | 19.53 ns | 54.77 ns |  1.29 |    0.10 | 0.0191 |     - |     - |      40 B |
