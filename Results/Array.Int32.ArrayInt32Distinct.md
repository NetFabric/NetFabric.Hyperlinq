## Array.Int32.ArrayInt32Distinct

### Source
[ArrayInt32Distinct.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Distinct.cs)

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
|               Method | Duplicates | Count |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |          4 |   100 | 3.553 μs | 0.0686 μs | 0.0962 μs |  1.00 |    0.00 | 2.8687 |     - |     - |    6008 B |
|          ForeachLoop |          4 |   100 | 3.539 μs | 0.0652 μs | 0.1072 μs |  1.00 |    0.04 | 2.8687 |     - |     - |    6008 B |
|                 Linq |          4 |   100 | 7.689 μs | 0.1509 μs | 0.2978 μs |  2.16 |    0.10 | 2.0599 |     - |     - |    4312 B |
|               LinqAF |          4 |   100 | 9.894 μs | 0.1935 μs | 0.3337 μs |  2.78 |    0.13 | 5.9204 |     - |     - |   12400 B |
|           StructLinq |          4 |   100 | 4.689 μs | 0.0932 μs | 0.1275 μs |  1.32 |    0.05 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |          4 |   100 | 4.148 μs | 0.0813 μs | 0.1624 μs |  1.17 |    0.05 |      - |     - |     - |         - |
|            Hyperlinq |          4 |   100 | 4.501 μs | 0.0893 μs | 0.1864 μs |  1.27 |    0.06 |      - |     - |     - |         - |
