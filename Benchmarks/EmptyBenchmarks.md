## EmptyBenchmarks

### Source
[EmptyBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/EmptyBenchmarks.cs)

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
|                Method |  Categories |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------- |------------ |----------:|----------:|----------:|----------:|------:|--------:|------:|------:|------:|----------:|
|            Linq_Empty |       Empty |  7.602 ns | 0.1770 ns | 0.1569 ns |  7.565 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|       Hyperlinq_Empty |       Empty |  1.518 ns | 0.0651 ns | 0.1837 ns |  1.430 ns |  0.21 |    0.03 |     - |     - |     - |         - |
|                       |             |           |           |           |           |       |         |       |       |       |           |
|      Linq_Empty_Async | Empty_Async | 57.497 ns | 0.7314 ns | 0.6107 ns | 57.148 ns |  1.00 |    0.00 |     - |     - |     - |         - |
| Hyperlinq_Empty_Async | Empty_Async | 31.473 ns | 0.3411 ns | 0.3024 ns | 31.402 ns |  0.55 |    0.01 |     - |     - |     - |         - |
