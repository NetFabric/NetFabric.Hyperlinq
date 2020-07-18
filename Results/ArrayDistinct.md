## ArrayDistinct

- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.1.9](https://www.nuget.org/packages/StructLinq.BCL/0.1.9)
- NetFabric.Hyperlinq: [3.0.0-beta19](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta19)

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|      Method | Count |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |------ |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|     ForLoop |   100 | 1.457 μs | 0.0292 μs | 0.0259 μs |  1.00 |    0.00 | 2.8706 |     - |     - |    6008 B |
| ForeachLoop |   100 | 1.414 μs | 0.0129 μs | 0.0120 μs |  0.97 |    0.02 | 2.8706 |     - |     - |    6008 B |
|        Linq |   100 | 2.606 μs | 0.0156 μs | 0.0146 μs |  1.79 |    0.03 | 2.0599 |     - |     - |    4312 B |
|  StructLinq |   100 | 1.979 μs | 0.0214 μs | 0.0200 μs |  1.36 |    0.02 |      - |     - |     - |         - |
|   Hyperlinq |   100 | 1.848 μs | 0.0170 μs | 0.0159 μs |  1.27 |    0.03 |      - |     - |     - |         - |
