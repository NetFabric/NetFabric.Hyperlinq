## BoundsBenchmarks

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
|                 Method | Offset | Count |     Mean |     Error |    StdDev | Ratio | Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |------- |------ |---------:|----------:|----------:|------:|------:|------:|------:|----------:|
|                  Array |      0 | 10000 | 5.525 μs | 0.0214 μs | 0.0179 μs |  1.00 |     - |     - |     - |         - |
|        Array_Variables |      0 | 10000 | 5.592 μs | 0.0253 μs | 0.0224 μs |  1.01 |     - |     - |     - |         - |
|           ArraySegment |      0 | 10000 | 5.517 μs | 0.0105 μs | 0.0098 μs |  1.00 |     - |     - |     - |         - |
| ArraySegment_Variables |      0 | 10000 | 5.451 μs | 0.0370 μs | 0.0328 μs |  0.99 |     - |     - |     - |         - |
|                   List |      0 | 10000 | 9.971 μs | 0.0430 μs | 0.0402 μs |  1.80 |     - |     - |     - |         - |
|          List_Variable |      0 | 10000 | 6.176 μs | 0.0170 μs | 0.0151 μs |  1.12 |     - |     - |     - |         - |
|            ListSegment |      0 | 10000 | 6.306 μs | 0.0297 μs | 0.0263 μs |  1.14 |     - |     - |     - |         - |
|  ListSegment_Variables |      0 | 10000 | 6.169 μs | 0.0479 μs | 0.0400 μs |  1.12 |     - |     - |     - |         - |
