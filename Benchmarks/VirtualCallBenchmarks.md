## VirtualCallBenchmarks

### References:
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta25](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta25)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  DefaultJob : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT


```
|                         Method | Categories |  Size |     Mean |    Error |   StdDev | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |----------- |------ |---------:|---------:|---------:|------:|--------:|------:|------:|------:|----------:|
|                Array_Interface |      Array | 10000 | 59.20 μs | 0.494 μs | 0.462 μs |  1.00 |    0.00 |     - |     - |     - |         - |
|                    Array_Class |      Array | 10000 | 22.85 μs | 0.316 μs | 0.280 μs |  0.39 |    0.00 |     - |     - |     - |         - |
|        Array_GenericConstraint |      Array | 10000 | 58.64 μs | 0.998 μs | 0.833 μs |  0.99 |    0.02 |     - |     - |     - |         - |
| Array_GenericConstraintWrapper |      Array | 10000 | 19.79 μs | 0.178 μs | 0.158 μs |  0.33 |    0.00 |     - |     - |     - |         - |
|                                |            |       |          |          |          |       |         |       |       |       |           |
|                 List_Interface |       List | 10000 | 58.49 μs | 0.721 μs | 0.639 μs |  1.00 |    0.00 |     - |     - |     - |         - |
|                     List_Class |       List | 10000 | 23.67 μs | 0.234 μs | 0.219 μs |  0.40 |    0.01 |     - |     - |     - |         - |
|         List_GenericConstraint |       List | 10000 | 53.59 μs | 0.704 μs | 0.624 μs |  0.92 |    0.01 |     - |     - |     - |         - |
|  List_GenericConstraintWrapper |       List | 10000 | 24.90 μs | 0.204 μs | 0.191 μs |  0.43 |    0.01 |     - |     - |     - |         - |
