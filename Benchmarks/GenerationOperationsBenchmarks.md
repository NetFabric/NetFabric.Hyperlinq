## GenerationOperationsBenchmarks

### Source
[GenerationOperationsBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/GenerationOperationsBenchmarks.cs)

### References:
- Linq: 5.0.0-preview.6.20305.6
- System.Linq.Async: [4.1.1](https://www.nuget.org/packages/System.Linq.Async/4.1.1)
- System.Interactive: [4.1.1](https://www.nuget.org/packages/System.Interactive/4.1.1)
- System.Interactive.Async: [4.1.1](https://www.nuget.org/packages/System.Interactive.Async/4.1.1)
- StructLinq: [0.19.3](https://www.nuget.org/packages/StructLinq/0.19.3)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=macOS Catalina 10.15.6 (19G2021) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                 Method |   Categories | Count |         Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |------------- |------ |-------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|             Linq_Empty |        Empty |   100 |     7.229 ns | 0.0215 ns | 0.0180 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|        Hyperlinq_Empty |        Empty |   100 |     1.625 ns | 0.0096 ns | 0.0080 ns |  0.22 |    0.00 |      - |     - |     - |         - |
|                        |              |       |              |           |           |       |         |        |       |       |           |
|       Linq_Empty_Async |  Empty_Async |   100 |    56.121 ns | 0.1659 ns | 0.1385 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_Empty_Async |  Empty_Async |   100 |    33.244 ns | 0.0624 ns | 0.0521 ns |  0.59 |    0.00 |      - |     - |     - |         - |
|                        |              |       |              |           |           |       |         |        |       |       |           |
|             Linq_Range |        Range |   100 |   490.860 ns | 1.4281 ns | 1.2660 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|       StructLinq_Range |        Range |   100 |    44.580 ns | 0.1275 ns | 0.1065 ns |  0.09 |    0.00 |      - |     - |     - |         - |
|        Hyperlinq_Range |        Range |   100 |    51.952 ns | 0.1163 ns | 0.1031 ns |  0.11 |    0.00 |      - |     - |     - |         - |
|                        |              |       |              |           |           |       |         |        |       |       |           |
|       Linq_Range_Async |  Range_Async |   100 | 5,530.618 ns | 8.3510 ns | 6.5199 ns |  1.00 |    0.00 | 0.0229 |     - |     - |      48 B |
|  Hyperlinq_Range_Async |  Range_Async |   100 | 1,857.147 ns | 3.2657 ns | 2.5496 ns |  0.34 |    0.00 | 0.0153 |     - |     - |      32 B |
|                        |              |       |              |           |           |       |         |        |       |       |           |
|            Linq_Repeat |       Repeat |   100 |   540.052 ns | 3.8082 ns | 3.3759 ns |     ? |       ? | 0.0191 |     - |     - |      40 B |
|                        |              |       |              |           |           |       |         |        |       |       |           |
|      Linq_Repeat_Count | Repeat_Count |   100 |   516.174 ns | 2.9000 ns | 2.7127 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_Repeat_Count | Repeat_Count |   100 |   161.024 ns | 0.2224 ns | 0.1972 ns |  0.31 |    0.00 |      - |     - |     - |         - |
|                        |              |       |              |           |           |       |         |        |       |       |           |
|            Linq_Return |       Return |   100 |    32.821 ns | 0.2004 ns | 0.1875 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|       Hyperlinq_Return |       Return |   100 |     9.792 ns | 0.0120 ns | 0.0106 ns |  0.30 |    0.00 |      - |     - |     - |         - |
|                        |              |       |              |           |           |       |         |        |       |       |           |
|      Linq_Return_Async | Return_Async |   100 |    83.915 ns | 0.2599 ns | 0.2304 ns |  1.00 |    0.00 | 0.0229 |     - |     - |      48 B |
| Hyperlinq_Return_Async | Return_Async |   100 |    53.954 ns | 0.2121 ns | 0.1771 ns |  0.64 |    0.00 |      - |     - |     - |         - |
|                        |              |       |              |           |           |       |         |        |       |       |           |
|            Linq_Create |       Create |   100 |   659.351 ns | 2.0729 ns | 1.7310 ns |  1.00 |    0.00 | 0.0534 |     - |     - |     112 B |
|       Hyperlinq_Create |       Create |   100 |   177.542 ns | 0.2932 ns | 0.2289 ns |  0.27 |    0.00 | 0.0305 |     - |     - |      64 B |
