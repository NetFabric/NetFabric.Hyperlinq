## Array.ValueType.ArrayValueTypeDistinct

### Source
[ArrayValueTypeDistinct.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeDistinct.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
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
|               Method | Duplicates | Count |         Mean |     Error |    StdDev | Ratio |     Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |-------------:|----------:|----------:|------:|----------:|------:|------:|----------:|
|              ForLoop |          4 |   100 |   516.893 μs | 2.4507 μs | 2.2924 μs | 1.000 | 1095.7031 |     - |     - | 2292184 B |
|          ForeachLoop |          4 |   100 |   522.311 μs | 1.2742 μs | 0.9948 μs | 1.011 | 1095.7031 |     - |     - | 2292184 B |
|                 Linq |          4 |   100 |   529.445 μs | 2.5564 μs | 2.2662 μs | 1.024 | 1092.7734 |     - |     - | 2286672 B |
|               LinqAF |          4 |   100 | 1,692.494 μs | 9.0976 μs | 8.0648 μs | 3.274 | 2187.5000 |     - |     - | 4575075 B |
|           StructLinq |          4 |   100 |   594.348 μs | 2.1316 μs | 1.8896 μs | 1.150 | 1086.9141 |     - |     - | 2273633 B |
| StructLinq_IFunction |          4 |   100 |     4.661 μs | 0.0139 μs | 0.0116 μs | 0.009 |         - |     - |     - |         - |
|            Hyperlinq |          4 |   100 |   493.049 μs | 6.7244 μs | 5.6152 μs | 0.954 | 1045.8984 |     - |     - | 2187585 B |
