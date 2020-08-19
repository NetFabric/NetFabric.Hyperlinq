## ImmutableArrayBenchmarks

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
|      Method | Categories | Count |         Mean |      Error |     StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |----------- |------ |-------------:|-----------:|-----------:|------:|-------:|------:|------:|----------:|
|       **Where** |      **Where** |     **0** |     **13.59 ns** |   **0.060 ns** |   **0.054 ns** |  **1.00** |      **-** |     **-** |     **-** |         **-** |
|  WhereHyper |      Where |     0 |     15.99 ns |   0.132 ns |   0.123 ns |  1.18 |      - |     - |     - |         - |
|             |            |       |              |            |            |       |        |       |       |           |
|      Select |     Select |     0 |     22.77 ns |   0.253 ns |   0.237 ns |  1.00 |      - |     - |     - |         - |
| SelectHyper |     Select |     0 |     12.82 ns |   0.054 ns |   0.048 ns |  0.56 |      - |     - |     - |         - |
|             |            |       |              |            |            |       |        |       |       |           |
|       **Where** |      **Where** |    **10** |     **75.66 ns** |   **0.519 ns** |   **0.434 ns** |  **1.00** | **0.0229** |     **-** |     **-** |      **48 B** |
|  WhereHyper |      Where |    10 |     65.10 ns |   0.341 ns |   0.302 ns |  0.86 |      - |     - |     - |         - |
|             |            |       |              |            |            |       |        |       |       |           |
|      Select |     Select |    10 |    127.52 ns |   1.132 ns |   1.004 ns |  1.00 | 0.0229 |     - |     - |      48 B |
| SelectHyper |     Select |    10 |     60.09 ns |   0.564 ns |   0.528 ns |  0.47 |      - |     - |     - |         - |
|             |            |       |              |            |            |       |        |       |       |           |
|       **Where** |      **Where** | **10000** | **41,372.35 ns** | **124.375 ns** | **116.340 ns** |  **1.00** |      **-** |     **-** |     **-** |      **48 B** |
|  WhereHyper |      Where | 10000 | 61,415.92 ns | 377.049 ns | 314.853 ns |  1.48 |      - |     - |     - |         - |
|             |            |       |              |            |            |       |        |       |       |           |
|      Select |     Select | 10000 | 55,764.85 ns | 403.775 ns | 357.936 ns |  1.00 |      - |     - |     - |      48 B |
| SelectHyper |     Select | 10000 | 49,017.82 ns | 531.779 ns | 497.427 ns |  0.88 |      - |     - |     - |         - |
