## Array.Int32.ArrayInt32WhereCount

### Source
[ArrayInt32WhereCount.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereCount.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta39](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta39)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=6.0.100-preview.1.21103.13
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **6.929 ns** |  **0.0600 ns** |  **0.0561 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     6.652 ns |  0.0523 ns |  0.0489 ns |  0.96 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    69.016 ns |  0.2077 ns |  0.1943 ns |  9.96 |    0.08 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |    10 |    21.658 ns |  0.0908 ns |  0.0805 ns |  3.13 |    0.02 |      - |     - |     - |         - |
|               LinqAF |    10 |    35.926 ns |  0.1259 ns |  0.1051 ns |  5.19 |    0.05 |      - |     - |     - |         - |
|           StructLinq |    10 |    49.380 ns |  0.1045 ns |  0.0816 ns |  7.14 |    0.06 | 0.0306 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |    21.901 ns |  0.0393 ns |  0.0368 ns |  3.16 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    24.945 ns |  0.0501 ns |  0.0444 ns |  3.60 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |    14.811 ns |  0.0301 ns |  0.0251 ns |  2.14 |    0.02 |      - |     - |     - |         - |
|                      |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |   **789.882 ns** |  **3.4718 ns** |  **2.7105 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |   791.396 ns |  3.0288 ns |  2.8332 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq |  1000 | 8,673.381 ns | 34.1523 ns | 30.2751 ns | 10.98 |    0.06 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |  1000 | 2,730.267 ns | 48.7233 ns | 59.8366 ns |  3.47 |    0.09 |      - |     - |     - |         - |
|               LinqAF |  1000 | 3,545.425 ns | 27.1049 ns | 24.0278 ns |  4.49 |    0.03 |      - |     - |     - |         - |
|           StructLinq |  1000 | 5,124.013 ns | 49.0809 ns | 38.3191 ns |  6.49 |    0.06 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 |   800.408 ns |  4.4174 ns |  3.9159 ns |  1.01 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 1,558.078 ns |  3.6428 ns |  3.0419 ns |  1.97 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |   648.223 ns |  1.5357 ns |  1.2824 ns |  0.82 |    0.00 |      - |     - |     - |         - |
