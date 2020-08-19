## RangeBenchmarks

### References:
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta25](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta25)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|     Method | Start |  Count |      Mean |    Error |   StdDev | Ratio | Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------- |------ |------- |----------:|---------:|---------:|------:|------:|------:|------:|----------:|
|       Linq |     0 | 100000 | 395.70 μs | 2.527 μs | 2.364 μs |  1.00 |     - |     - |     - |      40 B |
| StructLinq |     0 | 100000 |  26.99 μs | 0.222 μs | 0.208 μs |  0.07 |     - |     - |     - |         - |
|  Hyperlinq |     0 | 100000 |  26.81 μs | 0.162 μs | 0.143 μs |  0.07 |     - |     - |     - |         - |
