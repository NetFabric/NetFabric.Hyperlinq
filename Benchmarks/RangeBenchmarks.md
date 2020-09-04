## RangeBenchmarks

### Source
[RangeBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/RangeBenchmarks.cs)

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
|                Method |  Categories | Count |        Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------- |------------ |------ |------------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|            Linq_Range |       Range |   100 |   509.97 ns |  9.589 ns |  8.970 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|      StructLinq_Range |       Range |   100 |    45.30 ns |  0.331 ns |  0.293 ns |  0.09 |      - |     - |     - |         - |
|       Hyperlinq_Range |       Range |   100 |    53.24 ns |  0.833 ns |  0.780 ns |  0.10 |      - |     - |     - |         - |
|                       |             |       |             |           |           |       |        |       |       |           |
|      Linq_Range_Async | Range_Async |   100 | 5,696.20 ns | 84.920 ns | 75.280 ns |  1.00 | 0.0229 |     - |     - |      48 B |
| Hyperlinq_Range_Async | Range_Async |   100 | 1,928.12 ns | 13.714 ns | 11.452 ns |  0.34 | 0.0153 |     - |     - |      32 B |
