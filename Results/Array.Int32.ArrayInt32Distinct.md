## Array.Int32.ArrayInt32Distinct

### Source
[ArrayInt32Distinct.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Distinct.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta23](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta23)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|      Method | Duplicates | Count |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |----------- |------ |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|     ForLoop |          4 |   100 | 3.069 μs | 0.0190 μs | 0.0178 μs |  1.00 |    0.00 | 2.8687 |     - |     - |    6008 B |
| ForeachLoop |          4 |   100 | 3.084 μs | 0.0191 μs | 0.0160 μs |  1.01 |    0.01 | 2.8687 |     - |     - |    6008 B |
|        Linq |          4 |   100 | 6.633 μs | 0.0485 μs | 0.0453 μs |  2.16 |    0.02 | 2.0599 |     - |     - |    4312 B |
|  StructLinq |          4 |   100 | 5.077 μs | 0.0390 μs | 0.0365 μs |  1.65 |    0.02 |      - |     - |     - |         - |
|   Hyperlinq |          4 |   100 | 3.744 μs | 0.0445 μs | 0.0395 μs |  1.22 |    0.01 |      - |     - |     - |         - |
